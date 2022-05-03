using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;

namespace APIRestDotNet.Utils
{
    public class MealQuery
    {
        public AppDb Db { get; }

        public MealQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Meal> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `label` FROM `meal` WHERE `id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }
        
        public async Task<List<Meal>> GetAllMealsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `label` FROM `meal` ORDER BY `id`;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }
        
        public async Task DeleteAllAsync()
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `meal`";
            await cmd.ExecuteNonQueryAsync();
            await txn.CommitAsync();
        }

        private async Task<List<Meal>> ReadAllAsync(DbDataReader reader)
        {
            var meals = new List<Meal>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var meal = new Meal(Db)
                    {
                        Id = reader.GetInt32(0),
                        Label = reader.GetString(1),
                    };
                    meals.Add(meal);
                }
            }
            return meals;
        }
    }
}