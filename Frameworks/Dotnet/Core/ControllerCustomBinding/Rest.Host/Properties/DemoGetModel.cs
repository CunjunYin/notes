using Core.Models.Binders;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Core.Models;

[ModelBinder(typeof(DemoGetBinder))]
public class DemoGetModel: IValidatableObject
{
    public string Name { get; set; }
    public int Age { get; set; }

    public string? Authorization { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            yield return new ValidationResult("Invalid Name");
        }

        if (Age < 0 || Age > 120 || Age == null)
        {
            yield return new ValidationResult("Invalid Age");
        }
    }
}