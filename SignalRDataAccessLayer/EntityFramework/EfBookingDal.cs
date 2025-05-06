using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.Repositories;
using SignalRDtoLayer.BookingDto;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

        public void BookingStatusAppRoved(int id)
        {
            using var context = new SignalRContext();
            var values = context.Bookings.Find(id);
            values.Description = "Rezervasyon Onaylandı";
            context.SaveChanges();
        }

        public int BookingStatusApprovedCount()
        {
            using var context = new SignalRContext();
            return context.Bookings.Where(x => x.Description == "Rezervasyon Onaylandı").Count();
        }

        public List<Booking> BookingStatusApprovedList()
        {
            using var context = new SignalRContext();
            return context.Bookings.Where(x=>x.Description== "Rezervasyon Onaylandı").ToList();
            

        }

        public void BookingStatusCanselled(int id)
        {
            using var context = new SignalRContext();
            var values = context.Bookings.Find(id);
            values.Description = "Rezervasyon İptal Edildi";
            context.SaveChanges();
        }

        public int BookingStatusCanselledCount()
        {
            using var context = new SignalRContext();
            return context.Bookings.Where(x => x.Description == "Rezervasyon İptal Edildi").Count();
        }

        public List<Booking> BookingStatusCanselledList()
        {
            using var context = new SignalRContext();
            return context.Bookings.Where(x => x.Description == "Rezervasyon İptal Edildi").ToList();
        }

        public List<Booking> BookingStatusPendingApproval()
        {
            using var context = new SignalRContext();
            return context.Bookings.Where(x => x.Description == "Rezervasyon Alındı").ToList();
        }

        public int BookingStatusPendingApprovalCount()
        {
            using var context = new SignalRContext();
            return context.Bookings.Where(x => x.Description == "Rezervasyon Alındı").Count();
        }
    }
}
