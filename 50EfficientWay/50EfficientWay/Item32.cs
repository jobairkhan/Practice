using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _50EfficientWay
{
    public static class Item32
    {
        public static void Execute()
        {
            Console.WriteLine("32");
            string s1 = "Something";
            string s2 = (string)s1.Clone();
            if (s2 != "Something")
                Console.WriteLine("Not the same!");
            if (object.ReferenceEquals(s1, s2))
                Console.WriteLine("Reference not equal!");

        }
    }
}
