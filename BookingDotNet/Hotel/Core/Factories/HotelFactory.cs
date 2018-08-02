﻿using System;
using System.Collections.Generic;
using System.Text;
using HotelManagement.Contracts;
using HotelManagement.Models;


namespace Hotel.Core.Factories
{
    class HotelFactory : IHotelFactory
    {
        private static IHotelFactory instanceHolder = new HotelFactory();

        private HotelFactory()
        {
        }

        public static IHotelFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        //Create Hotel

        public IHotel CreateHotel(string name, int floors)
        {
            return new Hotel(name, floors);
        }

        //Create Rooms

        public IRegularRoom CreateRegularRoom(int capacity, int beds, bool forSmokers, string view, decimal basePrice, int onFloor)
        {
            return new RegularRoom(capacity, beds, forSmokers, view, basePrice, onFloor);
        }

        public IDeluxeRoom CreateDeluxeRoom(int capacity, int beds, bool forSmokers, string view, decimal basePrice, int onFloor)
        {
            return new DeluxeRoom(capacity, beds, forSmokers, view, basePrice, onFloor);
        }

        public IApartment CreateApartment(int capacity, int beds, bool forSmokers, string view, decimal basePrice,
            bool fullyQuipped, int bedrooms, int bathrooms, int onFloor)
        {
            return new Apartment(capacity, beds, forSmokers, view, basePrice, fullyQuipped, bedrooms, bathrooms, onFloor);
        }

        public IVilla CreateVilla(int numberOfFloors, int bedrooms, int bathrooms, int capacity, int beds, bool forSmokers,
            string view, decimal basePrice)
        {
            return new Apartment(numberOfFloors, bedrooms, bathrooms, capacity, beds, forSmokers, view, basePrice);
        }

        //Create Clients

        public INatural CreateNaturalRegular(string firstName, string lastName, DateTime dateOfBirth, DateTime registeredOn,
                        int numberOfVisits, string telephoneNumber, string email)
        {
            return new NaturalRegular(firstName, lastName, dateOfBirth, registeredOn, numberOfVisits, telephoneNumber, email);
        }

        public INatural CreateNaturalLoyal(string firstName, string lastName, DateTime dateOfBirth, DateTime registeredOn,
                            int numberOfVisits, string telephoneNumber, string email, decimal discount)
        {
            return new NaturalLoyal(firstName, lastName, dateOfBirth, registeredOn, numberOfVisits, telephoneNumber, email, discount);
        }

        public ICorporate CreateCorporateRegular(string name, int numberOfEmployees, DateTime registeredOn, int numberOfVisits,
             string telephoneNumber, string email)
        {
            return new CorporateRegular(name, numberOfEmployees, registeredOn, numberOfVisits, telephoneNumber, email);
        }

        public ICorporate CreateCorporateLoyal(decimal discount, string name, int numberOfEmployees, DateTime registeredOn, int numberOfVisits,
             string telephoneNumber, string email)
        {
            return new CorporateRegular(discount, name, numberOfEmployees, registeredOn, numberOfVisits, telephoneNumber, email);
        }
    }
}
