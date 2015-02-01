using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bSeamless.DotNetProg.Ninject.V1.Runner
{
    public interface IFoo
    {
        void bar();
    }

    public class FooBase : IFoo
    {
        public virtual void bar()
        {
        }
    }

    public class Foo : FooBase
    {
        public virtual void bar()
        {
            Console.WriteLine("HI");
        }
    }
}
