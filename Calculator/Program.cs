class Program()
{
    static readonly string[] operations = ["Add", "Subtract", "Multiply", "Divide"];

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
       
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Add");
        Console.ResetColor();
        Console.WriteLine("Subtract");
        Console.WriteLine("Multiply");
        Console.WriteLine("Divide");

        // string selectedOption = Console.ReadLine();
        int maxIndex = Console.CursorTop;
        int minIndex = Console.CursorTop - 4;
        int currentIndex = minIndex;
        int relativeIndex = 0;
        Console.SetCursorPosition(0, currentIndex);

        ConsoleKeyInfo readKey = Console.ReadKey();
        while (readKey.Key != ConsoleKey.Escape && readKey.Key != ConsoleKey.Enter)
        {
            Console.Write(operations[relativeIndex]);

            switch (readKey.Key)
            {
                case ConsoleKey.UpArrow:
                    if (currentIndex > minIndex)
                    {
                        currentIndex--;
                        relativeIndex--;
                    }

                    UpdateOperationList(currentIndex, relativeIndex);
                    break;
                case ConsoleKey.DownArrow:
                    if (currentIndex + 1 < maxIndex)
                    {
                        currentIndex++;
                        relativeIndex++;
                    }

                    UpdateOperationList(currentIndex, relativeIndex);
                    break;
                default:
                    Console.SetCursorPosition(0, relativeIndex);
                    break;
            }

            readKey = Console.ReadKey();
        }
    }

    static void UpdateOperationList(int currentIndex, int relativeIndex)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(0, currentIndex);
        Console.Write($"{operations[relativeIndex]}");

        Console.ResetColor();

        Console.SetCursorPosition(0, currentIndex);
    }

    static bool IsValidDecimal(string numberString, out decimal number)
    {
        return decimal.TryParse(numberString, out number);
    }
}