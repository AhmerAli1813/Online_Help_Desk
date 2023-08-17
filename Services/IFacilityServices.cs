using OHD.Models;
using OHD.ModelsViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.Services
{
	public interface IFacilityServices
	{
		IEnumerable<FacilityView> GetALLFacility();
		FacilityView GetFacilityById(int id);
		void UpdateFacility(FacilityView vm);
		void DeleteFacility(int id);
		void InsertFacility(FacilityView vm);
	}
}
