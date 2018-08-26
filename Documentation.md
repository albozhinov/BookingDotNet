# Team Name: Pichovete
# Team Members:
    - Drago
    - Alex(Bozhinov)
    - Teo

# Booking API Documentation


Booking is an app that enables its users to easily create hotels, add rooms to them and use reservation logic. The application also provides functionallity for user system with several pre-defined user types. The application relies on the implementation of a command design patterns. The basic commands for controlling the application are predefined, but users can easily add more commands.


# User Types
The application includes the following user types: 

  - Regular Natural Client
  - Loyal Natural Client
  - Regular Corporate Client
  - Loyal Corporate Client

The functionalities of these classes are provided by a 3-levels of depth inheritance structure, offering the users of the application to easily implement more user types according to their needs. All user types MUST implement the IClient interface, in order to be user by the application. The abstract classes that are defined are the following:

  - Client - Second level of inheritance. Takes care of the basic properties, that a class of type client NEED to have, in order to be registered in the pseudo-storage of the application.
  - NaturalClient - Third level of inheritance. Provides the properties common for all types of Natural Client classes.
  - Corporate Client - Third level of inheritance. Provides the properties common for all types of Corporate Client.

Of course, more abstract classes can be derived by implementing the IClient interface. 

# Accomodation Properties

The basic, common types of properties, that you'd find in a hotel are already implemented in the application. Adding a new type of property is easy - you just have to inherit the IAccomodationProperty interface. In order to save some time and spare some duplicate code, you can also inherit the AccomodationProperty class. It provides the basic implementation for properties. 

# Commands
| Command | Parameters | Brief Explanation
| ------ | ------ | ------ |
|createregularroom|int capacity, int beds, bool forSmokers, string view(Sea,Mountain,City), decimal basePrice, int onFloor| Command for creating accomodation property of type: Regular Room |
|createdeluxeroom|int capacity , int beds , bool forSmokers , string view(Sea,Mountain,City) , decimal basePrice , int onFloor| Command for creating accomodation property of type: Deluxe Room |
|createapartment|int capacity , int beds , bool forSmokers , string view(Sea,Mountain,City) , decimal basePrice , bool fullyEquipped , int bedrooms , int bathrooms , int onFloor| Command for creating accomodation property of type: Apartment  |
|createvilla|int numberOfFloors , int bedrooms , int bathrooms , int capacity , int beds , bool forSmokers , string view , decimal basePrice| Command for creating accomodation property of type: Villa  |
|createhotel|string name , int floors , int stars , string of [coma-delimated integers]| Command for creating a Hotel  |
|createcorporateregular|string name , int numberOfEmployees , int numberOfVisits , string telephoneNumber , string email| Command for creating a user of type: Corporate Regular  |
|createcorporateloyal|decimal discount , string name , int numberOfEmployees , int numberOfVisits , string telephoneNumber , string email| Command for creating a user of type: Corporate Loyal  |
|createnaturalregular|string firstName , string lastName , DateTime dd/MM/yyyy , int numberofvisits , string telephonenumber , string email| Command for creating a user of type: Regular Natural  |
|createnaturalloyal|string firstName , string lastName , DateTime dd/MM/yyyy , int numberofvisits , string telephonenumber , string email| Command for creating a user of type: Loyal Natural  |
|addextra|int id , int roomIndex : id of the extra(number in list) / index of the room in the list of rooms| roomIndex can be found from the listroomsinhotel commands |
|addroomtohotel|int hotelID , comma delimated room indexes| roomIndex can be found from the listrooms in hotel command. hotelID can be found from the listhotel command |
|inquiry| int hotelID , int numOfPeople , DateTime in format "d/M/yyyy"| Check availability of rooms by certain parameters|
|bookbyInquiry|int userID , int hotelID , int roomID , DateTime in format "d/M/yyyy"|Book room
|bookHotel|int userID , int hotelID , int number of people , DateTime in format "d/M/yyyy" , string of extras delimated by ,|Book a room by certain requirments(extras, capacity and Date|
|listusers|No params|List all users registered in the app|
|listhotel|No params| List all hotels|
|listroomsinhotel|int hotelID| list all rooms in a certain hotel|

# Design Pattterns

The application makes use of several design patterns, in order to make it as easy for maintainance as possible.
The core of the application is using the Command Design Patterns. Commands are automatically registered by autofac, and are called by typing their name in the console. For example for the listusers command you'd write listusers in the console and the app, with the help of autofac, will do the magic for you. The command patter suits the situation very well, since it's very easy to be extended with absolutely no inner modifications. 
Factory design pattern is used to simplify the creation of the models. All models are created via the HotelFactory class. The logic of the creation can be easily changed, due to the fact that polymorphism is used in every possible aspect of the application. You can simply make your own factory logic, that implements the IHotelFactory interface, change the registered type in the autofac config class(InjectorModule.cs), and the application will start using the new factory logic.
Singleton is used in the application, although not direclty. It is absolutely crucial for the data class ListDataStorage.cs to be single instance, since it is the pseudo database of the application. All created model objects are kept in it. Singleton is achieved via the autofac method - SingleInstance().

# Solid Principles

By using our application you can be sure that you are using a product, that follows the SOLID principles. Each of the modules of the application is written in such a way that it fulfils a single purpose. The API can be easily extended - most of its logic is working through interfaces, so the functionality of every single module can be easily replaced according to the needs of the user. Child classes do not mess with the functionality of their parents - they are connected types that provide a bit different implementation without breaking the logic of the base classes. Interfaces are small. Dependancy injection is used in all modules. Objects that have dependancies are receiving them from the outside. Inversion of control container is used to maintain these dependancies for the purpose of simplicity and automatization of the addition of new types.

# Problems encountered

Before the process of refractoring the application was following the SOLID principles pretty good, already. The main problem encountered was the lack of dependancy injenction in some of our classes. All of our dependancies had to be dealt inside the classes that use them. A problem like that is serious, because is creates strong coupling between the class and its dependancies. A potential change can lead to a lot of extra work. We solved this problem with the help of Inversion of control container - autofac. 