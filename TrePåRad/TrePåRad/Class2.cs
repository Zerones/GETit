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
            var trekk = Console.ReadLine();
            if (trekk != null && trekk.Length > 2) return -1;
            if (trekk == null) return -1;
            var nummer = trekk.Substring(1, 1);
            var isNumeric = int.TryParse(nummer, out var n);
            if (!trekk.ToLower().Contains("x") || !isNumeric) return -1;
            var tall = int.Parse(nummer) - 1;
            if (tall > -1)
                return tall;
            return -1;

        }
        public static int PcTrekk(string[] map)
        {
            int pctall = 0;
            bool randomer = false;
            while (true)
            {
                Random random = new Random();
                pctall = random.Next(0, 9);
                if (map[pctall] == " ")
                {
                    break;
                }
            }
            return pctall;
        }
    }
}
