using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PharmacyOrderDetailsDTO
    {
        public int Id { get; set; }

        public int PharmacyBillingId { get; set; }
        public int MedicineId { get; set; }
    }
}
