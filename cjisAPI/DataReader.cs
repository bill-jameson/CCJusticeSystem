using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace cjisAPI {
  public class DataReader {
    SqlDataReader SqlReader;

    public DataReader(SqlDataReader sqlDataReader) {
      SqlReader = sqlDataReader;
    }

    public bool Read() {
      return SqlReader.Read();
    }

    public int? GetInteger(string columnName) {
      int columnIndex = SqlReader.GetOrdinal(columnName);
      return !SqlReader.IsDBNull(columnIndex) ? SqlReader.GetInt32(columnIndex) : (int?)null;
    }

    public string GetString(string columnName) {
      int columnIndex = SqlReader.GetOrdinal(columnName);
      return !SqlReader.IsDBNull(columnIndex) ? SqlReader.GetString(columnIndex) : null;
    }

    public bool? GetBoolean(string columnName) {
      int columnIndex = SqlReader.GetOrdinal(columnName);
      return !SqlReader.IsDBNull(columnIndex) ? SqlReader.GetBoolean(columnIndex) : (bool?)null;
    }
  }
}
