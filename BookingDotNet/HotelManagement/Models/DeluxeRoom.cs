using HotelManagement.Common;
using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace HotelManagement.Models
{
    public class DeluxeRoom : AccomodationProperty, IDeluxeRoom
    {
        private int onFloor;

        public DeluxeRoom(int capacity, int beds, bool forSmokers, string view, decimal basePrice, int onFloor) 
            : base(capacity, beds, forSmokers, view, basePrice)
        {
            this.OnFloor = onFloor;
        }

        public override int Beds
        {
            get
            {
                return base.Beds;
            }
            set
            {
                Validation.NumberBorderCheck(1, 2, value, Constants.roomBeds);
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
                Validation.NumberBorderCheck(1, 3, value, Constants.deluxeRoomCapacity);
                base.Capacity = value;
            }
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
        public override void AddExtra(IExtra extra)
        {
            Validation.NumberBorderCheck(1, 2, extra.Tier, Constants.extraTierdeluxeRoom);
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
