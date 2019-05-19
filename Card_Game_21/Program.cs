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
            Random random = new Random();

            int suitLength = Enum.GetNames(typeof(Suit)).Length;
            int faceLenght = Enum.GetNames(typeof(Face)).Length;

            Card[] deckOfCards = new Card[suitLength * faceLenght];
            int[] facePoint = new int[deckOfCards.Length];


            for (int y = 0; y < faceLenght; y++)
            {
                facePoint[(int)Face.Jack] = 2;
                facePoint[(int)Face.Qween] = 3;
                facePoint[(int)Face.King] = 4;
                facePoint[(int)Face.Six] = 6;
                facePoint[(int)Face.Seven] = 7;
                facePoint[(int)Face.Eight] = 8;
                facePoint[(int)Face.Nine] = 9;
                facePoint[(int)Face.Ten] = 10;
                facePoint[(int)Face.Ace] = 11;
            }


        }
    }
}
