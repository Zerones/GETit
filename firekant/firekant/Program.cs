using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firekant
{
    class Program
    {
        static void Main(string[] args)
        {
            var lol = new VirtualScreenRow(9);
            for (int i = 0; i < 1; i++)
            {
                lol.Show();
            }
            Console.ReadKey();
        }
    }
}
