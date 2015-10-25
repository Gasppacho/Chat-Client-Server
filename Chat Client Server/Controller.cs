using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat_Client_Server
{
    static class Controller
    {
        static private Thread chatThread;

        static public void text()
        {
            string str = "";
            str = Console.ReadLine();
            if (str == "")
            {
                return;
            }
            else if (str.ElementAt<char>(0) == '/')
            {
                switch (str)
                {
                    case "/historic":
                        Client.writeHistoric(Session.chatRoom.messages);
                        break;
                    case "/all":
                        Client.writeSessionMessages(Session.messages);
                        break;
                    case "/exitroom":
                        Session.alive = false;
                        Client.chooseRoom();
                        break;
                    case "/exit":
                        Session.alive = false;
                        Environment.Exit(0);
                        break;
                }
                return;
            }
            else
            {
                Message message = new Message(Session.user.name, DateTime.Now, str);

                Session.chatRoom.addMessage(message);
                Session.addMessage(message);

                Server.addMessage(message, Session.chatRoom.name);

                return;
            }
        }

        static public void startChat()
        {
            chatThread = new Thread(new ThreadStart(Client.chatting));
            chatThread.Start();
        }

        /* WARNING NEVER USED */
        static public void stopChat()
        {
            Session.alive = false;
            while (chatThread.IsAlive)
            {
                chatThread.Join();
            }
        }

        
    }

}
