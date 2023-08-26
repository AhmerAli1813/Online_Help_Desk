using OHD.Infrastructure;
using OHD.Models;
using OHD.ModelsViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.Services
{

	public class FacilityServices : IFacilityServices
	{
		private IUnitOfWork _unitOfWork;
		public FacilityServices(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void DeleteFacility(int id)
		{
			try
			{
				var Facilityvm = _unitOfWork.GenericRepository<Facility>().GetT(x => x.FacilityId == id);
				_unitOfWork.GenericRepository<Facility>().DeleteAsync(Facilityvm);
				_unitOfWork.Save();

			}
			catch (NullReferenceException N)
			{
				Console.WriteLine(N);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
		public IEnumerable<FacilityView> GetALLFacility()
		{
			List<FacilityView> vmList = new List<FacilityView>();
			var FacilityModel = _unitOfWork.GenericRepository<Facility>().GetAll();
			vmList = ConvertModelToViewModel(FacilityModel);
			return vmList;
		}
		public FacilityView GetFacilityById(int id)
		{ 
			var Facilityvm = _unitOfWork.GenericRepository<Facility>().GetT(x => x.FacilityId == id);
			var vm = new FacilityView(Facilityvm);
			return vm;
		}

		public void InsertFacility(FacilityView vm)
		{
			try
			{
				var model = new FacilityView().ConvertModel(vm);
				_unitOfWork.GenericRepository<Facility>().Add(model);
				_unitOfWork.Save();

			}
			catch (NullReferenceException N)
			{
				Console.WriteLine(N);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}

		public void UpdateFacility(FacilityView vm)
		{
			try
			{
				var model = new FacilityView().ConvertModel(vm);
				_unitOfWork.GenericRepository<Facility>().Update(model);
				_unitOfWork.Save();

			}
			catch (NullReferenceException N)
			{
				Console.WriteLine(N);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}

		private List<FacilityView> ConvertModelToViewModel(IEnumerable<Facility> FacilityModel)
		{
			return FacilityModel.Select(x => new FacilityView(x)).ToList();
		}
	}
}
