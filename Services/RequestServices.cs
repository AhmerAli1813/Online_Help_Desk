using Azure.Core;
using Microsoft.AspNetCore.Http;
using OHD.Infrastructure;
using OHD.Models;
using OHD.ModelsViews;
using OHD.Services.utilityClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace OHD.Services
{   
    public class RequestServices : IRequestServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private IEmailSender _emailSender;
        

        public RequestServices(IUnitOfWork unitOfWork , IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
           
        }
        public UserDataView AdminData()
        {
           var model = _unitOfWork.GenericRepository<Register>().GetT(x => x.RoleId == 2000);
            var vm = new UserDataView(model);
             return vm;
        }
        public Requests GetRequestById(int id)
        {
            
            var list = _unitOfWork.GenericRepository<Requests>().GetT(x => x.RequestsId == id);
            return list;
        }
        public RequstedAssigendView GetRequestByIdToFacilityHead(int id)
        {
            var list = _unitOfWork.GenericRepository<Requests>().GetT(x => x.RequestsId == id,IncludeProperties: "Requestor,Assigner,Facility");
            var vm = new RequstedAssigendView(list);
            return vm;

        }
        public RequstedAssigendByFacilityView GetRequestByIdToFacility(int id)
        {
            var list = _unitOfWork.GenericRepository<Requests>().GetT(x => x.RequestsId == id, IncludeProperties: "Requestor,Assigner,Facility");
            var vm = new RequstedAssigendByFacilityView(list);
            return vm;

        }
        public async Task   createRequest(CreateRequestView vm)
        {   
            
            var model = new CreateRequestView().ConvertModel(vm);
           await _unitOfWork.GenericRepository<Requests>().AddAsync(model);
           await _unitOfWork.SaveAsync();
            string SenderEmail = AdminData().email;
         
            Task task = _emailSender.SendEmailAsync("complaint: " + vm.Subject, "Salam Admin \n\n " + vm.Descripation, SenderEmail);
        }

        public IEnumerable<CreateRequestView> GetAllCreateRequests(int id)
        {
                    List<CreateRequestView> createRequests = new List<CreateRequestView>();
            var list = _unitOfWork.GenericRepository<Requests>().GetAll(x=>x.RequestorId ==id,IncludeProperties: "Requestor");
          var   listVm = ConvertModelToViewModel(list);
            return listVm;

        }

        public IEnumerable<RequstedAssigendView> GetAllRequests()
        {
            List<RequstedAssigendView> createRequests = new List<RequstedAssigendView>();
            var list = _unitOfWork.GenericRepository<Requests>().GetAll(IncludeProperties: "Requestor,Assigner,Facility");
            var listVm = ConvertModelToViewModel2(list);
            return listVm;
        }
		

        private IEnumerable<RequstedAssigendView> ConvertModelToViewModel2(IEnumerable<Requests> list)
        {
            return list.Select(x => new RequstedAssigendView(x)).ToList();
        }

        
        private IEnumerable<CreateRequestView> ConvertModelToViewModel(IEnumerable<Requests> list)
        {
            return list.Select(x=> new CreateRequestView(x)).ToList();
        }

        public async Task UpdateAssigerRequestToAssigen(RequstedAssigendView vm,Requests models)
        {
            var model = new RequstedAssigendView().ConvertModel(vm, models);
          
            _unitOfWork.GenericRepository<Requests>().Update(model);
            _unitOfWork.Save();
            string SenderEmail = GetUserByFaciliyIdAndAssinger(vm.FacilityId,vm.AssignerId).AssignerEmail;
            string AssignerName = GetUserByFaciliyIdAndAssinger(vm.FacilityId, vm.AssignerId).AssignerName;
            Task task = _emailSender.SendEmailAsync("Assigner: " + model.Subject, "Salam  "+AssignerName+"<br> \r\n\n " + model.Descripation, SenderEmail);
        }
        public async Task UpdateAssigerRequestRemarks(RequstedAssigendByFacilityView vm, Requests models)
        {
            var model = new RequstedAssigendByFacilityView().ConvertModel(vm, models);
            _unitOfWork.GenericRepository<Requests>().Update(model);
            _unitOfWork.Save();
            string SenderEmail = GetUserByFaciliyIdAndAssinger(model.FacilityId, model.AssignerId).RequestorEmail;
            string Name = GetUserByFaciliyIdAndAssinger(model.FacilityId, model.AssignerId).RequestorName;
            string Remark = vm.Remarks;
            Task task = _emailSender.SendEmailAsync("Resloved: " + model.Subject, "Salam  <b>" + Name + "</b> <br> <b>Complaint:</b> " + model.Descripation+" <br>   "+Remark, SenderEmail);

        }

        public IEnumerable<Facility> GetALLFacility()
        {
           var list =  _unitOfWork.GenericRepository<Facility>().GetAll();
            return list;

        }

        public IEnumerable<UserDataView> GetALLAssigerByFacilityId(int facilityID)
        {
            var data = _unitOfWork.GenericRepository<Register>().GetAll(x => x.FacilityId == facilityID);
            var listVm = ConvertModelToViewModel4(data);
            return listVm;

        }

        private IEnumerable<UserDataView> ConvertModelToViewModel4(IEnumerable<Register> data)
        {
            return data.Select(x=>new UserDataView(x)).ToList();
        }

        public IEnumerable<RequstedAssigendByFacilityView> GetAllRequestByFacility(int id)
        {
            var model = _unitOfWork.GenericRepository<Requests>().GetAll(x => x.FacilityId == id , IncludeProperties: "Requestor,Assigner,Facility,AssigneeHead");
            var modelvm = ConvertModelToViewModel5(model);
            return modelvm;
        }
        private IEnumerable<RequstedAssigendByFacilityView> ConvertModelToViewModel5(IEnumerable<Requests> model)
        {
            return model.Select(x => new RequstedAssigendByFacilityView(x)).ToList();
        }

        public bool DeleteRequsted(int id)
        {
            try 
            {

                var registervm = _unitOfWork.GenericRepository<Requests>().GetT(x => x.RequestsId == id);
                _unitOfWork.GenericRepository<Requests>().Delete(registervm);
                _unitOfWork.Save();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public CreateRequestView GetRequestByIdToCreateUser(int id)
        {
            var list = _unitOfWork.GenericRepository<Requests>().GetT(x => x.RequestsId == id, IncludeProperties: "Requestor,Assigner,Facility");
            var vm = new CreateRequestView(list);
            return vm;
        }
        public RequstedAssigendView GetUserByFaciliyIdAndAssinger(int? facilityId,int? AssingerId)
        {
            var list = _unitOfWork.GenericRepository<Requests>().GetT(x => x.AssignerId == AssingerId && x.FacilityId==facilityId, IncludeProperties: "AssigneeHead,Requestor,Assigner,Facility");
            var vm = new RequstedAssigendView(list);
            return vm;
        }
    }
}
