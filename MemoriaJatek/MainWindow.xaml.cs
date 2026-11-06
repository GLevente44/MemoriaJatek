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

namespace MemoriaJatek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Kartya> kartyak = new List<Kartya>();

        private Kartya elsoKartya = null;
        private Kartya masodikKartya = null;

        private int megtalaltParok = 0;
        private bool ellenorzesFolyamatban = false;

        private string[] ertekek = {"#", "@", "$", "*"};

        public MainWindow()
        {
            InitializeComponent();
            JatekInditasa();
        }

        private void JatekInditasa()
        {
            kartyaHelye.Children.Clear();
            kartyak.Clear();

            elsoKartya = null;
            masodikKartya = null;

            megtalaltParok = 0;
            ellenorzesFolyamatban = false;

            pontszam.Content = "Megtalált párok: 0 / 4";

            List<string> lista = new List<string>();

            foreach (string ertek in ertekek)
            {
                lista.Add(ertek);
                lista.Add(ertek);
            }

            
            foreach (string ertek in lista)
            {
                Kartya kartya = new Kartya(ertek);

                kartya.Click += KartyaKattintas;

                kartyak.Add(kartya);
                kartyaHelye.Children.Add(kartya);
            }
        }

        private void KartyaKattintas(object sender, RoutedEventArgs e)
        {
            if (ellenorzesFolyamatban)
                return;

            Kartya kattintottKartya = sender as Kartya;
            if (kattintottKartya == null || kattintottKartya.Megtalalva || kattintottKartya.Felforditva)
                return;

            kattintottKartya.Felfordit();

            if (elsoKartya == null)
            {
                elsoKartya = kattintottKartya;
                return;
            }

            masodikKartya = kattintottKartya;

            ellenorzesFolyamatban = true;

            if (elsoKartya.Ertek == masodikKartya.Ertek)
            {
                elsoKartya.ParMegtalalva();
                masodikKartya.ParMegtalalva();

                megtalaltParok++;

                pontszam.Content ="Megtalált párok: " + megtalaltParok + " / 4";

                elsoKartya = null;
                masodikKartya = null;

                ellenorzesFolyamatban = false;

                if (megtalaltParok == 4)
                {
                    MessageBox.Show("Megtaláltad az összes párt!");
                }
            }
            else
            {

                elsoKartya.Visszafordit();
                masodikKartya.Visszafordit();

                elsoKartya = null;
                masodikKartya = null;

                ellenorzesFolyamatban = false;
            }
        }

        private void UjJatek(object sender, RoutedEventArgs e)
        {
            JatekInditasa();
        }
    }
}