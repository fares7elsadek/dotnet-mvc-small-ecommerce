using SmallEcommerceProject.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace SmallEcommerceProject.Custome_Attributes
{
    public class UniqueNameAttribute: ValidationAttribute
    {
        public string ErrorMessage { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string Name = (string)value;

            using (var context = new AppDbContext()) {
                var product = context.Products.FirstOrDefault(p => p.Name == Name);
                if (product == null) {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage);
        }
    }
}
