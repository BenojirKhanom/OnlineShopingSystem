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

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.OrderDtls = new HashSet<OrderDtl>();
        }

        public int EmpID { get; set; }
        [Required]
        [Display(Name = "Emplyee Name")]
        [StringLength(50)]
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        [Required]
        [Display(Name = "City")]
        [StringLength(50)]
        public string Country { get; set; }
        public Nullable<decimal> Salary { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDtl> OrderDtls { get; set; }
    }
}
