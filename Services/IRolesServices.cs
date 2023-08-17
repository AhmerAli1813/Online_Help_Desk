using OHD.Models;
using OHD.ModelsViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.Services
{
	public interface IRolesServices
	{
		IEnumerable<RolesView> GetALLRoles();
		
		RolesView GetRoleById(int id);
		void UpdateRoles(RolesView vm);
		void DeleteRoles(int id);
		void InsertRoles(RolesView vm);
	}
}
