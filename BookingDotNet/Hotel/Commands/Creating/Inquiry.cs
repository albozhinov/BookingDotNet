using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Hotel.Commands.Creating
{
    class Inquiry
    {
        private readonly IHotelFactory factory;
        private readonly IEngine engine;

        public Inquiry(IHotelFactory factory, IEngine engine)
        {
            this.factory = factory ?? throw new ArgumentNullException();
            this.engine = engine ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
        {            
            int hotelID;
            int numOfPeople;            
            DateTime date;

            try
            {
                
                hotelID = int.Parse(parameters[0]);
                numOfPeople = int.Parse(parameters[2]);
                date = DateTime.ParseExact(parameters[3], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);                
            }
            catch
            {
                throw new ArgumentException("Failed to parse AddExtra command parameters.");
            }
            try
            {
                var hotel = this.engine.Hotels[hotelID];
            }
            catch
            {
                throw new ArgumentException("Invalid hotel!");
            }

            this.engine.Hotels[hotelID].ReserveRoom(this.engine.Hotels[hotelID], numOfPeople, extras, date);


            return "Reservation sucesfully made!";
        }

    }
}
