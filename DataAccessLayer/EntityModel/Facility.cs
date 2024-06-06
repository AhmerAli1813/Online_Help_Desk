using System.ComponentModel.DataAnnotations;

namespace OHD.DataAccessLayer.EntityModel
{
	public class Facility
	{
		[Key]
		public int FacilityId { get; set; }
		public string? FacilityName { get; set; }
		public string? FacilityDescription { get; set; }
	}
}
