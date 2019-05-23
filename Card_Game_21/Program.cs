using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game_21
{
    enum Suit
    {
        Hurt, Diamond, Spades, Clubs
    }
    enum Face
    {
        Jack, Qween, King, Six, Seven,
        Eight, Nine, Ten, Ace
    }
   struct Card
    {
        public Suit Suit;
        public Face Face;
        public int CardPoint;

        public Card[] Cards(Card[] arr)
        {
            Card[] arrCopy = new Card[arr.Length + 1];
            Array.Copy(arr, 0, arrCopy, 0, arrCopy.Length - 1);

            return arrCopy;
        }
    }
   


    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int suitLength = Enum.GetNames(typeof(Suit)).Length;
            int faceLenght = Enum.GetNames(typeof(Face)).Length;
            Card card = new Card();
            Card[] deckOfCards =card.Cards(new Card[suitLength * faceLenght]);
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
                    deckOfCards[count].CardPoint = facePoint[y];
                    count++;
                }
            }
            for (int i = deckOfCards.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                var temp = deckOfCards[j];
                deckOfCards[j] = deckOfCards[i];
                deckOfCards[i] = temp;
            }
            for (int i = 0; i < deckOfCards.Length; i++)
            {
                Console.WriteLine($"{deckOfCards[i].Suit} {deckOfCards[i].Face} {deckOfCards[i].CardPoint}");
            }
        }
    }
}
