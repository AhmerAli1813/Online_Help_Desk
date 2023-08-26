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
    public class RequstedAssigendView
    {
        public int Id { get; set; }
        
        [Required]
        public int? AssignerId { get; set; }

        //only Get fileds
        public Register? Assigner { get; set; }

        public string AssignerName {get; set; }
        public string AssignerEmail { get; set; }
        public Register? Requestor { get; set; }
        public int RequestorId { get; set; }
        public string RequestorName { get; set; }
        public string RequestorEmail { get; set; }
        //public string? AssignerFacility { get; set; }
        public Facility Facility { get; set; }
        [Required]
        public int? FacilityId { get; set; }
        [DisplayName("location")]
        public string? AssigneLocation { get; set; }

        public bool IsOpen { get; set; }

        public Status status { get; set; }

        public string? Subject { get; set; }
        public string? Descripation { get; set; }
        public DateTime CreateTime { get; set; }
        public RequstedAssigendView()
        {
            
        }

        public RequstedAssigendView(Requests model)
        {
            if (model != null)
            {
                Id = model.RequestsId;
                AssignerId = model.AssignerId;
                if (model.Assigner != null) {
                     AssignerName = model.Assigner.Name;
                    AssignerEmail = model.Assigner.Email;
                }
                RequestorId = model.RequestorId;
                if (model.Requestor != null)
                {
                    RequestorName = model.Requestor.Name;
                    RequestorEmail = model.Requestor.Email;
                    
                }
                if(model.Facility != null)
                {
                    AssigneLocation = model.Facility.FacilityName;
                }
                
                FacilityId = model.FacilityId;
                Subject = model.Subject;
                Descripation = model.Descripation;
                status = model.status;
                CreateTime = model.ReqCreateDate;


            }
        }
        public Requests ConvertModel(RequstedAssigendView vm , Requests model)
        {
            return new Requests
            {
                //admin can work only this filed
                RequestsId = vm.Id,
                AssignerId = vm.AssignerId,
                FacilityId = vm.FacilityId,
                status = vm.status,
                IsOpen = vm.IsOpen,

                //already Create RequestorDefine
                AssigneeHeadId = model.AssigneeHeadId,
                RequestorId = model.RequestorId,
                Subject = model.Subject,
                Descripation = model.Descripation,
                ReqCreateDate = model.ReqCreateDate
                
            };
        }
    }
}
