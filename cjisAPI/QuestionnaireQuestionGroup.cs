using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cjisAPI {
  public class QuestionnaireQuestionGroup {
		public int QuestionGroupID { get; set; }
		public string Alias { get; set; }
		public string Name { get; set; }
		public bool? SameScreen { get; set; }
		public bool? OneResponse { get; set; }
		public string FollowUpValue { get; set; }

		public QuestionnaireQuestionGroup(DataReader dataReader) {
			QuestionGroupID = (int)dataReader.GetInteger("QuestionnaireQuestionGroupID");
			Alias = dataReader.GetString("Alias");
			Name = dataReader.GetString("Name");
			SameScreen = dataReader.GetBoolean("SameScreen");
			OneResponse = dataReader.GetBoolean("OneResponse");
			FollowUpValue = dataReader.GetString("FollowUpValue");
		}
	}
}
