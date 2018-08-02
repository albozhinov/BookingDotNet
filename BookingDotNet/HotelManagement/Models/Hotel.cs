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

        public string Name { get => this.name; set { Validation.StringLengthCheck(2, 15, value, Constants.hotelName); this.name = value; } }

        public int Floors { get => this.floors; set { Validation.NumberBorderCheck(1, 15, value, Constants.numberOfFloors); this.floors = value; } }

        public List<IAccomodationProperty> Rooms { get => new List<IAccomodationProperty>(this.rooms); }

        //This method have to be totally rewritten!!!

        public string checkAvailability(int numberOfPeople, string extras, DateTime date)
        {
            var extrasList = new List<AvailableExtras>();
            
            var extrasString = extras.Split(' ');
            foreach (var extra in extrasString)
            {
                var success = Enum.TryParse(extra, out AvailableExtras result);
                if (success)
                { 
                extrasList.Add(result);
                }
                else
                {
                    Console.WriteLine($"Unable to parse {extra}");
                }
            }



            //var roomsc = this.Rooms.Where(x => extrasList.Except(x.ListOfExtras.Select(e => e.Name).ToList()).Any()).ToList();
            var rooms2 = this.Rooms.Where(x => extrasList.All(i => x.ListOfExtras.Select(e => e.Name).Contains(i))).FirstOrDefault();
            //var rooms3 = this.Rooms.Where(x => x.ListOfExtras.Select(p=>p.Name).Any(w => extrasList.Contains(w)));

            
            if(rooms2 == null)
            {
                return "Nothing found";
            }
            else
            {
                return "Found a room";
            }
        }
    }
}
