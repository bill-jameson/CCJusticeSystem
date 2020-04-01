using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cjisAPI {
	public class QuestionnaireQuestion {
		public int QuestionID { get; set; }
		public string Alias { get; set; }
		public string Question { get; set; }
		public int AnswerTypeID;
		public QuestionnaireAnswerType AnswerType { get; set; }
		public string AnswerSuffix { get; set; }
		public int? QuestionGroupID;
		public QuestionnaireQuestionGroup QuestionGroup {get;set;}
		public int DisplayOrder { get; set; }
		public bool Enabled { get; set; }
		public List<QuestionnaireAnswer> _Answers = new List<QuestionnaireAnswer>();
		public List<QuestionnaireAnswer> Answers { get { return _Answers; } }
		public QuestionnaireResponse Response { get; set; }

		public QuestionnaireQuestion(DataReader dataReader) {
			QuestionID = (int)dataReader.GetInteger("QuestionID");
			Alias = dataReader.GetString("Alias");
			Question = dataReader.GetString("Question");
			AnswerTypeID = (int)dataReader.GetInteger("AnswerTypeID");
			AnswerSuffix = dataReader.GetString("AnswerSuffix");
			QuestionGroupID = dataReader.GetInteger("QuestionnaireQuestionGroupID");
			//GroupID = dataReader.GetInteger("QuestionnaireQuestionGroupID");
			//GroupAlias = dataReader.GetString("QuestionGroupAlias");
			DisplayOrder = (int)dataReader.GetInteger("DisplayOrder");
			Enabled = (bool)dataReader.GetBoolean("Enabled");
		}
	}
}
