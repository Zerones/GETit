using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MinSQL.TDbModel;

namespace MinSQL
{
    class Delete<TDbModel>
    {
        private readonly PropertyInfo[] _properties;

        public Delete()
        {
            var dbModelType = typeof(TDbModel);
            _properties = dbModelType.GetProperties();
        }
        public void DeleteUser(SqlConnection connection, string name, string path)
        {
            var sql = CreateSelectStringBuilder(name, path).ToString();
            ExecuteQuery(connection, sql);
        }

        private static void ExecuteQuery(SqlConnection connection, string sql)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                }
            }
        }
        private StringBuilder CreateSelectStringBuilder(string name, string path)
        {
            var sql = new StringBuilder();
            sql.Append(path);
            sql.Insert(0,"DELETE FROM ");
            sql.Append(" WHERE ");
            sql.Append($"[Name] = '{name}'");
            sql.Append(" ");
            return sql;
        }

    }
}
