using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;

namespace APIRestDotNet.Utils
{
    public class DishQuery
    {
        public AppDb Db { get; }

        public DishQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Dish> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `name`, `dishStatus`,`dishType` FROM `dish` WHERE `id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }
        
        public async Task<List<Dish>> GetAllDishesAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `name`, `dishType`, `dishStatus` FROM `dish` ORDER BY `id`;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }
        
        public async Task DeleteAllAsync()
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `dish`";
            await cmd.ExecuteNonQueryAsync();
            await txn.CommitAsync();
        }

        private async Task<List<Dish>> ReadAllAsync(DbDataReader reader)
        {
            var dishes = new List<Dish>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var dish = new Dish(Db)
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        DishStatus = reader.GetString(2),
                        DishType= reader.GetString(3),
                    };
                    dishes.Add(dish);
                }
            }
            return dishes;
        }
    }
}