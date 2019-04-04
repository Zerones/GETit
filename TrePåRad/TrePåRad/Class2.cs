using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrePåRad
{
    class Input
    {
        public static int SpillerTrekk()
        {
            string trekk = Console.ReadLine();
            if(trekk.Length < 2)
            {
                return -1;
            }
            string nummer = trekk.Substring(1, 1);
            bool isNumeric = int.TryParse(nummer, out int n);
            if (trekk.Contains("X") || trekk.Contains("x") && isNumeric == true)
            {
                int tall = Int32.Parse(nummer) - 1;
                return tall;
            }
            else return -1;
        }
    }
}
