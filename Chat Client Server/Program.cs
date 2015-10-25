using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Client_Server
{
    class Program
    {
        static void Main(string[] args)
        {

            /* Bdd population */
            Bdd.users.Add(new User("admin", "azerty123"));
            Bdd.chatrooms.Add(new ChatRoom("room1"));
            Bdd.chatrooms.Add(new ChatRoom("room2"));
            Bdd.chatrooms.Add(new ChatRoom("room3"));

            Client.welcome();
        }
    }
}
