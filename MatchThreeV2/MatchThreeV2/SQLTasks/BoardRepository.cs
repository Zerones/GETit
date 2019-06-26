using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using MatchThreeV2.Models;

namespace MatchThreeV2.SQLTasks
{
    class BoardRepository
    {
        private readonly SqlConnection _connection;

        public BoardRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<BoxObject>> FetchBoard()
        {
            const string sql = @"SELECT Id, [Between], Time FROM Board WHERE Id < 10";
            return await _connection.QueryAsync<BoxObject>(sql);
        }

        public async Task<IEnumerable<BoxObject>> FetchCounter()
        {
            const string sql = @"SELECT Id, [Between] FROM Board WHERE Id = 10";
            return await _connection.QueryAsync<BoxObject>(sql);
        }


        public async Task<int> UpdateBoard(string letter, int id)
        {
            var sql = $@"UPDATE Board SET [Between] = '{letter}' WHERE Id = {id}";
            return await _connection.ExecuteAsync(sql);
        }

        public async Task<int> UpdateCounter(string nextPlayer)
        {
            var sql = $@"UPDATE Board SET [Between] = '{nextPlayer}'  WHERE Id = 10";
            return await _connection.ExecuteAsync(sql);
        }
    }
}
