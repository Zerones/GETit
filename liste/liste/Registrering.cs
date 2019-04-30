using System;

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

        public void Regi(string[] line)
        {
            if (Int32.TryParse(line[0], out int result))
            {
                StartNumber = result;
            }
            else StartNumber = -1;
            Name = line[1];
            if (string.IsNullOrEmpty(line[2])) Club = "No Registered Club";
            else Club = line[2];
            Nationality = line[3];
            Group = line[4];
            Class = line[5];

        }
    }
}
