using OHD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OHD.Models.Register;

namespace OHD.ModelsViews
{
    public class RegisterView
    {
        public RegisterView()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public gender Gender { get; set; }
        public status Status { get; set; }
        public DateTime ROD { get; set; } = DateTime.Now;
        public Roles roles { get; set; }
        public int RoleId { get; set; }
        
        public Facility Facilities { get; set; }
        public int FacilityId { get; set; }
        

        public RegisterView( Register model)
        {
            Id = model.RegisterId;
            Name = model.Name;
            Username = model.Username;
            Email = model.Email;
            Address = model.Address;
            Password = model.Password;
            Gender = model.Gender;
            Status = model.Status;
            roles = model.Role;
            RoleId = model.RoleId;
            Facilities = model.Facility;
            FacilityId = model.FacilityId;
            
        }
        public Register ConvertModel(RegisterView model)
        {
            return new Register()
            {

                RegisterId = model.Id,
                Name = model.Name,
                Username = model.Username,
                Email = model.Email,
                Address = model.Address,
                Password = model.Password,
                Gender = model.Gender,
                Status = model.Status,
                Role = model.roles,
                RoleId = model.RoleId,
                FacilityId = model.FacilityId
            };

        }

    }
}
