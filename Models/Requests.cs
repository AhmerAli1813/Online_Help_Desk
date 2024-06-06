
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.Models
{
    
    public class Requests
    {
        public enum Status
        {
            pedding,accepted,work_in_progress,rejected,cancel,done
        }
        [Key]
        public int RequestsId { get; set; }
        [ForeignKey("RequestorId")]
        public Register? Requestor { get; set; }
        [Required]
        public int RequestorId { get; set; }
        [ForeignKey("AssigneeHeadId")]
        public Register? AssigneeHead { get; set; }
        
        public int? AssigneeHeadId { get; set; }
        [ForeignKey("AssignerId")]
        public Register? Assigner { get; set; }
        public int? AssignerId { get; set; }

        [ForeignKey("FacilityId")]
        public Facility? Facility { get; set; }
        public int? FacilityId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ReqCreateDate { get; set; } = DateTime.Now;
        public bool IsOpen { get; set; }
        [DefaultValue(0)]
        public Status status { get; set; }
        [MaxLength(100, ErrorMessage = "Enter Your Subject?")]
        public string? Subject { get; set; }
        [MaxLength(100 , ErrorMessage = "Enter Your Descripation?")]
        public string? Descripation { get; set; }
        [StringLength(100) ]
        public string? Remarks {get; set;}
    }

    
}
