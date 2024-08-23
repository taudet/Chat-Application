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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        public ChatWindow()
        {
            InitializeComponent();
        }

        public void sendButton_Click(object sender, RoutedEventArgs e)
        {
            string OutgoingMessage = messageSendBox.Text.Trim();

            messageReceiveBox.Text = OutgoingMessage;
        }

        private void messageSendBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void messageSendBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }

}