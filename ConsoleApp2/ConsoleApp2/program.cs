using ConsoleApp2;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to MathsTutor!");

        bool keepRunning = true;
        while (keepRunning)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Instructions");
            Console.WriteLine("2. Deal 3 cards");
            Console.WriteLine("3. Quit");
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




