using System;
using System.Diagnostics;

namespace CalculatorApp
{
    class Program
    {
        static double memory = 0;
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
            Console.Write("Enter operator (+, -, *, /, ^, %, s, c, t, l, M, m, C, R): "); // Added M, m, C, R
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
                        case 'M':
                        case 'm':
                        case 'C':
                        case 'R':
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
            try
            {
                switch (op)
                {
                    case '+': return num1 + num2;
                    case '-': return num1 - num2;
                    case '*': return num1 * num2;
                    case '/':
                        if (num2 == 0)
                        {
                            throw new DivideByZeroException(); // Throw exception
                        }
                        return num1 / num2;
                    case '^': return Math.Pow(num1, num2);
                    case '%': return num1 % num2;
                    case 's':
                        if (num1 < 0)
                        {
                            throw new ArgumentException("Cannot take square root of a negative number");
                        }
                        return Math.Sqrt(num1);
                    case 'c': return Math.Cos(num1 * Math.PI / 180); // Cosine (degrees to radians)
                    case 't': return Math.Tan(num1 * Math.PI / 180); // Tangent (degrees to radians)
                    case 'l': return Math.Log10(num1); // Logarithm base 10
                    case 'M':
                        memory += num1;
                        return memory;
                    case 'm':
                        memory -= num1;
                        return memory;
                    case 'C':
                        memory = 0;
                        return memory;
                    case 'R':
                        return memory;
                    default: return 0; // Should not happen due to operatpr validation
                }
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division by zero error!");
                return double.NaN; // Return NaN (Not a Number) to indicate an error
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return double.NaN;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
                return double.NaN;
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine($"Current Memory: {memory}"); // Display memory
                
                double num1 = GetNumberInput("Enter first number: ");
                char op = GetOperatorInput();

                double num2 = 0; // Initialize
                if (op != 's' && op != 'c' && op != 't' && op != 'l' && op != 'C' && op != 'R') // Don't ask for a second number
                {
                    if (op != 'M' && op != 'm') // Added this check
                    {
                        num2 = GetNumberInput("Enter second number: ");
                    }
                }

                double result = Calculate(num1, op, num2);

                if (!double.IsNaN(result)) // Check if the result is valid (not NaN) 
                {
                    Console.WriteLine($"{num1} {op} {num2} = {result}");
                }

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