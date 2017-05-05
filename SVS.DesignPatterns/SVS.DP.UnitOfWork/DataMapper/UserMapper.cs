using SVS.DP.Common.Entities;

namespace SVS.DP.Patterns.DataMapper
{
    public class UserMapper
    {
        public User Map(UserDTO userDto)
        {
            return new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Address = userDto.Address
            };
        }
    }
}
