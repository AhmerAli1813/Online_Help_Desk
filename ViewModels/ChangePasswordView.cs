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
		public int Id { get; set; }
		public string? oldPassword { get; set; }
		[DataType(DataType.Password)]

		public string NewPassword { get; set; }
		[DataType(DataType.Password)]
		[Compare("NewPassword")]
		public string? ConfrimPassword { get; set; }
		public ChangePasswordView(Register model)
		{
			if (model != null)
			{
				NewPassword = model.Password;
			}

		}
		public Register ConvertModel(ChangePasswordView modelvm, Register model)
		{
			return new Register()

			{
				//only change Password
				Password = modelvm.NewPassword,

				RegisterId = modelvm.Id,

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
