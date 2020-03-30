using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cjisAPI {
	public class Questionnaire {
		public int? JurorID { get; set; }
		public List<QuestionnaireQuestion> _Questions = new List<QuestionnaireQuestion>();
		public List<QuestionnaireQuestion> Questions { get { return _Questions; } }

		public Questionnaire(int? jurorId) {
			JurorID = jurorId;

			GetData();
		}

		private void GetData() {
			DataCommand command = new DataCommand("spGetQuestionnaireQuestions");

			DataReader dataReader = command.ExecuteReader();

			while (dataReader.Read()) {
				QuestionnaireQuestion question = new QuestionnaireQuestion(dataReader);
				Questions.Add(question);
			}

			command = new DataCommand("spGetQuestionnaireAnswers");

			dataReader = command.ExecuteReader();

			while (dataReader.Read()) {
				QuestionnaireAnswer answer = new QuestionnaireAnswer(dataReader);
				AddAnswer(answer);
			}

			command = new DataCommand("spGetQuestionnaireResponses");
			command.AddParameter("@jurorId", JurorID);

			dataReader = command.ExecuteReader();

			while (dataReader.Read()) {
				QuestionnaireResponse response = new QuestionnaireResponse(dataReader);
				AddResponse(response);
			}
		}

		private void AddResponse(QuestionnaireResponse response) {
			foreach (QuestionnaireQuestion question in Questions) {
				if (question.QuestionID == response.QuestionID) {
					question.Response = response;
					break;
				}
			}
		}

		private void AddAnswer(QuestionnaireAnswer answer) {
			foreach (QuestionnaireQuestion question in Questions) {
				if (question.QuestionID == answer.QuestionID) {
					question.Answers.Add(answer);
					break;
				}
			}
		}
	}
}
