using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace amadei.nicola._5H.Cioccolatini
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public Cioccolatini Scatola { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
                      
                     
        }

        private async void AppBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddContent a = new AddContent();
                ContentDialogResult cres = await a.ShowAsync();
                if (cres == ContentDialogResult.Primary)
                {
                    Scatola.Add(a.Cioccolatino);
                }
            }
            catch(Exception erore)
            {
                MessageDialog msg = new MessageDialog("Non è possibile inserire i dati.\n" + erore.Message, "Qualcosa non va!");
                await msg.ShowAsync();
            }     
       
        }

        private void abtnDelete_Click(object sender, RoutedEventArgs e)
        {
            throw (new NotImplementedException());
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Scatola = new Cioccolatini("Dati.xml");
                lstScatola.ItemsSource = Scatola;
            }
            catch (Exception erore)
            {
                MessageDialog msg = new MessageDialog("Non è possibile recuperare i dati.\n" + erore.Message, "Qualcosa non va!");
                await msg.ShowAsync();
            }
        }
    }
}
