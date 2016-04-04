using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _50EfficientWay
{
    namespace first
    {
        public class B2 { }
        public class D2 : B2 { }

        public class B
        {
            public void Foo(D2 parm)
            {
                Console.WriteLine("In B.Foo");
            }
            public B ShallowCopy()
            {
                return (B)this.MemberwiseClone();
            }
        }

        public class D : B
        {
        }
    }

    namespace second
    {
        public class B2 { }
        public class D2 : B2 { }

        public class B
        {
            public void Foo(D2 parm)
            {
                Console.WriteLine("In B.Foo");
            }           
        }

        public class D : B
        {
            public void Foo(B2 parm)
            {
                Console.WriteLine("In D.Foo");
            }
        }
    }

    namespace third
    {
        public class B2 { }
        public class D2 : B2 { }

        public class B
        {
            public void Foo(D2 parm)
            {
                Console.WriteLine("In B.Foo");
            }
            public void Bar(B2 parm)
            {
                Console.WriteLine("In B.Bar");
            }
        }

        public class D : B
        {
            public void Foo(B2 parm)
            {
                Console.WriteLine("In D.Foo");
            }
        }
    }

    namespace third_ol
    {
        public class B2 { }
        public class D2 : B2 { }

        public class B
        {
            public void Foo(D2 parm)
            {
                Console.WriteLine("In B.Foo");
            }
            public void Bar(B2 parm)
            {
                Console.WriteLine("In B.Bar");
            }
        }

        public class D : B
        {
            public void Foo(B2 parm)
            {
                Console.WriteLine("In D.Foo");
            }

            public void Bar(B2 parm1, B2 parm2 = null)
            {
                Console.WriteLine("In D.Bar");
            }
        }
    }

    namespace fourth
    {
        public class B2 { }
        public class D2 : B2 { }

        public class B
        {
            public void Foo(D2 parm)
            {
                Console.WriteLine("In B.Foo");
            }
            public void Bar(B2 parm)
            {
                Console.WriteLine("In B.Bar");
            }

            public void Foo2(IEnumerable<D2> parm)
            {
                Console.WriteLine("In B.Foo2");
            }
        }

        public class D : B
        {
            public void Foo(B2 parm)
            {
                Console.WriteLine("In D.Foo");
            }

            public void Bar(B2 parm1, B2 parm2 = null)
            {
                Console.WriteLine("In D.Bar");
            } 
        }
    }


    namespace fourth_ol
    {
        public class B2 { }
        public class D2 : B2 { }

        public class B
        {
            public void Foo(D2 parm)
            {
                Console.WriteLine("In B.Foo");
            }
            public void Bar(B2 parm)
            {
                Console.WriteLine("In B.Bar");
            }

            public void Foo2(IEnumerable<D2> parm)
            {
                Console.WriteLine("In B.Foo2");
            }
        }

        public class D : B
        {
            public void Foo(B2 parm)
            {
                Console.WriteLine("In D.Foo");
            }

            public void Bar(B2 parm1, B2 parm2 = null)
            {
                Console.WriteLine("In D.Bar");
            }
            public void Foo2(IEnumerable<B2> parm)
            {
                Console.WriteLine("AsB2 - In D.Foo2");
            }
        }
    }
}
