using System;
using System.Collections.Generic;
using System.Text;
using HotelManagement.Contracts;
using UserManagement.Contracts;
using Utility;

namespace UserManagement.ReservationLogic
{
    public class Reservation : IReservation
    {
        private IHotel hotel;
        private IAccomodationProperty room;
        private IClient client;
        private DateTime date;

        public Reservation(IHotel hotel, IAccomodationProperty room, IClient client, DateTime date)
        {
            this.Hotel = hotel;
            this.Room = room;
            this.Client = client;
            this.Date = date.Date;
        }

        public IHotel Hotel
        {
            get
            {
                return this.hotel;
            }
            private set
            {
                Validation.CheckIfObjectIsNull(value, Constants.invalidHotel);
                this.hotel = value;
            }
        }

        public IAccomodationProperty Room
        {
            get
            {
                return this.room;
            }
            private set
            {
                Validation.CheckIfObjectIsNull(value, Constants.invalidRoom);
                this.room = value;
            }
        }

        public IClient Client
        {
            get
            {
                return this.client;
            }
            private set
            {
                Validation.CheckIfObjectIsNull(value, Constants.invalidUser);
                this.client = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                if (value < DateTime.Now.Date)
                {
                    throw new ArgumentException("You cannot reserve a room for past dates");
                }
                this.date = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"======= Hotel: {this.Hotel.Name} || Room Type: {this.Room.GetType().Name} || Date: {this.Date.ToString("dd/MM/yyyy")}");
            return sb.ToString();
        }
    }
}
