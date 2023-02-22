namespace Projects.Domain;

public class Project
{
    public string Name { get; set; } = "Project";

    public List<Issue> Issues { get; set; } = new();

}

public abstract class Issue
{
    public IssuePriority Priority { get; set; }
}

public class UserStory : Issue
{
    public DateTime DueDate { get; set; } = DateTime.Now;
}

public class Epic : Issue
{
    public string Owner { get; set; } = "Owner";

    public List<UserStory> UserStories { get; set; } = new();
}