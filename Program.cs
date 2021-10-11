using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EU
{
    class Program
    {
        public struct eu
        {
            public string allam;
            public DateTime csatdatum;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("EUcsatlakozas.txt", Encoding.UTF8);
            List<eu> adatok = new List<eu>();
            string sor;
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine();
                string[] x = sor.Split(";");
                eu e = new eu();
                e.allam = x[0];
                e.csatdatum = Convert.ToDateTime(x[1]);
                adatok.Add(e);
            }
            sr.Close();
            Console.WriteLine($"3.feladat: EU tagállamainak száma: {adatok.Count} db");
            int db = 0;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].csatdatum.Year == 2007)
                {
                    db++;
                }
            }
            Console.WriteLine($"4. feladat: 2007-ben {db} ország csatlakozott.");

            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].allam == "Magyarország")
                {
                    Console.WriteLine($"5.feladat: Magyarország csatlakozásának dátuma: {adatok[i].csatdatum.ToString("yyyy.MM.dd")}");
                }
            }

            int y = 0;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].csatdatum.Month == 5)
                {
                    y++;
                }
            }
            if (0 < y)
            {
                Console.WriteLine("6.feladat: Májusban volt csatlakozás!");
            }
            else
            {
                Console.WriteLine("6.feladat: Májusban nem volt csatlakozás!");
            }

            HashSet<DateTime> csatlakozas = new HashSet<DateTime>();
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].csatdatum < Convert.ToDateTime("2021.01.01"))
                {
                    csatlakozas.Add(adatok[i].csatdatum);
                }
            }
            List<DateTime> csatlakozasL = new List<DateTime>(csatlakozas);
            DateTime utolso = csatlakozasL.Max();
            for (int i = 0; i < adatok.Count; i++)
            {
                if (utolso==adatok[i].csatdatum)
                {
                    Console.WriteLine($"7.feladat: Legutoljára csatlakozott ország: {adatok[i].allam}");
                }
            }
            Console.ReadKey();
        }
    }
}
