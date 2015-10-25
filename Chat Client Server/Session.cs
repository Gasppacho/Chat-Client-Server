using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Client_Server
{
    static class Session
    {
        static private User m_user;
        static private ChatRoom m_chatRoom;
        static private bool m_alive;

        static private List<Message> m_messages = new List<Message>();

        /* Getter Setter */
        static public User user
        {
            get { return m_user; }
            set { m_user = value; }
        }
        static public ChatRoom chatRoom
        {
            get { return m_chatRoom; }
            set { m_chatRoom = value; }
        }
        static public bool alive
        {
            get { return m_alive; }
            set { m_alive = value; }
        }
        static public List<Message> messages
        {
            get { return m_messages; }
            set { m_messages = value; }
        }

        static public void addMessage(Message message)
        {
            m_messages.Add(message);
        }
    }
}
