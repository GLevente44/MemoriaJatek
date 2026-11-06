using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace MemoriaJatek
{
    public class Kartya : Button
    {
        public string Ertek { get; set; }
        public bool Megtalalva { get; set; }
        public bool Felforditva { get; set; }

        public Kartya(string ertek)
        {
            Ertek = ertek;
            Megtalalva = false;
            Felforditva = false;

            Width = 100;
            Height = 100;
            Margin = new Thickness(20);
            FontSize = 40;
            FontWeight = FontWeights.Bold;

            Content = "?";
            Background = System.Windows.Media.Brushes.LightBlue;
        }

        public void Felfordit()
        {
            Content = Ertek;
            Background = System.Windows.Media.Brushes.LightYellow;
            Felforditva = true;
        }

        public void Visszafordit()
        {
            Content = "?";
            Background = System.Windows.Media.Brushes.LightBlue;
            Felforditva = false;
        }

        public void ParMegtalalva()
        {
            Megtalalva = true;
            Background = System.Windows.Media.Brushes.LightGreen;
        }
    }
}
