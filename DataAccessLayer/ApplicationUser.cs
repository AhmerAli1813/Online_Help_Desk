using Microsoft.AspNetCore.Identity;

namespace OHD.DataAccessLayer
{
	public class ApplicationUser : IdentityUser
	{
		public string? FullName { get; set; }
		public string? Address { get; set; }
	}
}