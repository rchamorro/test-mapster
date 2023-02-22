using Mapster;
using Projects.Domain;
using Projects.Dtos;
using Users.Domain;
using Users.Dtos;

namespace Tests;

[TestFixture]
public class TestMapster
{
    [SetUp]
    public void Setup()
    {
        TypeAdapterConfig.GlobalSettings
            .Scan(
                typeof(UserDto).Assembly,
                typeof(ProjectDto).Assembly);
    }

    [Test]
    public void SimpleMapping()
    {
        var source = new User {Id = 1, Address = new Address {Street = "Calle"}};
        var target = source.Adapt<UserDto>();
        Assert.That(source.Id, Is.EqualTo(target.Id));
        Assert.That(source.Address.Street, Is.EqualTo(target.AddressStreet));
    }

    [Test]
    public void ComplexMapping()
    {
        var source = new Project
        {
            Name = "Project",
            Issues = new List<Issue>
            {
                new UserStory
                {
                    Priority = IssuePriority.High,
                    DueDate = new DateTime(2022, 01, 05)
                },
                new Epic
                {
                    Owner = "Owner",
                    Priority = IssuePriority.Low,
                    UserStories = new List<UserStory>
                    {
                        new () {Priority = IssuePriority.Medium, DueDate = new DateTime(2022, 02, 07)},
                    }
                }
            }
        };
        var target = source.Adapt<ProjectDto>();
        Assert.That(target.Name, Is.EqualTo(source.Name));
        Assert.That(target.Issues.Count, Is.EqualTo(source.Issues.Count));
        Assert.That(target.Issues[0], Is.TypeOf<UserStoryDto>());
        Assert.That(target.Issues[0].Priority, Is.EqualTo(source.Issues[0].Priority));
        Assert.That(((UserStoryDto) target.Issues[0]).DueDate, Is.EqualTo(((UserStory) source.Issues[0]).DueDate));
        Assert.That(target.Issues[1], Is.TypeOf<EpicDto>());
        Assert.That(target.Issues[1].Priority, Is.EqualTo(source.Issues[1].Priority));
        Assert.That(((EpicDto) target.Issues[1]).Owner, Is.EqualTo(((Epic) source.Issues[1]).Owner));
        Assert.That(((EpicDto) target.Issues[1]).UserStories.Count, Is.EqualTo(((Epic) source.Issues[1]).UserStories.Count));
        Assert.That(((EpicDto) target.Issues[1]).UserStories[0].Priority, Is.EqualTo(((Epic) source.Issues[1]).UserStories[0].Priority));
    }
    
    [Test]
    public void ValidateConfiguration()
    {
        // TypeAdapterConfig.GlobalSettings.RequireDestinationMemberSource = true;
        // TypeAdapterConfig.GlobalSettings.RequireExplicitMapping = true;
        TypeAdapterConfig.GlobalSettings.Compile();
    }
}