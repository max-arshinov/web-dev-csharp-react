using System.ComponentModel.DataAnnotations;
using Hw7.ErrorMessages;
using Hw7.Models.ForTests;

namespace Hw7.Models;

public enum Sex : byte
{
    Male,
    Female
};

public class UserProfile : BaseModel
{
    [Required(ErrorMessage = Messages.RequiredMessage)]
    [MaxLength(30, ErrorMessage = $"First Name {Messages.MaxLengthMessage}")]
    [Display(Name = "Имя")]
    public override string FirstName { get; set; } = null!;

    [Required(ErrorMessage = Messages.RequiredMessage)]
    [MaxLength(30, ErrorMessage = $"Last Name {Messages.MaxLengthMessage}")]
    [Display(Name = "Фамилия")]
    public override string LastName { get; set; } = null!;

    [Required(ErrorMessage = Messages.RequiredMessage)] 
    [MaxLength(30, ErrorMessage = $"Middle Name {Messages.MaxLengthMessage}")]
    [Display(Name = "Отчество")]
    public override string? MiddleName { get; set; }
    
    [Range(10, 100, ErrorMessage = $"Age {Messages.RangeMessage}")]
    [Display(Name = "Возраст")]
    public override int Age { get; set; }
        
    [Display(Name = "Пол")]
    public override Sex Sex { get; set; }
} 