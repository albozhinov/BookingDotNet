using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Contracts;

namespace Hotel.Core.Factories
{
    public interface IHotelFactory
    {
        IHotel CreateHotel(string name, int floors, int stars);

        IRegularRoom CreateRegularRoom(int capacity, int beds, bool forSmokers, string view, decimal basePrice, int onFloor);

        IDeluxeRoom CreateDeluxeRoom(int capacity, int beds, bool forSmokers, string view, decimal basePrice, int onFloor);

        IApartment CreateApartment(int capacity, int beds, bool forSmokers, string view, decimal basePrice,
                                   bool fullyQuipped, int bedrooms, int bathrooms, int onFloor);

        IVilla CreateVilla(int numberOfFloors, int bedrooms, int bathrooms, int capacity, int beds, bool forSmokers,
                           string view, decimal basePrice);

        INaturalClient CreateNaturalRegular(int numberOfVisits, string telephoneNumber, string email, string firstName, string lastName, DateTime dateOfBirth);

        INaturalClient CreateNaturalLoyal(int numberOfVisits, string telephoneNumber, string email, string firstName, string lastName, DateTime dateOfBirth, decimal discount);

        ICorporateClient CreateCorporateRegular(int numberOfVisits, string telephoneNumber, string email, string name, int numberOfEmployees);

        ICorporateClient CreateCorporateLoyal(int numberOfVisits, string telephoneNumber, string email, string name, int numberOfEmployees, decimal discount);
    }
}
