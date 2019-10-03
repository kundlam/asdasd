using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mastermind
{
    class Program
    {
        public int[] tippekk;
        static void tabla()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(8, 1);
            //fejléc
            Console.Write("- ═ M A S T E R M I N D ═ - ");
            Console.SetCursorPosition(0, 1);
            Console.Write("║");
            Console.SetCursorPosition(44, 1);
            Console.Write("║");
            Console.SetCursorPosition(48, 1);
            Console.Write("JH");
            Console.SetCursorPosition(45, 1);
            Console.Write("║");
            Console.SetCursorPosition(53, 1);
            Console.Write("║");
            Console.SetCursorPosition(55, 1);
            Console.Write("JHSZ");
            Console.SetCursorPosition(52, 1);
            Console.Write("║");
            Console.SetCursorPosition(60, 1);
            Console.Write("║");
            Console.SetCursorPosition(65, 1);
            Console.Write("JELMAGYARÁZAT");
            Console.SetCursorPosition(61, 1);
            Console.Write("║");
            Console.SetCursorPosition(80, 1);
            Console.Write("║");


            for (int i = 0; i < 81; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("═");
                Console.SetCursorPosition(i, 2);
                Console.Write("═");
            }
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 81; j++)
                {
                    Console.SetCursorPosition(j, i*2+4);
                    Console.Write("═");
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 3; j < 24; j++)
                {
                    Console.SetCursorPosition(i + i * 10, j);
                    if (j % 2 == 1)
                    {
                        Console.Write("║");
                    }
                    else
                    {
                        Console.Write("╬");
                    }
                }
            }
            //Oszlopok JH-JHSZ
            for (int j = 3; j < 24; j++)
            {
                Console.SetCursorPosition(45, j);
                Console.Write("║");
                Console.SetCursorPosition(52, j);
                Console.Write("║");
                Console.SetCursorPosition(53, j);
                Console.Write("║");
                Console.SetCursorPosition(60, j);
                Console.Write("║");
                //jelmagyarázat
                Console.SetCursorPosition(80, j);
                Console.Write("║");
                Console.SetCursorPosition(61, j);
                Console.Write("║");
            }
            //sarkok szélek 
            Console.SetCursorPosition(0,0);
            Console.Write("╔");
            Console.SetCursorPosition(44,0);
            Console.Write("╗");
            Console.SetCursorPosition(0,24);
            Console.Write("╚");
            Console.SetCursorPosition(44,24);
            Console.Write("╝");//*/
            for (int k = 0; k < 11; k++)
            {
                Console.SetCursorPosition(0, k*2+2);
                Console.Write("╠");
                Console.SetCursorPosition(44, k * 2 + 2);
                Console.Write("╣");
            }
            for (int k = 1; k < 4; k++)
            {
                Console.SetCursorPosition(k * 11, 2);
                Console.Write("╦");
                Console.SetCursorPosition(k * 11, 24);
                Console.Write("╩");
            }
            //JH-JSZsarkok szélek 
            Console.SetCursorPosition(45, 0);
            Console.Write("╔");
            Console.SetCursorPosition(52, 0);
            Console.Write("╗");
            Console.SetCursorPosition(45, 24);
            Console.Write("╚");
            Console.SetCursorPosition(52, 24);
            Console.Write("╝");//*/
            Console.SetCursorPosition(53, 0);
            Console.Write("╔");
            Console.SetCursorPosition(60, 0);
            Console.Write("╗");
            Console.SetCursorPosition(53, 24);
            Console.Write("╚");
            Console.SetCursorPosition(60, 24);
            Console.Write("╝");//*/

            //SZÉLEK JH-JHSZ
            for (int k = 0; k < 11; k++)
            {
                Console.SetCursorPosition(45, k * 2 + 2);
                Console.Write("╠");
                Console.SetCursorPosition(53, k * 2 + 2);
                Console.Write("╠");
                Console.SetCursorPosition(52, k * 2 + 2);
                Console.Write("╣");
                Console.SetCursorPosition(60, k * 2 + 2);
                Console.Write("╣");
            }
            //szélek jelmagyarázat
            for(int k = 0; k < 11; k++)
            {
                Console.SetCursorPosition(61, k * 2 + 2);
                Console.Write("╠");
                Console.SetCursorPosition(80, k * 2 + 2);
                Console.Write("╣");
            }
            Console.SetCursorPosition(61, 0);
            Console.Write("╔");
            Console.SetCursorPosition(80, 0);
            Console.Write("╗");
            Console.SetCursorPosition(61, 24);
            Console.Write("╚");
            Console.SetCursorPosition(80, 24);
            Console.Write("╝");//*/
        }
        static void general()
        {
            for (int i = 1; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(j+1, 3);
                    Console.Write("█");
                    Console.SetCursorPosition(j+12, 3);
                    Console.Write("█");
                    Console.SetCursorPosition(j+23, 3);
                    Console.Write("█");
                    Console.SetCursorPosition(j+34, 3);
                    Console.Write("█");
                }
            }
        }
        static void jatek()
        {
            bool rossz_input;
            char ch;
            int tipp_sor = 1, tipp_oszlop = 0;
            int tipp;
            int sorsz = 0;
            int[] tippekk = new int[4];
            do
            {
                rossz_input = false;
                sorsz++;
                ch = Console.ReadKey(true).KeyChar;
                if (tipp_oszlop == 4)
                {
                    tipp_sor += 2;
                    tipp_oszlop = 1;
                }
                else
                {
                    tipp_oszlop++;
                }
                switch (ch)
                {
                    case 'r':
                        Console.ForegroundColor = ConsoleColor.Red;
                        tippekk[sorsz] = 1;
                        break;
                    case 'g':
                        Console.ForegroundColor = ConsoleColor.Green;
                        tippekk[sorsz] = 2;
                        break;
                    case 'b':
                        Console.ForegroundColor = ConsoleColor.Blue;
                        tippekk[sorsz] = 3;
                        break;
                    case 'y':
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        tippekk[sorsz] = 4;
                        break;
                    case 'm':
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        tippekk[sorsz] = 5;
                        break;
                    case 'w':
                        Console.ForegroundColor = ConsoleColor.White;
                        tippekk[sorsz] = 6;
                        break;
                    default:
                        rossz_input = true;
                        break;
                }
                if (ch != 27)
                {
                    switch (tipp_oszlop)
                    {
                        case 1: Console.SetCursorPosition(1, tipp_sor + 4); break;
                        case 2: Console.SetCursorPosition(12, tipp_sor + 4); break;
                        case 3: Console.SetCursorPosition(23, tipp_sor + 4); break;
                        case 4: Console.SetCursorPosition(34, tipp_sor + 4); break;
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write("█");
                    }
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
            } while (ch != 27 && sorsz / 3.3 <= 12);
        }
        static void Main(string[] args)
        {
            Console.SetWindowSize(81, 25);
            Console.OutputEncoding = Encoding.UTF8;
            bool helyes = false;
            int tipSZ = 0;
            Random rnd = new Random();
            int szam = rnd.Next(1110, 6667);
            tabla();
            //tabla2();            
            general();
            jatek();

            /*  
            do
            {
                Console.WriteLine("Válassz mennyi tipped legyen? [4-12]");
                tipSZ = Convert.ToInt32(Console.ReadLine());
                if (tipSZ >= 4 && tipSZ<=12)
                {
                    helyes = true;
                }
            } while (helyes == false);
            helyes = false;
            int[] tip = new int[tipSZ];
            for (int i = 0; i < tipSZ; i++)
            {
                do
                {
                    Console.WriteLine(i+1+". tipped: ");
                    tip[i] = Convert.ToInt32(Console.ReadLine());
                    if (tip[i] >= 1111 && tip[i] <= 6666)
                    {
                        helyes = true;
                    } else
                    {
                        Console.WriteLine("Nem helyes tipp [1111-6666]");
                    }
                } while (helyes==false);
                
            }
            for (int i = 0; i < tip.Length; i++)
            {
                Console.WriteLine(tip[i]);
            }
            */
            
            Console.ReadKey();
        }
    }
}