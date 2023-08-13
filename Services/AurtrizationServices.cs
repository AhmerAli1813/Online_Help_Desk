using Microsoft.Extensions.Logging;
using OHD.DataAccessLayer.Infrastructure.IRepository;
using OHD.Models;
using OHD.ModelsViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.Services
{
	public class AurtrizationServices : IAurtrizationServices
	{
		private IUnitOfWork _unitOfWork;
		private ILogger<RegisterServices> _logger;

		public AurtrizationServices(IUnitOfWork unitOfWork, ILogger<RegisterServices> logger)
		{
			_unitOfWork = unitOfWork;
			_logger = logger;
		}

		public RegisterView Aurthrization(AurthrizationView vm)
		{
			
			var model = _unitOfWork.RegisterIU.GetT(x=>x.Username==vm.Username && x.Password==vm.Password );
			
			var aurth = new RegisterView(model);
			return aurth;
		}

		
	}
}
