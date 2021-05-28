using System;
using System.Collections.Generic;
using System.Text;

namespace HappyCoding20210528
{
    public class Operations
    {
        public static void Add(int x, int y)
        {
            Console.WriteLine($"{x} + {y} = {x + y}");
        }

        public static void Subtract(int x, int y)
        {
            Console.WriteLine($"{x} - {y} = {x - y}");
        }

        public static void Multiply(int x, int y)
        {
            Console.WriteLine($"{x} * {y} = {x * y}");
        }

        public static void Division(int x, int y)
        {
            Console.WriteLine($"{x} / {y} = {x / y}");
        }
    }
}
