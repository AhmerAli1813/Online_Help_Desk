using OHD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.ModelsViews
{
    public class UserDataView
    {
        public int id { get; set; }
        public string? name { get; set; }
        public int role { get; set; }
        public int facility { get; set; }

        public UserDataView(Register model)
        {
            id = model.RegisterId;
            name = model.Name;
            role = model.RoleId;
            facility = model.FacilityId;

        }
    }
}
