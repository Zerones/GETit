using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace asyncSQL
{
    class AsyncResource
    {
        public async Task<IEnumerable<Person>> Create(SqlConnection connection, string name)
        {
            var content = $"INSERT INTO [Student] VALUES ('{name}')";
            return await connection.QueryAsync<Person>(content, new {Name = name});
        }

        public async Task<IEnumerable<Person>> Update(SqlConnection connection, string name, string newName)
        {
            var content = $"UPDATE [Student] SET [Name] = ('{newName}') WHERE [Name] = ('{name}') ";
            return await connection.QueryAsync<Person>(content, new { Name = name });
        }

        public async Task<IEnumerable<Person>> SelectAll(SqlConnection connection)
        {
            var content = "SELECT [Id],[Name] FROM [Student]";
            var persons = await connection.QueryAsync<Person>(content);
            return await connection.QueryAsync<Person>(content);
        }

        public async Task<IEnumerable<Person>> SelectPerson(SqlConnection connection, string name)
        {
            var content = @"SELECT Id, [Name] FROM [Student] WHERE upper(Name) = upper(@Name)";
            var person = await connection.QueryAsync<Person>(content, new {Name = name.Trim()});
            return person;
        }
    }
}
