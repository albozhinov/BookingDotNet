﻿using HotelManagement.Common;
using HotelManagement.Contracts;
using System.Text;
using Utility;

namespace HotelManagement.Models
{
    public class RegularRoom : AccomodationProperty, IRegularRoom
    {
        private int onFloor;

        public RegularRoom(int capacity, int beds, bool forSmokers, string view, decimal basePrice, int onFloor) 
            : base(capacity, beds, forSmokers, view, basePrice)
        {
            this.OnFloor = onFloor;
           this.Capacity = capacity;
        }


        public int OnFloor
        {
            get
            {
                return this.onFloor;
            }
            set
            {
                Validation.CantBeZero(value, Constants.floorCannotBeNegative);
                this.onFloor = value;
            }
        }

        public override int Capacity
        {
            get => base.Capacity;
            set
            {
                Validation.NumberBorderCheck(1, 2, value, Constants.regularRoomCapacity);
                base.Capacity = value;
            }
        }

        public override int Beds
        {
            get => base.Beds;
            set
            {
                Validation.NumberBorderCheck(1, 2, value, Constants.roomBeds);
                base.Beds = value;
            }
        }

        public override void AddExtra(IExtra extra)
        {
            Validation.NumberBorderCheck(1, 1, extra.Tier, Constants.regularRoomExtra);
            base.AddExtra(extra);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendLine($"===== Room is on floor number: {this.OnFloor}");
            return sb.ToString();
        }
    }
}
