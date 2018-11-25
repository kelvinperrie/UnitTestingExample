﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingExample3.business;
using UnitTestingExample3.data;

namespace UnitTestingExample3
{
    class Program
    {
        private static ResultService _resultService = new ResultService(new ResultRepository());

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to example 2");
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
