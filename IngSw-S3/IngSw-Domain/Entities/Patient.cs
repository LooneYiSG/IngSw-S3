namespace IngSw_Domain.Entities;

public class Patient : Person
{
    public Affiliate? Affiliate { get; set; }
    public Domicilie? Domicilie { get; set; }
}
