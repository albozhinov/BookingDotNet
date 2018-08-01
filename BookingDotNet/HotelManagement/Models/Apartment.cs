using HotelManagement.Common;
using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Utility;


namespace HotelManagement.Models
{
    class Apartment : AccomodationProperty, IApartment
    {
        private bool fullyQuipped;
        private int bedrooms;
        private int bathrooms;
        private int onFloor;

        // Constructor
        public Apartment()
        {

        }

        // Properties
        public bool FullyQuipped
        {
            get => this.fullyQuipped;
            set => this.fullyQuipped = value;
        }

        public int Bedrooms
        {
            get => this.bedrooms;
            set
            {
                this.bedrooms = value;
            }
        }

        public int Bathrooms
        {
            get => this.bathrooms;
            set
            {
                this.bathrooms = value;
            }
        }

        public int OnFloor
        {
            get => this.onFloor;
        }
    }
}
