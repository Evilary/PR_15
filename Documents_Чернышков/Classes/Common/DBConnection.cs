using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documents_Чернышков.Classes.Common
{
    public class DBConnection
    {

        public static readonly string Path = @"";

        public static OleDbConnection Connection()
        {
            OleDbConnection oleDbConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Database.accdb");

            oleDbConnection.Open();

            return oleDbConnection;

        }

        public static OleDbDataReader Query(string Query, OleDbConnection Connection)
        {
            return new OleDbCommand(Query, Connection).ExecuteReader();
        }

        public static void CloseConnection(OleDbConnection Connection) {
        
            Connection.Close();
        
        }
    }
}
