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
    public class CreateRequestView
    {
        public int Id { get; set; }
        
        public Register? Requestor { get; set; }
        [Required]
        public int RequestorId { get; set; }
        [DisplayName("Self")]
        public string? RequestorName { get; set; }
        public Register? AssigneeHead { get; set; }
        [Required]
        public int? AssigneeHeadId { get; set; }

        [Required]
        public string? Subject { get; set; }
        [Required]
        public string? Descripation { get; set; }
        public Status status { get; set; } = 0;
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public CreateRequestView()
        {
            
        }
        public CreateRequestView(int adminID)
        {
            AssigneeHeadId = adminID;
        }
        public CreateRequestView(Requests model)
        {
            if (model != null)
            {
                Id = model.RequestsId;
                AssigneeHeadId = model.AssigneeHeadId;
                
                RequestorId = model.RequestorId;
                if (Requestor != null)
                {
                    RequestorName = model.Requestor.Name;

                }
                Subject = model.Subject;
                Descripation = model.Descripation;
                status = model.status;
               CreateTime = model.ReqCreateDate;


            }
        }
        public Requests ConvertModel(CreateRequestView vm)
        {
            return new Requests
            {
                RequestsId = vm.Id,
                RequestorId = vm.RequestorId,
                AssigneeHeadId = vm.AssigneeHeadId,
                Subject = vm.Subject,
                Descripation = vm.Descripation,
                ReqCreateDate = vm.CreateTime,
                status = vm.status
            };
        }
        
    }
}
