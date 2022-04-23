using System.Data;
using System.Threading.Tasks;
using APIRestDotNet.Utils;
using MySqlConnector;

namespace APIRestDotNet
{
    public class Dish
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DishType { get; set; }

        public string DishStatus { get; set; }
        
        internal AppDb Db { get; set; }
        
        public Dish(){}

        internal Dish(AppDb db)
        {
            Db = db;
        }
        
        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `dish` (`name`, `dishType`, `dishStatus`) VALUES (@name, @dishType, @dishStatus);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `dish` SET `name` = @name, `dishType` = @dishType, `dishStatus` = @dishStatus  WHERE `id` = @id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `dish` WHERE `id` = @id;";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = Id,
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@name",
                DbType = DbType.String,
                Value = Name,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@dishType",
                DbType = DbType.String,
                Value = DishType,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@dishStatus",
                DbType = DbType.String,
                Value = DishStatus,
            });
        }
    }
}