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
    SqlCommand command;

    public DataCommand(string sql, CommandType commandType = CommandType.Text) {
      //Sql = sql;
      //string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
      //Connection = new SqlConnection(connectionString);
      //Connection.Open();
      command = new SqlCommand(Sql, Connection);
      //command.CommandType = commandType;
    }

    public SqlDataReader ExecuteReader() {
      return command.ExecuteReader();
    }

    //public void Close() {
    //  Connection.Close();
    //}

    //internal void AddParameter(string paramName, object paramValue) {
    //  command.Parameters.Add(new SqlParameter(paramName, paramValue));
    //}
  }
}
