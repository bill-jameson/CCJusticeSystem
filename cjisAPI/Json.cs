using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cjisAPI {
  public class Json {
    public class EmptyObject { }
    //public class ErrorObject {
    //  public string Error { get; set; }
    //  public string ErrorMessage { get; set; }
    //  public ErrorObject(string errorMessage) {
    //    Error = "An error occurred.";
    //    ErrorMessage = errorMessage;
    //  }
    //}

    public static EmptyObject Nothing { get { return new EmptyObject(); } }
    //public static ErrorObject Error(string errorMessage) {
    //  return new ErrorObject(errorMessage);
    //}
  }
}
