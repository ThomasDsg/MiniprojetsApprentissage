using System.Text.RegularExpressions;
using CalculatorLibrary;

class Program
{
    static (string, string, bool) getInput()
    {
        string? numInput = "";
      
        string? inputKey = Convert.ToString(Console.ReadKey(true).KeyChar);

        while (inputKey != "+" && inputKey != "-" && inputKey != "*" && inputKey != "/" && inputKey != "\r")
        {
            if (double.TryParse(inputKey, out double cleanNum1))
            {
                numInput = numInput + inputKey;
                Console.Write(inputKey);
            }
            else if (inputKey == "\b")
            {
                numInput = numInput.Remove(numInput.Length - 1);
                Console.Write("\b \b");
            }
            else if (inputKey == "\e") {
                return ("", "", true);
            }
            inputKey = Convert.ToString(Console.ReadKey(true).KeyChar);
        }
        return (numInput, inputKey, false);
    }
    static void Main(string[] args)
    {
        bool endApp = false;
        // Display title as the C# console calculator app.
        Console.WriteLine("Console Calculator in C#\r");
       // Console.WriteLine("Press ESCAPE to close the app\r");
        Console.WriteLine("------------------------\n");
        Calculator calculator = new Calculator();

        double finalNum1 = 0;
        double finalNum2 = 0;
        string? op = "";
        string? op2 = "";

        while (!endApp)
        {
            double result = 0;
            if(op == "\r" | op == "")
            {
                var getInputResult = getInput(); 
                if (getInputResult.Item3) break;
                op = getInputResult.Item2;
                if (getInputResult.Item1 != "") finalNum1 = Convert.ToDouble(getInputResult.Item1);
            }

            if (op != "\r")
            {
                Console.Write(" {0} ", op);
                var getInputResult = getInput();
                if (getInputResult.Item3) break;
                if (getInputResult.Item1 != "") finalNum2 = Convert.ToDouble(getInputResult.Item1);
                op2 = getInputResult.Item2;
            }
            else op = "+";
            try
            {
                result = calculator.DoOperation(finalNum1, finalNum2, op);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("\nThis operation will result in a mathematical error.\n");
                }
                else
                {
                    //Console.Write(new String(' ', Console.BufferWidth));
                    Console.Write("\n= {0:0.##}\n", result);
                    finalNum1 = result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
            }
            if (op2 != "\r")
            {
                op = op2;
            }
            else op = "";

            //if (Console.ReadKey(true).Key == ConsoleKey.Escape) endApp = true;
        }
        Console.WriteLine("\n"); // Friendly linespacing.
        calculator.Finish();
        return;
    }
}