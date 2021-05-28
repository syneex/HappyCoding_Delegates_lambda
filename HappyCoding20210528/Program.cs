using System;
using System.Linq;

namespace HappyCoding20210528
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------ Flächenberechnung ------------------\n");
            // without delegates
            int x = 5;
            int result = BerechneQuadratFlaeche(x);
            Console.WriteLine(result);

            // with Func delegates
            x = 6;
            int y = 7;
            Func<int, int> quadratFlaeche = x => x * x;
            Func<int, int, int> rechteckFlaeche = (x, y) => x * y;
            Console.WriteLine("Quadratfläche: " + quadratFlaeche(x));
            Console.WriteLine("Rechteckfläche: " + rechteckFlaeche(x, y));

            Console.WriteLine("------------------ Action Delegate ------------------\n");
            // with Action delegates
            Action<string> outputParameter = param =>
            {
                string parameter = $"Der übergebene Parameter lautet: {param}";
                Console.WriteLine(parameter);
            };
            outputParameter("Happy Coding");

            Console.WriteLine("------------------ Predicate Delegate ------------------\n");

            Person[] personen =
            {
                new Person { Name = "Samuel", Age = 19 },
                new Person { Name = "Leonard", Age = 21 },
                new Person { Name = "Alexander", Age = 25 },
                new Person { Name = "Jonathan", Age = 18 },
                new Person { Name = "Christine", Age = 24 },
                new Person { Name = "Paul", Age = 16 }
            };

            Predicate<Person> prediactePerson = FindePersonenAelterAlsAchtzehn;
            Person[] personenAelterAlsAchtzehn = Array.FindAll(personen, prediactePerson);

            Console.WriteLine("Gefundene Personen:\n");

            foreach (Person person in personenAelterAlsAchtzehn)
            {
                Console.WriteLine($"Name: {person.Name}");
            }


            Console.WriteLine("------------------ Lambda / LINQ ------------------\n");
            personen = personen.Where(x => x.Age >= 18).ToArray();

            int[] zahlenArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] zahlenGerade = Array.FindAll(zahlenArray, x => x % 2 == 0);
            int[] zahlenUngerade = Array.FindAll(zahlenArray, x => x % 2 != 0);

            Console.WriteLine("Gerade Zahlen: " + string.Join(" ", zahlenGerade));
            Console.WriteLine("Ungerade Zahlen: " + string.Join(" ", zahlenUngerade));


            Console.WriteLine("------------------ Lambda Expression im Delegate Array ------------------\n");
            Func<int, int, int>[] berechnungen = new Func<int, int, int>[]
            {
                (x, y) => x + y,
                (x, y) => x - y,
                (x, y) => x * y,
                (x, y) => x / y,
            };

            Console.WriteLine("LEA-Addition: " + berechnungen[0](5, 5));
            Console.WriteLine("LEA-Substraktion: " + berechnungen[1](5, 5));
            Console.WriteLine("LEA-Multiplikation: " + berechnungen[2](5, 5));
            Console.WriteLine("LEA-Dividierung: " + berechnungen[3](5, 5));

            Calculations calc = new Calculations(Operations.Add);
            calc(5, 5);

            calc = new Calculations(Operations.Subtract);
            calc(10, 9);

            calc = new Calculations(Operations.Multiply);
            calc(10, 10);

            calc = new Calculations(Operations.Division);
            calc(10, 5);

            Console.ReadKey();
        }

        private delegate void Calculations(int x, int y);

        private static bool FindePersonenAelterAlsAchtzehn(Person person)
        {
            return person.Age >= 18;
        }

        static int BerechneQuadratFlaeche(int x)
        {
            int result = x * x;
            return result;
        }
    }
}
