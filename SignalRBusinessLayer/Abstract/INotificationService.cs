﻿using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Abstract
{
    public interface INotificationService:IGenericService<Notification>
    {
        int TNotificationCountByStatusFalse();

        List<Notification> TGetAllNotificationByFalse();

        void TNotificationChangToTrue(int id);

        void TNotificationChangToFalse(int id);
    }
}
