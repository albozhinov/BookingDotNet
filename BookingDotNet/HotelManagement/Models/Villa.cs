using HotelManagement.Common;
using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace HotelManagement.Models
{
    public class Villa : AccomodationProperty, IVilla
    {
        private int numberOfFloors;
        private int bedrooms;
        private int bathrooms;

        public Villa(int numberOfFloors, int bedrooms, int bathrooms, int capacity,
            int beds, bool forSmokers, string view, decimal basePrice) 
            : base(capacity, beds, forSmokers, view, basePrice)
        {
            this.NumberOfFloors = numberOfFloors;
            this.Bedrooms = bedrooms;
            this.Bathrooms = bathrooms;
        }

        public override int Capacity
        {
            get
            {
                return base.Capacity;
            }
            set
            {
                Validation.NumberBorderCheck(1, 8, value, Constants.villaCapacity);
                base.Capacity = value;
            }
        }

        public override int Beds
        {
            get
            {
                return base.Beds;
            }
            set
            {
                Validation.NumberBorderCheck(1, 8, value, Constants.villaBeds);
                base.Beds = value;
            }
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

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"===== Number of Floors: {this.NumberOfFloors}");
            sb.AppendLine($"===== Bedrooms: {this.Bedrooms}");
            sb.AppendLine($"===== Bathrooms: {this.Bathrooms}");


            return sb.ToString();

        }
    }
}
