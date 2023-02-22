using Mapster;
using Users.Domain;

namespace Users.Dtos;

public class UserMappingsRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserDto>()
            .Map(t => t.AddressFull, 
                s => s.Address!.Street + ", " + s.Address!.Number, 
                c => c.Address != null);
    }
}