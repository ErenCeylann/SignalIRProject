﻿using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Concrete
{
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void TAdd(Slider entity)
        {
            _sliderDal.Add(entity);
        }

        public void TDelete(Slider entity)
        {
            _sliderDal.Delete(entity);
        }

        public List<Slider> TGetAll()
        {
           return _sliderDal.GetAll();
        }

        public Slider TGetById(int id)
        {
            return _sliderDal.GetById(id);
        }

        public void TUpdate(Slider entity)
        {
            _sliderDal.Update(entity);
        }
    }
}
