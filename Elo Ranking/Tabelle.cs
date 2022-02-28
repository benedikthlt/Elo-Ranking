using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elo_Ranking
{
    public class Tabelle
    {
        public static void SpielerListe(Spielerverwaltung spielerverwaltung)
        {
            for (int i = 0; i < spielerverwaltung.Spieler.Count; i++)
            {
                Console.WriteLine(i + ": " + spielerverwaltung.Spieler[i].Name);
            }
        }

        public static void TabelleLigaColored(Spielerverwaltung spielerverwaltung)
        {
            var SpielerSorted = spielerverwaltung.Spieler.OrderByDescending(Spieler => Spieler.Elo).ToList();

            for (int i = 0; i < SpielerSorted.Count; i++)
            {
                if (SpielerSorted[i].Name.Length >= 7)
                {
                    if (SpielerSorted[i].Name == spielerverwaltung.Spieler[spielerverwaltung.Player1].Name)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{SpielerSorted[i].Name} \t {SpielerSorted[i].Elo.ToString("n0")} Elo");
                        Console.ResetColor();

                    }
                    else if (SpielerSorted[i].Name == spielerverwaltung.Spieler[spielerverwaltung.Player2].Name)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{SpielerSorted[i].Name} \t {SpielerSorted[i].Elo.ToString("n0")} Elo");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"{SpielerSorted[i].Name} \t {SpielerSorted[i].Elo.ToString("n0")} Elo");
                    }
                }
                else
                {
                    if (SpielerSorted[i].Name == spielerverwaltung.Spieler[spielerverwaltung.Player1].Name)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{SpielerSorted[i].Name} \t\t {SpielerSorted[i].Elo.ToString("n0")} Elo");
                        Console.ResetColor();

                    }
                    else if (SpielerSorted[i].Name == spielerverwaltung.Spieler[spielerverwaltung.Player2].Name)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{SpielerSorted[i].Name} \t\t {SpielerSorted[i].Elo.ToString("n0")} Elo");
                        Console.ResetColor();

                    }
                    else
                    {
                        Console.WriteLine($"{SpielerSorted[i].Name} \t\t {SpielerSorted[i].Elo.ToString("n0")} Elo");
                    }
                }
            }
        }
        public static void TabelleLiga(Spielerverwaltung spielerverwaltung)
        {
            var SpielerSorted = spielerverwaltung.Spieler.OrderByDescending(Spieler => Spieler.Elo).ToList();

            for (int i = 0; i < SpielerSorted.Count; i++)
            {
                if (SpielerSorted[i].Name.Length >= 7)
                {
                    Console.WriteLine($"{SpielerSorted[i].Name} \t {SpielerSorted[i].Elo.ToString("n0")} Elo");
                }
                else
                {
                    Console.WriteLine($"{SpielerSorted[i].Name} \t\t {SpielerSorted[i].Elo.ToString("n0")} Elo");
                }
            }
        }
    }
}
