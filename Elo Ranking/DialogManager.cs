using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elo_Ranking
{
    public class DialogManager
    {
        
        public static string error = "Bitte wähle eine der vorgegebenen Optionen";
        public static string newName = "Bitte gib deinen Namen ein";
        public static string wrongFormat = "Bitte gib eine Zahl ein";
        public static string newPlayer = "Neuen Spieler hinzufügen? J/N";
        public static string setPlayer2 = "Bitte wähle Spieler 2";
        public static string wrongPlayers = "Spieler 1 und Spieler 2 können nicht die selbe Person sein";
        public static string followRules = "Bitte gib die Punkte gem. Regelwerk an";
        public static string nextStep = "Was möchtest du als nächstes tun?\n1: Revange\n2: neues Spiel\n3: Tabelle ansehen";
        public static string start = "Bitte drücke Enter um ein Spiel zu starten";
        public static void WriteSetPlayer1()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Bitte wähle Spieler 1");
            Console.ResetColor();
        }
        public static void WriteSetPlayer2()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Bitte wähle Spieler 2");
            Console.ResetColor();
        }
        public static void WriteSetResult1(Spielerverwaltung spielerverwaltung)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Punktzahl {spielerverwaltung.Spieler[spielerverwaltung.Player1].Name} :");
            Console.ResetColor();
        }
        public static void WriteSetResult2(Spielerverwaltung spielerverwaltung)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nPunktzahl {spielerverwaltung.Spieler[spielerverwaltung.Player2].Name} :");
            Console.ResetColor();
        }
        public static void SetPlayer1(Spielerverwaltung spielerverwaltung)
        {
            Tabelle.SpielerListe(spielerverwaltung);

            while (true)
            {
                WriteSetPlayer1();

                if (spielerverwaltung.UmwandlungPlayer1(Console.ReadLine()))
                {
                    break;
                }
                Console.WriteLine(error);
            }
        }
        public static void SetPlayer2(Spielerverwaltung spielerverwaltung)
        {
            while (true)
            {
                WriteSetPlayer2();
                bool umwandlung = spielerverwaltung.UmwandlungPlayer2(Console.ReadLine());
                bool samePlayer = spielerverwaltung.Player1 == spielerverwaltung.Player2;

                if (umwandlung && !samePlayer)
                {
                    Console.WriteLine("");
                    break;
                }
                else if (samePlayer)
                {
                    Console.WriteLine(wrongPlayers);
                }
                else
                {
                    Console.WriteLine(error);
                }
            }
        }
        public static void SetResult1(Spielerverwaltung spielerverwaltung)
        {
            while (true)
            {
                WriteSetResult1(spielerverwaltung);
                if (spielerverwaltung.Result1(Console.ReadLine()))
                {
                    break;
                }
                Console.WriteLine(wrongFormat);
            }
        }




    }
}
