using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging.EventLog;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using cjisAPI.Controllers;

namespace cjisAPI {
  public class Error {
    public string ApiError { get; set; }
    public string ErrorMessage { get; set; }

    public Error(string errorMessage) {
      ApiError = "An error occurred.";
      ErrorMessage = errorMessage;
    }

    public static object LogError(ILogger logger, Exception e, bool logToDatabase = true, bool logToFile = true) {
      Type exceptiontype;
      /*** write to database log table ***/
      if (logToDatabase) {
        try {
          DataCommand command = new DataCommand("spErrorLogInsert");
          command.AddParameter("@errorMessage", e.Message);
          command.AddParameter("@source", e.Source);
          command.AddParameter("@stackTrace", e.StackTrace);
          exceptiontype = e.GetType();
          if (exceptiontype == typeof(SqlException)) {
            SqlException sqlException = (SqlException)e;
            command.AddParameter("@procedure", sqlException.Procedure);
            command.AddParameter("@server", sqlException.Server);
          }
          command.Execute();
        } catch (Exception sqlException) {
          LogError(logger, sqlException, false, false);
        }
      }

      /*** write to log file ***/
      if (logToDatabase) {
        try {
          string logFilePath = Environment.GetEnvironmentVariable("CJIS_API_LOG_FILE_PATH");
          if (logFilePath != null && logFilePath.Trim() != "") {
            bool logFileExists = File.Exists(logFilePath);
            using (StreamWriter logFile = new StreamWriter(logFilePath, true)) {
              if (!logFileExists) logFile.WriteLine("LogDateTime\tMessage");
              logFile.WriteLine(DateTime.Now + "\t" + e.Message.Replace("\t", " ").Replace("\r", " ").Replace("\n", " "));
            }
          }
        } catch (Exception fileException) {
          LogError(logger, fileException, false, false);
        }
      }

      /*** write to windows application log ***/
      string strError = "";
      strError += "Error Message:\n" + e.Message;
      strError += "\n\nSource:\n" + e.Source;
      exceptiontype = e.GetType();
      if (exceptiontype == typeof(SqlException)) {
        SqlException sqlException = (SqlException)e;
        strError += "\n\nProcedure:\n" + sqlException.Procedure;
        strError += "\n\nServer:\n" + sqlException.Server;
      }
      strError += "\n\nStackTrace:\n" + e.StackTrace;
      logger.LogError(strError);

      return new Error(e.Message);
    }
  }
}
