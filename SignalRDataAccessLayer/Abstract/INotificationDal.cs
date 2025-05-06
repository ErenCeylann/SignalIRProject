using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.Abstract
{
    public interface INotificationDal:IGenericDal<Notification>
    {
        int NotificationCountByStatusFalse();

        List<Notification> GetAllNotificationByFalse();

        void NotificationChangToTrue(int id);

        void NotificationChangToFalse(int id);

    }
}
