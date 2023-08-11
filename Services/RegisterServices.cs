using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OHD.DataAccessLayer.Infrastructure.IRepository;
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
            var registervm = _unitOfWork.RegisterIU.GetT(x => x.RegisterId == id);
            _unitOfWork.RegisterIU.Delete(registervm);
            _unitOfWork.save();
        }

        public IEnumerable<Facility> GetALLFacility()
        {
            var list = _unitOfWork.FacilityIU.GetAll().ToList();
            return list;
        }

        public IEnumerable<RegisterView> GetALLRegisters()
        {
            List<RegisterView> vmList = new List<RegisterView>(); 
            var RegisterModel = _unitOfWork.RegisterIU.GetAll(IncludeProperties: "Facility,Role");
            vmList = ConvertModelToViewModel(RegisterModel);
                return vmList;
        }

        public IEnumerable<Roles> GetALLRoles()
        {
            var list = _unitOfWork.RolesIU.GetAll().ToList();
            return list;
        }


        public RegisterView GetRegisterByExprission(int id)
        {
            var registervm = _unitOfWork.RegisterIU.GetT(x => x.RegisterId == id,IncludeProperties: "Facility,Role");
            	var vm = new RegisterView(registervm);

				return vm;
            
            
        }

        public void InsertRegister(RegisterView registerView)
        {
            var model = new RegisterView().ConvertModel(registerView);
            _unitOfWork.RegisterIU.Add(model);
            _unitOfWork.save();

        }

        public void UpdateRegister(RegisterView registerView)
        {
            var model = new RegisterView().ConvertModel(registerView);
            _unitOfWork.RegisterIU.update(model);
            _unitOfWork.save();
        }

        private List<RegisterView> ConvertModelToViewModel(IEnumerable<Register> registerModel)
        {
            return registerModel.Select(x=> new RegisterView(x)).ToList();
        }
    }
}
