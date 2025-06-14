﻿using AutoMapper;
using SignalRDtoLayer.BookingDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class BookingMapping:Profile
    {
        public BookingMapping()
        {
            CreateMap<Booking,ResultBookingDto>().ReverseMap();
            CreateMap<Booking,GetBookingDto>().ReverseMap();
            CreateMap<Booking,CreateBookingDto>().ReverseMap();
            CreateMap<Booking,UpdateBookingDto>().ReverseMap();
        }
    }
}
