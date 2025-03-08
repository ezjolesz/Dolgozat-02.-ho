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

        private void Kereses_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBoxOra.Text, out int ora) && int.TryParse(TextBoxPerc.Text, out int perc))
            {
                int darab = adatok.Count(a => int.Parse(a[1]) == ora && int.Parse(a[2]) == perc);
                Label4.Content = $"A jeladások száma: {darab}";
            }
            else
            {
                Label4.Content = "Érvényes számokat adjon meg!";
            }
        }

        private void MentesFajlba()
        {
            var rendszamok = adatok.Select(a => a[0]).Distinct();
            var idoLista = new List<string>();

            foreach (var rendszam in rendszamok)
            {
                var idok = adatok.Where(a => a[0] == rendszam).Select(a => new { Ora = int.Parse(a[1]), Perc = int.Parse(a[2]) });
                int minOra = idok.Min(x => x.Ora);
                int minPerc = idok.Where(x => x.Ora == minOra).Min(x => x.Perc);
                int maxOra = idok.Max(x => x.Ora);
                int maxPerc = idok.Where(x => x.Ora == maxOra).Max(x => x.Perc);
                idoLista.Add($"{rendszam} {minOra}:{minPerc} {maxOra}:{maxPerc}");
            }

            File.WriteAllLines("ido.txt", idoLista);
        }
    }
}
