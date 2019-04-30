using System.Collections.Generic;

namespace liste
{
    class Club
    {
        public List<Registrering> Members { get; }
        public string Name { get; }
        
        public  Club()
        {
             Members = new List<Registrering>();
        }
        public  Club(string navn) : this()
        {
            Name = navn;
        }
        public void addMember(Registrering registering)
        {
            Members.Add(registering);
        }
    }
}


