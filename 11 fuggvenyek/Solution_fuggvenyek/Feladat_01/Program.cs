using IOlibrary;
int number1 = ExtendentConsole.ReadInteger("Kérek egy számot: ");
int number2 = ExtendentConsole.ReadInteger("Kérek egy másik számot: ");

int resultSum = Sum(number1, number2);
int resultSubtraction = Subtraction(number1, number2);
int resultMultiplication = Multiply(number1, number2);
double resultDivide = Divide(number1,number2);


Console.WriteLine($"{resultSum}; {resultSubtraction}; {resultMultiplication}; {resultDivide}") ;

int Sum(int number1, int number2) => number1 + number2;

int Subtraction(int number1, int number2) => number1 - number2;

int Multiply(int number1, int number2)  => number1 * number2;
double Divide(int number1, int number2) => number1 / (double)(number2);
