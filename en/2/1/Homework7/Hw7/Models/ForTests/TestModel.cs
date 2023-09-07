using System.ComponentModel.DataAnnotations;
using Hw7.ErrorMessages;

namespace Hw7.Models.ForTests;

public class TestModel : BaseModel
{
    //without [Display(Name = "Имя")]
    [Required(ErrorMessage = Messages.RequiredMessage)]
    [MaxLength(30, ErrorMessage = $"First Name {Messages.MaxLengthMessage}")]
    public override string FirstName { get; set; } = null!;

    //without [Required(ErrorMessage = Messages.RequiredMessage)]
    [MaxLength(30, ErrorMessage = $"Last Name {Messages.MaxLengthMessage}")]
    [Display(Name = "Фамилия")]
    public override string LastName { get; set; } = null!;

    //without [MaxLength(30, ErrorMessage = $"Middle Name {Messages.MaxLengthMessage}")]
    [Required(ErrorMessage = Messages.RequiredMessage)]
    [Display(Name = "Отчество")]
    public override string? MiddleName { get; set; }
    
    //without [Display(Name = "Возраст")]
    [Range(10, 100, ErrorMessage = $"Age {Messages.RangeMessage}")]
    public override int Age { get; set; }
    
    [Display(Name = "Пол")]
    public override Sex Sex { get; set; }
    
    public string A { get; set; } = null!;
}