using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new String('-', 10));
            Console.WriteLine("---------------");
            stairCase();
            Console.ReadLine();
            Console.WriteLine("!3 = {0}", Factorial(3));
            Math.Sqrt(2);
            foreach (var i in GeneratePrimesParallel(100))
            {
                Console.Write("prime numbers {0}, ", i);
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------");

            Console.WriteLine("!{0} = {1}", 20, Factorial(20));
            //Console.WriteLine("!{0} = {1}", 21, Factorial(21));
            try
            {
                //Console.WriteLine("!{0} = {1}", short.MaxValue, Factorial(short.MaxValue));
            }
            catch { }

            Console.WriteLine("-----------------");
            orderSequenceBySquareValue();

            Console.WriteLine(new String('-', 50));
            printFizzBuzz();
            printPopStar();
            Console.ReadLine();
        }

        private static void orderSequenceBySquareValue()
        {
            var collection = Enumerable.Range(-5, 11)
                .Select(x => new { Original = x, Square = x * x })
                .OrderBy(x => x.Square)
                .ThenBy(x => x.Original);

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }
        }

        private static void printFizzBuzz()
        {
            Console.WriteLine(
                String.Join(
                "\t",
                Enumerable.Range(1, 100)
                .Select(n => n % 15 == 0 ? "FizzBuzz"
                        : n % 3 == 0 ? "Fizz"
                        : n % 5 == 0 ? "Buzz"
                        : n.ToString())
                )
            );
        }

        private static void stairCase()
        {
            Console.Out.WriteLine("Number of stairs: ");
            int N = Convert.ToInt32(Console.ReadLine());
            //for (int i = 0; i < N; i++)
            //    Console.WriteLine(new String('#', i + 1).PadLeft(N, ' '));    
            //Enumerable.Range(0, N).ToList().ForEach(i => Console.WriteLine(new String('#', i + 1).PadLeft(N, ' ')));
            Console.WriteLine(
                String.Join(
                    Environment.NewLine,
                    Enumerable.Range(0, N).Select(i => new String('#', i + 1).PadLeft(N, ' '))
                )
            );
        }

        public static void printPopStar()
        {
            foreach (var i in popStar(1, 100))
            {
                Console.Write("{0}{1} ", i, i != "100" ? "," : string.Empty);
            }
            Console.WriteLine();

        }

        private static IEnumerable<string> popStar(int number, int Length)
        {
            for (int i = 0; i < Length; i++)
            {
                string result = i.ToString();
                bool dividedBy5 = i % 5 == 0;
                bool dividedBy3 = i % 3 == 0;
                if (dividedBy5 && dividedBy3)
                {
                    result = "PopStar";
                }
                else
                {
                    result = dividedBy5 ? "Star" : result;
                    result = dividedBy3 ? "Pop" : result;
                }
                yield return result;
            }
        }

        public static long Factorial(int number)
        {
            checked
            {
                if (number < 0)
                {
                    throw new ArgumentException("Value must be > or = to 0");
                }
                return (number <= 1) ? 1 : number * Factorial(number - 1);
            }
        }

        public static List<int> GeneratePrimesParallel(int n)
        {
            var sqrt = (int)Math.Sqrt(n);
            var lowestPrimes = GeneratePrimes(sqrt);
            var highestPrimes = (Enumerable.Range(sqrt + 1, n - sqrt)
                                      .AsParallel()
                                      .Where(i => lowestPrimes.All(prime => i % prime != 0)));
            return lowestPrimes.Concat(highestPrimes).ToList();
        }

        public static List<int> GeneratePrimes(int n)
        {
            var primes = new List<int>();
            for (var i = 2; i <= n; i++)
            {
                var ok = true;
                foreach (var prime in primes)
                {
                    if (prime * prime > i)
                        break;
                    if (i % prime == 0)
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                    primes.Add(i);
            }
            return primes;
        }
    }
}
