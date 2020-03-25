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
  public class GetSummonsRecipientLoginController : ControllerBase
  {
    private readonly ILogger<GetSummonsRecipientLoginController> _logger;

    public GetSummonsRecipientLoginController(ILogger<GetSummonsRecipientLoginController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public Juror Get(string socialLastFour, string summonsId) {
      string connectionString = "Server=localhost\\SQLEXPRESS;Database=CJIS;Trusted_Connection=True;";

      SqlConnection connection = new SqlConnection(connectionString);
      connection.Open();

      SqlCommand command = new SqlCommand("EXEC spGetSummonsRecipientLogin '" + socialLastFour + "', ''", connection);

      SqlDataReader reader = command.ExecuteReader();

      Juror juror = reader.Read() ? Juror.GetJuror(reader.GetInt32(0)) : null;

      connection.Close();

      return juror;
    }
  }
}
