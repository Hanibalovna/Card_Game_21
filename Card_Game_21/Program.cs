using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game_21
{
    enum Suit
    {
        Hurt,
        Diamond,
        Spades,
        Clubs
    }

    enum Face
    {
        Jack, Qween, King,
        Six, Seven, Eight,
        Nine, Ten, Ace
    }

    struct Card
    {
        public Suit Suit;
        public Face Face;
        public int cardPoint;
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
