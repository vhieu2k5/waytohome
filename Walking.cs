using System;

class Program
{
    static void Main()
    {
        string choice = Console.ReadLine();
        if (choice =="1")
        {
Console.WriteLine("nhap input: ");
int a = Convert.ToInt32(Console.ReadLine());
int b = Convert.ToInt32(Console.ReadLine());
     //   Console.WriteLine($"{a}, {b}");
        
        for(int i=0;i<a;i++)
        {
            for (int j = 0; j < b; j++)
            {
  Console.Write("*");
            }
            Console.WriteLine();
        }
        }
        else if( choice =="2")
        {
            Console.WriteLine("2");
            Console.Writeline("3");
            Console.Write("7");
        }

    }
}




