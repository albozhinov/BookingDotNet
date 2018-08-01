using Utility;


namespace HotelManagement.Common
{
    public struct Extra : IExtra
    {
        private int tier;
        private AvailableExtras name;
        private decimal price;

        public Extra(int tier, string extra, decimal price)
        {
            this.Tier = tier;
            this.Name = enum.TryParse
        }

        public int Tier
        {
            get
            {
                return this.tier;
            }
            set
            {
                Validation.NumberBorderCheck(1, 4, value, Constants.extraTier);
                this.tier = value;
            }
        }

        public AvailableExtras Name { get; }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                Validation.CantBeZero(value, Constants.tierPriceCannotBeZero);
                this.price = value;
            }
        }

    }
}
