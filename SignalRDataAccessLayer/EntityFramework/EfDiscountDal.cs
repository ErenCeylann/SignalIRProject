using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.Repositories;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.EntityFramework
{
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(SignalRContext context) : base(context)
        {
        }

        public void ChangToStatusFalse(int id)
        {
            using var context = new SignalRContext();
            var values = context.Discounts.Find(id);
            values.Status = false;
            context.SaveChanges();
        }

        public void ChangToStatusTrue(int id)
        {
            using var context = new SignalRContext();
            var values = context.Discounts.Find(id);
            values.Status = true;
            context.SaveChanges();
        }

        public List<Discount> GetListByStatusTrue()
        {
            using var context = new SignalRContext();
            var values=context.Discounts.Where(x => x.Status==true).ToList(); 
            return values;
        }
    }
}
