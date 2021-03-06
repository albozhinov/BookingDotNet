﻿using HotelManagement.Common;
using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Utility;


namespace HotelManagement.Models
{
    public class Apartment : AccomodationProperty, IApartment
    {
        private bool fullyQuipped;
        private int bedrooms;
        private int bathrooms;
        private int onFloor;

        // Constructor
        public Apartment(int capacity, int beds, bool forSmokers, string view, decimal basePrice,
            bool fullyQuipped, int bedrooms, int bathrooms, int onFloor)
            : base (capacity, bedrooms, forSmokers, view, basePrice)
        {
            this.FullyQuipped = fullyQuipped;
            this.Bedrooms = bedrooms;
            this.Bathrooms = bathrooms;
            this.OnFloor = onFloor;
        }

        // Properties

        public override int Beds
        {
            get => base.Beds;
            set
            {
                Validation.NumberBorderCheck(1, 6, value, Constants.apartmentBeds);
                base.Beds = value;
            }
        }

        public override int Capacity
        {
            get
            {
                return base.Capacity;
            }
            set
            {
                Validation.NumberBorderCheck(1, 6, value, Constants.apartmentCapacity);
                base.Capacity = value;
            }
        }

        public bool FullyQuipped
        {
            get => this.fullyQuipped;
            set => this.fullyQuipped = value;
        }

        public int Bedrooms
        {
            get => this.bedrooms;
            set
            {
                Validation.NumberBorderCheck(2, 3, value, Constants.apartmentBedrooms);
                this.bedrooms = value;
            }
        }

        public int Bathrooms
        {
            get => this.bathrooms;
            set
            {
                Validation.NumberBorderCheck(1, 3, value, Constants.apartmentBathrooms);
                this.bathrooms = value;
            }
        }

        public int OnFloor
        {
            get => this.onFloor;
            set
            {
                Validation.CantBeZero(value, Constants.apartmentFloor);
                this.onFloor = value;
            }
        }

        public override void AddExtra(IExtra extra)
        {
            Validation.NumberBorderCheck(1, 3, extra.Tier, Constants.extraTierApart);
            base.AddExtra(extra);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(base.ToString());           
            sb.AppendLine($"===== FullyQuipped: {this.FullyQuipped}");
            sb.AppendLine($"===== Bedrooms: {this.Bedrooms}");
            sb.AppendLine($"===== Bathrooms: {this.Bathrooms}");
            sb.AppendLine($"===== On Floor: {this.OnFloor}");
            return sb.ToString();
        }
    }
}
