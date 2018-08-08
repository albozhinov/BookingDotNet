using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Commands.Creating
{
    class BookHotel : ICommand
    {
        private readonly IHotelFactory factory;
        private readonly IEngine engine;

        public BookHotel(IHotelFactory factory, IEngine engine)
        {
            this.factory = factory ?? throw new ArgumentNullException();
            this.engine = engine ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
        {
            int userID;
            int hotelID;
            int numOfPeople;
            string extras;
            DateTime date;

            try
            {
                userID = int.Parse(parameters[0]);
                hotelID = int.Parse(parameters[1]);
                numOfPeople = int.Parse(parameters[2]);
                date = DateTime.ParseExact(parameters[3], "dd/MM/yyyy",System.Globalization.CultureInfo.InvariantCulture);
                extras = parameters[4];
            }
            catch
            {
                throw new ArgumentException("Failed to parse AddExtra command parameters.");
            }

            try
            {
                var user = this.engine.Clients[userID];
            }
            catch
            {
                throw new ArgumentException("Invalid user!");
            }
            try
            {
                var hotel = this.engine.Hotels[hotelID];
            }
            catch
            {
                throw new ArgumentException("Invalid hotel!");
            }

            this.engine.Clients[userID].ReserveRoom(this.engine.Hotels[hotelID], numOfPeople, extras, date);


            return "Reservation sucesfully made!";
        }
    }
}
