namespace Utility
{
    public class Constants
    {
        public const string hotelName = "Hotel name cannot be less than 2 or more than 15 characters long";
        public const string priceCannotBeNegative = "The price of the room cannot be less than 0";
        public const string luxuryRoomPrice = "The price of the luxury room cannot be less than $50 and more than $1000";
        public const string regularRoomPrice = "The price of the regular room cannot be less than $20 and more than $200";
        public const string userName = "The username cannot be less than 2 characters and more than 15 characters long";
        public const string extraTier = "The tier of the extras should be between 1 and 4";
        public const string tierPriceCannotBeZero = "An extra cannot have a negative price";
        public const string commonCapacity = "The capacity must be a number between 1 and 10";
        public const string commonBeds = "The amount of beds must be a number between 1 and 10";
        public const string commonBasePrice = "The base price of a room should be a number between 50 and 400";
        public const string floorCannotBeNegative = "The floor cannot be a negative number";
        public const string regularRoomCapacity = "The capacity of the regular room cannot be less than 1 and more than 2 people";
        public const string regularRoomBeds = "The beds in a regular room cannot be less than 1 and more than 2";
        public const string regularRoomExtra = "The extras in a regular room cannot be from a tier higher than 1";
        public const string deluxeRoom = "The extras in a regular room cannot be from a higher tier than 2";

    }
}