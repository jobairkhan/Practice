using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _50EfficientWay
{
    class Program
    {
        static void Main(string[] args)
        {
            object b = null;
            Console.WriteLine(b);
            /*Item32.Execute();
            item34();
            Item36.Execute();
            Item37.Execute();*/
            Item41.Execute();
            Console.ReadLine();
        }


        private static void item34()
        {
            Console.WriteLine("34");

            var obj1 = new first.D();
            obj1.Foo(new first.D2());
            Console.WriteLine("-------------obj1");

            var obj1_1 = new second.D();
            obj1_1.Foo(new second.D2());
            Console.WriteLine("-------------obj1_ol");


            var obj2 = new second.D();
            obj2.Foo(new second.D2());
            obj2.Foo(new second.B2());
            Console.WriteLine("-------------obj2");


            second.B obj3 = new second.D();
            obj3.Foo(new second.D2());
            Console.WriteLine("-------------obj3");
            var obj4 = new second.D();
            ((second.B)obj4).Foo(new second.D2());
            obj4.Foo(new second.B2());
            Console.WriteLine("-------------obj4");

            Console.WriteLine();
            nowAddBar();

            Console.WriteLine();
            enumerableMethods();
            
        }

        private static void nowAddBar()
        {
            Console.WriteLine();

            var obj1 = new third.D();
            obj1.Bar(new third.D2());
            Console.WriteLine("-----------BBar--obj1");

            var objOl1 = new third_ol.D();
            objOl1.Bar(new third_ol.D2());
            Console.WriteLine("-----------DBar--obj1_ol");


            third_ol.B objOl1B = new third_ol.D();
            objOl1B.Bar(new third_ol.D2());
            Console.WriteLine("-----------BBar--obj1_ol");
        }

        private static void enumerableMethods()
        {
            Console.WriteLine();
            var sequence = new List<fourth.D2> { new fourth.D2(), new fourth.D2() };
            var obj2 = new fourth.D();
            obj2.Foo2(sequence);
            Console.WriteLine("-------------sequence");

            var sequence_ol = new List<fourth_ol.B2> { new fourth_ol.B2(), new fourth_ol.B2() };
            var obj2_ol = new fourth_ol.D();
            obj2_ol.Foo2(sequence_ol);
            Console.WriteLine("-------------sequence ol");
        }

        
    }
}
