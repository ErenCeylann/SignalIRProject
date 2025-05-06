using SignalRDtoLayer.BookingDto;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.Abstract
{
    public interface IBookingDal:IGenericDal<Booking>
    {
        void BookingStatusAppRoved(int id);
        void BookingStatusCanselled(int id);

        List<Booking> BookingStatusApprovedList();
        List<Booking> BookingStatusCanselledList();
        List<Booking> BookingStatusPendingApproval();

        int BookingStatusApprovedCount();
        int BookingStatusCanselledCount();
        int BookingStatusPendingApprovalCount();
    }
}
