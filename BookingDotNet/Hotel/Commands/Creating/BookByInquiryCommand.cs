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
    class BookByInquiryCommand: Command, ICommand
    {

        public BookByInquiryCommand(IHotelFactory factory, IData data) : base(factory, data)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            int userID;
            int hotelID;
            int roomId;
            DateTime date;

            try
            {
                userID = int.Parse(parameters[0]);
                hotelID = int.Parse(parameters[1]);
                roomId = int.Parse(parameters[2]);
                date = DateTime.ParseExact(parameters[3], "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                throw new ArgumentException("Failed to parse BookByInquiry command parameters.");
            }

            try
            {
                var user = this.Data.Clients[userID];
                var hotel = this.Data.Hotels[hotelID];
                var room = this.Data.Rooms[roomId];
            }
            catch
            {
                throw new ArgumentException("Invalid user, hotel or room!");
            }
            Data.Rooms[roomId].SaveRoom(date);
            this.Data.Clients[userID].ReserveByInquiry(this.Data.Hotels[hotelID], this.Data.Rooms[roomId], date);

            return "Reservation successfully made!";
        }
    }
}
