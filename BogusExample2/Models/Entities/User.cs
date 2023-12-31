using BogusExample2.Entities;
using BogusExample2.Models.Enums;

namespace BogusExample2.Models.Entities;

public class User
{
    public User(int userId, string ssn)
    {
        Id = userId;
        Ssn = ssn;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string SomethingUnique { get; set; }
    public Guid SomeGuid { get; set; }

    public string Avatar { get; set; }
    public Guid CartId { get; set; }
    public string Ssn { get; set; }
    public Gender Gender { get; set; }

    public List<Order> Orders { get; set; }
}