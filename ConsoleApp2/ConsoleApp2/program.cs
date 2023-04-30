using ConsoleApp2;
using System;
using System.Diagnostics;
using System.IO;

class Program
{
    private static string statisticsFilePath = "statistics.txt";

    public static string StatisticsFilePath { get => statisticsFilePath; set => statisticsFilePath = value; }

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to MathsTutor!");

        bool keepRunning = true;
        while (keepRunning)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Instructions");
            Console.WriteLine("2. Deal 3 cards");
            Console.WriteLine("3. Deal 5 cards");
            Console.WriteLine("4. Quit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Tutorial.ShowInstructions();
                    break;
                case 2:
                    DealThreeCards();
                    break;
                case 3:
                    DealFiveCards();
                    break;
                case 4:
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }


        Console.WriteLine("\nGoodbye!");
    }

    private static void DealThreeCards()
    {

        {
            Pack pack = new Pack();
            Card card1 = pack.DrawCard();
            Card card2 = pack.DrawCard();
            Card card3 = pack.DrawCard();

            char operatorChar = GetOperatorFromSuit(card2.Suit);

            Console.WriteLine($"Problem: {card1.Value} {operatorChar} {card3.Value}");
            Console.Write("Enter your answer: ");
            double answer = double.Parse(Console.ReadLine());

            double correctAnswer = CalculateAnswer(card1.Value, card3.Value, operatorChar);

            if (Math.Abs(answer - correctAnswer) < 0.001)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}.");
            }
        }
    }

    private static void DealFiveCards()
    {
        Pack pack = new Pack();
        Card card1 = pack.DrawCard();
        Card card2 = pack.DrawCard();
        Card card3 = pack.DrawCard();
        Card card4 = pack.DrawCard();
        Card card5 = pack.DrawCard();

        char operatorChar1 = GetOperatorFromSuit(card2.Suit);
        char operatorChar2 = GetOperatorFromSuit(card4.Suit);

        Console.WriteLine($"Problem: {card1.Value} {operatorChar1} {card3.Value} {operatorChar2} {card5.Value}");
        Console.Write("Enter your answer: ");
        double answer = double.Parse(Console.ReadLine());

        double correctAnswer = CalculateBODMASAnswer(card1.Value, card3.Value, card5.Value, operatorChar1, operatorChar2);

        if (Math.Abs(answer - correctAnswer) < 0.001)
        {
            Console.WriteLine("Correct!");

        }
        else
        {
            Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}.");

        }
    }

    // Existing code for GetOperatorFromSuit and CalculateAnswer

    private static double CalculateBODMASAnswer(int value1, int value2, int value3, char operatorChar1, char operatorChar2)
    {
        double intermediateValue;

        if ((operatorChar1 == '*' || operatorChar1 == '/') && (operatorChar2 == '+' || operatorChar2 == '-'))
        {
            intermediateValue = CalculateAnswer(value1, value2, operatorChar1);
            return CalculateAnswer((int)Math.Round(intermediateValue), value3, operatorChar2);
        }
        else
        {
            intermediateValue = CalculateAnswer(value2, value3, operatorChar2);
            return CalculateAnswer(value1, (int)Math.Round(intermediateValue), operatorChar1);
        }
    }
    private static char GetOperatorFromSuit(int suit)
    {
        return suit switch
        {
            1 => '+',
            2 => '-',
            3 => '*',
            4 => '/',
            _ => throw new ArgumentException("Invalid suit value."),
        };
    }
    private static double CalculateAnswer(int value1, int value2, char operatorChar)
    {
        return operatorChar switch
        {
            '+' => value1 + value2,
            '-' => value1 - value2,
            '*' => value1 * value2,
            '/' => (double)value1 / value2,
            _ => throw new ArgumentException("Invalid operator character."),
        };
    }
}




