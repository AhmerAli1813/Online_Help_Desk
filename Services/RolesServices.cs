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
	public class RolesServices : IRolesServices
	{
		private IUnitOfWork _unitOfWork;

		public RolesServices(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void DeleteRoles(int id)
		{
			try
			{
				var Rolesvm = _unitOfWork.GenericRepository<Roles>().GetT(x => x.RoleId == id);
				_unitOfWork.GenericRepository<Roles>().Delete(Rolesvm);
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

		
		public IEnumerable<RolesView> GetALLRoles()
		{
			List<RolesView> vmList = new List<RolesView>();
			var RolesModel = _unitOfWork.GenericRepository<Roles>().GetAll();
			vmList = ConvertModelToViewModel(RolesModel);
			return vmList;
		}



		public RolesView GetRoleById(int id)
		{
			var Rolesvm = _unitOfWork.GenericRepository<Roles>().GetT(x => x.RoleId == id);
			var vm = new RolesView(Rolesvm);

			return vm;


		}

		public void InsertRoles(RolesView vm)
		{
			try
			{
				var model = new RolesView().ConvertModel(vm);
				_unitOfWork.GenericRepository<Roles>().Add(model);
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

		public void UpdateRoles(RolesView vm)
		{
			try
			{
				var model = new RolesView().ConvertModel(vm);
				_unitOfWork.GenericRepository<Roles>().Update(model);
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

		private List<RolesView> ConvertModelToViewModel(IEnumerable<Roles> RolesModel)
		{
			return RolesModel.Select(x => new RolesView(x)).ToList();
		}
	}
}
