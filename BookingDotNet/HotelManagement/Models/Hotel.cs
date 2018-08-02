﻿using HotelManagement.Common;
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

        public bool checkAvailability(int numberOfPeople, string extras, DateTime date)
        {
            var extrasList = new List<AvailableExtras>();
            var extrasString = extras.Split(" ");
            foreach (var extra in extrasString)
            {
                Enum.TryParse(extra, out AvailableExtras result);
                extrasList.Add(result);
            }



            var rooms = this.Rooms.Where(x => !!extrasList.Except(x.ListOfExtras.Select(e => e.Name).ToList()).Any()).ToList();


            return true;
        }
    }
}
