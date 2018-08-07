using System;
using System.Collections.Generic;
using System.Text;
using HotelManagement.Contracts;
using UserManagement.Contracts;
using UserManagement.ReservationLogic;
using Utility;

namespace UserManagement.Models
{
    public class Client : IClient
    {
        private int numberOfVisits;
        private string telephoneNumber;
        private string email;
        private readonly List<IReservation> reservations;

        public Client(int numberOfVisits, string telephoneNumber, string email)
        {
            this.NumberOfVisits = numberOfVisits;
            this.TelephoneNumber = telephoneNumber;
            this.Email = email;
            this.RegisteredOn = DateTime.Now.Date;
            this.reservations = new List<IReservation>();
        }

        public DateTime RegisteredOn { get; set; }
        public int NumberOfVisits
        {
            get
            {
                return this.numberOfVisits;
            }
            set
            {
                Validation.CantBeZero(value, Constants.numberOfVisits);
                this.numberOfVisits = value;
            }
        }
        public string TelephoneNumber
        {
            get
            {
                return this.telephoneNumber;
            }
            set
            {
                Validation.StringLengthCheck(8, 12, value, Constants.telNo);
                Validation.isNumber(value, Constants.telNoNum);
                this.telephoneNumber = value;
            }
        }
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                Validation.StringLengthCheck(8, 30, value, Constants.email);
                this.email = value;
            }
        }

        public List<IReservation> Reservations
        {
            get
            {
                return new List<IReservation>(this.reservations);
            }
        }

        public void ReserveRoom(IHotel hotel, int numberOfPeople, string extras, DateTime date)
        {
            IAccomodationProperty roomFound = hotel.checkAvailability(numberOfPeople, extras, date);

            Validation.CheckIfObjectIsNull(roomFound, Constants.roomNotFound);

            this.reservations.Add(new Reservation(hotel, roomFound, this, date));

        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"== Information for user with registration email: {this.Email}");
            sb.AppendLine($"===== Registration date: {this.RegisteredOn.ToString("dd/MM/yyyy")}");
            sb.AppendLine($"===== Telephone number: {this.TelephoneNumber}");
            sb.AppendLine($"===== Visits booked: {this.NumberOfVisits}");
            if(this.Reservations.Count == 0)
            {
                sb.AppendLine("===== No reservations pending at this moment");
            }
            else
            {
                sb.AppendLine("===== Reservations: ");
                foreach(var reservation in this.Reservations)
                {
                    sb.AppendLine(reservation.ToString());
                }
            }
            return sb.ToString();
        }
    }
}
