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
    
    public partial class QuestionItem
    {
        public Nullable<int> AnswerId { get; set; }
        public int QuestionId { get; set; }
        public int QuestionVersion { get; set; }
        public int QuestionListId { get; set; }
        public System.Guid Guid { get; set; }
    
        public virtual Answer Answer { get; set; }
        public virtual Question Question { get; set; }
        public virtual QuestionList QuestionList { get; set; }
    }
}
