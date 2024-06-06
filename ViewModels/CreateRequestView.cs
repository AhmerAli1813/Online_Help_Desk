using OHD.DataAccessLayer;
using OHD.DataAccessLayer.EntityModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static OHD.DataAccessLayer.EntityModel.Requests;

namespace OHD.ModelsViews
{
	public class CreateRequestView
	{
		public int Id { get; set; }

		public ApplicationUser? Requestor { get; set; }
		[Required]
		public int RequestorId { get; set; }
		[DisplayName("Self")]
		public string? RequestorName { get; set; }
		public ApplicationUser? AssigneeHead { get; set; }
		[Required]
		public int? AssigneeHeadId { get; set; }

		[Required]
		public string? Subject { get; set; }
		[Required]
		public string? Descripation { get; set; }
		public Status status { get; set; } = 0;
		public DateTime CreateTime { get; set; } = DateTime.Now;
		public CreateRequestView()
		{

		}
		public CreateRequestView(int adminID)
		{
			AssigneeHeadId = adminID;
		}
		public CreateRequestView(Requests model)
		{
			if (model != null)
			{
				Id = model.RequestsId;
				AssigneeHeadId = model.AssigneeHeadId;

				RequestorId = model.RequestorId;
				if (Requestor != null)
				{
					RequestorName = model.Requestor.FullName;

				}
				Subject = model.Subject;
				Descripation = model.Descripation;
				status = model.status;
				CreateTime = model.ReqCreateDate;


			}
		}
		public Requests ConvertModel(CreateRequestView vm)
		{
			return new Requests
			{
				RequestsId = vm.Id,
				RequestorId = vm.RequestorId,
				AssigneeHeadId = vm.AssigneeHeadId,
				Subject = vm.Subject,
				Descripation = vm.Descripation,
				ReqCreateDate = vm.CreateTime,
				status = vm.status
			};
		}

	}
}
