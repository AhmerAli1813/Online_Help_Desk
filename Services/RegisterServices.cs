
using Microsoft.Extensions.Logging;
using OHD.Infrastructure;
using OHD.Models;
using OHD.ModelsViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OHD.Services
{
    public class RegisterServices : IRegisterServices
    {
        private IUnitOfWork _unitOfWork;
        private ILogger<RegisterServices> _logger;

        public RegisterServices(IUnitOfWork unitOfWork, ILogger<RegisterServices> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public void DeleteRegister(int id)
        {
            try
            {
                var registervm = _unitOfWork.GenericRepository<Register>().GetT(x => x.RegisterId == id);
                _unitOfWork.GenericRepository<Register>().Delete(registervm);
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
        public IEnumerable<Facility> GetALLFacility()
        {
            var list = _unitOfWork.GenericRepository<Facility>().GetAll().ToList();
            return list;
        }
        public IEnumerable<RegisterView> GetALLRegisters()
        {
            List<RegisterView> vmList = new List<RegisterView>(); 
            var RegisterModel = _unitOfWork.GenericRepository<Register>().GetAll(IncludeProperties: "Facility,Role");
            vmList = ConvertModelToViewModel(RegisterModel);
                return vmList;
        }
        public IEnumerable<Roles> GetALLRoles()
        {
            var list = _unitOfWork.GenericRepository<Roles>().GetAll().ToList();
            return list;
        }
        public RegisterView GetRegisterByExprission(int id)
        {
            var registervm = _unitOfWork.GenericRepository<Register>().GetT(x => x.RegisterId == id,IncludeProperties: "Facility,Role");
            	var vm = new RegisterView(registervm);
    		return vm;
        }
    public void InsertRegister(RegisterView registerView)
        {
            try 
            { 
                var model = new RegisterView().ConvertModel(registerView);
                _unitOfWork.GenericRepository<Register>().Add(model);
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
        public void UpdateRegister(RegisterView registerView)
        {
            try 
            { 
                var model = new RegisterView().ConvertModel(registerView);
                _unitOfWork.GenericRepository<Register>().Update(model);
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
        private List<RegisterView> ConvertModelToViewModel(IEnumerable<Register> registerModel)
        {
            return registerModel.Select(x=> new RegisterView(x)).ToList();
        }
    }
}
