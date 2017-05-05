using NUnit.Framework;
using SVS.DP.Patterns.DataMapper;

namespace SVS.DP.Tests
{
    [TestFixture]
    public class DataMapperTests
    {
        [Test]
        public void Main()
        {
            var mapper = new UserMapper();

            var userDto = GetUserFromDb();

            var user = mapper.Map(userDto);

            Assert.IsNotNull(user);
        }

        private UserDTO GetUserFromDb()
        {
            return new UserDTO()
            {
                Id = 1,
                Dni = "12345678",
                Name = "Juan",
                LastName = "Perez",
                Address = "Jr. Puno B9"
            };
        }
    }
}
