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

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.CustomerReviews = new HashSet<CustomerReview>();
            this.Orders = new HashSet<Order>();
        }
    
        public int CustomerId { get; set; }
        [Required]
        [Display(Name = "CustomerName")]
        [StringLength(50)]
        public string CustomerName { get; set; }
        [Required]
        [Display(Name = "Address")]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Mobile")]
        [DataType(DataType.PhoneNumber)]
        public string Number { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerReview> CustomerReviews { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
