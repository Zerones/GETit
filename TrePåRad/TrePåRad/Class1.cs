using System;

namespace TrePåRad
{
    class Boks
    {
        public static void Show()
        {
            bool lo = false;
            while(lo == false)
            {
                Console.WriteLine(BoksForm());
            }
        }

        public static string BoksForm()
        {
            string[] verdi = BoardModel();
            string boks =
                  "_____________" + Environment.NewLine +
                  "| " + verdi[0] + " | " + verdi[1] + " | " + verdi[2] + " |" + Environment.NewLine +
                  "| " + verdi[3] + " | " + verdi[4] + " | " + verdi[5] + " |" + Environment.NewLine +
                  "| " + verdi[6] + " | " + verdi[7] + " | " + verdi[8] + " |" + Environment.NewLine +
                  "-------------";
            return boks;
        }

        public static string[] BoardModel()
        {
            string[] model = new string[] {"","","","","","","","",""};
            int inputt = Input.SpillerTrekk();
            for(int i = 0; i < 9; i++)
            {
                if(i == inputt)
                {
                    model[i] = "X";
                }
                else
                {
                    model[i] = " ";
                }
            }
            return model; 
        }
    }
}
