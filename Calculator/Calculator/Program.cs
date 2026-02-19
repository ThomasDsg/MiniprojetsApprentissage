using System.Text.RegularExpressions;
using CalculatorLibrary;

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        // Display title as the C# console calculator app.
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");
        Calculator calculator = new Calculator();

        while (!endApp)
        {
            // Declare variables and set to empty.
            // Use Nullable types (with ?) to match type of System.Console.ReadLine
            string? numInput1 = "";
            string? numInput2 = "";
            string? op = "+";
            double result = 0;
            double finalNum1 = 0;
            double finalNum2 = 0;

            // Ask the user to type the first number.
            //Console.Write("Type a number, and then press Enter: ");
            //numInput1 = Console.ReadLine();
            string? input1 = Convert.ToString(Console.ReadKey(true).KeyChar);
            double cleanNum1 = 0;

            while (input1 != "+" && input1 != "-" && input1 != "*" && input1 != "/" && input1 != "\r")
            {
                if(double.TryParse(input1, out cleanNum1))
                {
                    numInput1 = numInput1 + input1;
                    cleanNum1 = 0;
                    Console.Write(input1);
                }
                else if (input1 == "\b"){
                    numInput1 = numInput1.Remove(numInput1.Length - 1);
                    Console.Write("\b \b");
                }
                input1 = Convert.ToString(Console.ReadKey(true).KeyChar);
            }
            if (input1 != "\r")
            {
                op = input1;
            }
            Console.Write(" {0} ", op);


            /*while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput1 = Console.ReadLine();
            }*/

            // Ask the user to type the second number.
            //Console.Write("Type another number, and then press Enter: ");
            //numInput2 = Console.ReadLine();
            string? input2 = Convert.ToString(Console.ReadKey(true).KeyChar);
            double cleanNum2 = 0;

            while (input2 != "+" && input2 != "-" && input2 != "*" && input2 != "/" && input2 != "\r")
            {
                if (double.TryParse(input2, out cleanNum2))
                {
                    numInput2 = numInput2 + Convert.ToString(input2);
                    cleanNum2 = 0;
                    Console.Write(input2);
                }
                else if (input2 == "\b")
                {
                    numInput2 = numInput2.Remove(numInput2.Length - 1);
                    Console.Write("\b \b");
                }
                input2 = Convert.ToString(Console.ReadKey(true).KeyChar);

            }
            /*while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput2 = Console.ReadLine();
            }*/

            // Validate input is not null, and matches the pattern

            try
            {
                finalNum1 = Convert.ToDouble(numInput1);
                finalNum2 = Convert.ToDouble(numInput2);

                result = calculator.DoOperation(finalNum1, finalNum2, op);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("\nThis operation will result in a mathematical error.\n");
                }
                else
                {
                    //Console.Write(new String(' ', Console.BufferWidth));
                    Console.WriteLine("\n{0:0.##}\n", result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
            }
            
            Console.WriteLine("------------------------\n");

            // Wait for the user to respond before closing.
            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n"); // Friendly linespacing.
        }
        calculator.Finish();
        return;
    }
}