using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT_Project.DATA.EF.Models//.Metadata
{
   public class CourseMetadata
    {
        public int CourseId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Must not exceed 50 characters")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; } = null!;

        [Required]
        [Display(Name = "Course Description")]
        [DataType(DataType.MultilineText)]
        public string CourseDescription { get; set; } = null!;

        [Required]
        [Display(Name = "Credit Hours")]
        public byte CreditHours { get; set; }

        [StringLength(250, ErrorMessage ="Must not exceed 250 characters")]
        [DataType(DataType.MultilineText)]
        public string? Curriculum { get; set; }

        [StringLength(500, ErrorMessage = "Must not exceed 500 characters")]
        [DataType(DataType.MultilineText)]
        public string? Notes { get; set; }

        public bool IsActive { get; set; }

    }

    public class EnrollmentMetadata
    {
        public int EnrollmentId { get; set; }

        [Required]
        [Display(Name = "Student ID")]
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "Scheduled Class ID")]
        public int ScheduledClassId { get; set; }

        [Required]
        [Display(Name = "Enrollment Date")]
        [DisplayFormat(DataFormatString = "{0:d}, ApplyFormatInEditMode=true")]
        public DateTime EnrollmentDate { get; set; }

        //public virtual ScheduledClass ScheduledClass { get; set; } = null!;
        //public virtual Student Student { get; set; } = null!;
    }

    public class ScheduledClassMetadata
    {
        public int ScheduledClassId { get; set; }

        [Required]
        [Display(Name = "Course ID")]
        public int CourseId { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:d}, ApplyFormatInEditMode=true")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:d}, ApplyFormatInEditMode=true")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name ="Instructor")]
        [StringLength(40, ErrorMessage ="Must not exceed 40 characters")]
        public string InstructorName { get; set; } = null!;

        [Required]
        [StringLength(20, ErrorMessage ="Must not exceed 20 characters")]
        public string Location { get; set; } = null!;

        [Required]
        public int Scsid { get; set; }
    }

    public class ScheduledClassStatusMetadata
    {
        public int Scsid { get; set; }

        [Required]
        [StringLength(50, ErrorMessage ="Must not esceed 50 characters")]
        public string Scsname { get; set; } = null!;
    }

    public class StudentMetadata
    {
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage ="Must not exceed 20 characters")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "Must not exceed 20 characters")]
        public string LastName { get; set; } = null!;

        [StringLength(50, ErrorMessage = "Must not exceed 50 characters")]
        public string? Address { get; set; }

        [StringLength(25, ErrorMessage = "Must not exceed 25 characters")]
        public string? City { get; set; }

        [StringLength(2, ErrorMessage = "Must not exceed 2 characters")]
        public string? State { get; set; }

        [Display(Name ="Zip")]
        [StringLength(10, ErrorMessage = "Must not exceed 10 characters")]
        [DataType(DataType.PostalCode)]
        public string? ZipCode { get; set; }

        [StringLength(13, ErrorMessage = "Must not exceed 13 characters")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "Must not exceed 60 characters")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [StringLength(100, ErrorMessage = "Must not exceed 100 characters")]
        public string? PhotoUrl { get; set; }

        [Required]
        public int Ssid { get; set; }

        public virtual StudentStatus Ss { get; set; } = null!;
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }

    public class StudentStatusMetadata
    {
        public int Ssid { get; set; }

        [Required]
        [Display(Name = "Status")]
        [StringLength(30, ErrorMessage = "Must not exceed 30 characters")]
        public string Ssname { get; set; } = null!;

        [Display(Name = "Description of Status")]
        [StringLength(250, ErrorMessage = "Must not exceed 250 characters")]
        [DataType(DataType.MultilineText)]
        public string? Ssdescription { get; set; }
    }
}
