using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging.EventLog;
using System.Data.SqlClient;

namespace cjisAPI {
  public class Error {
    public string ApiError { get; set; }
    public string ErrorMessage { get; set; }

    public Error(string errorMessage) {
      ApiError = "An error occurred.";
      ErrorMessage = errorMessage;
    }

    public static object LogError(Exception e) {
      /*** write to database log table ***/
      DataCommand command = new DataCommand("spErrorLogInsert");
      command.AddParameter("@errorMessage", e.Message);
      var exceptiontype = e.GetType();
      command.AddParameter("@source", e.Source);
      command.AddParameter("@stackTrace", e.StackTrace);
      if (exceptiontype == typeof(SqlException)) {
        SqlException sqlException = (SqlException)e;
        command.AddParameter("@procedure", sqlException.Procedure);
        command.AddParameter("@server", sqlException.Server);
      }
      command.Execute();

      /*** write to log file ***/
      string logFilePath = Environment.GetEnvironmentVariable("CJIS_API_LOG_FILE_PATH");
      bool logFileExists = File.Exists(logFilePath);
      using (StreamWriter logFile = new StreamWriter(logFilePath/*, true*/)) {
        if (!logFileExists) logFile.WriteLine("LogDateTime\tMessage");
        logFile.WriteLine(DateTime.Now + "\t" + e.Message.Replace("\t", " ").Replace("\r", " ").Replace("\n", " "));
      }

      return new Error(e.Message);
    }
  }
}
