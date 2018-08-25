using HotelManagement.Common;
using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace HotelManagement.Models
{
    public class HotelProperty : IHotel
    {
        private string name;
        private int floors;
        private int stars;

        public HotelProperty(string name, int floors, int stars)
        {
            this.Name = name;
            this.Floors = floors;
            this.Stars = stars;
            this.Rooms = new List<IAccomodationProperty>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                Validation.StringLengthCheck(2, 15, value, Constants.hotelName);
                this.name = value;
            }
        }

        public int Floors
        {
            get => this.floors;
            set
            {
                Validation.NumberBorderCheck(1, 15, value, Constants.numberOfFloors);
                this.floors = value;
            }
        }

        public int Stars
        {
            get => this.stars;
            set
            {
                Validation.NumberBorderCheck(1, 5, value, Constants.hotelStars);
                this.stars = value;
            }
        }

        public List<IAccomodationProperty> Rooms { get; }

        public IAccomodationProperty checkAvailability(int numberOfPeople, string extras, DateTime date)
        {
            var extrasList = extras.Split(',').ToList();
            var roomsAvailable = new List<IAccomodationProperty>();
            foreach (var room in this.Rooms)
            {
                var roomExtras = room.ListOfExtras.Select(x => x.Name.ToString()).ToList();

                if (extrasList.All(i => roomExtras.Contains(i)))
                {
                    roomsAvailable.Add(room);
                }
            }
            var roomSelected = roomsAvailable.Where(x => (x.Capacity >= numberOfPeople && ! (x.NotAvailable.Contains(date)))).FirstOrDefault();
            if(roomSelected != null)
            {
                roomSelected.SaveRoom(date.Date);
            }
            return roomSelected;
        }


        public void AddRoom(IAccomodationProperty room)
        {
            Validation.CheckIfObjectIsNull(room, "Invalid room");
            if (this.Rooms.Contains(room))
            {
                throw new ArgumentException($"Room {this.Rooms.IndexOf(room)} already exists in {this.Name} hotel!");
            }
            this.Rooms.Add(room);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"=== Information for hotel: {this.Name}");
            sb.AppendLine($"===== Stars: {this.Stars} *");
            sb.AppendLine($"===== Number of floors: {this.Floors}");
            if(this.Rooms.Count == 0)
            {
                sb.AppendLine("===== No rooms added in this hotel.");
            }
            else
            {
                sb.AppendLine("===== Rooms:");
                foreach (var room in this.Rooms)
                {
                    sb.AppendLine(room.ToString());
                }
            }
            return sb.ToString();
        }
    }
}
