using Hotel.Commands.Common;
using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Hotel.Commands.Creating
{
    class CreateHotelCommand : Command, ICommand
    {
        private IWriter writer;
        public CreateHotelCommand(IHotelFactory factory, IData data, IWriter writer) : base(factory, data)
        {
            this.writer = writer;
        }

        public override string Execute(IList<string> parameters)
        {
            string name;
            int floors;
            int stars;
            List<int> roomIndexes;

            try
            {
                name = parameters[0];
                floors = int.Parse(parameters[1]);
                stars = int.Parse(parameters[2]);
                roomIndexes = parameters[3].Split(",").Select(x => int.Parse(x)).ToList();
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateHotel command parameters.");
            }

            var hotel = this.Factory.CreateHotel(name, floors,stars);

            foreach(var index in roomIndexes)
            {
                if (index >= this.Data.Rooms.Count)
                {
                    this.writer.WriteLine($"Room with ID: {index} cannot be added to the hotel, because it doesn't exist!");
                }
                else
                {
                    hotel.AddRoom(this.Data.Rooms[index]);
                }
            }
            
            this.Data.Hotels.Add(hotel);

            return $"Hotel with ID {Data.Hotels.Count - 1} was created.";
        }
    }
}
