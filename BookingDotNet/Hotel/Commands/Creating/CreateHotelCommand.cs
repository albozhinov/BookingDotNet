using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Hotel.Commands.Creating
{
    class CreateHotelCommand : ICommand
    {

        private readonly IHotelFactory factory;
        private readonly IEngine engine;

        public CreateHotelCommand(IHotelFactory factory, IEngine engine)
        {
            this.factory = factory ?? throw new ArgumentNullException();
            this.engine = engine ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
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

            var hotel = this.factory.CreateHotel(name, floors,stars);

            foreach(var index in roomIndexes)
            {
                if (index >= this.engine.Rooms.Count)
                {
                    this.engine.Writer.WriteLine($"Room with ID: {index} cannot be added to the hotel, because it doesn't exist!");
                }
                else
                {
                    hotel.AddRoom(this.engine.Rooms[index]);
                }
            }
            
            this.engine.Hotels.Add(hotel);

            return $"Hotel with ID {engine.Hotels.Count - 1} was created.";
        }
    }
}
