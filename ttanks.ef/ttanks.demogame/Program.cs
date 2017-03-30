using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ttanks.demogame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press n for new player.");
            var cmd = Console.ReadLine();

            if (string.IsNullOrEmpty(cmd))
            {
                Console.WriteLine("No input insert!");
                Console.Read();
                return;
            }

            if (cmd.Equals("n", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("you press n!");
                Console.ReadLine();
            }

           
        }
    }
}
