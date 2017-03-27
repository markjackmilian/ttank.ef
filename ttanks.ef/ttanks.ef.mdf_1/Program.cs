using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ttanks.ef.mdf_1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Model1Container())
            {
                context.StudentSet.Add(new Student
                {
                    Name = "pippo"
                });

                context.SaveChanges();
            }
        }
    }
}
