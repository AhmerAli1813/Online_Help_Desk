using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.Models
{
    public class Register
    {
        public enum status
        {
            Online,Offline,Block,UnActive
        }
        public enum gender { Male,Female,other}
        public int RegisterId { get; set; }
        public string Name { get; set; }
        public string  Username { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Address { get; set; }

        [DataType(DataType.Password)]

        public string Password { get; set; } 
        public gender Gender { get; set; }
        public status Status { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ROD { get; set; }   = DateTime.Now;
        public Roles? Role { get; set; }
        public int RoleId { get; set; }
        public Facility? Facility { get; set; }
        public int  FacilityId { get; set; }

    }
}
