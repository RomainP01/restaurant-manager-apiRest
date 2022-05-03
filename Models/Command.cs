using System;
using System.Data;
using System.Threading.Tasks;
using APIRestDotNet.Utils;
using MySqlConnector;

namespace APIRestDotNet
{
    public class Command
    {
        public int Id { get; set; }
        public DateTime CommandDate { get; set; }
        public int CommandTable { get; set; }

        public int IdStarter { get; set; }
        public int IdMeal { get; set; }
        public int IdDessert { get; set; }
        public int IdDrink { get; set; }

        public string StateStarter { get; set; }
        public string StateMeal { get; set; }
        public string StateDessert { get; set; }
        public string StateDrink { get; set; }
        internal AppDb Db { get; set; }

        public Command()
        {
        }

        internal Command(AppDb db)
        {
            Db = db;
        }

        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText =
                @"INSERT INTO `command` (`commandDate`, `commandTable`, `idStarter`, `idMeal`, `idDessert`, `idDrink`, `stateStarter`, `stateMeal`, `stateDessert`, `stateDrink`) VALUES (@commandDate, @commandTable, @idStarter, @idMeal, @idDessert, @idDrink, @stateStarter, @stateMeal, @stateDessert, @stateDrink);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText =
                @"UPDATE `command` SET `commandDate` = @commandDate, `commandTable` = @commandTable, `idStarter` = @idStarter, `idMeal` = @idMeal, `idDessert` = @idDessert, `idDrink` = @idDrink , `stateStarter` = @stateStarter, `stateMeal` = @stateMeal, `stateDessert` = @stateDessert , `stateDrink` = @stateDrink WHERE `id` = @id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `command` WHERE `id` = @id;";
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
                ParameterName = "@commandDate",
                DbType = DbType.DateTime,
                Value = CommandDate,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@commandTable",
                DbType = DbType.Int32,
                Value = CommandTable,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@idStarter",
                DbType = DbType.Int32,
                Value = IdStarter,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@idMeal",
                DbType = DbType.Int32,
                Value = IdMeal,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@idDessert",
                DbType = DbType.Int32,
                Value = IdDessert,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@idDrink",
                DbType = DbType.Int32,
                Value = IdDrink,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@stateStarter",
                DbType = DbType.String,
                Value = StateStarter,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@stateMeal",
                DbType = DbType.Int32,
                Value = StateMeal,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@stateDessert",
                DbType = DbType.Int32,
                Value = StateDessert,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@stateDrink",
                DbType = DbType.Int32,
                Value = StateDrink,
            });
        }
    }
}