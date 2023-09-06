using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeTeste
{
    

    class Program
    {
        static void Main(string[] args)
        {
            //new FileComposite().Execute();

            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine();

            new EmployeeComposite().Execute();
        }
    }
}
