using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace liste
{
    class Program
    {
        static void Main(string[] args)
        {
            var registering = new List<Registrering>();
            var resourceList = new StreamReader("startlist.csv", Encoding.UTF8);
            while(true)
            {
                var line = resourceList.ReadLine();
                if (line == null) break;
                var deltelinje = line.Split(',').Select(n => n.Trim('"')).ToArray();
                var personInfo = new Registrering();
                personInfo.Regi(deltelinje);
                registering.Add(personInfo);
            }
            var ClubList = new List<Club>();
            int count = 0;
            foreach(var person in registering)
            {
                var club = new Club(person.Club);
                if (count == 0)
                {
                    club.addMember(person);
                    ClubList.Add(club);
                    count++;
                    continue;
                }
                for (var i = 0; i < ClubList.ToArray().Length; i++)
                {
                    if (ClubList[i].Name == person.Club)
                    {
                        ClubList[i].addMember(person);
                        break;
                    }
                    else if (person.Club.ToString() == "No Registered Club")
                    {
                        break;
                    } else
                    {
                        club.addMember(person);
                        ClubList.Add(club);
                        break;
                    }
                }
            }
            string process = "Processing";
            for (var i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Console.Clear();
                process += ".";
                Console.WriteLine(process);
            }
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Processing Completed, listing clubs:");
            Thread.Sleep(1000);
            foreach (var club in ClubList)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine(club.Name + ":");
                Console.WriteLine();
                foreach(var member in club.Members)
                {
                    Console.WriteLine(member.Name);
                    Thread.Sleep(50);
                }
                Thread.Sleep(500);
            }
            Console.WriteLine("-------------------------------------------------------------");
            Console.ReadKey();
        }
    }
}
