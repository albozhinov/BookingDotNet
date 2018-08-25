using System;
using System.Collections.Generic;
using System.Text;
using HotelManagement.Contracts;
using HotelManagement.Models;
using UserManagement.Models;
using UserManagement.Contracts;

namespace Hotel.Core.Factories
{
    public class HotelFactory : IHotelFactory
    {


        //Create Hotel

        public IHotel CreateHotel(string name, int floors, int stars)
        {
            return new HotelProperty(name, floors, stars);
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
            return new Villa(numberOfFloors, bedrooms, bathrooms, capacity, beds, forSmokers, view, basePrice);
        }

        //Create Clients

        public INaturalClient CreateNaturalRegular(int numberOfVisits, string telephoneNumber, string email, string firstName, string lastName, DateTime dateOfBirth)
                          
        {
            return new NaturalRegular(numberOfVisits, telephoneNumber, email, firstName, lastName, dateOfBirth);
        }

        public INaturalClient CreateNaturalLoyal(int numberOfVisits, string telephoneNumber, string email, string firstName, string lastName, DateTime dateOfBirth, decimal discount)

        {
            return new NaturalLoyal(numberOfVisits, telephoneNumber, email, firstName, lastName, dateOfBirth, discount);
        }

        public ICorporateClient CreateCorporateRegular(int numberOfVisits, string telephoneNumber, string email, string name, int numberOfEmployees)
              
        {
            return new CorporateRegular(numberOfVisits, telephoneNumber, email, name, numberOfEmployees);
        }

        public ICorporateClient CreateCorporateLoyal(int numberOfVisits, string telephoneNumber, string email, string name, int numberOfEmployees, decimal discount)

        {
            return new CorporateLoyal(numberOfVisits, telephoneNumber, email, name, numberOfEmployees, discount);
        }
    }
}
