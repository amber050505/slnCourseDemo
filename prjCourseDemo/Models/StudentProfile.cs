using System;
using System.Collections.Generic;

#nullable disable

namespace prjCourseDemo.Models
{
    public partial class StudentProfile
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string Enrollment { get; set; }
        public string Grade { get; set; }
        public string Status { get; set; }
        public string ThumbnailName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
    }
}
