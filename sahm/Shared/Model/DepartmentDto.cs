﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sahm.Shared.Models
{
    public class DepartmentDto
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
