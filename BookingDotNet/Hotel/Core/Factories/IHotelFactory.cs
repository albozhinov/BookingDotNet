using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Contracts;

namespace Hotel.Core.Factories
{
    interface IHotelFactory
    {
        IHotel CreateHotel(string name, int floors);

        IRegularRoom CreateRegularRoom(int capacity, int beds, bool forSmokers, string view, decimal basePrice, int onFloor);
        IDeluxeRoom CreateDeluxeRoom(int capacity, int beds, bool forSmokers, string view, decimal basePrice, int onFloor);
        IApartment CreateApartment(int capacity, int beds, bool forSmokers, string view, decimal basePrice,
            bool fullyQuipped, int bedrooms, int bathrooms, int onFloor);
        IVilla CreateVilla(int numberOfFloors, int bedrooms, int bathrooms, int capacity, int beds, bool forSmokers,
            string view, decimal basePrice);

        INaturalClient CreateNaturalRegular(string firstName, string lastName, DateTime dateOfBirth, DateTime registeredOn,
                        int numberOfVisits, string telephoneNumber, string email);
        INaturalClient CreateNaturalLoyal(string firstName, string lastName, DateTime dateOfBirth, DateTime registeredOn,
                            int numberOfVisits, string telephoneNumber, string email, decimal discount);
        ICorporateClient CreateCorporateRegular(string name, int numberOfEmployees, DateTime registeredOn, int numberOfVisits,
             string telephoneNumber, string email);
        ICorporateClient CreateCorporateLoyal(decimal discount, string name, int numberOfEmployees, DateTime registeredOn, int numberOfVisits,
             string telephoneNumber, string email);
    }
}
