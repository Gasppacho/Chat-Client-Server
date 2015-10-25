using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Client_Server
{
    class User
    {

        private string m_name;
        private string m_password;

        /* constructor */
        public User() { ; }
        public User (string name, string password)
        {
            m_name = name;
            m_password = password;
        }

        /* Getter Setter */
        public string name
        {
            get
            {
                return m_name;
            }

            set
            {
                m_name = value;
            }
        }

        public string password
        {
            get
            {
                return m_password;
            }

            set
            {
                m_password = value;
            }
        }
    }
}
