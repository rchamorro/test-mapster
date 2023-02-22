using Users.Domain;
using Users.Dtos;

namespace Users.Dtos
{
    public partial class UsersMapper : IUsersMapper
    {
        public UserDto Map(User p1)
        {
            return p1 == null ? null : new UserDto()
            {
                Id = p1.Id,
                AddressStreet = p1.Address == null ? null : p1.Address.Street,
                AddressFull = p1.Address != null ? p1.Address.Street + ", " + (object)p1.Address.Number : null
            };
        }
    }
}