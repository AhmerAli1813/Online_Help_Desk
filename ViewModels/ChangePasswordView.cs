using OHD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OHD.ModelsViews
{
	public class ChangePasswordView
	{
		public ChangePasswordView()
		{

		}
		public int id { get; set; }
		public string? username { get; set; }
		
		[DataType(DataType.Password)]

		public string newPassword { get; set; }
		[DataType(DataType.Password)]
		[Compare("newPassword")]
		public string? confrimPassword { get; set; }
		public string? email { get; set; }
		public int pin { get; set; }
		public ChangePasswordView(Register model)
		{
			if (model != null)
			{
				id = model.RegisterId;
				email = model.Email;
				username = model.Username;
			}

		}
		public Register ConvertModel(ChangePasswordView modelvm, Register model)
		{
			return new Register()

			{
				//only change Password
				Password = modelvm.newPassword,

				RegisterId = modelvm.id,

				Name = model.Name,
				Email = model.Email,
				Address = model.Address,
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
