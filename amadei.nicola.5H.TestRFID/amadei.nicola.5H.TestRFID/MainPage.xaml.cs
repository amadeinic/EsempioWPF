using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        private const int LED_PIN = 26;
        private GpioPin pin;
        private GpioPinValue pinValue;

        public MainPage()
        {
            this.InitializeComponent();
            InitGPIO();
            btnStart_Click(null, null);
        }
        private void InitGPIO()
        {
            var gpio = GpioController.GetDefault();

            // Show an error if there is no GPIO controller
            if (gpio == null)
            {
                pin = null;                
                return;
            }
            pin = gpio.OpenPin(LED_PIN);
            pinValue = GpioPinValue.Low;
            pin.Write(pinValue);
            pin.SetDriveMode(GpioPinDriveMode.Output);          

        }

        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            int cont = 0;
            var mfrc = new Mfrc522();
            await mfrc.InitIO();

            while (true)
            {
                if (mfrc.IsTagPresent())
                {
                    var uid = mfrc.ReadUid();
                    mfrc.HaltTag();
                    pinValue = GpioPinValue.High;
                    pin.Write(pinValue);
                    await Task.Delay(300);
                    pinValue = GpioPinValue.Low;
                    pin.Write(pinValue);
                    await Task.Delay(2000);
                    cont++;
                }
                

            }
        }

       
        
    }
}
