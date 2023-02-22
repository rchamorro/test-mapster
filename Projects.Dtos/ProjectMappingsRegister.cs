using Mapster;
using Projects.Domain;

namespace Projects.Dtos;

public class ProjectMappingsRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Issue, IssueDto>()
            .Include<UserStory, UserStoryDto>()
            .Include<Epic, EpicDto>();
    }
}