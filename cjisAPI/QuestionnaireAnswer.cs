using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cjisAPI {
  public class QuestionnaireAnswer {
		public int QuestionnaireAnswerID { get; set; }
		public int QuestionID { get; set; }
		public string Label { get; set; }
		public int DisplayOrder { get; set; }
		public bool Enabled { get; set; }


		public QuestionnaireAnswer(DataReader dataReader) {
			QuestionnaireAnswerID = (int)dataReader.GetInteger("QuestionnaireAnswerID");
			QuestionID = (int)dataReader.GetInteger("QuestionID");
			Label = dataReader.GetString("Label");
			DisplayOrder = (int)dataReader.GetInteger("DisplayOrder");
			Enabled = (bool)dataReader.GetBoolean("Enabled");
		}
	}
}
