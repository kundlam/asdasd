using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace foci
{
    class Program
    {
        struct Meccs
        {
            public string HazaiNeve { get; set; }
            public string IdegenNeve { get; set; }
            public int hazaiFel;
            public int vendegFel;
            public int hazaiGol;
            public int vendegGol;
            public int Forduló;
            public string Győztes
            {
                get
                {
                    return hazaiGol > vendegGol ?
                    HazaiNeve : hazaiGol == vendegGol ? "Döntetlen" : IdegenNeve;
                }
            }

        }
        static void Main(string[] args)
        {
            List<Meccs> meccsek = new List<Meccs>();
            FileStream fajl = new FileStream(@"C:\Users\Diak\Desktop\kispályás_labdarúgás\meccs.txt", FileMode.Open);
            using (StreamReader sr = new StreamReader(fajl))
            {
                int elso = Convert.ToInt32(sr.ReadLine());
                for (int i = 0; i < elso; i++)
                {
                    string sor = sr.ReadLine();
                    var sorok = sor.Trim().Split(' ');
                    Meccs újMeccs = new Meccs()
                    {
                        Forduló = Convert.ToInt32(sorok[0]),
                        hazaiGol = Convert.ToInt32(sorok[1]),
                        vendegGol = Convert.ToInt32(sorok[2]),
                        hazaiFel = Convert.ToInt32(sorok[3]),
                        vendegFel = Convert.ToInt32(sorok[4]),
                        HazaiNeve = sorok[5],
                        IdegenNeve = sorok[6]
                    };
                    meccsek.Add(újMeccs);
                }
            }
            ////////////////////// 2. feladat //////////////////////
            Console.Write("2. feladat: Adjon meg egy fordulót: ");
            int f = Convert.ToInt32(Console.ReadLine());

            var fordulók = (from m in meccsek where (m.Forduló == f) select m);
            foreach (var z in fordulók)
            {
                Console.WriteLine($"\t{z.HazaiNeve}-{z.IdegenNeve}: {z.hazaiGol}-{z.vendegGol} ({z.hazaiFel}-{z.vendegFel})");
            }
            ////////////////////// 3. feladat //////////////////////
            Console.WriteLine("\n3. Feladat: Az eredményt megfordító csapatok:");
            var fordítások = from m in meccsek
                              where ((m.hazaiGol > m.vendegGol &&
                                       m.hazaiFel < m.vendegFel) ||
                                      (m.hazaiGol < m.vendegGol &&
                                       m.hazaiFel > m.vendegFel))
                              select m;
            //var fordítások = meccsek.Find(m => m.hazaiGol > m.vendegGol && m.hazaiFel < m.vendegFel || m.hazaiGol<m.vendegGol && m.hazaiFel>m.vendegFel);
            foreach (var i in fordítások)
            {
                Console.WriteLine("\t{0}. forduló: {1}", i.Forduló, i.Győztes);
            }
            ////////////////////// 4. feladat //////////////////////
            Console.Write("\n4. feladat: A kiválasztott csapat neve: ");
            string csapat = Console.ReadLine();
            ////////////////////// 5. feladat //////////////////////
            var hL = (from m in meccsek where m.HazaiNeve == csapat select m.hazaiGol).Sum();
            var iL = (from m in meccsek where m.IdegenNeve == csapat select m.vendegGol).Sum();
            var hK = (from m in meccsek where m.HazaiNeve == csapat select m.vendegGol).Sum();
            var iK = (from m in meccsek where m.IdegenNeve == csapat select m.hazaiGol).Sum();
            //var iK = meccsek.Find(x => (x.IdegenNeve == csapat)(x.hazaiGol));
            int a = hL + iL;
            int b = hK + iK;
            Console.WriteLine($"\n5. Feladat: {a} lőtt gól és {b} kapott gól.");
            ////////////////////// 6. feladat //////////////////////
            var elsőKikap = (from m in meccsek where m.HazaiNeve == csapat && m.Győztes != csapat && m.Győztes != "Döntetlen" orderby m.Forduló select m);
           // var elsőKikap = meccsek.Find(m => m.HazaiNeve == csapat && m.Győztes != csapat && m.Győztes != "Döntetlen").OrderBy(m.Forduló));
            Console.WriteLine("6. feladat:" );
            if (elsőKikap.Count() > 0)
            {
                Console.WriteLine("\tA(z){0} a(z) {1}. fordulóban kapott ki először a(z) {2}-tól/től!", csapat, elsőKikap.First().Forduló, elsőKikap.First().Győztes);
            }
            else
            {
                Console.WriteLine("\tA csapat otthon veretlen maradt.");
            }
            ////////////////////// 7. feladat //////////////////////

            Console.ReadKey();
        }
    }
}
