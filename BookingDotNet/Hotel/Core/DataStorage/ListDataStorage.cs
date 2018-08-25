using System;
using System.Collections.Generic;
using System.Text;
using HotelManagement.Common;
using HotelManagement.Contracts;
using UserManagement.Contracts;

namespace Hotel.Core.DataStorage
{
    public class ListDataStorage : IData
    {

        public ListDataStorage()
        {
            this.Clients = new List<IClient>();
            this.Hotels = new List<IHotel>();
            this.Rooms = new List<IAccomodationProperty>();
            this.Extras = new List<IExtra>();
            InternalExtrasInitialization();

        }
        public IList<IClient> Clients { get; private set; }

        public IList<IHotel> Hotels { get; private set; }

        public IList<IAccomodationProperty> Rooms { get; private set; }

        public IList<IExtra> Extras { get; private set; }

        private void InternalExtrasInitialization()
        {
            foreach (AvailableExtras extra in Enum.GetValues(typeof(AvailableExtras)))
            {
                int tier = 1;
                int price = 0;
                if (((int)extra > 5 && (int)extra < 12))
                {
                    tier = 2;
                    price = 2;
                }
                else if (((int)extra > 11 && (int)extra < 18))
                {
                    tier = 3;
                    price = 3;
                }
                else if ((int)extra > 17)
                {
                    tier = 4;
                    price = 4;
                }
                this.Extras.Add(new Extra(tier, extra, price));
            }
        }
    }
}
