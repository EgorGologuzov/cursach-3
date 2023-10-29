using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.ComponentModel;

namespace Minesweeper
{
    static internal class DataBaseTool
    {
        static public OleDbConnection Connection;

        static public void OpenConnection()
        {
            Connection = new OleDbConnection(Properties.Resources.OleDbConnectionString);
            Connection.Open();
        }

        static public void CloseConnection()
        {
            Connection.Close();
        }

        /// <summary>
        /// SELECT UserName, Time, ModeName FROM (Records INNER JOIN HardMode ON Records.HardMode = HardMode.Id)
        /// </summary>
        /// <returns></returns>
        static public OleDbDataReader SelectRecords()
        {
            string query =
                $"SELECT UserName, [Time], ModeName " +
                $"FROM (Records INNER JOIN HardMode ON Records.HardMode = HardMode.Id) " +
                $"ORDER BY [Time]";
            OleDbCommand cmd = new OleDbCommand(query, Connection);
            return cmd.ExecuteReader();
        }
        /// <summary>
        /// SELECT UserName, Time, ModeName FROM (Records INNER JOIN HardMode ON Records.HardMode = HardMode.Id) WHERE ModeName = '{hardMode}'"
        /// </summary>
        /// <param name="hardMode"></param>
        /// <returns></returns>
        static public OleDbDataReader SelectRecords(string hardMode)
        {
            string query =
                $"SELECT UserName, Time, ModeName " +
                $"FROM (Records INNER JOIN HardMode ON Records.HardMode = HardMode.Id) " +
                $"WHERE ModeName = '{hardMode}' " +
                $"ORDER BY [Time]";
            OleDbCommand cmd = new OleDbCommand(query, Connection);
            return cmd.ExecuteReader();
        }
        /// <summary>
        /// INSERT INTO Records (UserName, Time, HardMode) VALUES ('{name}', {time}, {(byte)hardMode})
        /// </summary>
        /// <param name="name"></param>
        /// <param name="time"></param>
        /// <param name="hardMode"></param>
        static public void InsertRecord(string name, int time, HardMode hardMode)
        {
            OleDbCommand cmd = new OleDbCommand($"INSERT INTO Records (UserName, [Time], HardMode) VALUES ('{name}', {time}, {(byte)hardMode})", Connection);
            cmd.ExecuteNonQuery();
        }
    }
}
