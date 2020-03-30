﻿using System;
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
