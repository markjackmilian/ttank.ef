using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ttanks.dbf_2_cf
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Model1())
            {
                context.Customer.Add(new Customer
                {
                    FirstName = "Marco",
                    LastName = "Milani",
                    City = "Prato",
                    Country = "Italia",
                    Phone = "123"

                });

                context.SaveChanges();
            }
        }
    }
}
