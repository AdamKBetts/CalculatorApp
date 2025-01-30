using System;

namespace CalculatorApp
{
    class Program
    {
        static double GetNumberInput(string prompt)
        {
            double number;
            Console.Write(prompt);
            while(!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Invalid input. Please enter a number: ");
                Console.Write(prompt); // Reprompt
            }
            return number;
        }

        static char GetOperatorInput()
        {
            char op;
            Console.Write("Enter operator (+, -, *, /, ^, %, s, c, t, l: "); // Added c, t, l
            while (true) // Loop until a valid operator is entered
            {
                string input = Console.ReadLine(); // Read the entire line as a string
                if(input.Length == 1) // Check if only one char was entered
                {
                    op = input[0]; // Get the first character
                    switch (op)
                    {
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                        case '^':
                        case '%':
                        case 's':
                        case 'c':
                        case 't':
                        case 'l':
                            return op;
                        default:
                            Console.WriteLine("Invalid operator. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid operator. Please enter a single character.");
                }
            }
        }

        static double Calculate(double num1, char op, double num2)
        {
            switch (op)
            {
                case '+': return num1 + num2;
                case '-': return num1 - num2;
                case '*': return num1 * num2;
                case '/': 
                    if (num2 == 0)
                    {
                        Console.WriteLine("Cannot divide by zero!");
                        Environment.Exit(1); // More robust exit
                    }
                    return num1 / num2;
                case '^': return Math.Pow(num1, num2);
                case '%': return num1 % num2;
                case 's':
                    if(num1 < 0)
                    {
                        Console.WriteLine("Cannot take square root of a negative number.");
                        Environment.Exit(1);
                    }
                    return Math.Sqrt(num1);
                case 'c': return Math.Cos(num1 * Math.PI / 180); // Cosine (degrees to radians)
                case 't': return Math.Tan(num1 * Math.PI / 180); // Tangent (degrees to radians)
                case 'l': return Math.Log10(num1); // Logarithm base 10
                default: return 0; // Should not happen due to operatpr validation
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                double num1 = GetNumberInput("Enter first number: ");
                char op = GetOperatorInput();

                double num2 = 0; // Initialize
                if (op != 's' && op != 'c' && op != 't' && op != 'l') // Don't ask for a second number
                {
                    num2 = GetNumberInput("Enter second number: ");
                }

                double result = Calculate(num1, op, num2);
                Console.WriteLine($"{num1} {op} {num2} = {result}");

                Console.Write("Do you want to perform another calculation? (y/n): ");
                char continueChoice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if(continueChoice != 'y')
                {
                    break;
                }
            }
        }
    }
}