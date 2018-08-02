using HotelManagement.Common;
using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace HotelManagement.Models
{
    public class HotelProperty : IHotel
    {
        private string name;
        private int floors;
        private readonly List<IAccomodationProperty> rooms;

        public HotelProperty(string name, int floors)
        {
            this.Name = name;
            this.Floors = floors;
            this.rooms = new List<IAccomodationProperty>();
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

        public List<IAccomodationProperty> Rooms
        {
            get => new List<IAccomodationProperty>(this.rooms);
        }

        //This method have to be totally rewritten!!!
        public string checkAvailability(int numberOfPeople, string extras, DateTime date)
        {
            var extrasList = extras.Split(' ').ToList();
            var roomsAvailable = new List<IAccomodationProperty>();
            foreach (var room in this.rooms)
            {
                var roomExtras = room.ListOfExtras.Select(x => x.Name.ToString()).ToList();

                if (extrasList.All(i => roomExtras.Contains(i)))
                {
                    roomsAvailable.Add(room);
                }
            }
            roomsAvailable = roomsAvailable.Where(x => (x.Capacity >= numberOfPeople && ! (x.NotAvailable.Contains(date)))).ToList();
            if (roomsAvailable.Count == 0)
            {
                return "Nothing found";
            }
            else
            {
                return "Found a room";
            }
        }

        public void addRoom(IAccomodationProperty room)
        {
            Validation.CheckIfObjectIsNull(room, "Invalid room");
            this.rooms.Add(room);
        }
    }
}
