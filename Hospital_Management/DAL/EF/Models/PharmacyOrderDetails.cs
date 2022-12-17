using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class PharmacyOrderDetails
    {
        public int Id { get; set; }

        [ForeignKey("CustomerPharmacy")]
        public int CustomerPharmacyId { get; set; }
        public virtual CustomerPharmacy CustomerPharmacy { get; set; }

        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
