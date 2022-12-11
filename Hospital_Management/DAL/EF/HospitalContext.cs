using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class HospitalContext : DbContext
    {
        public DbSet<PatientIPD> PatientIPDs { get; set; }
        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<CustomerOPD> CustomerOPDs { get; set; }
        public DbSet<CustomerPharmacy> CustomerPharmacies { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ItemExam> ItemExams { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<OTDetails> OTDetails { get; set; }
        public DbSet<PaymentInfo> PaymentInfos { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
