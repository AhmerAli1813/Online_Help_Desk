﻿using OHD.ModelsViews;
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
	}
}