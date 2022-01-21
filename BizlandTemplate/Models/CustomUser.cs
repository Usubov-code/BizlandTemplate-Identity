using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BizlandTemplate.Models
{
    public class CustomUser:IdentityUser
    {

        [MaxLength(50),MinLength(3)]
        public string FullName { get; set; }
    }
}
