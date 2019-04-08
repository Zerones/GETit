using System;

namespace TrePåRad
{
    class Boks
    {
        public static void Show()
        {
            string[] map = new string[0];
            map = NewBoard();
            string boks = BoksForm(map);
            bool turn = false;
            int tidsrom = 0;
            Console.Write(boks);
            Console.Write(Environment.NewLine + "Skriv inn hvor du vil sette kryss (f.eks. \"x2\"): ");
            bool spillerVant = false; 
            while (turn == false)
            {
                tidsrom++;
                int inputt = Input.SpillerTrekk();
                if (inputt == -1 || inputt > map.Length || map[inputt] == "O" || map[inputt] == "X")
                {
                    Console.WriteLine("Invalid input, try again!");
                    continue;
                }
                else map[inputt] = "X";
                boks = BoksForm(map);
                Console.WriteLine(boks);
                if (Vinner(map) == true)
                {
                    spillerVant = true;
                    break;
                }
                int cpuTrekk = Input.PcTrekk(map);
                map[cpuTrekk] = "O";
                boks = BoksForm(map);
                Console.WriteLine(boks);
                if (Tapper(map) == true)
                {
                    break;
                }
            }
            if (spillerVant == true)
            {
                Console.WriteLine(Environment.NewLine + "Gratulerer du vant!!!");
                Console.ReadKey();
            }
            else Console.WriteLine(Environment.NewLine + "Du tapte!!!");
        }

        public static bool Tapper(string[] map)
        {
            string[] bord = map;
            if (bord[0] == "O" && bord[1] == "O" && bord[2] == "O") return true;
            else if (bord[3] == "O" && bord[4] == "O" && bord[5] == "O") return true;
            else if (bord[0] == "O" && bord[3] == "O" && bord[6] == "O") return true;
            else if (bord[0] == "O" && bord[4] == "O" && bord[8] == "O") return true;
            else if (bord[6] == "O" && bord[4] == "O" && bord[2] == "O") return true;
            else if (bord[1] == "O" && bord[4] == "O" && bord[7] == "O") return true;
            else if (bord[2] == "O" && bord[5] == "O" && bord[8] == "O") return true;
            else if (bord[6] == "O" && bord[7] == "O" && bord[8] == "O") return true;
            else return false;
        }


        public static bool Vinner(string[] map)
        {
            string[] bord = map;
            if (bord[0] == "X" && bord[1] == "X" && bord[2] == "X") return true;
            else if (bord[3] == "X" && bord[4] == "X" && bord[5] == "X") return true;
            else if (bord[0] == "X" && bord[3] == "X" && bord[6] == "X") return true;
            else if (bord[0] == "X" && bord[4] == "X" && bord[8] == "X") return true;
            else if (bord[6] == "X" && bord[4] == "X" && bord[2] == "X") return true;
            else if (bord[1] == "X" && bord[4] == "X" && bord[7] == "X") return true;
            else if (bord[2] == "X" && bord[5] == "X" && bord[8] == "X") return true;
            else if (bord[6] == "X" && bord[7] == "X" && bord[8] == "X") return true;
            else return false;
        }

        public static string BoksForm(string[] map)
        {
            string[] verdi = map;
            string boks =
                  "_____________" + Environment.NewLine +
                  "| " + verdi[0] + " | " + verdi[1] + " | " + verdi[2] + " |" + Environment.NewLine +
                  "| " + verdi[3] + " | " + verdi[4] + " | " + verdi[5] + " |" + Environment.NewLine +
                  "| " + verdi[6] + " | " + verdi[7] + " | " + verdi[8] + " |" + Environment.NewLine +
                  "-------------";
            return boks;
        }

        public static string[] NewBoard()
        {
            string[] model = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " };
            return model;
        }
    }
}
