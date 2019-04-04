using System;

namespace TrePåRad
{
    class Boks
    {
        public static string test()
        {
            string[] verdi = innhold();
            string boks =
              "_____________" + Environment.NewLine +
              "| " + verdi[0] + " | " + verdi[1] + " | " + verdi[2] + " |" + Environment.NewLine +
              "| " + verdi[3] + " | " + verdi[4] + " | " + verdi[5] + " |" + Environment.NewLine +
              "| " + verdi[6] + " | " + verdi[7] + " | " + verdi[8] + " |" + Environment.NewLine +
              "-------------";
            return boks;
        }

        private static string[] innhold()
        {
            return new string[] {"X", "X", "X", "X", "X", "X", "X", "X", "X"};
        }
    }
}
