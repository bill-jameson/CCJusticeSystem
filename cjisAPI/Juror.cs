using System;
using System.Data.SqlClient;
using System.Data;

namespace cjisAPI
{
	public class Juror {
		/***properties***/
		public int JurorID { get; set; }
		public string FirstName { get; set; }
		public string MiddleInitial { get; set; }
		public string LastName { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string T { get; set; }
		public string G { get; set; }
		public int CityID { get; set; }
		public int StateID { get; set; }
		public int ZIP { get; set; }
		public string SocialSecurityNumber { get; set; }
		public string HomePhone { get; set; }
		public string WorkPhone { get; set; }
		public string Race { get; set; }
		public string Sex { get; set; }
		public bool Hispanic { get; set; }
		public string Source { get; set; }
		public int VoterRegistrationID { get; set; }
		public int DriverLicenseNumber { get; set; }
		public int JuryBoxID { get; set; }
		public int NonCitizen { get; set; }
		public string Comment { get; set; }
		public int NonCitizenID { get; set; }
		public bool QuestionnaireCompleted { get; set; }

		public Juror(int jurorId) {
			JurorID = jurorId;

			GetData();
		}

		private void GetData() {
			DataCommand command = new DataCommand("spGetJuror", CommandType.StoredProcedure);
			command.AddParameter("@jurorId", JurorID);

			SqlDataReader reader = command.ExecuteReader();

			if (reader.Read()) {
				JurorID = reader.GetInt32(0);
				FirstName = reader.GetString(1);
				//MiddleInitial = reader.GetString(2);
				LastName = reader.GetString(3);
				//Address1 = reader.GetString(4);
				//Address2 = reader.GetString(5);
				//DateOfBirth = reader.GetDateTime(6);
				//T = reader.GetString(7);
				//G = reader.GetString(8);
				//CityID = reader.GetInt32(9);
				//StateID = reader.GetInt32(10);
				//ZIP = reader.GetInt32(11);
				//SocialSecurityNumber = reader.GetString(12);
				//HomePhone = reader.GetString(13);
				//WorkPhone = reader.GetString(14);
				//Race = reader.GetString(15);
				//Sex = reader.GetString(16);
				//Hispanic = reader.GetBoolean(17);
				//Source = reader.GetString(18);
				//VoterRegistrationID = reader.GetInt32(19);
				//DriverLicenseNumber = reader.GetInt32(20);
				//JuryBoxID = reader.GetInt32(21);
				//NonCitizen = reader.GetInt32(22);
				//Comment = reader.GetString(23);
				//NonCitizenID = reader.GetInt32(24);
				//QuestionnaireCompleted = reader.GetBoolean(25);
			}

			command.Close();
		}

		public static Juror GetJuror(int jurorId) {
			return new Juror(jurorId);
		}
	}
}
