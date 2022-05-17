using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ConstReadonlyDeneme
    {
        public int a;
        public readonly int readonlyA;
        public const int constA=15;

        public ConstReadonlyDeneme(int sayi)
        {
            readonlyA = sayi;
        }
        public void Yazdir()
        {
            
            Console.WriteLine(a);
        }

        public void YazdirReadonly()
        {
            Console.WriteLine(readonlyA);
        }
    }
}
