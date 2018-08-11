using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using HotelManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Commands.Creating
{
    class AddExtra : ICommand
    {
        private readonly IHotelFactory factory;
        private readonly IEngine engine;

        public AddExtra(IHotelFactory factory, IEngine engine)
        {
            this.factory = factory ?? throw new ArgumentNullException();
            this.engine = engine ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
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
                var room = this.engine.Rooms[roomIndex];
            }
            catch
            {
                throw new ArgumentException("Invalid room!");
            }
            try
            {
                var extra = this.engine.Extras[id];

            }
            catch
            {
                throw new ArgumentException("Invalid extra!");
            }
            if (this.engine.Rooms[roomIndex].ListOfExtras.Contains(this.engine.Extras[id]))
            {
                throw new ArgumentException("Extra already exists!");
            }
            this.engine.Rooms[roomIndex].AddExtra(this.engine.Extras[id]);
            
           

            return $"{this.engine.Extras[id].Name.ToString()} added to room with ID: {roomIndex}";
        }
    }
}
