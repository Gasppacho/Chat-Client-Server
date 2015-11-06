using System;

namespace TCPService
{
    class TCPService
    {
        
        // TCPServcer, the server of the application.
        private TCPServer tcp_server = null;

        // Main fonction of the program. 
        // Start a new TCPService and a TCPServer by calling TCPService's constructor.
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t==== Application Server ====\n\n");

            TCPService service = new TCPService();

            Console.ReadLine();
        }
        
        // Constructor of TCPService
        // Will start a TCPServer by calling OnStart function.
        public TCPService()
        {
            OnStart();
        }
        
        // Destructor of TCPService
        // Will stop the TCPServer by calling OnStop function.
        ~TCPService()
        {
            OnStop();
        }

        // OnStart function will create a new instance of TCPServer and start it.
        private void OnStart()
        {
            tcp_server = new TCPServer();
            tcp_server.StartServer();
        }

        // OnStop function will stop the TCPServer and set him to null.
        private void OnStop()
        {
            tcp_server.StopServer();
            tcp_server = null;
        }
    }
}
