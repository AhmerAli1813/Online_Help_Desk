using OHD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OHD.Models.Requests;

namespace OHD.ModelsViews
{
    public class RequstedAssigendByFacilityView
    {
        public int Id { get; set; }
        public Register? AssigneeHead { get; set; }
        [DisplayName("Head")]
        public string? AssigneeHeadName { get; set; }
        public Register? Requestor { get; set; }
        [DisplayName("Requestor")]
        public string? RequestorName { get; set; }
        public Register? Assigner { get; set; }
        [DisplayName("Your Depart")]
        public string AssignerName { get; set; }
        public Facility Facility { get; set; }
        [DisplayName("Location")]
        public string? AssigneLocation { get; set; }
        public string? Subject { get; set; }
        public string? Descripation { get; set; }
        public DateTime CreateTime { get; set; }
        [Required]
        public Status status { get; set; }
        [Required]
        public string? Remarks { get; set; }
        public RequstedAssigendByFacilityView()
        {
            
        }

        public RequstedAssigendByFacilityView(Requests model)
        {
            
                if (model != null)
                {
                    Id = model.RequestsId;
                    
                    if (model.AssigneeHead != null)
                    {
                        AssigneeHeadName = model.AssigneeHead.Name;
                    }
                    
                    if (model.Requestor != null)
                    {
                        RequestorName = model.Requestor.Name;
                    }

                    if (model.Facility != null)
                    {
                        AssigneLocation = model.Facility.FacilityName;
                    }
                if (model.Assigner != null)
                {
                    AssignerName = model.Assigner.Name;
                }

                    
                    Subject = model.Subject;
                    Descripation = model.Descripation;
                    status = model.status;
                    CreateTime = model.ReqCreateDate;
                Remarks = model.Remarks;

            }
        }
        public Requests ConvertModel(RequstedAssigendByFacilityView vm , Requests model)
        {
            return new Requests
            {
                //facility can work only this filed
                status = vm.status,
                Remarks = vm.Remarks,
                RequestsId = vm.Id,
                //already Create Requestor and Admin Define
                AssigneeHeadId = model.AssigneeHeadId,
                RequestorId = model.RequestorId,
                AssignerId = model.AssignerId,
                FacilityId = model.FacilityId,
                IsOpen = model.IsOpen,
                Subject = model.Subject,
                Descripation = model.Descripation,
                ReqCreateDate = model.ReqCreateDate
                
            };
        }
    }
}
