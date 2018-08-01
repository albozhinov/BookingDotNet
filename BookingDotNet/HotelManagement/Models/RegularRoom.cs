using HotelManagement.Common;
using HotelManagement.Contracts;
using Utility;

namespace HotelManagement.Models
{
    public class RegularRoom : AccomodationProperty, IRegularRoom
    {
        private int onFloor;
        public RegularRoom(int capacity, int beds, bool forSmokers, string view, decimal basePrice, int onFloor ) :base(capacity,beds,forSmokers,view,basePrice)
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

        public override int Capacity { get => base.Capacity; set { Validation.NumberBorderCheck(1, 2, value, Constants.regularRoomCapacity); base.Capacity = value; } }
        public override int Beds { get => base.Beds; set { Validation.NumberBorderCheck(1, 2, value, Constants.regularRoomBeds); base.Beds = value; } }

        public override void AddExtra(IExtra extra)
        {
            Validation.NumberBorderCheck(1, 1, extra.Tier, Constants.regularRoomExtra);
            base.AddExtra(extra);
        }
    }
}
