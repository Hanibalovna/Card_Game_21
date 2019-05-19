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
            int computerChoice = random.Next(0, 2);
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


            if (cardPointHuman == 21)
                Console.WriteLine("Human win");



            else if (cardPointHuman > 21)
            {
                Console.WriteLine("Game is over");
                //computer should also make decision stop receiving the third card or get one more

                if (computerChoice == 0)
                {
                    for (int i = 0; i < computerDeck.Length; i++)
                    {
                        computerDeck[i].Face = deckOfCards[i].Face;
                        computerDeck[i].Suit = deckOfCards[i].Suit;

                        computerDeck[i].cardPoint = deckOfCards[i].cardPoint;
                        cardPointComputer += deckOfCards[i].cardPoint;

                        lastIndexDeckOfCards = i;
                        Console.WriteLine($"{computerDeck[i].Suit} {computerDeck[i].Face} {deckOfCards[i].cardPoint}");
                    }
                    Console.WriteLine(lastIndexDeckOfCards);

                    if (cardPointComputer == 21)
                        Console.WriteLine("Computer win");
                }
            }

            else
            {
                Console.WriteLine("decide what do you want? get one more card(press 'y') or stop receiving cards('n')");

                string choise = Console.ReadLine();
                if (choise == "y")
                {
                    Card[] humanDeck1 = new Card[humanDeck.Length + 1];
                    for (int i = 0; i < humanDeck1.Length; i++)
                    {

                        humanDeck1[0].Suit = humanDeck[0].Suit;
                        humanDeck1[0].Face = humanDeck[0].Face;
                        humanDeck1[1].Suit = humanDeck[1].Suit;
                        humanDeck1[1].Face = humanDeck[1].Face;
                        humanDeck1[lastIndexDeckOfCards + 1].Face = deckOfCards[lastIndexDeckOfCards + 1].Face;
                        humanDeck1[lastIndexDeckOfCards + 1].Suit = deckOfCards[lastIndexDeckOfCards + 1].Suit;

                        humanDeck1[i].cardPoint = deckOfCards[i].cardPoint;
                        cardPointHuman += deckOfCards[i].cardPoint;
                        lastIndexDeckOfCards = i;

                        Console.WriteLine($"{humanDeck1[i].Face} {humanDeck1[i].Suit} {humanDeck1[i].cardPoint}");
                    }
                    Console.WriteLine(lastIndexDeckOfCards);

                    if (cardPointHuman == 21)
                        Console.WriteLine("Human win");

                    else if (cardPointHuman > 21)
                    {
                        Console.WriteLine("Game is over");

                        Card[] computerDeck1 = new Card[computerDeck.Length + 1];
                        if (computerChoice == 0)
                        {
                            for (int i = 0; i < computerDeck1.Length; i++)
                            {
                                computerDeck1[0].Face = deckOfCards[0].Face;
                                computerDeck1[0].Suit = deckOfCards[0].Suit;
                                computerDeck1[1].Face = deckOfCards[1].Face;
                                computerDeck1[1].Suit = deckOfCards[1].Suit;

                                computerDeck1[lastIndexDeckOfCards + 1].Face = deckOfCards[lastIndexDeckOfCards + 1].Face;
                                computerDeck1[lastIndexDeckOfCards + 1].Suit = deckOfCards[lastIndexDeckOfCards + 1].Suit;
                                computerDeck1[i].cardPoint = deckOfCards[i].cardPoint;
                                cardPointComputer += deckOfCards[i].cardPoint;

                                lastIndexDeckOfCards = i;
                                Console.WriteLine($"{computerDeck[i].Suit} {computerDeck[i].Face} {computerDeck1[i].cardPoint}");
                            }
                            Console.WriteLine(lastIndexDeckOfCards);

                            if (cardPointComputer == 21)
                                Console.WriteLine("Computer win");
                        }
                        else
                        {
                            if (cardPointHuman > 22 && cardPointHuman > cardPointComputer)
                                Console.WriteLine("Computer win");
                        }

                    }
                    else
                    {
                        Card[] humanDeck2 = new Card[humanDeck.Length + 2];
                        for (int i = 0; i < humanDeck2.Length; i++)
                        {
                            humanDeck2[0].Suit = humanDeck1[0].Suit;
                            humanDeck2[0].Face = humanDeck1[0].Face;
                            humanDeck2[1].Suit = humanDeck1[1].Suit;
                            humanDeck2[1].Face = humanDeck1[1].Face;
                            humanDeck2[2].Suit = humanDeck1[2].Suit;
                            humanDeck2[2].Face = humanDeck1[2].Face;
                            humanDeck2[lastIndexDeckOfCards + 1].Face = deckOfCards[lastIndexDeckOfCards + 1].Face;
                            humanDeck2[lastIndexDeckOfCards + 1].Suit = deckOfCards[lastIndexDeckOfCards + 1].Suit;

                            humanDeck2[i].cardPoint = deckOfCards[i].cardPoint;
                            cardPointHuman += deckOfCards[i].cardPoint;
                            lastIndexDeckOfCards = i;

                            Console.WriteLine($"{humanDeck2[i].Face} {humanDeck2[i].Suit} {humanDeck2[i].cardPoint}");
                        }
                        Console.WriteLine(lastIndexDeckOfCards);

                        if (cardPointHuman == 21)
                            Console.WriteLine("Human win");

                        else if (cardPointHuman > 21)
                        {
                            Console.WriteLine("Game is over");
                            //computer should also make decision stop receiving the third card or get one more
                            Card[] computerDeck2 = new Card[computerDeck.Length + 2];
                            if (computerChoice == 0)
                            {
                                for (int i = 0; i < computerDeck2.Length; i++)
                                {
                                    computerDeck2[0].Face = deckOfCards[0].Face;
                                    computerDeck2[0].Suit = deckOfCards[0].Suit;
                                    computerDeck2[1].Face = deckOfCards[1].Face;
                                    computerDeck2[1].Suit = deckOfCards[1].Suit;
                                    computerDeck2[lastIndexDeckOfCards + 1].Face = deckOfCards[lastIndexDeckOfCards + 1].Face;
                                    computerDeck2[lastIndexDeckOfCards + 1].Suit = deckOfCards[lastIndexDeckOfCards + 1].Suit;

                                    computerDeck2[i].cardPoint = deckOfCards[i].cardPoint;
                                    cardPointComputer += deckOfCards[i].cardPoint;
                                    lastIndexDeckOfCards = i;

                                    Console.WriteLine($"{computerDeck2[i].Suit} {computerDeck2[i].Face} {computerDeck2[i].cardPoint}");
                                }
                                Console.WriteLine(lastIndexDeckOfCards);

                                if (cardPointComputer == 21)
                                    Console.WriteLine("Computer win");
                            }
                            else
                            {
                                if (cardPointHuman > 22 && cardPointHuman > cardPointComputer)
                                    Console.WriteLine("Computer win");
                            }

                        }
                    }
                }
                else if (choise == "n")
                {
                    Console.WriteLine($"Computer hand:");

                    for (int i = 0; i < computerDeck.Length; i++)
                    {
                        computerDeck[i].Face = deckOfCards[i].Face;
                        computerDeck[i].Suit = deckOfCards[i].Suit;
                        deckOfCards[i].cardPoint = deckOfCards[i].cardPoint;
                        cardPointComputer += deckOfCards[i].cardPoint;
                        lastIndexDeckOfCards = i;
                        Console.WriteLine($"{computerDeck[i].Suit} {computerDeck[i].Face} {deckOfCards[i].cardPoint}");
                    }
                    Console.WriteLine(lastIndexDeckOfCards);
                    if (cardPointComputer == 21 || cardPointComputer == 22)
                        Console.WriteLine("Coputer win");
                    else
                    {
                        Card[] computerDeck1 = new Card[computerDeck.Length + 1];
                        for (int i = 0; i < computerDeck1.Length; i++)
                        {

                            computerDeck1[0].Suit = computerDeck[0].Suit;
                            computerDeck1[0].Face = computerDeck[0].Face;
                            computerDeck1[1].Suit = computerDeck[1].Suit;
                            computerDeck1[1].Face = computerDeck[1].Face;
                            computerDeck1[lastIndexDeckOfCards + 1].Face = deckOfCards[lastIndexDeckOfCards + 1].Face;
                            computerDeck1[lastIndexDeckOfCards + 1].Suit = deckOfCards[lastIndexDeckOfCards + 1].Suit;
                            cardPointHuman += deckOfCards[i].cardPoint;
                            lastIndexDeckOfCards = i;
                            Console.WriteLine($"{computerDeck1[i].Face} {computerDeck1[i].Suit} {computerDeck1[i].cardPoint}");
                        }
                        Console.WriteLine(lastIndexDeckOfCards);
                    }

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
}
