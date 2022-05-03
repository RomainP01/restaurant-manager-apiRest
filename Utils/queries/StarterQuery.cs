using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;

namespace APIRestDotNet.Utils
{
    public class StarterQuery
    {
        public AppDb Db { get; }

        public StarterQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Starter> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `label` FROM `starter` WHERE `id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }
        
        public async Task<List<Starter>> GetAllStartersAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `label` FROM `starter` ORDER BY `id`;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }
        
        public async Task DeleteAllAsync()
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `starter`";
            await cmd.ExecuteNonQueryAsync();
            await txn.CommitAsync();
        }

        private async Task<List<Starter>> ReadAllAsync(DbDataReader reader)
        {
            var starters = new List<Starter>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var starter = new Starter(Db)
                    {
                        Id = reader.GetInt32(0),
                        Label = reader.GetString(1),
                    };
                    starters.Add(starter);
                }
            }
            return starters;
        }
    }
}