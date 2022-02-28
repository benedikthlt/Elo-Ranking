using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elo_Ranking
{
    public class Spieler
    {

        public float Elo { get; set; } = 1000;
        public string Name { get; set; }
        public Spieler(string name, float elo)
        {
            Name = name;
            Elo = elo;
        }
        public Spieler()
        {

        }

        public void UpdateElo(int result1, int result2, float eloGegner)
        {
            float ausgang = Ausgang(result1, result2);
            float expected = Expected(eloGegner);
            Elo += 15 * (ausgang - expected);
        }

        public float Ausgang(int result1, int result2)
        {
            if (result1 > result2)
            {
                return 1f;
            }
            else if (result1 < result2)
            {
                return 0f;
            }
            else
            {
                return 0.5f;
            }
        }

        public float Expected(float elo2)
        {
            double nenner = 1 + Math.Pow(10, ((elo2 - Elo) / 400));
            float expected1 = (float)(1 / nenner);
            return expected1;
        }

    }
}
