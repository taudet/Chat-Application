using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chat_Application
{
    public partial class ChatWindow : Window
    {
        private TcpClient chatClient;
        private NetworkStream chatStream;
        private string clientID;
        private string IpAddress;
        private int Port;


        public ChatWindow()
        {
            InitializeComponent();

            this.clientID = "1221121212";
            this.IpAddress = "192.168.1.200";
            this.Port = 2706;
        }

        public void sendButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                chatClient = new TcpClient(IpAddress, Port);
                chatStream = chatClient.GetStream();

                string OutgoingMessage = messageSendBox.Text.Trim();

                sendResponse(chatStream, clientID, OutgoingMessage);

                messageSendBox.Clear();
                
            }
            catch (Exception ex) 
            {

            }
        }


        public static void WriteStringToStream(NetworkStream stream, string data)
        {
            byte[] bytesToSend = Encoding.ASCII.GetBytes(data);
            stream.Write(bytesToSend, 0, bytesToSend.Length);
        }



        public static void sendResponse(NetworkStream stream, string clientID, string chatMessage)
        {
            string stringToSend = clientID + ";" + chatMessage;
            WriteStringToStream(stream, stringToSend);
        }

        private (TcpClient, string) ConnectClient(string server, int port)
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(server, port);
                NetworkStream stream = client.GetStream();

                string clientID = Guid.NewGuid().ToString();

                byte[] bytesToSend = Encoding.ASCII.GetBytes(clientID);
                stream.Write(bytesToSend, 0, bytesToSend.Length);


                return (client, clientID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed");
                client.Close();
                return (null, null);
            }
        }
    }

}