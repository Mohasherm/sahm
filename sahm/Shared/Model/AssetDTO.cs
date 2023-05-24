﻿using LocalizationLibrary.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sahm.Shared.Model
{
    public class AssetDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
