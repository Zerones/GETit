using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;


namespace asyncSQL
{
    class Program
    {
        public static void Main(string[] args)
        {
            UserInterface();
            Console.ReadLine();
        }
        public static void UserInterface()
        {
            Console.WriteLine("===============================================================================");
            Console.WriteLine("|Welcome to this SQL database basic modification program, you can use commands|");
            Console.WriteLine("|to change, bring up and even create new user in the database                 |");
            Console.WriteLine("|The current commands are select, select {user}, create and update {user}     |");
            Console.WriteLine("===============================================================================");
            Thread.Sleep(3000);
            while (true)
            {
                Console.Clear();
                Console.Write("Please input a command:");
                var text = Console.ReadLine();
                if (!string.IsNullOrEmpty(text))
                {
                    var input = text.Split(' ');
                    if (input.Length > 0)
                    {
                        OpenConnectionAsync(input).Wait();
                        break;
                    }
                    if (text.ToLower() == "select")
                    {
                        OpenConnectionAsync(new string[] {"select"}).Wait();
                        break;
                    }
                }
                Console.Write(Environment.NewLine);
            }
        }

        public static async Task OpenConnectionAsync(string[] commando)
        {
            var connectionPath = ConfigurationManager.ConnectionStrings["minSQL"].ConnectionString;
            var connection = new SqlConnection(connectionPath);
            var syncSources = new AsyncResource();
            if (commando.Length > 1)
            {
                var name = NameCompiler(commando);
                switch (commando[0].ToLower())
                {
                    case "select":
                        SelectUser(await syncSources.SelectPerson(connection,
                            name));
                        break;
                    case "update":
                        Console.Write($"Please input the Username you wish to change {name} to:");
                        UpdateUser(await syncSources.Update(connection,
                            name,
                            Console.ReadLine()));
                        break;
                    case "create":
                        await syncSources.Create(connection,
                            name);
                        break;
                    case "delete":
                        Console.WriteLine("Not yet implemented ;)");
                        break;
                }
            }
            else if (commando[0].ToLower() == "select")
            {
                SelectAll(await syncSources.SelectAll(connection));
            }
            else
            {
                Console.WriteLine("Invalid command please try again..");
                Thread.Sleep(2000);
                UserInterface();
            }
        }

        public static string NameCompiler(string[] wholeName)
        {
            var name = "";
            for (var i = 1; i < wholeName.Length; i++)
            {
                name += " " + wholeName[i];
            }

            return name;
        }

        public static void UpdateUser(IEnumerable<Person> user)
        {
            var list = new List<Person>();
            Reader(list);
        }

        public static void SelectUser(IEnumerable<Person> users)
        {
            if (!users.Any()) return;
            var list = new List<Person> {users.First()};
            Reader(list);
        }

        public static void SelectAll(IEnumerable<Person> allUsers)
        {
            var list = new List<Person>();
            list.AddRange(allUsers);
            Reader(list);
        }

        public static void Reader(List<Person> list)
        {
            foreach (var person in list)
            {
                Console.Write(person.Id + " " + person.Name + Environment.NewLine);
            }
        }
    }
}
