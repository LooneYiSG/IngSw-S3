namespace IngSw_Domain.Entities;

public class Employee : Person
{
    public string? Registration { get; set; }
    public Guid? IdUser{ get; set; }
    public User User { get; set; }
    public string? PhoneNumber { get; set; }
}
