using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elo_Ranking;

namespace Elo_Ranking
{
    public class Spielerverwaltung
    {
        public List<Spieler> Spieler = new List<Spieler>();


        private int player1;
        public int Player1 => player1;

        private int player2;
        public int Player2 => player2;

        private int result1;
        private int result2;

        public void FirstAction()
        {
            Tabelle.SpielerListe(this);
            Console.WriteLine(DialogManager.newPlayer);
            bool isCorrect = false;
            while (!isCorrect)
            {
                isCorrect = true;
                string newPlayerChoice = Console.ReadLine();

                if (newPlayerChoice == "J" || newPlayerChoice == "j")
                {
                    NewPlayer();
                }
                else if (newPlayerChoice == "N" || newPlayerChoice == "n")
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine(DialogManager.error);
                    isCorrect = false;
                }

            }
        }

        public void NewPlayer()
        {

            Console.WriteLine(DialogManager.newName);
            string newPlayer = Console.ReadLine();
            Spieler.Add(new Spieler(newPlayer, 1000));
            Console.Clear();
            FirstAction();
        }

        public void SetPlayer1()
        {
            Tabelle.SpielerListe(this);

            while (true)
            {
                DialogManager.WriteSetPlayer1();

                if (UmwandlungPlayer1(Console.ReadLine()))
                {
                    break;
                }
                Console.WriteLine(DialogManager.error);
            }
        }
        private bool UmwandlungPlayer1(string player1Eingabe)
        {
            bool umwandlung = Int32.TryParse(player1Eingabe, out player1);

            return umwandlung && player1 < Spieler.Count();
        }

        public void SetPlayer2()
        {
            while (true)
            {
                DialogManager.WriteSetPlayer2();
                bool umwandlung = UmwandlungPlayer2(Console.ReadLine());
                bool samePlayer = player1 == player2;

                if (umwandlung && !samePlayer)
                {
                    Console.WriteLine("");
                    break;
                }
                else if (samePlayer)
                {
                    Console.WriteLine(DialogManager.wrongPlayers);
                }
                else
                {
                    Console.WriteLine(DialogManager.error);
                }
            }
        }

        private bool UmwandlungPlayer2(string player2Eingabe)
        {
            bool umwandlung = Int32.TryParse(player2Eingabe, out player2);
            return umwandlung && player2 < Spieler.Count();
        }

        public void SetResult1()
        {
            bool isCorrect = false;

            while (!isCorrect)
            {
                isCorrect = true;
                DialogManager.WriteSetResult1(this);
                string result1Eingabe = Console.ReadLine();
                bool umwandlung = Int32.TryParse(result1Eingabe, out result1);
                if (!umwandlung)
                {
                    Console.WriteLine(DialogManager.wrongFormat);
                    isCorrect = false;
                }
            }
        }

        public void SetResult2()
        {
            bool isCorrect = false;

            while (!isCorrect)
            {
                isCorrect = true;
                DialogManager.WriteSetResult2(this);
                //Console.WriteLine($"\nPunktzahl {Spieler[player2].Name} :");
                string result2Eingabe = Console.ReadLine();
                bool umwandlung = Int32.TryParse(result2Eingabe, out result2);
                if (!umwandlung)
                {
                    Console.WriteLine(DialogManager.wrongFormat);
                    isCorrect = false;
                }
            }

        }

        public bool CheckResult()
        {
            if (!(result1 == 11 && result2 < 10 || result1 < 10 && result2 == 11 || Math.Abs(result1 - result2) == 2 && (result1 > 11 || result2 > 11)))
            {
                Console.WriteLine(DialogManager.followRules);
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ApplyMatch()
        {
            //var SpielerSorted = Spieler.OrderByDescending(Spieler => Spieler.Elo).ToList();
            float EloAltPlayer1 = Spieler[player1].Elo;
            float EloAltPlayer2 = Spieler[player2].Elo;
            Spieler[player1].UpdateElo(result1, result2, Spieler[player2].Elo);
            Spieler[player2].UpdateElo(result2, result1, EloAltPlayer1);
            float DiffEloPlayer1 = Spieler[player1].Elo - EloAltPlayer1;
            float DiffEloPlayer2 = Spieler[player2].Elo - EloAltPlayer2;
            Console.WriteLine($"\n{ Spieler[player1].Name} bekommt {DiffEloPlayer1.ToString("n0")} Elo-Punkte");
            Console.WriteLine($"{Spieler[player2].Name} bekommt {DiffEloPlayer2.ToString("n0")} Elo-Punkte\n");
        }

        public void TabelleColoredAnzeigen()
        {
            Tabelle.TabelleLigaColored(this);
        }

        public void TabelleAnzeigen()
        {
            Tabelle.TabelleLiga(this);
        }

        public void IndiciesAlt()
        {

        }




    }
}

