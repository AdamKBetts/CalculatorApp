using System;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true) // Main loop
            {


                double num1, num2;

                Console.Write("Enter first number: ");
                while (!double.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("Invalid input. Please enter a number: ");
                }

                Console.Write("Enter operator (+, -, *, /, ^, %, s): ");
                char op = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (op != 's') // Only ask for the second number if it's not a square root operation
                {
                    Console.Write("Enter second number: ");
                    while (!double.TryParse(Console.ReadLine(), out num2))
                    {
                        Console.WriteLine("Invalid input. Please enter a number: ");
                    }
                }
                else
                {
                    num2 = 0; // Dummy value for square root calculation
                }

                double result = 0;

                switch (op)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        if (num2 == 0)
                        {
                            Console.WriteLine("Cannot divide by zero!");
                            return;
                        }
                        result = num1 / num2;
                        break;
                    case '^': // Exponentiation
                        result = Math.Pow(num1, num2);
                        break;
                    case '%': // Modulus
                        result = num1 % num2;
                        break;
                    case 's': // Square root (of the first number)
                        if (num1 < 0)
                        {
                            Console.WriteLine("Cannot take square root of a negative number.");
                            return;
                        }
                        result = Math.Sqrt(num1);
                        break;
                    default:
                        Console.WriteLine("Invalid operator!");
                        return;
                }

                Console.WriteLine($"{num1} {op} {num2} = {result}");

                Console.Write("Do you want to perform another calculation? (y/n): ");
                char continueChoice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if(continueChoice != 'y')
                {
                    break; // Exit the loop if the user doesn't enter 'y'
                }
            }
        }
    }
}