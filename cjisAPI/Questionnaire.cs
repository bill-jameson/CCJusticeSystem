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
			/*** get questions ***/
			DataCommand command = new DataCommand("spGetQuestionnaireQuestions");
			DataReader dataReader = command.ExecuteReader();
			while (dataReader.Read()) {
				QuestionnaireQuestion question = new QuestionnaireQuestion(dataReader);
				if (!question.Enabled) continue;
				Questions.Add(question);
			}

			/*** get question groups ***/
			command = new DataCommand("spGetQuestionnaireQuestionGroups");
			dataReader = command.ExecuteReader();
			while (dataReader.Read()) {
				QuestionnaireQuestionGroup questionGroup = new QuestionnaireQuestionGroup(dataReader);
				AddQuestionGroup(questionGroup);
			}

			/*** get answer types ***/
			command = new DataCommand("spGetQuestionnaireAnswerTypes");
			dataReader = command.ExecuteReader();
			while (dataReader.Read()) {
				QuestionnaireAnswerType answerType = new QuestionnaireAnswerType(dataReader);
				AddAnswerType(answerType);
			}

			/*** get answers ***/
			command = new DataCommand("spGetQuestionnaireAnswers");
			dataReader = command.ExecuteReader();
			while (dataReader.Read()) {
				QuestionnaireAnswer answer = new QuestionnaireAnswer(dataReader);
				AddAnswer(answer);
			}

			/*** get questionnaire responses ***/
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

		private void AddQuestionGroup(QuestionnaireQuestionGroup questionGroup) {
			foreach (QuestionnaireQuestion question in Questions) {
				if (question.QuestionGroupID == questionGroup.QuestionGroupID) {
					question.QuestionGroup = questionGroup;
				}
			}
		}

		private void AddAnswerType(QuestionnaireAnswerType answerType) {
			foreach (QuestionnaireQuestion question in Questions) {
				if (question.AnswerTypeID == answerType.AnswerTypeID) {
					question.AnswerType = answerType;
				}
			}
		}
	}
}
