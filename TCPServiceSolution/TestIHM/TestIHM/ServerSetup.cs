using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;


namespace TestIHM
{
    public partial class ServerSetup : Form
    {

        // Thread to start the chat server form.
        private Thread chatServerThread = null;

        private String text_ipAddress = null;
        private String text_port = null;

        private IPEndPoint ipEndPoint = null;

        public ServerSetup()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Récupération de l'addresse IP
            this.text_ipAddress = IPPart1.Text + "." + IPPart2.Text + "." + IPPart3.Text + "." + IPPort4.Text;
            // Récupération du port d'écoute
            this.text_port = Port.Text;

            ipEndPoint = new IPEndPoint(IPAddress.Parse(text_ipAddress), int.Parse(text_port));

            // Close this form to open the chat server form
            this.Close();
            this.chatServerThread = new Thread(openChatServer);
            this.chatServerThread.SetApartmentState(ApartmentState.STA);
            this.chatServerThread.Start();
        }

        private void openChatServer()
        {
            Application.Run(new ChatServer(ipEndPoint));
        }

    }
}
