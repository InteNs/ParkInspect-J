//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Commission = new HashSet<Commission>();
            this.Workday = new HashSet<Workday>();
        }
    
        public int Id { get; set; }
        public System.Guid Guid { get; set; }
        public string Password { get; set; }
        public int FunctionId { get; set; }
        public System.Guid FunctionGuid { get; set; }
        public int PersonId { get; set; }
        public System.Guid PersonGuid { get; set; }
        public System.DateTime DateHired { get; set; }
        public Nullable<System.DateTime> DateFired { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commission> Commission { get; set; }
        public virtual Function Function { get; set; }
        public virtual Person Person { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Workday> Workday { get; set; }
    }
}
