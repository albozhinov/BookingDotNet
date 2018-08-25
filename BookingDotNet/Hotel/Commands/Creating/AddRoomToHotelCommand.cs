using Hotel.Commands.Common;
using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Commands.Creating
{
    class AddRoomToHotelCommand: Command, ICommand
    {

        public AddRoomToHotelCommand(IHotelFactory factory, IData data) : base(factory, data)
        {

        }

        public override string Execute(IList<string> parameters)
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

                try
                {
                    this.Data.Hotels[hotelID].AddRoom(this.Data.Rooms[index]);
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
