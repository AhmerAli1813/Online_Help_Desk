using OHD.ModelsViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.Services
{
	public interface IAurtrizationServices
	{
		Task<RegisterView> Aurthrization(AurthrizationView view);
		Task<ProfileUpdateView> GetProfileUser(int id);
		Task<ChangePasswordView>  GetUserDataByUsername(string Usesname);
		Task<bool> UpdateProfile(ProfileUpdateView profile);
		Task<bool> UpdatePassword(ModifiyPasswordView view);
        Task<bool> ForgetPassword(ChangePasswordView view);
        int GetAdminID();
		string GetAdminEmail();
    }
}
