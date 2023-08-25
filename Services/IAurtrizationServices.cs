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
		RegisterView Aurthrization(AurthrizationView view);
		ProfileUpdateView GetProfileUser(int id);
		ChangePasswordView  GetUserDataByUsername(string Usesname);
		bool UpdateProfile(ProfileUpdateView profile);
		bool UpdatePassword(ModifiyPasswordView view);
        bool ForgetPassword(ChangePasswordView view);
        int GetAdminID();
		string GetAdminEmail();
    }
}
