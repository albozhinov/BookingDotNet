using Utility;


namespace HotelManagement.Common
{
    public struct Extra : IExtra
    {
        private int tier;
        private AvailableExtras name;
        private decimal price;

        public Extra(int tier, AvailableExtras name, decimal price) : this()
        {
            this.Tier = tier;
            this.name = name;
            this.Price = price;
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

        public AvailableExtras Name { get => this.name; }

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
