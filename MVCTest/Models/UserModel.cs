

using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTest.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "Limit exceeded!")]
        public string Name { get; set; }

        [EmailAddress]
        [StringLength(maximumLength: 50, ErrorMessage = "Email Number not be more then 50 characters")]
        public string Email { get; set; }

       
        [StringLength(maximumLength: 10, ErrorMessage = "Limit exceeded!")]
        [MinLength(10, ErrorMessage = "Enter 10 digit number")]
      
        public string Mobile { get; set; }

        //[ForeignKey("CourseId")]
        //public int CourseId { get; set; }
        // public CourseModel Course { get; set; }
        public string? Courses { get; set; }

        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string EnterBy { get; set; }
    }

    public class CourseModel
    {
        public string CName { get; set; }
        public List<string> selectedCourses { get; set; }

    }
    public class CommonModel
    {
        public UserModel userModel { get; set; }
        public CourseModel courseModel { get; set; }
        public IEnumerable<UserModel>? Model1 { get; set; }


    }
}
