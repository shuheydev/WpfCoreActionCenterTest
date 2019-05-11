using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace WpfCoreActionCenterTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Windows.System.Launcher.LaunchUriAsync(new Uri("https://example.com")).AsTask().Wait();

            string title = "The current time is";
            string timeString = $"{DateTime.Now:HH:mm:ss}";
            string thomasImage = "https://www.thomasclaudiushuber.com/thomas.jpg";

            string toastXmlString =
            $@"<toast><visual>
            <binding template='ToastGeneric'>
            <text>{title}</text>
            <text>{timeString}</text>
            <image src='{thomasImage}'/>
            </binding>
        </visual></toast>";

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(toastXmlString);

            var toastNotification = new ToastNotification(xmlDoc);

            var toastNotifier = ToastNotificationManager.CreateToastNotifier();
            toastNotifier.Show(toastNotification);
        }
    }
}
