using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace MinSQL
{
    public class Insert<TDbModel>
    {
        private readonly PropertyInfo[] _properties;

        public Insert()
        {
            var dbModelType = typeof(TDbModel);
            _properties = dbModelType.GetProperties();
        }
        public void AddUser(SqlConnection connection, string name, string path)
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
            sql.Insert(0, "INSERT INTO ");
            sql.Append(" VALUES('");
            sql.Append(name + "')");
            sql.Append(" ");
            return sql;
        }
    }
}
