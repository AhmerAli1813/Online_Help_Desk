using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using OHD.DataAccessLayer.Infrastructure.IRepository;
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

		

		public RegisterView Aurthrization(AurthrizationView vm)
		{
			
			var model = _unitOfWork.GenericRepository<Register>().GetT(x=>x.Username==vm.Username && x.Password==vm.Password );
			
			var aurth = new RegisterView(model);
			return aurth;
		}

		
		public ProfileUpdateView GetProfileUser(int id)
		{
			var model = _unitOfWork.GenericRepository<Register>().GetT(x => x.RegisterId == id);
			var modelVm = new ProfileUpdateView(model);
			return modelVm;

		}

		public bool UpdateProfile(ProfileUpdateView profile)
		{
			var model = _unitOfWork.GenericRepository<Register>().GetT(x => x.RegisterId == profile.Id);
			if(model.Password == profile.oldPassword)
			{
				var modelVm = new ProfileUpdateView().ConvertModel(profile , model);
				//var m = new RegisterView().ConvertModel(modelVm);
				_unitOfWork.GenericRepository<Register>().Update(modelVm);
				_unitOfWork.Save();
				return true;
			}
			return false;
			
		}
	}
}
