using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Client_Server
{
    class ChatRoom
    {

        private string m_name;
        private List<Message> m_messages = new List<Message>();

        /* Constructor */
        public ChatRoom() { ; }
        public ChatRoom(string name)
        {
            m_name = name;
        }

        /* getter setter */
        public string name
        {
            get { return m_name; }
            set { m_name = name; }
        }
        public List<Message> messages
        {
            get { return m_messages; }
            set { m_messages = value; }
        }

        /* List<Message> actions */
        public void addMessage(Message message)
        {
            m_messages.Add(message);
        }

        public void delmessage(Message message)
        {
            m_messages.Remove(message);
        }



    }
}
