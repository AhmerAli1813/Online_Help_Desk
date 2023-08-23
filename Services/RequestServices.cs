using Azure.Core;
using OHD.Infrastructure;
using OHD.Models;
using OHD.ModelsViews;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.Services
{   
    public class RequestServices : IRequestServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
        public void createRequest(CreateRequestView vm)
        {
            var model = new CreateRequestView().ConvertModel(vm);
            _unitOfWork.GenericRepository<Requests>().Add(model);
            _unitOfWork.Save();
        }

        public IEnumerable<CreateRequestView> GetAllCreateRequests(int id)
        {
                    List<CreateRequestView> createRequests = new List<CreateRequestView>();
            var list = _unitOfWork.GenericRepository<Requests>().GetAll(x=>x.RequestorId ==id);
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

        public void UpdateAssigerRequestToAssigen(RequstedAssigendView vm,Requests models)
        {
            var model = new RequstedAssigendView().ConvertModel(vm, models);
            _unitOfWork.GenericRepository<Requests>().Update(model);
            _unitOfWork.Save();
        }
        public void UpdateAssigerRequestRemarks(RequstedAssigendByFacilityView vm, Requests models)
        {
            var model = new RequstedAssigendByFacilityView().ConvertModel(vm, models);
            _unitOfWork.GenericRepository<Requests>().Update(model);
            _unitOfWork.Save();
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
    }
}
