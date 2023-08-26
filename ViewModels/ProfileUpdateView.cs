using OHD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OHD.Models.Register;

namespace OHD.ModelsViews
{
	public class ProfileUpdateView
	{
        public ProfileUpdateView()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Email { get; set; }
        public string Address { get; set; }
		public ProfileUpdateView(Register model)
        {
            if(model!=null)
            {   Id = model.RegisterId;
                Name = model.Name;
                Email = model.Email;
                Address = model.Address;
            }
        }
        public Register ConvertModel(ProfileUpdateView modelvm ,Register model )
        {
            return new Register()

            {

                RegisterId = modelvm.Id,
                Name = modelvm.Name,
                Email = modelvm.Email,
                Address = modelvm.Address,
                Password = model.Password,
                Username = model.Username,
                FacilityId = model.FacilityId,
                RoleId = model.RoleId,
                Status = model.Status,
                Gender = model.Gender,
                ROD = model.ROD
                
            };

        }

	}
}
