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
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(SignalRContext context) : base(context)
        {
        }

        public int NotificationCountByStatusFalse()
        {
            using var context = new SignalRContext();
            return context.Notifications.Where(x=>x.Status==false).Count();
        }

        public List<Notification> GetAllNotificationByFalse()
        {
            using var context=new SignalRContext(); 
            return context.Notifications.Where(x=>x.Status==false).OrderByDescending(x=>x.NotificationId).ToList();
        }

        public void NotificationChangToTrue(int id)
        {
            using var context= new SignalRContext();
            var value = context.Notifications.Find(id);
            value.Status=true;
            context.SaveChanges();
        }

        public void NotificationChangToFalse(int id)
        {
            using var context = new SignalRContext();
            var value = context.Notifications.Find(id);
            value.Status = false;
            context.SaveChanges();
        }
    }
}
