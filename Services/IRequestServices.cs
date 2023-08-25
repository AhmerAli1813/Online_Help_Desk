using Azure.Core;
using OHD.Models;
using OHD.ModelsViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.Services
{
    public interface IRequestServices
    {
        
        IEnumerable<CreateRequestView> GetAllCreateRequests(int id);
        IEnumerable<RequstedAssigendView> GetAllRequests();
        IEnumerable<Facility> GetALLFacility();
        IEnumerable<UserDataView> GetALLAssigerByFacilityId(int facilityID );
        IEnumerable<RequstedAssigendByFacilityView> GetAllRequestByFacility(int id);
        Task UpdateAssigerRequestToAssigen(RequstedAssigendView vm, Requests models);
        Task UpdateAssigerRequestRemarks(RequstedAssigendByFacilityView vm, Requests models);
        Requests GetRequestById(int id);
       // RequstedAssigendView GetRequestViewById(int id);
        RequstedAssigendView GetRequestByIdToFacilityHead(int id);
        RequstedAssigendByFacilityView GetRequestByIdToFacility(int id);
        CreateRequestView GetRequestByIdToCreateUser(int id);
        bool DeleteRequsted(int id);
        Task createRequest(CreateRequestView vm);
    }
}
