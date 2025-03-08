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
        private void UtolsoJeladas()
        {
            var utolsoJeladas = adatok[^1];
            Label2.Content = $"Az utolsó jeladás időpontja: {utolsoJeladas[1]}:{utolsoJeladas[2]}, a jármű rendszáma: {utolsoJeladas[0]}";
        }

        private void ElsoJarmuJelzesei()
        {
            var elsoJarmu = adatok[0][0];
            var idopontok = adatok.Where(a => a[0] == elsoJarmu).Select(a => $"{a[1]}:{a[2]}");
            Label3.Content = $"Az első jármű: {elsoJarmu}\nJeladásainak időpontjai: {string.Join(" ", idopontok)}";
        }
    }
}
