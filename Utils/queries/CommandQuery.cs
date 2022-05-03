using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;

namespace APIRestDotNet.Utils
{
    public class CommandQuery
    {
        public AppDb Db { get; }

        public CommandQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Command> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `commandDate`, `commandTable`, `idStarter`, `idMeal`, `idDessert`, `idDrink`, `stateStarter`, `stateMeal`, `stateDessert`, `stateDrink` FROM `command` WHERE `id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }
        
        public async Task<List<Command>> GetAllCommandsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `commandDate`, `commandTable`, `idStarter`, `idMeal`, `idDessert`, `idDrink`, `stateStarter`, `stateMeal`, `stateDessert`, `stateDrink` FROM `command` ORDER BY `id`;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }
        
        public async Task DeleteAllAsync()
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `command`";
            await cmd.ExecuteNonQueryAsync();
            await txn.CommitAsync();
        }

        private async Task<List<Command>> ReadAllAsync(DbDataReader reader)
        {
            var commands = new List<Command>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var command = new Command(Db)
                    {
                        Id = reader.GetInt32(0),
                        CommandDate = reader.GetDateTime(1),
                        CommandTable = reader.GetInt32(2),
                        IdStarter = reader.GetInt32(3),
                        IdMeal = reader.GetInt32(4),
                        IdDessert = reader.GetInt32(5),
                        IdDrink = reader.GetInt32(6),
                        StateStarter = reader.GetString(7),
                        StateMeal = reader.GetString(8),
                        StateDessert = reader.GetString(9),
                        StateDrink = reader.GetString(10),
                        
                    };
                    commands.Add(command);
                }
            }
            return commands;
        }
    }
}
