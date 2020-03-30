using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cjisAPI {
	public class QuestionnaireQuestion {
		public enum QuestionnaireAnswerType { TextOnly = 1, TextEntry = 2, Checkbox = 3 }

		public int QuestionID { get; set; }
		public string Question { get; set; }
		public QuestionnaireAnswerType AnswerType { get; set; }
		public string StrAnswerType { get { return AnswerType.ToString(); } }
		public int? GroupID { get; set; }
		public string GroupAlias { get; set; }
		public int DisplayOrder { get; set; }
		public bool Enabled { get; set; }
		public List<QuestionnaireAnswer> _Answers = new List<QuestionnaireAnswer>();
		public List<QuestionnaireAnswer> Answers { get { return _Answers; } }

		public QuestionnaireQuestion(DataReader dataReader) {
			QuestionID = (int)dataReader.GetInteger("QuestionID");
			Question = dataReader.GetString("Question");
			AnswerType = (QuestionnaireAnswerType)dataReader.GetInteger("AnswerTypeID");
			GroupID = dataReader.GetInteger("QuestionnaireQuestionGroupID");
			GroupAlias = dataReader.GetString("QuestionGroupAlias");
			DisplayOrder = (int)dataReader.GetInteger("DisplayOrder");
			Enabled = (bool)dataReader.GetBoolean("Enabled");
		}
	}
}
