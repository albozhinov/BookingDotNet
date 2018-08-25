using Hotel.Commands.Common;
using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;
using HotelManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Commands.Creating
{
    public class AddExtraCommand : Command, ICommand
    {

        public AddExtraCommand(IHotelFactory factory, IData data) : base(factory, data)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            int id;
            int roomIndex;

            try
            {
                id = int.Parse(parameters[0]);
                roomIndex = int.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse AddExtra command parameters.");
            }
            try
            {
                var room = this.Data.Rooms[roomIndex];
            }
            catch
            {
                throw new ArgumentException("Invalid room!");
            }
            try
            {
                var extra = this.Data.Extras[id];

            }
            catch
            {
                throw new ArgumentException("Invalid extra!");
            }
            if (this.Data.Rooms[roomIndex].ListOfExtras.Contains(this.Data.Extras[id]))
            {
                throw new ArgumentException("Extra already exists!");
            }
            this.Data.Rooms[roomIndex].AddExtra(this.Data.Extras[id]);
            
           

            return $"{this.Data.Extras[id].Name.ToString()} added to room with ID: {roomIndex}";
        }
    }
}
