using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Client_Server
{
    class Message
    {

        private string m_name;
        private DateTime m_date;
        private string m_content;

        /* Constructor */
        public Message(string name, DateTime date, string content)
        {
            m_name = name;
            m_date = date;
            m_content = content;
        }

        /* Getter Setter */
        public string name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public DateTime date
        {
            get { return m_date; }
            set { m_date = date; }
        }

        public string content
        {
            get { return m_content; }
            set { m_content = content; }
        }

    }
}
