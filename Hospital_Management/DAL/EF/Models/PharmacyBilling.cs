using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class PharmacyBilling
    {
        public int Id { get; set; }
        [Required]
        public double ItemTotal { get; set; }
        [Required]
        public double TotalVat { get; set; }
        [Required]
        public double Discount { get; set; }
        [Required]
        public double TotalBill { get; set; }
        [Required]
        public double PaidAmount { get; set; }
        [Required]
        public double DueAmount { get; set; }
        [StringLength(10)]
        [Required]
        public string PaymentStatus { get; set; }

        [ForeignKey("CustomerPharmacy")]
        public int CustomerPharmacyId { get; set; }
        public virtual CustomerPharmacy CustomerPharmacy { get; set; }
    }
}
