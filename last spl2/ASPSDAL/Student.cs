//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace ASPSDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.Contents = new HashSet<Content>();
            this.CourseRecommendations = new HashSet<CourseRecommendation>();
            this.Results = new HashSet<Result>();
        }
    
        public long StudentID { get; set; }
        [Required(ErrorMessage = "Please enter email address")]
        [RegularExpression(@"[a-zA-Z0-9\.]*@iit.du.ac.bd", ErrorMessage = "Enter iit domain email address")]
        public string StudentEmail { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [StringLength(12, MinimumLength = 4)]
        public string Password { get; set; }
        public string BloodGroup { get; set; }
        public string Address { get; set; }
        public string Religion { get; set; }
        public string Gender { get; set; }
        public string Roll { get; set; }
        public string RegistrationNumber { get; set; }
        public Nullable<decimal> Result { get; set; }
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Enter 11 digit mobile number")]
        public string MobileNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Content> Contents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseRecommendation> CourseRecommendations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results { get; set; }
    }
}
