using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace liste
{
    class Program
    {
        static void Main(string[] args)
        {
            var brukere = new List<Registrering>();
            var Klubber = new List<Club>();
            var resourceList = new StreamReader("startlist.csv", Encoding.UTF8);
            var liste = new List<string>();
            while(true)
            {
                var line = resourceList.ReadLine();
                if (line == null) break;
                liste.Add(line);
            }

            // noe av koden er litt kronglete fordi jeg brukte File.ReadAllLines før jeg senere byttet til StreamReader, 
            // etter at jeg fikk problemer med den og etter å ha sett på løsningsforslaget.

            foreach (string line in liste)
            {
                if (line.Length <= 0) continue;     // bare for å ungå blanke linjer eller liknede problemer, ligger litt igjen fra jeg brukte ReadAllLines.
                var bruker = new Registrering();
                bruker.LagBruker(line);             // Funksjon som legger til informasjonen/stringet til brukeren, burde kanskje ha brukt .Split, men det fungerte 
                                                    // sånn greit selv etter at jeg byttet til StreamReader. Ganske fornøyd egentlig at jeg slapp og skrive Registrering klassen
                                                    // om igjen, hvem vet hva slags spagetti bolognese det hadde blitt ;).
                brukere.Add(bruker);
            }

            if (Klubber.ToArray().Length == 0)      // Klumsete måte å få foreach løkkene under til å fungere, det er fra her + StreamReader vs. ReadAllLines som jeg
            {                                       // Ønsket tilbakemeldig på.
                var nyKlubb = new Club();
                nyKlubb.OpprettKlubb("", "Ingen Klubb Tilgjengelig:");
                Klubber.Add(nyKlubb);
            }

            foreach (var bruker in brukere)         // Siden jeg går igjennom to lister/array'er, så må jeg ha to løkker(?).
            {
                bool nyklubblos = false;
                foreach (var klubb in Klubber)
                {
                    if (bruker.Club == klubb.KlubNavn)  // Sammenlikner innholdet i stringene, å finne ut om en klubb har allerede blitt opprettet.
                    {
                        klubb.LeggTilMedlem(bruker.Name);
                        nyklubblos = true;
                        break;                          // Bryter løkka hvis brukeren er medlem og blitt lagt til klubb lista, ingen grunn til å kjøre gjennom hele lista hver gang. 
                    }
                    else if(bruker.Club == " ")     // Et forsøk på fjerne/filtrere bort de som ikke har en klubb, fungerte ikke helt...
                    {
                        nyklubblos = true;
                        break;
                    }
                }
                if(bruker.Club == " ")          // forsøk nummer 2 på å unngå lage/legge til medlemmer i en blank klubb. 
                {
                    nyklubblos = true;
                    continue;
                }
                if(nyklubblos == false)     // Lager en ny klubb hvis den ikke finner en match i klubb listen.
                {
                    var nyKlubb = new Club();
                    nyKlubb.OpprettKlubb(bruker.Name, bruker.Club);
                    Klubber.Add(nyKlubb);
                }
            }
            Club[] Club = Klubber.ToArray();       // Tilslutt valgte jeg en ganske "hack" metode for å unngå å vise frem den store klubben "           ". 
            for(var i = 3; i < Club.Length; i++)   // Kan hende at ' ' ikke er det riktige tegnet for de med ingen klubb, men at det heller er brukt tab || '   ' i lista...
            {
                Console.Write(Club[i].KlubNavn.Trim().Trim('"') + Environment.NewLine); // Jeg skrapa ReadAllLines og koden jeg hadde koblet til det, så da forsvant opprydningen i lista også,
                Console.WriteLine(Club[i].Medlemmer.Trim().Replace('"', ' '));          // Så for å gjøre det litt leselig mens jeg debugga, valgte jeg å legge det til her nede...
            }                                                                           // men nå er jeg for lat til å gjøre noe med det ;P.
            Console.ReadKey();
        }
    }
}
