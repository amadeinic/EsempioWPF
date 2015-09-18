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
using System.Collections.ObjectModel;

namespace EsempioWPF01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<Persona> persone;
        class Persona
        {
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public string CF { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
            persone = new ObservableCollection<Persona>();
            dgvTabella.ItemsSource = persone;
        }

        private void btnInserisci_Click(object sender, RoutedEventArgs e)
        {
            persone.Add(new Persona() { Nome = txtNome.Text, Cognome = txtCognome.Text, CF = txtCF.Text });
        }
    }
}
