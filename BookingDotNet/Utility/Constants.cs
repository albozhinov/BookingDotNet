﻿namespace Utility
{
    public class Constants
    {
        public const string hotelName = "Hotel name cannot be less than 2 or more than 15 characters long.";
        public const string hotelStars = "Hotel stars must be a number between 1 and 5.";
        public const string priceCannotBeNegative = "The price of the room cannot be less than 0.";
        public const string userName = "The username cannot be less than 2 characters and more than 15 characters long.";
        public const string extraTier = "The tier of the extras should be between 1 and 4.";
        public const string extraTierApart = "The extras in an apartment cannot be from a tier higher than 3";
        public const string tierPriceCannotBeZero = "An extra cannot have a negative price.";
        public const string commonCapacity = "The capacity must be a number between 1 and 10.";
        public const string deluxeRoomCapacity = "The capacity must be a number between 1 and 3.";
        public const string apartmentCapacity = "The capacity must be a number between 1 and 6.";
        public const string villaCapacity = "The capacity must be a number between 1 and 8.";
        public const string commonBeds = "The amount of beds must be a number between 1 and 10.";
        public const string roomBeds = "The amount of beds must be a number between 1 and 2.";
        public const string apartmentBeds = "The amount of beds must be a number between 1 and 6.";
        public const string villaBeds = "The amount of beds must be a number between 1 and 8.";
        public const string commonBasePrice = "The base price of a room should be a number between 50 and 400.";
        public const string telNo = "The telephone cannot be less than 8 or more than 12 characters long.";
        public const string telNoNum = "The telephone may contain only numbers.";
        public const string email = "The e-mail cannot be less than 8 or more than 20 characters long.";
        public const string villaFloors = "The floors in a villa should be between 1 and 3.";
        public const string floorCannotBeNegative = "The floor cannot be a negative number.";
        public const string regularRoomCapacity = "The capacity of the regular room cannot be less than 1 and more than 2 people.";        
        public const string regularRoomExtra = "The extras in a regular room cannot be from a tier higher than 1.";
        public const string numberOfVisits = "The number of visits cannot be less than 0.";
        public const string discount = "Discount cannot be less than 5% or more than 20%.";
        public const string extraTierdeluxeRoom = "The extras in a deluxe room cannot be from a higher tier than 2.";
        public const string villaBedrooms = "A villa cannot have less than 1 or more than 3 bedrooms.";
        public const string villaBathrooms = "A villa cannot have less than 1 or more than 3 bathrooms.";
        public const string numberOfEmployees = "A corporate client cannot have a negative number of employees.";
        public const string numberOfFloors = "A hotel cannot have less than 1 or more than 15 floors";
        public const string apartmentBedrooms = "The apartment cannot have less than 2 or more than 3 bedrooms.";
        public const string apartmentBathrooms = "The apartment cannot have less than 1 or more than 3 bathrooms.";
        public const string apartmentFloor = "The apartment floor cannot be negative.";
        public const string clientAge = "The age of client cannot be less than 18 and more than 100.";
        public const string invalidHotel = "Hotel is invalid";
        public const string invalidUser = "User is invalid";
        public const string invalidRoom = "Room is invalid";
        public const string roomNotFound = "There are no rooms available in the hotel you selected with this parameters. Please try searching for less extras, or different dates";
        public const string corpName = "Company name cannot be less than 3 or more than 20 characters long.";
        public const string invalidExtra = "This extra is invalid!";

    }
}