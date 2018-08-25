using UserManagement.Models;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.Mocks
{
    public class ClientMock : Client
    {
        public ClientMock(int numOfVisits, string telephone, string email) :base(numOfVisits, telephone, email)
        {

        }
    }
}
