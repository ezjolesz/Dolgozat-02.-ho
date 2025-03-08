using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace Dolgozat_02._ho
{
    public partial class MainWindow : Window
    {
        private List<string[]> adatok = new List<string[]>();

        public MainWindow()
        {
            InitializeComponent();
            Beolvasas();
        }

        private void Beolvasas()
        {
            foreach (var sor in File.ReadAllLines("jeladas.txt"))
            {
                var adatokSor = sor.Split('\t');
                adatok.Add(adatokSor);
            }
        }
    }
}
