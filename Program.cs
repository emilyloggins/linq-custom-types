using System;
using System.Collections.Generic;
using System.Linq;

namespace custom_types
{
    class Program
    {
        static void Main(string[] args)
        {
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

            // Build a collection of costumers who are millionaires

            // LAMBDA syntax
            // IEnumerable<Customer> MillionaresClub = customers.Where(customer => customer.Balance >= 1000000);

            // Query syntax
            IEnumerable<Customer> MillionaresClub = from customer in customers
                where customer.Balance >= 1000000
                select customer;

            // Check to make sure everyone's in the club
            Console.WriteLine("This is the Millionares Club:");
            foreach (Customer c in MillionaresClub)
            {
                Console.WriteLine(c.Name);
            }

            // display how many millionaires per bank.
            // LABMDA SYNTAX
            IEnumerable<IGrouping<String,Customer>> MillionaresPerBank = MillionaresClub.GroupBy(c => c.Bank);

            // QUERY SYNTAX
            // IEnumerable<IGrouping<String,Customer>> MillionaresPerBank = from millionare in MillionaresClub
            //     group millionare by millionare.Bank into bankGroup
            //     select bankGroup;

            // Check to make sure all the banks and millionaires are there
            Console.WriteLine("Number of millionaires per bank:");
            foreach (IGrouping<String, Customer> m in MillionaresPerBank)
            {
                Console.WriteLine($"{m.Key} {m.Count()}");
            }
        }
    }
}
