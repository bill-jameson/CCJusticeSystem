using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cjisAPI {
  public class QuestionnaireAnswerType {
		public int AnswerTypeID { get; set; }
		public string AnswerTypeAlias { get; set; }
		public string AnswerType { get; set; }
		public int DisplayOrder { get; set; }

		public QuestionnaireAnswerType(DataReader dataReader) {
			AnswerTypeID = (int)dataReader.GetInteger("AnswerTypeID");
			AnswerTypeAlias = dataReader.GetString("AnswerTypeAlias");
			AnswerType = dataReader.GetString("AnswerType");
			DisplayOrder = (int)dataReader.GetInteger("AnswerTypeID");
		}
	}
}
