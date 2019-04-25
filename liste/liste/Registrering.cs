using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liste
{
    class Registrering
    {
        public int StartNumber { get; private set; }
        public string Name { get; private set; }
        public string Club { get; private set; }
        public string Nationality { get; private set; }
        public string Group { get; private set; }
        public string Class { get; private set; }

        public void LagBruker(string line)
        {
            string[] info = line.Split(',');
            if(Int32.TryParse(info[0], out int result)) // Jeg stjal denne koden fra løsningsforslaget ditt, men gjorde den verre ved å kutte bort effektiviteten din :^)
            {
                StartNumber = result;
            }
            else
            {
                StartNumber = 0; 
            }
            Name = info[1];             // Igjen jeg burde ha brukt .Split istedenfor å lese rett av stringet som om det var et Array... 
            Club = info[2];
            Nationality = info[3];
            Group = info[4];
            Class = info[5];
        }
    }
}
