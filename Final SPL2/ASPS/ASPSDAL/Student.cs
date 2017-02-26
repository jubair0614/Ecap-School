//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASPSDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Faculty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Faculty()
        {
            this.Contents = new HashSet<Content>();
            this.Courses = new HashSet<Course>();
            this.CourseRecommendations = new HashSet<CourseRecommendation>();
        }
    
        public string FacultyEmail { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string BloodGroup { get; set; }
        public string Address { get; set; }
        public string Religion { get; set; }
        public string Gender { get; set; }
        public string Roll { get; set; }
        public string RegistrationNumber { get; set; }
        public Nullable<decimal> Result { get; set; }
        public Nullable<decimal> MobileNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Content> Contents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseRecommendation> CourseRecommendations { get; set; }
    }
}
