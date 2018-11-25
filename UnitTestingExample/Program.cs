using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingExample.business;
using UnitTestingExample.data;

namespace UnitTestingExample
{
    class Program
    {
        private static ResultService _resultService = new ResultService();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to example 1");
            Console.WriteLine("Enter nhi");
            var nhi = Console.ReadLine();
            Console.WriteLine("Enter amount");
            var amount = Console.ReadLine();

            var result = _resultService.CreateResult(nhi, amount);
            Console.WriteLine($"Result created with id of {result.id}");
            Console.ReadKey();
        }
    }
}
