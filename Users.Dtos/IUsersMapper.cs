using Mapster;
using Users.Domain;

namespace Users.Dtos;

[Mapper]
public interface IUsersMapper
{
    UserDto Map(User source);
}