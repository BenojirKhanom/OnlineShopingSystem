//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class CustomerReview
    {
        public int ReviewId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        [Required]
        [Display(Name = "Comment")]
        [StringLength(50)]
        public string Opinion { get; set; }
        public string ImageFile { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
