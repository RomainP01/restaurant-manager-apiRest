using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;

namespace APIRestDotNet.Utils
{
    public class DrinkQuery
    {
        public AppDb Db { get; }

        public DrinkQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Drink> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `label` FROM `drink` WHERE `id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }
        
        public async Task<List<Drink>> GetAllDrinksAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `label` FROM `drink` ORDER BY `id`;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }
        
        public async Task DeleteAllAsync()
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `drink`";
            await cmd.ExecuteNonQueryAsync();
            await txn.CommitAsync();
        }

        private async Task<List<Drink>> ReadAllAsync(DbDataReader reader)
        {
            var drinks = new List<Drink>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var drink = new Drink(Db)
                    {
                        Id = reader.GetInt32(0),
                        Label = reader.GetString(1),
                    };
                    drinks.Add(drink);
                }
            }
            return drinks;
        }
    }
}