using System;

namespace ConsoleApp1
{
    class Program
    {
      
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ConstReadonlyDeneme obj = new ConstReadonlyDeneme(15);
            Console.WriteLine(obj.readonlyA);
            ConstReadonlyDeneme obj1 = new ConstReadonlyDeneme(20);


        }
    }
}
