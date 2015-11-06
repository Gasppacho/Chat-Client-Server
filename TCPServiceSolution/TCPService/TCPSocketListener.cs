using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading;

namespace TCPService
{
    class TCPSocketListener
    {
        private Socket clientSocket = null;

        private bool stopClient = false;
        private bool markedForDeletion = false;

        private Thread clientListenerThread = null;
        
        public TCPSocketListener(Socket socketClient)
        {
            this.clientSocket = socketClient;
        }

        ~TCPSocketListener()
        {
            StopSocketListener();
        }

        public void StartSocketListener()
        {
            if(clientSocket != null)
            {
                clientListenerThread = new Thread(new ThreadStart(SocketListenerThreadStart));
                clientListenerThread.Start();
            }
        }

        private void SocketListenerThreadStart()
        {
            while (!stopClient)
            {
                try
                {

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
    }
}
