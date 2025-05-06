using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Abstract
{
    public interface IBookingService:IGenericService<Booking>
    {
        void TBookingStatusAppRoved(int id);
        void TBookingStatusCanselled(int id);

        List<Booking> TBookingStatusApprovedList();
        List<Booking> TBookingStatusCanselledList();
        List<Booking> TBookingStatusPendingApproval();

        int TBookingStatusApprovedCount();
        int TBookingStatusCanselledCount();
        int TBookingStatusPendingApprovalCount();
    }
}
