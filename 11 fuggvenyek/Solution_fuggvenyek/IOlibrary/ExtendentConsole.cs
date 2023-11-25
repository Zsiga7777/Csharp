namespace IOlibrary;

    public static class ExtendentConsole
    {
        public static int ReadInteger(string promt)
        {
            bool isNumber = false;
            int number = 0;
            do
            {
            Console.Write($"{promt}");
            string text = Console.ReadLine();
                isNumber = int.TryParse( text, out number );
            }
            while (!isNumber);

            return number;
        }

        public static int ReadInteger(int maximum, string promt)
            {
                bool isNumber = false;
                int number = 0;
                do
                {
            Console.Write($"{promt}");
                    string text = Console.ReadLine();
                    isNumber = int.TryParse(text, out number);
                    if(number > maximum)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A megadott szám nem lehet nagyobb, mint {maximum}");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"A folytatáshoz nyomja meg bármely gombot!");

                Console.ReadKey();
                Console.Clear();

                Console.ResetColor();
            }
                }
                while (!isNumber || number > maximum);

                return number;
            }

    public static int ReadInteger(int minimum, int maximum, string promt)
    {
        bool isNumber = false;
        int number = 0;
        do
        {
            Console.Write($"{promt}");
            string text = Console.ReadLine();
            isNumber = int.TryParse(text, out number);
        }
        while (!isNumber || number < minimum || number > maximum);

        return number;
    }



    public static double ReadDouble(string promt)
        {
            bool isNumber = false;
            double number = 0;
            do
            {
            Console.Write($"{promt}");
            string text = Console.ReadLine();
                isNumber = double.TryParse(text, new CultureInfo("en-EN"), out number);
            }
            while (!isNumber);

            return number;
        }

    public static double ReadDouble(double min,string promt)
    {
        bool isNumber = false;
        double number = 0;
        do
        {
            Console.Write($"{promt}");
            string text = Console.ReadLine();
            isNumber = double.TryParse(text, new CultureInfo("en-EN"), out number);
        }
        while (!isNumber || number < min);

        return number;
    }

    public static string ReadString(string promt)
    {
        string text = string.Empty;
        do
        {
            Console.Write($"{promt}");
            text = Console.ReadLine().Trim();
           
        }
        while (string.IsNullOrWhiteSpace(text));

        return text;
    }

}

