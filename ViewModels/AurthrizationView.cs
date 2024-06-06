using OHD.DataAccessLayer;
using System.ComponentModel.DataAnnotations;

namespace OHD.ModelsViews
{
	public class AurthrizationView
	{
		[Required(ErrorMessage = "Username is Required")]
		public string? Username { get; set; }
		[Required(ErrorMessage = "password is Required")]
		[DataType(DataType.Password)]
		public string? Password { get; set; }
		[Display(Name = "Remember Me")]
		public bool RememberMe { get; set; }

		public AurthrizationView()
		{

		}
		public AurthrizationView(ApplicationUser model)
		{
			Username = model.UserName;

			Password = model.PasswordHash;

		}
	}
}
