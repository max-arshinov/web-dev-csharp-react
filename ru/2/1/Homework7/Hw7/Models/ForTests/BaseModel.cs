namespace Hw7.Models.ForTests;

public class BaseModel
{
    public virtual string FirstName { get; set; } = null!;

    public virtual string LastName { get; set; } = null!;

    public virtual string? MiddleName { get; set; }
    
    public virtual int Age { get; set; }
    
    public virtual Sex Sex { get; set; }
}