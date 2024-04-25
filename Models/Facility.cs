﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.Models
{
    public class Facility
    {
        [Key]
        public int FacilityId { get; set; }
        public string? FacilityName { get; set; }
        public string? FacilityDescription { get; set; }
    }
}
