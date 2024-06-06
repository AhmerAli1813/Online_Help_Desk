using OHD.DataAccessLayer;

namespace OHD.ModelsViews
{
	public class UserDataView
	{
		public int id { get; set; }
		public string? name { get; set; }
		public int role { get; set; }
		public int facility { get; set; }
		public string? email { get; set; }
		public UserDataView(ApplicationUser model)
		{

			name = model.FullName;

			//facility = model.FacilityId;
			email = model.Email;
		}


	}
}
