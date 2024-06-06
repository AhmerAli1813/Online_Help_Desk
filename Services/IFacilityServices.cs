using OHD.ModelsViews;

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
