using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BizlandTemplate.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
