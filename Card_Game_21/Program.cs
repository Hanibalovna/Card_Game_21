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

            int count = 0;
            for (int x = 0; x < suitLength; x++)
            {
                for (int y = 0; y < faceLenght; y++)
                {
                    deckOfCards[count].Suit = (Suit)x;
                    deckOfCards[count].Face = (Face)y;
                    deckOfCards[count].cardPoint = facePoint[y];
                    count++;
                }
            }
            //for (int a = 0; a < deckOfCards.Length; a++)
            //{
            //    Console.WriteLine($"{deckOfCards[a].Suit} {deckOfCards[a].Face} {deckOfCards[a].cardPoint}");
            //}
            //Console.WriteLine();

            for (int i = deckOfCards.Length - 1; i >= 1; i--)
            {

                int j = random.Next(i + 1);
                var temp = deckOfCards[j];
                deckOfCards[j] = deckOfCards[i];
                deckOfCards[i] = temp;

                // Console.WriteLine($"{deckOfCards[i].Suit} {deckOfCards[i].Face} {deckOfCards[i].cardPoint}");

            }


            Card[] humanDeck = new Card[2];
            Card[] computerDeck = new Card[2];
            int cardPointHuman = 0;
            int cardPointComputer = 0;

            int lastIndexDeckOfCards = 0;
            int who = random.Next(2);
            //human first
            if (who == 1)
            {
                Console.WriteLine("Human first");
                Console.WriteLine($"Human hand:");

                for (int i = 0; i < humanDeck.Length; i++)
                {
                    humanDeck[i].Face = deckOfCards[i].Face;
                    humanDeck[i].Suit = deckOfCards[i].Suit;

                    humanDeck[i].cardPoint = deckOfCards[i].cardPoint;
                    cardPointHuman += deckOfCards[i].cardPoint;
                    lastIndexDeckOfCards = i;

                    Console.WriteLine($" { humanDeck[i].Suit} {humanDeck[i].Face} {humanDeck[i].cardPoint}");
                }
                Console.WriteLine(lastIndexDeckOfCards);


            }

            //computer first
            else
            {
                Console.WriteLine("Computer first");
                Console.WriteLine($"Computer hand:");

                for (int i = 0; i < computerDeck.Length; i++)
                {
                    computerDeck[i].Face = deckOfCards[i].Face;
                    computerDeck[i].Suit = deckOfCards[i].Suit;
                    deckOfCards[i].cardPoint = (int)deckOfCards[i].Face;

                    lastIndexDeckOfCards = i;
                    Console.WriteLine($"{computerDeck[i].Suit} {computerDeck[i].Face} {deckOfCards[i].cardPoint}");
                }
                Console.WriteLine(lastIndexDeckOfCards);

                if (cardPointComputer == 21)
                    Console.WriteLine("Computer win");
            }
        }
    }
}
