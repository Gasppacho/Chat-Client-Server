using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading;

namespace TCPService
{
    class TCPSocketListener
    {
        // Socket of the client.
        private Socket clientSocket = null;

        // State of the client. 
        // If stopClient = true, the client must be disconnected.
        // If markedForDeletion = true, the client must be deleted from the client list.
        private bool stopClient = false;
        private bool markedForDeletion = false;

        // Thread of the client. 
        // Will wait for message to come.
        private Thread clientListenerThread = null;
        
        // The socket receive the client's socket
        public TCPSocketListener(Socket socketClient)
        {
            this.clientSocket = socketClient;
        }

        // Stop the client socket
        ~TCPSocketListener()
        {
            StopSocketListener();
        }

        // The client will start to listen with the Thread
        // SocketListenerThreadStart()
        public void StartSocketListener()
        {
            if(clientSocket != null)
            {
                clientListenerThread = new Thread(new ThreadStart(SocketListenerThreadStart));
                clientListenerThread.Start();
            }
        }

        // This is the main client socket Thread. 
        // A client will wait to receive messages until he is disconnected.
        private void SocketListenerThreadStart()
        {
            int size = 0;
            Byte[] byteBuffer = new Byte[1024];

            // While the client is not disconnected. 
            while (!stopClient)
            {
                try
                {
                    size = clientSocket.Receive(byteBuffer);
                    ParserBufferArray(byteBuffer, size);
                }
                catch(SocketException se) 
                {
                    stopClient = true;
                    markedForDeletion = true;
                    Debug.WriteLine(se.ToString());
                }
            }
        }

        public void StopSocketListener()
        {
            if(clientSocket != null)
            {
                // Stop the client by closing its socket.
                stopClient = true;
                clientSocket.Close();

                // Wait one second for the Thread to stop.
                clientListenerThread.Join(1000);

                // Abort the Thread if still alive.
                if(clientListenerThread.IsAlive)
                {
                    clientListenerThread.Abort();
                }

                // Put Thread and Socket to null, client marked for deletion.
                clientListenerThread = null;
                clientSocket = null;
                markedForDeletion = true;
            }
        }

        public bool IsMarkedForDeletion()
        {
            return this.markedForDeletion;
        }

        private void ParserBufferArray(Byte[] byteBufferArray, int size)
        {
            String 
        }
    }
}
