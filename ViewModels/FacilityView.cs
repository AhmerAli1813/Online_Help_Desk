using OHD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.ModelsViews
{
	public class FacilityView
	{
		public FacilityView() { }
		public int Id { get; set; }
		public string? Facility { get; set; }
		public string? Description { get; set; }
		public FacilityView(Facility model)
		{
			Id = model.FacilityId;
			Facility = model.FacilityName;
			Description = model.FacilityDescription;
		}
		public Facility ConvertModel(FacilityView modelVm)
		{
			return new Facility()
			{

				FacilityId = modelVm.Id,
				FacilityName = modelVm.Facility,
				FacilityDescription = modelVm.Description
			};

		}

	}
}
