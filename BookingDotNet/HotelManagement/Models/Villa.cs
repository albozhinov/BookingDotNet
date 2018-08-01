using HotelManagement.Common;
using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace HotelManagement.Models
{
    class Villa : AccomodationProperty, IVilla
    {
        private int numberOfFloors;
        private int bedrooms;
        private int bathrooms;

        public Villa(int numberOfFloors, int bedrooms, int bathrooms, List<IExtra> listOfExtras, int capacity, int beds, bool forSmokers,
            string view, decimal basePrice) : base(capacity, beds, forSmokers, view, basePrice)
        {
            this.NumberOfFloors = numberOfFloors;
            this.Bedrooms = bedrooms;
            this.Bathrooms = bathrooms;
        }

        public int NumberOfFloors
        {
            get
            {
                return this.numberOfFloors;
            }
            set
            {
                Validation.NumberBorderCheck(1, 3, value, Constants.villaFloors);
                this.numberOfFloors = value;
            }
        }
        public int Bedrooms
        {
            get
            {
                return this.bedrooms;
            }
            set
            {
                Validation.NumberBorderCheck(1, 3, value, Constants.villaBedrooms);
                this.bedrooms = value;
            }
        }
        public int Bathrooms
        {
            get
            {
                return this.bathrooms;
            }
            set
            {
                Validation.NumberBorderCheck(1, 3, value, Constants.villaBathrooms);
                this.bathrooms = value;
            }
        }

        public override void AddExtra(IExtra extra)
        {
            base.AddExtra(extra);
        }
    }
}
