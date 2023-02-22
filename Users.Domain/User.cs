namespace Users.Domain;

public class Address
{
    public string Street { get; set; } = "Tu calle";
    public int Number { get; set; } = 13;
}

public class User
{
    public int Id { get; set; }

    public Address? Address { get; set; }
}