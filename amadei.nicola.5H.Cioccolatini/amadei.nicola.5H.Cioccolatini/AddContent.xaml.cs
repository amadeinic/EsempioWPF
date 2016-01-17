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

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace amadei.nicola._5H.Cioccolatini
{
    public sealed partial class AddContent : ContentDialog
    {
        public Cioccolatino Cioccolatino { get; set; }

        public AddContent()
        {
            this.InitializeComponent();
        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            try
            {
                Cioccolatino = new Cioccolatino()
                {
                    Marca = txtMarca.Text,
                    Nome = txtNome.Text
                };
            }
            catch(Exception erore)
            {
                MessageDialog msg = new MessageDialog("Errore di inserimento.\n" + erore.Message, "Qualcosa non va!");
                await msg.ShowAsync();
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
    }
}
