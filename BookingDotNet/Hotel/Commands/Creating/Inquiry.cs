using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HotelManagement.Contracts;
using Hotel.Commands.Contracts;

namespace Hotel.Commands.Creating
{
    class Inquiry : ICommand
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
                numOfPeople = int.Parse(parameters[1]);
                date = DateTime.ParseExact(parameters[2], "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                if (date < DateTime.Now || this.engine.Hotels.Count < hotelID)
                {
                    throw new ArgumentException("Date or hotel ID is not valid.");
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to parse Inquiry command parameters.");
            }

            List<IAccomodationProperty> roomsSelected = this.engine.Hotels[hotelID].Rooms.Where(x => x.Capacity >= numOfPeople).ToList();


            return $"All rooms: {String.Join("",this.engine.Hotels[hotelID].Rooms.Count)} " +
                $"\n\rAvailable rooms: {roomsSelected.Count} \n\r{String.Join(Environment.NewLine,roomsSelected)}";
        }

    }
}
