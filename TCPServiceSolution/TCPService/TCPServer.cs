using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Collections;
using System.Diagnostics;

namespace TCPService
{
    /**
     *  Class : TCPServer 
     *  Description : A TCP Server that will manage all the chat and 
     *  the connection of differents clients. 
     */

    class TCPServer
    {
        /**
         * Default value for the server.
         * Do not change this value. Change the value by using the different constructors avaible.
         */

        // Default listening port : 8001
        public static int DEFAULT_PORT = 8001;
        // Default IP Address : Localhost 127.0.0.1
        public static IPAddress DEFAULT_SERVER = IPAddress.Parse("127.0.0.1");
        // Default IPEndPoint.
        public static IPEndPoint DEFAULT_IP_END_POINT = new IPEndPoint(DEFAULT_SERVER, DEFAULT_PORT);

        // The server.
        private TcpListener server = null;

        // State of the server
        private bool stopServer = false;        // Stop the server
        private bool stopPurging = false;       // Stop the purging

        // MultiThreaded server need Thread to handle the clients.
        private Thread serverThread = null;
        private Thread purgingThread = null;

        // Put all the client socket Thread into a ArrayList
        private ArrayList socketListenerList = null;

        // How to manage the chat rooms?

        /**
         * The different constructor to make the TCPServer class
         * mobile and adaptable to any server (localhost or external server).
         */

        // Default constructor.
        public TCPServer()
        {
            initialize(DEFAULT_IP_END_POINT);
        }

        // Change the IP Address but the Port stay the same (8001).
        public TCPServer(IPAddress ip)
        {
            initialize(new IPEndPoint(ip, DEFAULT_PORT));
        }

        // Change the Port but not the Ip Address (localhost: 127.0.0.1).
        public TCPServer(int port)
        {
            initialize(new IPEndPoint(DEFAULT_SERVER, port));
        }

        // Change the IP Address and the Port 
        public TCPServer(IPAddress ip, int port)
        {
            initialize(new IPEndPoint(ip, port));
        }

        // New IPEndPoint (i.e : new ip address and port)
        public TCPServer(IPEndPoint endPoint)
        {
            initialize(endPoint);
        }

        // Deconstructor
        // Stop all the activity of the server and close it.
        ~TCPServer()
        {
            StopServer();
        }

        // Initialize the server by giving him the address where to connect.
        private void initialize(IPEndPoint endPoint)
        {
            try
            {
                // Try to connect to the address given.
                server = new TcpListener(endPoint);
            }
            catch(Exception e)
            {
                // An error occured. Server is null and the error is displayed
                // on the Debug console.
                server = null;
                Debug.WriteLine(e.ToString());
            }
        }

        /**
         * Start the server with the different Thread 
         * i.e The ServerThread and the PurgingThread 
         */
        public void StartServer()
        {
            // If the server is not already started then...
            if(server != null)
            {
                // try to start the server
                try
                {
                    // List of clients
                    socketListenerList = new ArrayList();

                    // Starting the client
                    server.Start();

                    // Starting the Thread for the Server
                    serverThread = new Thread(new ThreadStart(ServerThreadStart));
                    serverThread.Start();

                    // Starting the Thread for the purging of the socketListenerList
                    purgingThread = new Thread(new ThreadStart(PurgingThreadStart));
                    purgingThread.Priority = ThreadPriority.Lowest;
                    purgingThread.Start();

                    // Indicate to the user that the server as started.
                    Console.WriteLine("Server Started.");
                    Console.WriteLine("Waiting for clients ...");
                }
                // Catch exceptions 
                catch (SocketException se)
                {
                    Console.WriteLine("The server didn't start properly");
                    Debug.WriteLine(se.ToString());
                }
            }
        }

        /**
         * Thread of the server
         * This Thread will wait for client to connect, accept them and Add them
         * to the list of client (i.e socketListenerList)
         */
        private void ServerThreadStart()
        {
            // Client socket variables.
            Socket clientSocket = null;
            TCPSocketListener socketListener = null;

            // While the server don't stop, do : 
            while(!stopServer)
            {
                try
                {
                    // Wait for any client request and accept it if any.
                    clientSocket = server.AcceptSocket();

                    // Create a socket listener for the client.
                    socketListener = new TCPSocketListener(clientSocket);

                    // Add the socket listener to a ArrayList in safe mode.
                    lock(socketListenerList)
                    {
                        socketListenerList.Add(socketListener);
                    }

                    // Start communicating with the client in a different thread.
                    // @See TCPSocketListener class, method StartSocketListener.
                    socketListener.StartSocketListener();

                    // Indicate that a new client as connected.
                    Console.WriteLine("A new client as connected");
                } 
                catch(SocketException e)
                {
                    // An error happened, the server stop all activity and 
                    // the error is displayed on the Debug Console.
                    stopServer = true;
                    Debug.WriteLine(e.ToString());
                }
            }
        }

        public void StopServer()
        {
            // If the server is not already stopped then ...
            if(server != null)
            {
                stopServer = true;
                server.Stop();
                
                // Wait a second for the Thread to stop.
                serverThread.Join(1000);

                // Abort the serverThread if still alive
                if(serverThread.IsAlive)
                {
                    serverThread.Abort();
                }

                // Set the server Thread to null.
                serverThread = null;

                // Stop the Purging Thread
                stopPurging = true;
                purgingThread.Join(1000);

                // Abort Purging Thread if still alive
                if(purgingThread.IsAlive)
                {
                    purgingThread.Abort();
                }

                purgingThread = null;

                server = null;
                
                // Stop all clients.
                StopAllSocketListeners();
            }

            // Indicate that the server has stopped.
            Console.WriteLine("The server has stopped");
        }

        private void StopAllSocketListeners()
        {
            // For all the socket client in ArrayList.
            foreach (TCPSocketListener socketListener in socketListenerList)
            {
                // Stop the socket client.
                socketListener.StopSocketListener();
            }

            // Clear the ArrayList and set to null.
            socketListenerList.Clear();
            socketListenerList = null;
        }

        private void PurgingThreadStart()
        {
            // While the purging is not over.
            while(!stopPurging)
            {
                // List of socket client to be deleted.
                ArrayList deleteList = new ArrayList();

                lock(socketListenerList)
                {
                    // For all the clients ...
                    foreach(TCPSocketListener socketListener in socketListenerList)
                    {
                        // Check if the client have to be deleted.
                        if(socketListener.IsMarkedForDeletion())
                        {
                            deleteList.Add(socketListener);         // Add the socket client to Delete ArrayList.
                            socketListener.StopSocketListener();    // Stop the socket client.
                        }
                    }

                    // Delete the client from the ArrayList.
                    for(int i = 0; i < deleteList.Count; i++)
                    {
                        socketListenerList.Remove(deleteList[i]);
                    }
                }
                // Set deleteList to null.
                deleteList = null;
                
                // Verification every 10 seconds.
                Thread.Sleep(10000);
                Console.WriteLine("Purge en cours...");
            }
        }

    }

}
