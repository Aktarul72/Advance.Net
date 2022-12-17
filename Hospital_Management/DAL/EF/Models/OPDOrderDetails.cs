using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class OPDOrderDetails
    {
        public int Id { get; set; }

        [ForeignKey("CustomerOPD")]
        public int CustomerOPDId { get; set; }
        public virtual CustomerOPD CustomerOPD { get; set; }

        [ForeignKey("ItemExam")]
        public int ItemExamId { get; set; }
        public virtual ItemExam ItemExam { get; set; }
    }
}
