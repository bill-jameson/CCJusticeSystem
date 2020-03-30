using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace cjisAPI {
  public class DataCommand {
    SqlConnection Connection;
    string Sql;
    SqlCommand sqlCommand;

    public DataCommand(string sql, CommandType commandType = CommandType.StoredProcedure) {
      Sql = sql;
      string connectionString = Environment.GetEnvironmentVariable("CJIS_API_CONNECTION_STRING");
      Connection = new SqlConnection(connectionString);
      Connection.Open();
      sqlCommand = new SqlCommand(Sql, Connection);
      sqlCommand.CommandType = commandType;
    }

    public DataReader ExecuteReader() {
      DataReader dataReader = new DataReader(sqlCommand.ExecuteReader());
      return dataReader;
    }

    public void Close() {
      Connection.Close();
    }

    internal void AddParameter(string paramName, object paramValue) {
      sqlCommand.Parameters.Add(new SqlParameter(paramName, paramValue));
    }
  }
}
