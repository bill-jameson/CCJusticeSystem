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
  public class QuestionnaireController : ControllerBase
  {
    private readonly ILogger<MobileController> _logger;

    public QuestionnaireController(ILogger<MobileController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public Questionnaire GetQuestionnaire(int? jurorId) {
      return new Questionnaire(jurorId);
    }
  }
}
