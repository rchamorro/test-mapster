using Projects.Domain;

namespace Projects.Dtos;

public class ProjectDto
{
    public string Name { get; set; } = "";

    public List<IssueDto> Issues { get; private set; } = new();
}

public class IssueDto
{
    public IssuePriority Priority { get; init; }
}

public class UserStoryDto : IssueDto
{
    public DateTime DueDate { get; set; } = DateTime.Now;
}

public class EpicDto : IssueDto
{
    public string Owner { get; set; } = "";

    public List<UserStoryDto> UserStories { get; private set; } = new();
}