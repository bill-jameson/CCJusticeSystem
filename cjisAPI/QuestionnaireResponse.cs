using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cjisAPI {
  public class QuestionnaireResponse {
		public int QuestionnaireResponseID { get; set; }
		public int JurorID { get; set; }
		public int QuestionID { get; set; }
		public string ResponseValue { get; set; }
		public int? QuestionnaireAnswerID { get; set; }


		public QuestionnaireResponse(DataReader dataReader) {
			QuestionnaireResponseID = (int)dataReader.GetInteger("QuestionnaireResponseID");
			JurorID = (int)dataReader.GetInteger("JurorID");
			QuestionID = (int)dataReader.GetInteger("QuestionID");
			ResponseValue = dataReader.GetString("ResponseValue");
			QuestionnaireAnswerID = dataReader.GetInteger("QuestionnaireAnswerID");
		}
	}
}
