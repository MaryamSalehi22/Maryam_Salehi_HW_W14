using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Form.Models
{
    public class FormViewModel
    {
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 30 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 30 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "Phone number must start with 09 and be 11 digits long.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }
        [Required(ErrorMessage = "Course Code is required.")]
        [Range(100, 999, ErrorMessage = "Course Code must be a three-digit number.")]
        [RegularExpression(@"^[02468]\d{2}$", ErrorMessage = "Course code must be a three-digit number with an even hundreds digit.")]
        public string CourseCode { get; set; }
        [EnumDataType(typeof(Gender))]
        public Gender GenderType { get; set; }
        [Required(ErrorMessage = "You must agree to the terms.")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to the terms and conditions.")] 
        public bool Checked { get; set; }

        public bool IsValidAge()
        {
            return DateTime.Now.Year - BirthDate.Year >= 18;
        }
    public enum Gender
    {
        Male = 1,
        Female = 2
    }
}
}
