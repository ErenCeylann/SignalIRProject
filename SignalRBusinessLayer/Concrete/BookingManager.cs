using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TAdd(Booking entity)
        {
            _bookingDal.Add(entity);
        }

        public void TBookingStatusAppRoved(int id)
        {
            _bookingDal.BookingStatusAppRoved(id);
        }

        public int TBookingStatusApprovedCount()
        {
            return _bookingDal.BookingStatusApprovedCount();
        }

        public List<Booking> TBookingStatusApprovedList()
        {
           return _bookingDal.BookingStatusApprovedList();
        }

        public void TBookingStatusCanselled(int id)
        {
            _bookingDal.BookingStatusCanselled(id);
        }

        public int TBookingStatusCanselledCount()
        {
            return _bookingDal.BookingStatusCanselledCount();
        }

        public List<Booking> TBookingStatusCanselledList()
        {
            return _bookingDal.BookingStatusCanselledList();
        }

        public List<Booking> TBookingStatusPendingApproval()
        {
           return _bookingDal.BookingStatusPendingApproval();
        }

        public int TBookingStatusPendingApprovalCount()
        {
            return _bookingDal.BookingStatusPendingApprovalCount();
        }

        public void TDelete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public List<Booking> TGetAll()
        {
            return _bookingDal.GetAll();
        }

        public Booking TGetById(int id)
        {
           return _bookingDal.GetById(id);
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
