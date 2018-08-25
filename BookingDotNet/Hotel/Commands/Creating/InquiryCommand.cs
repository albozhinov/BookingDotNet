using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HotelManagement.Contracts;
using Hotel.Commands.Contracts;
using Hotel.Commands.Common;
using Hotel.Core.DataStorage;

namespace Hotel.Commands.Creating
{
    public class InquiryCommand : Command, ICommand
    {


        public InquiryCommand(IHotelFactory factory, IData data) : base(factory, data)
        {

        }

        public override string Execute(IList<string> parameters)
        {            
            int hotelID;
            int numOfPeople;            
            DateTime date;

            try
            {
                
                hotelID = int.Parse(parameters[0]);
                numOfPeople = int.Parse(parameters[1]);
                date = DateTime.ParseExact(parameters[2], "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                if (date < DateTime.Now || this.Data.Hotels.Count < hotelID)
                {
                    throw new ArgumentException("Date or hotel ID is not valid.");
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to parse Inquiry command parameters.");
            }

            List<IAccomodationProperty> roomsSelected = this.Data.Hotels[hotelID].Rooms.Where(x => x.Capacity >= numOfPeople).ToList();


            return $"All rooms: {String.Join("",this.Data.Hotels[hotelID].Rooms.Count)} " +
                $"\n\rAvailable rooms: {roomsSelected.Count} \n\r{String.Join(Environment.NewLine,roomsSelected)}";
        }

    }
}
