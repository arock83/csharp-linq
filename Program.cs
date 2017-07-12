using System;
using System.Linq;
using System.Collections.Generic;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};

            var LFruits = from fruit in fruits where fruit.StartsWith("L") select fruit; 
            
            foreach(var n in LFruits)
            {
                Console.WriteLine(n);
            }


            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            var fourSixMultiples = numbers.Where(n => n % 4 == 0 || n % 6 == 0);

            foreach(var i in fourSixMultiples)
            {
                Console.WriteLine(i);
            }

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre" 
            };

            var descend = from name in names orderby name descending select name;

            foreach(var j in descend) 
            {
                Console.WriteLine(j);
            }


            // Build a collection of these numbers sorted in ascending order
            List<int> numbers2 = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            var ascendingNumbers = from num in numbers2 orderby num select num;

            foreach(var q in ascendingNumbers)
            {
                Console.WriteLine(q);
            }

            // Output how many numbers are in this list
            List<int> numbers3 = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            Console.WriteLine(numbers3.Count);

            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };

            Console.WriteLine(purchases.Sum());

            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };

            Console.WriteLine(prices.Max());

            /*
                Store each number in the following List until a perfect square
                is detected.

                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */
            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };

            IEnumerable<int> taken = wheresSquaredo.TakeWhile(p => Math.Sqrt(p) %1 != 0);

            foreach(var p in taken)
            {
                Console.WriteLine(p);
            }

            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };
            



            var millionaires = from cust in customers
                where cust.Balance >= 1000000
                select cust;
            foreach(var cust in millionaires)
            {
                Console.WriteLine($"{cust.Name} ${cust.Balance}");
            }

            var grouped = from mill in millionaires
                group mill by mill.Bank into taco
                select new { Bank = taco.Key, Count= taco.Count()};

            var groupedCombined = from cust in customers
                where cust.Balance >= 1000000
                group cust by cust.Bank into taco
                select new { Bank = taco.Key, Customers = taco};

            var groupedShort =  customers.Where(c => c.Balance >= 1000000)
                                .GroupBy(g => g.Bank);


            foreach (var potato in grouped)
            {
                Console.WriteLine($"{potato.Bank} - {potato.Count}");

            } 
            /* 
                Given the same customer set, display how many millionaires per bank.
                Ref: https://code.msdn.microsoft.com/LINQ-to-DataSets-Grouping-c62703ea

                Example Output:
                WF 2
                BOA 1
                FTB 1
                CITI 1
            */
            



            

        }
    }
    // Build a collection of customers who are millionaires
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }
}
