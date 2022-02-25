namespace Elo_Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
            var spielerverwaltung = new Spielerverwaltung();
            var spieler = new Spieler();
            var tabelle = new Tabelle();

            bool isRunning = true;
            while (isRunning)
            {
                isRunning = false;

                spielerverwaltung.FirstAction();
                spielerverwaltung.SetPlayer1();
                spielerverwaltung.SetPlayer2();

                bool isRunning2 = true;
                while (isRunning2)
                {
                    isRunning2 = false;

                    bool proved = false;

                    while (!proved)
                    {
                        proved = true;
                        spielerverwaltung.SetResult1();
                        spielerverwaltung.SetResult2();

                        if (!spielerverwaltung.CheckResult())
                        {
                            proved = false;
                        }
                    }
                    bool isRunning3 = true;
                    while (isRunning3)
                    {
                        isRunning3 = false;

                        spielerverwaltung.ApplyMatch();
                        Console.WriteLine("Tabelle:");
                        spielerverwaltung.TabelleAnzeigen();
                        Console.ReadLine();

                        bool isCorrect = false;
                        while (!isCorrect)
                        {
                            isCorrect = true;
                            Console.WriteLine(DialogManager.nextStep);
                            string auswahl = Console.ReadLine();
                            Console.Clear();
                            if (auswahl == "1")
                            {
                                isRunning2 = true;
                                Console.Clear();
                            }
                            else if (auswahl == "2")
                            {
                                isRunning = true;
                                Console.Clear();
                            }
                            else if (auswahl == "3")
                            {
                                spielerverwaltung.TabelleAnzeigen();
                                Console.ReadLine();
                                Console.Clear();
                                isRunning = true;
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine(DialogManager.error);
                                isCorrect = false;
                            }
                        }
                    }
                }
            }

            static void Start()
            {
                Console.WriteLine(DialogManager.start);
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}