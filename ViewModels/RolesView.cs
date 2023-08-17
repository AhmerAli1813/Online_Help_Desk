using OHD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.ModelsViews
{
	public class RolesView
	{
        public RolesView()
        {
            
        }
        public int Id { get; set; }
		public string? Role { get; set; }
		public string? Description { get; set; }
        public RolesView( Roles model)
        {
            Id = model.RoleId;
            Role = model.RoleName;
            Description = model.RoleDescription;
        }
		public Roles ConvertModel(RolesView modelVm)
		{
			return new Roles()
			{

				RoleId = modelVm.Id,
				RoleName = modelVm.Role,
				RoleDescription = modelVm.Description
			};

		}
	}
}
