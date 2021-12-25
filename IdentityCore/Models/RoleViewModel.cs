﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityCore.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Ad Alanı Gereklidir")]
        [Display(Name ="Ad :" )]
        public string Name { get; set; }
    }
}
