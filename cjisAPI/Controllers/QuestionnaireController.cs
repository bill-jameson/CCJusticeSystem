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
    private readonly ILogger _logger;

    public QuestionnaireController(ILogger<QuestionnaireController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public object GetQuestionnaire(int? jurorId) {
      try {
        return new Questionnaire(jurorId);
      } catch (Exception e) {
        return Error.LogError(_logger, e);
      }
    }
  }
}
