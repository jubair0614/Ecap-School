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
    
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.CourseRecommendations = new HashSet<CourseRecommendation>();
        }
    
        public string CourseNumber { get; set; }
        public string CourseName { get; set; }
        public Nullable<decimal> CourseMarks { get; set; }
        public string CourseGrade { get; set; }
        public Nullable<decimal> CoursePoint { get; set; }
        public string FacultyEmail { get; set; }
        public string SemesterNumber { get; set; }
    
        public virtual Faculty Faculty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseRecommendation> CourseRecommendations { get; set; }
    }
}
