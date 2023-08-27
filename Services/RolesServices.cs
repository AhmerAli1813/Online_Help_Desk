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

		public async Task DeleteRoles(int id)
		{
			try
			{
			var Rolesvm = await _unitOfWork.GenericRepository<Roles>().GetTAsync(x => x.RoleId == id);
			await	_unitOfWork.GenericRepository<Roles>().DeleteAsync(Rolesvm);
			await	_unitOfWork.SaveAsync();

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

		
		public async Task<IEnumerable<RolesView>> GetALLRoles()
		{
			List<RolesView> vmList = new List<RolesView>();
			var RolesModel = await _unitOfWork.GenericRepository<Roles>().GetAllAsync();
			vmList = ConvertModelToViewModel(RolesModel);
			return vmList;
		}



		public async Task<RolesView> GetRoleById(int id)
		{
			var Rolesvm = await _unitOfWork.GenericRepository<Roles>().GetTAsync(x => x.RoleId == id);
			var vm = new RolesView(Rolesvm);

			return vm;


		}

		public async Task InsertRoles(RolesView vm)
		{
			try
			{
				var model = new RolesView().ConvertModel(vm);
				await _unitOfWork.GenericRepository<Roles>().AddAsync(model);
				await _unitOfWork.SaveAsync();

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

		public async Task UpdateRoles(RolesView vm)
		{
			try
			{
				var model = new RolesView().ConvertModel(vm);
				await _unitOfWork.GenericRepository<Roles>().UpdateAsync(model);
				await _unitOfWork.SaveAsync();

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
