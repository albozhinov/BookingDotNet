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
            Validation.NumberBorderCheck(1, 2, extra.Tier, Constants.regularRoomExtra);
            base.AddExtra(extra);
        }
    }
}
