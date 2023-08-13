using OHD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.ModelsViews
{
	public class AurthrizationView
	{
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }

        public AurthrizationView()
        {
            
        }
        public AurthrizationView(Register model)
        {
			Username = model.Username;
			
			Password = model.Password;

        }
    }
}
