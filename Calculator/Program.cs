class Program()
{
    static void Main(string[] args)
    {
        Calculator calculatorInstance = new Calculator();

        Console.WriteLine("Welcome to the calculator app. In this app you can compute 2 numbers together!\n");
        Console.Write("Please provide the first number: ");
        string string1 = Console.ReadLine();

        decimal number1;
        while (!IsValidDecimal(string1, out number1))
        {
            Console.Write($"{string1} is not a valid decimal. Please try again: ");
            string1 = Console.ReadLine();
        }

        Console.Write("Please provide the second number: ");
        string string2 = Console.ReadLine();

        decimal number2;
        while (!IsValidDecimal(string2, out number2))
        {
            Console.Write($"{string2} is not a valid integer. Please try again: ");
            string2 = Console.ReadLine();
        }

        Console.WriteLine("Please choose the operation you would like to perform:");
        // TODO: Set foreground color for add to green to signify the default selection
        /****
        * TODO: when DownArrow or UpArrow is pressed change foreground color to signify line
        */
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Add");
        Console.ResetColor();
        Console.WriteLine("Subtract");
        Console.WriteLine("Multiply");
        Console.WriteLine("Divide");

        // string selectedOption = Console.ReadLine();
        int maxIndex = Console.CursorTop;
        Console.WriteLine(maxIndex);
        int minIndex = Console.CursorTop - 4;
        int currentIndex = minIndex;
        string[] operations = ["Add", "Subtract", "Multiply", "Divide"];
        int relativeIndex = 0;
        Console.SetCursorPosition(0, currentIndex);

        ConsoleKeyInfo readKey = Console.ReadKey();
        while (readKey.Key != ConsoleKey.Escape && readKey.Key != ConsoleKey.Enter)
        {
            Console.WriteLine(operations[relativeIndex]);
            if (readKey.Key == ConsoleKey.DownArrow && currentIndex < maxIndex)
            {
                currentIndex += 1;
                relativeIndex += 1;
                // Console.Write(new string(' ', Console.WindowWidth));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{operations[relativeIndex]}");
            }
            else if (readKey.Key == ConsoleKey.UpArrow && currentIndex > minIndex)
            {
                currentIndex -= 1;
                relativeIndex -= 1;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{operations[relativeIndex]}");
            }
            Console.ResetColor();

            Console.SetCursorPosition(0, currentIndex);
            readKey = Console.ReadKey();
        }
        //     Console.SetCursorPosition(0, currentIndex);

        //     selectedText = $">>> {selectedOption} <<<";

        //     if ()
        //         Console.WriteLine($"You pressed: {keyInfo.Key}");
        //     keyInfo = Console.ReadKey();
        // }
    }

    static bool IsValidDecimal(string numberString, out decimal number)
    {
        return decimal.TryParse(numberString, out number);
    }
}