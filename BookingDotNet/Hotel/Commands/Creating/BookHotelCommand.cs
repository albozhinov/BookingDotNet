using Hotel.Commands.Common;
using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Commands.Creating
{
    class BookHotelCommand : Command, ICommand
    {

        public BookHotelCommand(IHotelFactory factory, IData data) : base(factory, data)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            int userID;
            int hotelID;
            int numOfPeople;
            DateTime date;
            string extras;
            
            try
            {
                userID = int.Parse(parameters[0]);
                hotelID = int.Parse(parameters[1]);
                numOfPeople = int.Parse(parameters[2]);
                date = DateTime.ParseExact(parameters[3], "d/M/yyyy",System.Globalization.CultureInfo.InvariantCulture);
                extras = parameters[4];
            }
            catch
            {
                throw new ArgumentException("Failed to parse BookHotel command parameters.");
            }

            try
            {
                var user = this.Data.Clients[userID];
            }
            catch
            {
                throw new ArgumentException("Invalid user!");
            }
            try
            {
                var hotel = this.Data.Hotels[hotelID];
            }
            catch
            {
                throw new ArgumentException("Invalid hotel!");
            }

            this.Data.Clients[userID].ReserveRoom(this.Data.Hotels[hotelID], numOfPeople, extras, date);

            return "Reservation successfully made!";
        }
    }
}
