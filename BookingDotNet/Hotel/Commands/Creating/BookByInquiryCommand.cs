using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Commands.Creating
{
    class BookByInquiryCommand: ICommand
    {
        private readonly IHotelFactory factory;
        private readonly IEngine engine;

        public BookByInquiryCommand(IHotelFactory factory, IEngine engine)
        {
            this.factory = factory ?? throw new ArgumentNullException();
            this.engine = engine ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
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
                var user = this.engine.Clients[userID];
                var hotel = this.engine.Hotels[hotelID];
                var room = this.engine.Rooms[roomId];
            }
            catch
            {
                throw new ArgumentException("Invalid user, hotel or room!");
            }
            engine.Rooms[roomId].SaveRoom(date);
            this.engine.Clients[userID].ReserveByInquiry(this.engine.Hotels[hotelID], this.engine.Rooms[roomId], date);

            return "Reservation successfully made!";
        }
    }
}
