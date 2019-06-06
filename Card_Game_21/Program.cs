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
    class Card
    {
        public Suit Suit;
        public Face Face;
        public int CardPoint;
        public Card (Suit suit, Face face, int cardPoint)
        {
            Suit = suit;
            Face = face;
            CardPoint = cardPoint;
        }
    }
    class Deck
    {
        public Card[] DeckOfCards;
        public int Count = 0;

        public void GenerateDeck()
        {
            int suitLength = Enum.GetNames(typeof(Suit)).Length;
            int faceLenght = Enum.GetNames(typeof(Face)).Length;
            Card[] DeckOfCards = new Card[suitLength * faceLenght];
            int[] cardPoint = new int[DeckOfCards.Length];

            cardPoint[(int)Face.Jack] = 2;
            cardPoint[(int)Face.Qween] = 3;
            cardPoint[(int)Face.King] = 4;
            cardPoint[(int)Face.Six] = 6;
            cardPoint[(int)Face.Seven] = 7;
            cardPoint[(int)Face.Eight] = 8;
            cardPoint[(int)Face.Nine] = 9;
            cardPoint[(int)Face.Ten] = 10;
            cardPoint[(int)Face.Ace] = 11;

            for (int x = 0; x < suitLength; x++)
            {
                for (int y = 0; y < faceLenght; y++)
                {
                    DeckOfCards[Count]=new Card((Suit)x, (Face)y, cardPoint[y]);
                    Count++;
                }
            }
        }
        public void ShuffleDeck()
        {

            for (int i = DeckOfCards.Length - 1; i >= 1; i--)
            {
                Random random = new Random();
                int j = random.Next(i + 1);
                var temp = DeckOfCards[j];
                DeckOfCards[j] = DeckOfCards[i];
                DeckOfCards[i] = temp;
            }
        }
        public Card TakeOneCard(Card[] cards)
        {
            int a = 0;
            for (int i = DeckOfCards.Length - 1; i >= 1; i--)
            {
                if (i == DeckOfCards.Length - 1 && DeckOfCards.Length > 0)
                {
                    cards[a] = DeckOfCards[i];
                }
            }
            return cards[a];
        }
        public void PrintDeck()
        {
            for (int i = 0; i < DeckOfCards.Length; i++)
            {
                Console.WriteLine($"{DeckOfCards[i].Suit} {DeckOfCards[i].Face} {DeckOfCards[i].CardPoint}");
            }
        }
    }
    class Hand
    {
        public Card[] Cards;
        public Hand(Card[] cards)
        {
            Cards = cards;
        }
        public void HandCards(Card card)
        {
            Card[] arrHand = new Card[Cards.Length + 1];
            Array.Copy(Cards, 0, arrHand, 0, arrHand.Length - 1);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.GenerateDeck();
            deck.ShuffleDeck();
            deck.PrintDeck();
        }
    }
}
