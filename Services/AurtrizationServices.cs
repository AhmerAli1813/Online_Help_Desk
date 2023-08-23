using Microsoft.Extensions.Logging;
using Microsoft.Win32;
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
	public class AurtrizationServices : IAurtrizationServices
	{
		private IUnitOfWork _unitOfWork;
		private ILogger<AurtrizationServices> _logger;

		public AurtrizationServices(IUnitOfWork unitOfWork, ILogger<AurtrizationServices> logger)
		{
			_unitOfWork = unitOfWork;
			_logger = logger;
		}

		
		//LOGGIN
		public RegisterView Aurthrization(AurthrizationView vm)
		{
			try 
			{ 
					var model = _unitOfWork.GenericRepository<Register>().GetT(x=>x.Username==vm.Username && x.Password==vm.Password );
				
					var aurth = new RegisterView(model);

				return aurth;
			}
			catch (NullReferenceException N)
			{
				Console.WriteLine(N);
			}catch(Exception ex)
			{
				Console.WriteLine(ex);
			}
			return new RegisterView();
			
		}

        public int GetAdminID()
        {
			var data = _unitOfWork.GenericRepository<Register>().GetT(x => x.RoleId == 2001);
		return	data.RegisterId;
        }

        public ProfileUpdateView GetProfileUser(int id)
		{
			var model = _unitOfWork.GenericRepository<Register>().GetT(x => x.RegisterId == id);
			var modelVm = new ProfileUpdateView(model);
			return modelVm;

		}

		public bool UpdatePassword(ChangePasswordView view)
		{
			try
			{
				var model = _unitOfWork.GenericRepository<Register>().GetT(x => x.RegisterId == view.Id);
				if (model.Password == view.oldPassword)
				{
					var modelVm = new ChangePasswordView().ConvertModel(view, model);
					_unitOfWork.GenericRepository<Register>().Update(modelVm);
					_unitOfWork.Save();
					return true;
				}
				
			}
			catch(NullReferenceException N)
			{
				Console.WriteLine(N);
			}
			return false;


		}

		public bool UpdateProfile(ProfileUpdateView profile)
		{		
			try
			{
				var model = _unitOfWork.GenericRepository<Register>().GetT(x => x.RegisterId == profile.Id);
				var modelVm = new ProfileUpdateView().ConvertModel(profile , model);
				_unitOfWork.GenericRepository<Register>().Update(modelVm);
				_unitOfWork.Save();
				return true;
			}
			catch(NullReferenceException N)
			{
				Console.WriteLine(N);
			}
			return false;


		}
	}
}
