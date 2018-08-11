using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Commands.Creating
{
    class AddRoomToHotel: ICommand
    {
        private readonly IHotelFactory factory;
        private readonly IEngine engine;

        public AddRoomToHotel(IHotelFactory factory, IEngine engine)
        {
            this.factory = factory ?? throw new ArgumentNullException();
            this.engine = engine ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
        {
            int hotelID;
            List<int> roomIndexes;
            List<int> addedRooms = new List<int>();

            try
            {
                hotelID = int.Parse(parameters[0]);
                roomIndexes = parameters[1].Split(",").Select(x => int.Parse(x)).ToList();
            }
            catch
            {
                throw new ArgumentException("Failed to parse AddRoomToHotel command parameters.");
            }

            foreach (var index in roomIndexes)
            {
                //if(index >= this.engine.Rooms.Count)
                //{
                //    throw new ArgumentException($"Room with ID { index } was not added as it does not exist!");
                //}
                try
                {
                    this.engine.Hotels[hotelID].AddRoom(this.engine.Rooms[index]);
                    addedRooms.Add(index);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Room with ID { index } was not added as it does not exist!");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
            if (addedRooms.Count == 0)
            {
                return "No rooms added";
            }
            else
            {
                return $"Rooms with IDs {String.Join(",", addedRooms)} added to hotel with ID: {hotelID}";
            }

        }

    }
}
