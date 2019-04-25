using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liste
{
    class Club
    {
        public string Medlemmer { get; private set; }
        public string KlubNavn { get; private set; }
        public void OpprettKlubb(string bruker, string klubbnavn)
        {
            Medlemmer = bruker + Environment.NewLine;
            KlubNavn = klubbnavn;
        }
        public void LeggTilMedlem(string medlem)
        {
            Medlemmer += medlem + Environment.NewLine; 
        }
    }
}


//  Bare litt grønt her også, sånn at det ser ut som jeg så gjennom hele koden før jeg sender det til deg. 