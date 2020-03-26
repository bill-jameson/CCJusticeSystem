using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace cjisAPI.Controllers {
  [ApiController]
  [Route("[controller]")]
  public class MobileController : ControllerBase {
    private readonly ILogger<MobileController> _logger;

    public MobileController(ILogger<MobileController> logger) {
      _logger = logger;
    }

    [HttpGet]
    public int[]/*Juror*/ GetSummonsRecipientLogin(string socialLastFour, int juryId) {
      DataCommand command = new DataCommand("EXEC spGetSummonsRecipientLogin '" + socialLastFour + "', " + juryId);

      SqlDataReader dataReader = command.ExecuteReader();

      //Juror juror = dataReader.Read() ? Juror.GetJuror(dataReader.GetInt32(0)) : null;

      //command.Close();

      return new int[] { 0, 1, 2, 3, 4 }/*juror*/;
    }
  }
}
