using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PaymentInfoRepo : Repo, IRepo<PaymentInfo, int, PaymentInfo>
    {
        public PaymentInfo Add(PaymentInfo obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PaymentInfo> Get()
        {
            throw new NotImplementedException();
        }

        public PaymentInfo Get(int id)
        {
            throw new NotImplementedException();
        }

        public PaymentInfo Update(PaymentInfo obj)
        {
            throw new NotImplementedException();
        }
    }
}
