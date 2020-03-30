using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace cjisAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class MobileController : ControllerBase
  {
    private readonly ILogger<MobileController> _logger;

    public MobileController(ILogger<MobileController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public object GetSummonsRecipientLogin(string socialLastFour, int jurorId) {
      DataCommand command = new DataCommand("spGetSummonsRecipientLogin");
      command.AddParameter("@socialLastFour", socialLastFour);
      command.AddParameter("@jurorId", jurorId);

      DataReader dataReader = command.ExecuteReader();

      object juror = dataReader.Read() ? (object)Juror.GetJuror((int)dataReader.GetInteger("JurorID")) : (object)Json.Nothing;

      command.Close();

      return juror;
    }
  }
}
