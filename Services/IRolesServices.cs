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
		Task<IEnumerable<RolesView>> GetALLRoles();
		
		Task<RolesView> GetRoleById(int id);
		Task UpdateRoles(RolesView vm);
		Task DeleteRoles(int id);
		Task InsertRoles(RolesView vm);
	}
}
