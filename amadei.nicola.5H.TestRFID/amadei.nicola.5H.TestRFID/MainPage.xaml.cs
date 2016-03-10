using Newtonsoft.Json;
using PubNubMessaging.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace amadei.nicola._5H.TestRFID
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {                
        private Pubnub pubnub = new Pubnub(
            "pub-c-11c25050-7ec8-4901-9446-3d3fa9b0a65d",
            "sub-c-6541b1dc-e6e3-11e5-9dc0-0619f8945a4f"
        );
        DispatcherTimer timer;
        Mfrc522 mfrc = new Mfrc522();
        ASCIIEncoding ascii;
        public MainPage()
        {
            this.InitializeComponent();                               
        }

        private async void Timer_Tick(object sender, object e)
        {
            timer.Stop();            
            while (true)
            {
                if (mfrc.IsTagPresent())
                {
                    var uid = mfrc.ReadUid();
                    byte[] chiave =
                    {
                        0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF
                    };
                    var tagsl = mfrc.SelectTag(uid);
                    if (tagsl)
                    {
                        var content = mfrc.ReadBlock(2, uid, chiave, null);
                        String decoded = ascii.GetString(content);
                        decoded = decoded.Substring(0, decoded.IndexOf('\0'));
                        try
                        {
                            Studente s = new Studente { ID = decoded };
                            string str = "Test";

                            // Genera una eccezione!
                            str = JsonConvert.SerializeObject(s);

                            pubnub.Publish<string>(
                                "rfid_dev",
                                str,
                                false,
                                DisplayReturnMessage,
                                DisplayErrorMessage
                            );
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else
                    {

                    }
                    mfrc.HaltTag();
                    mfrc.Reset();
                    break;
                }
            }
            timer.Start();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
           
        }
       

        #region PUBNUB Methods
        public async void DisplayReturnMessage(string result)
        {
         

        }
        void DisplayErrorMessage(PubnubClientError result)
        {           
            switch (result.StatusCode)
            {
                case 103:
                    //Warning: Verify origin host name and internet connectivity
                    break;
                case 104:
                    //Critical: Verify your cipher key
                    break;
                case 106:
                    //Warning: Check network/internet connection
                    break;
                case 108:
                    //Warning: Check network/internet connection
                    break;
                case 109:
                    //Warning: No network/internet connection. Please check network/internet connection
                    break;
                case 110:
                    //Informational: Network/internet connection is back. Active subscriber/presence channels will be restored.
                    break;
                case 111:
                    //Informational: Duplicate channel subscription is not allowed. Internally Pubnub API removes the duplicates before processing.
                    break;
                case 112:
                    //Informational: Channel Already Subscribed/Presence Subscribed. Duplicate channel subscription not allowed
                    break;
                case 113:
                    //Informational: Channel Already Presence-Subscribed. Duplicate channel presence-subscription not allowed
                    break;
                case 114:
                    //Warning: Please verify your cipher key
                    break;
                case 115:
                    //Warning: Protocol Error. Please contact PubNub with error details.
                    break;
                case 116:
                    //Warning: ServerProtocolViolation. Please contact PubNub with error details.
                    break;
                case 117:
                    //Informational: Input contains invalid channel name
                    break;
                case 118:
                    //Informational: Channel not subscribed yet
                    break;
                case 119:
                    //Informational: Channel not subscribed for presence yet
                    break;
                case 120:
                    //Informational: Incomplete unsubscribe. Try again for unsubscribe.
                    break;
                case 121:
                    //Informational: Incomplete presence-unsubscribe. Try again for presence-unsubscribe.
                    break;
                case 122:
                    //Informational: Network/Internet connection not available. C# client retrying again to verify connection. No action is needed from your side.
                    break;
                case 123:
                    //Informational: During non-availability of network/internet, max retries for connection were attempted. So unsubscribed the channel.
                    break;
                case 124:
                    //Informational: During non-availability of network/internet, max retries for connection were attempted. So presence-unsubscribed the channel.
                    break;
                case 125:
                    //Informational: Publish operation timeout occured.
                    break;
                case 126:
                    //Informational: HereNow operation timeout occured
                    break;
                case 127:
                    //Informational: Detailed History operation timeout occured
                    break;
                case 128:
                    //Informational: Time operation timeout occured
                    break;
                case 4000:
                    //Warning: Message too large. Your message was not sent. Try to send this again smaller sized
                    break;
                case 4001:
                    //Warning: Bad Request. Please check the entered inputs or web request URL
                    break;
                case 4002:
                    //Warning: Invalid Key. Please verify the publish key
                    break;
                case 4010:
                    //Critical: Please provide correct subscribe key. This corresponds to a 401 on the server due to a bad sub key
                    break;
                case 4020:
                    // PAM is not enabled. Please contact PubNub support
                    break;
                case 4030:
                    //Warning: Not authorized. Check the permimissions on the channel. Also verify authentication key, to check access.
                    break;
                case 4031:
                    //Warning: Incorrect public key or secret key.
                    break;
                case 4140:
                    //Warning: Length of the URL is too long. Reduce the length by reducing subscription/presence channels or grant/revoke/audit channels/auth key list
                    break;
                case 5000:
                    //Critical: Internal Server Error. Unexpected error occured at PubNub Server. Please try again. If same problem persists, please contact PubNub support
                    break;
                case 5020:
                    //Critical: Bad Gateway. Unexpected error occured at PubNub Server. Please try again. If same problem persists, please contact PubNub support
                    break;
                case 5040:
                    //Critical: Gateway Timeout. No response from server due to PubNub server timeout. Please try again. If same problem persists, please contact PubNub support
                    break;
                case 0:
                    //Undocumented error. Please contact PubNub support with full error object details for further investigation
                    break;
                default:
                    break;
            }

            // 
            //if (showErrorMessageSegments)
            //{
            //    DisplayErrorMessageSegments(result);
            //    Console.WriteLine();
            //}
        }
        #endregion
        #region Classes
        public class Studente
        {
            public string ID { get; set; }
            public DateTime Time { get { return DateTime.Now; } }
        }

        #endregion

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await mfrc.InitIO();
            ascii = new ASCIIEncoding();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(2000);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
    }
}
