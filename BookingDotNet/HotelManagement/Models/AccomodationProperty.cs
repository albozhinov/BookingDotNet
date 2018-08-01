﻿using HotelManagement.Common;
using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace HotelManagement.Models
{
    public abstract class AccomodationProperty : IAccomodationProperty
    {
        private int capacity;
        private int beds;
        private readonly bool forSmokers;
        private readonly ViewType view;
        private readonly List<IExtra> listOfExtras;
        private decimal basePrice;

        public AccomodationProperty(int capacity, int beds, bool forSmokers, string view, decimal basePrice)
        {
            this.Capacity = capacity;
            this.Beds = beds;
            this.forSmokers = forSmokers;
            Enum.TryParse(view, out ViewType result);
            this.view = result;
            this.BasePrice = basePrice;
            this.listOfExtras = new List<IExtra>();
        }

        public virtual int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                Validation.NumberBorderCheck(1, 10, value, Constants.commonCapacity);
                this.capacity = value;
            }
        }
        public virtual int Beds
        {
            get
            {
                return this.beds;
            }
            set
            {
                Validation.NumberBorderCheck(1, 10, value, Constants.commonBeds);
                this.beds = value;
            }
        }


        public bool ForSmokers
        {
            get
            {
                return this.forSmokers;
            }
        }

        public ViewType View { get; set; }

        public List<IExtra> ListOfExtras
        {
            get
            {
                return new List<IExtra>(this.listOfExtras);
            }
        }

        public virtual decimal BasePrice
        {
            get
            {
                return this.basePrice;
            }
            set
            {
                Validation.NumberBorderCheck(50, 400, value, Constants.commonBasePrice);
                this.basePrice = value;
            }
        }

        public virtual void AddExtra(IExtra extra)
        {
            this.listOfExtras.Add(extra);
        }

        public virtual decimal CalculatePrice()
        {
            throw new NotImplementedException();
        }
    }
}
