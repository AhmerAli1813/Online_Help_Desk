using OHD.Models;
using OHD.ModelsViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OHD.Services
{
    public interface IRegisterServices
    {
        IEnumerable<RegisterView> GetALLRegisters();
        IEnumerable<Roles> GetALLRoles();
        IEnumerable<Facility> GetALLFacility();
        RegisterView GetRegisterByExprission(int id);
        void UpdateRegister(RegisterView registerView);
        void DeleteRegister(int id);
        void InsertRegister(RegisterView registerView);
    }
}
