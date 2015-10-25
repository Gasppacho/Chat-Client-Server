using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat_Client_Server
{
    static class Client
    {
        static public void welcome()
        {
            Console.WriteLine("             WELCOME IN THIS APPLICATION !   \n\n\n");
            identification();
        }

        static public void identification()
        {
            Console.WriteLine("IDENTIFICATION\n");
            Console.Write(" Name : ");
            string name = Console.ReadLine();
            Console.Write(" Password : ");
            string password = Controller.maskPassword();
            Console.WriteLine("");

            if(Server.identification(name, password))
            {
                Console.WriteLine("\n\nConnected");
                chooseRoom();
            }
            else
            {
                Console.WriteLine("Incorrect name or password \n Do you want to subscribe ? y/n");
                string yn = Console.ReadLine();

                if (yn == "y")
                {
                    subscribe();
                    return;
                }
                else if (yn == "n")
                {
                    identification();
                    return;
                }
            }

        }

        public static void subscribe()
        {
            string name;
            string password1;
            string password2;

            GOTOPOINT:

            Console.Clear();

            Console.WriteLine("SUBSCRIPTION");
            Console.WriteLine("\n\nEnter your informations :");

            Console.Write("\nName : ");
            name = Console.ReadLine();
            Console.Write("Password : ");
            password1 = Controller.maskPassword();
            Console.WriteLine("");
            Console.Write("Password : ");
            password2 = Controller.maskPassword();
            Console.WriteLine("");

            if (password1 == password2)
            {
                if(Controller.subscribtion(name, password1))
                {
                    Console.WriteLine("Subscription Done !");
                    Console.ReadLine();
                    Console.Clear();
                    identification();
                }
                else
                {
                    Console.WriteLine("This name already exist !");
                    Console.ReadLine();
                    goto GOTOPOINT;
                }
            }           
            return;
        }

        static public void chooseRoom()
        {
            string choice;

        ChoosePoint:

            Console.Clear();
            Console.WriteLine("CHOOSE A ROOM IN THE FOLLOWING LIST :\n");
            List<string> rooms = Server.getRoomList();
            for (int i = 0; i < rooms.Count(); i++)
            {
                Console.WriteLine("     " + rooms[i]);
            }
            choice = Console.ReadLine();

            if (Server.getRoom(choice))
            {
                Console.WriteLine("\nRoom found !");
                Session.alive = true;
                Controller.startChat();
            }
            else
            {
                Console.WriteLine("\nRoom not found, do you want to create a new room ? y/n");
                string yn = Console.ReadLine();
                if (yn == "y")
                {
                GotoPoint:
                    Console.Clear();
                    Console.WriteLine("Enter the name of the room : ");
                    string roomName = Console.ReadLine();
                    if (Server.addRoom(roomName))
                    {
                        Console.WriteLine("Succed !");
                        Console.Write("Press any key ...");
                        Console.ReadLine();
                        goto ChoosePoint;
                    }
                    else
                    {
                        Console.WriteLine("This name already exit !");
                        Console.Write("Press any key ...");
                        Console.ReadLine();
                        goto GotoPoint;
                    }
                }
                else
                {
                    goto ChoosePoint;
                }
            }
        
        }

        static public void chatting()
        {
            Console.Clear();
            Console.WriteLine("     WELCOME IN THE ROOM : " + Session.chatRoom.name + "\n\n");

            while (Session.alive)
            {
                Controller.text();
            }
        }

        static public void writeHistoric(List<Message> messages)
        {
            Console.WriteLine("     HISTORIC : ");
            for (int i = 0; i < messages.Count(); i++)
            {
                Console.WriteLine("    |     " + messages[i].content);
            }
        }

        static public void writeSessionMessages(List<Message> messages)
        {
            Console.WriteLine("     ALL SESSION MESSAGES : ");
            for (int i = 0; i < messages.Count(); i++)
            {
                Console.WriteLine("    |     " + messages[i].content);
            }
        }

        
    }
}
