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
    
    public partial class Workday
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public System.Guid EmployeeGuid { get; set; }
        public System.Guid Guid { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> StopTime { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
