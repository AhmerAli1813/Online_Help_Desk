using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OHD.DataAccessLayer.EntityModel
{

	public class Requests
	{
		public enum Status
		{
			pedding, accepted, work_in_progress, rejected, cancel, done
		}
		[Key]
		public int RequestsId { get; set; }
		[ForeignKey("RequestorId")]
		public ApplicationUser? Requestor { get; set; }
		[Required]
		public int RequestorId { get; set; }
		[ForeignKey("AssigneeHeadId")]
		public ApplicationUser? AssigneeHead { get; set; }

		public int? AssigneeHeadId { get; set; }
		[ForeignKey("AssignerId")]
		public ApplicationUser? Assigner { get; set; }
		public int? AssignerId { get; set; }

		[ForeignKey("FacilityId")]
		public Facility? Facility { get; set; }
		public int? FacilityId { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime ReqCreateDate { get; set; } = DateTime.Now;
		public bool IsOpen { get; set; }
		[DefaultValue(0)]
		public Status status { get; set; }
		[MaxLength(100, ErrorMessage = "Enter Your Subject?")]
		public string? Subject { get; set; }
		[MaxLength(100, ErrorMessage = "Enter Your Descripation?")]
		public string? Descripation { get; set; }
		[StringLength(100)]
		public string? Remarks { get; set; }
	}


}
