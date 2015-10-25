using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Client_Server
{
    static class Server
    {

        static public bool identification(string name, string password)
        {
            for (int i = 0; i < Bdd.users.Count(); i++)
            {
                if(Bdd.users[i].name == name && Bdd.users[i].password == password)
                {
                    Session.user = Bdd.users[i];
                    return true;
                }
            }
            return false;
        }

        static public bool userExistance(string name, string password)
        {
            for (int i = 0; i < Bdd.users.Count(); i++)
            {
                if (Bdd.users[i].name == name && Bdd.users[i].password == password)
                {
                    return true;
                }
            }
            return false;
        }

        static public void addUser(string name, string password)
        {
            User buffer = new User(name, password);
            Bdd.users.Add(buffer);
        }

        static public List<string> getRoomList()
        {
            List<string> roomList = new List<string>();
            for (int i = 0; i < Bdd.chatrooms.Count(); i++)
            {
                roomList.Add(Bdd.chatrooms[i].name);
            }
            return roomList;
        }

        static public bool getRoom(string name)
        {
            for (int i = 0; i < Bdd.chatrooms.Count(); i++)
            {
                if(Bdd.chatrooms[i].name == name)
                {
                    Session.chatRoom = Bdd.chatrooms[i];
                    return true;
                }
            }
            return false;
        }

        static public bool addRoom(string name)
        {
            ChatRoom buffer = new ChatRoom(name);
            for (int i = 0; i < Bdd.chatrooms.Count(); i++)
            {
                if (Bdd.chatrooms[i].name == name)
                {
                    return false;
                }
            }
            Bdd.chatrooms.Add(buffer);
            return true;
        }

        static public void addMessage(Message message, string name)
        {
            for (int i = 0; i < Bdd.chatrooms.Count(); i++)
            {
                if (Bdd.chatrooms[i].name == name)
                {
                    Bdd.chatrooms[i].addMessage(message);
                }
            }
        }


    }
}
