using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class PaymentInfo
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string PaymentType { get; set; }
        [Required]
        public double Amount { get; set; }
    }
}
