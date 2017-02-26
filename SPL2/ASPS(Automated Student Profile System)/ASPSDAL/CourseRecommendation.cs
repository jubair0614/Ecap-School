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
    
    public partial class CourseRecommendation
    {
        public long ContentID { get; set; }
        [Required]
        public long FacultyID { get; set; }
        [Required]
        public long StudentID { get; set; }
        [Required(ErrorMessage = "Please select course")]
        public long CourseID { get; set; }
        [Required(ErrorMessage = "Please select a rating number")]
        public Nullable<int> CourseRating { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual Student Student { get; set; }
    }
}
