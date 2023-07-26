// See https://aka.ms/new-console-template for more information
using ChequeWriting;

ConsoleKeyInfo esc;
var input = "";
do
{
    Console.Write("Please input the cheque number: ");
    input = Console.ReadLine();

    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Please Input the number!");
    }
    else
    {
        ChequeToString chequeToString = new ChequeToString();
        var result = chequeToString.ChangeToString(input);
        Console.WriteLine(result);
    }

    Console.WriteLine("Prease key to continue or press esc to close the programs");
    esc = Console.ReadKey();
} while (esc.Key != ConsoleKey.Escape);

Environment.Exit(0);