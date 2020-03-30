using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cjisAPI {
  public class Json {
    public class EmptyObject {}

    public static EmptyObject Nothing { get { return new EmptyObject(); } }
  }
}
