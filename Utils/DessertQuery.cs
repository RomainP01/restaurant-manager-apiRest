using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;

namespace APIRestDotNet.Utils
{
    public class DessertQuery
    {
        public AppDb Db { get; }

        public DessertQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Dessert> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `label` FROM `dessert` WHERE `id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }
        
        public async Task<List<Dessert>> GetAllDessertsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `label` FROM `dessert` ORDER BY `id`;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }
        
        public async Task DeleteAllAsync()
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `dessert`";
            await cmd.ExecuteNonQueryAsync();
            await txn.CommitAsync();
        }

        private async Task<List<Dessert>> ReadAllAsync(DbDataReader reader)
        {
            var desserts = new List<Dessert>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var dessert = new Dessert(Db)
                    {
                        Id = reader.GetInt32(0),
                        Label = reader.GetString(1),
                    };
                    desserts.Add(dessert);
                }
            }
            return desserts;
        }
    }
}