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
  public class EnvironmentController : ControllerBase
  {
    private readonly ILogger<MobileController> _logger;

    public EnvironmentController(ILogger<MobileController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public string GetConnectionString() {
      const string CJIS_API_CONNECTION_STRING = "CJIS_API_CONNECTION_STRING";
      return CJIS_API_CONNECTION_STRING + ": " + Environment.GetEnvironmentVariable(CJIS_API_CONNECTION_STRING);
    }
  }
}
