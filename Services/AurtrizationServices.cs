using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using OHD.Infrastructure;
using OHD.Models;
using OHD.ModelsViews;
using OHD.Services.utilityClasses;
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
		private IEmailSender _emailSender;
		public AurtrizationServices(IUnitOfWork unitOfWork, ILogger<AurtrizationServices> logger, IEmailSender emailSender)
		{
			_unitOfWork = unitOfWork;
			_logger = logger;
			_emailSender = emailSender;
		}

		
		//LOGGIN
		public async Task<RegisterView> Aurthrization(AurthrizationView vm)
		{
			try 
			{ 
					var model = await _unitOfWork.GenericRepository<Register>().GetTAsync(x=>x.Username==vm.Username && x.Password==vm.Password );
						
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

        public string GetAdminEmail()
        {

            var data = _unitOfWork.GenericRepository<Register>().GetT(x => x.RoleId == 2000);
            return data.Email;
        }

        public int GetAdminID()
        {
			var data = _unitOfWork.GenericRepository<Register>().GetT(x => x.RoleId == 2000);
		return	data.RegisterId;
        }

        public async Task<ProfileUpdateView> GetProfileUser(int id)
		{
			var model = await _unitOfWork.GenericRepository<Register>().GetTAsync(x => x.RegisterId == id);
			var modelVm = new ProfileUpdateView(model);
			return modelVm;

		}

		public async Task<bool> UpdatePassword(ModifiyPasswordView view)
		{
			try
			{
				var model = await _unitOfWork.GenericRepository<Register>().GetTAsync(x => x.RegisterId == view.Id);
				if (model.Password == view.oldPassword)
				{
					var modelVm = new ModifiyPasswordView().ConvertModel(view, model);
					await _unitOfWork.GenericRepository<Register>().UpdateAsync(modelVm);
					await _unitOfWork.SaveAsync();
					return true;
				}
				
			}
			catch(NullReferenceException N)
			{
				Console.WriteLine(N);
			}
			return false;


		}
        public async Task<bool> ForgetPassword(ChangePasswordView view)
        {
            try
            {
                var model = await _unitOfWork.GenericRepository<Register>().GetTAsync(x => x.RegisterId == view.id);
                    var modelVm = new ChangePasswordView().ConvertModel(view, model);
                   await _unitOfWork.GenericRepository<Register>().UpdateAsync(modelVm);
                    await _unitOfWork.SaveAsync();
                    return true;
                

            }
            catch (NullReferenceException N)
            {
                Console.WriteLine(N);
            }
            return false;


        }

        public async Task<bool> UpdateProfile(ProfileUpdateView profile)
		{		
			try
			{
				var model = await _unitOfWork.GenericRepository<Register>().GetTAsync(x => x.RegisterId == profile.Id);
				var modelVm = new ProfileUpdateView().ConvertModel(profile , model);
				await _unitOfWork.GenericRepository<Register>().UpdateAsync(modelVm);
				await _unitOfWork.SaveAsync();
				return true;
			}
			catch(NullReferenceException N)
			{
				Console.WriteLine(N);
			}
			return false;


		}

		public async Task<ChangePasswordView> GetUserDataByUsername(string Usesname)
		{
			var model = await _unitOfWork.GenericRepository<Register>().GetTAsync(x=>x.Username==Usesname);
			var modelVm = new ChangePasswordView(model);
			return modelVm;

		}
	}
}
