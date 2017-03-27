using System;
using System.Linq;

namespace ttanks.ef.dbf_1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new exampleEntities())
            {
                var allCustomer = context.Customer.ToList();

                allCustomer.ForEach(f =>
                {
                    Console.WriteLine($"{f.FirstName} {f.LastName}");
                });

                Console.WriteLine($"There are {allCustomer.Count} customers!");
            }

            Console.ReadLine();
        }
    }
}
