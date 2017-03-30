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
            try
            {
                TheGame.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }
    }
}
