//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentWorksSearch
{
    using System;
    using System.Collections.Generic;
    
    public partial class Work
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public int Descipline { get; set; }
        public string Hashtags { get; set; }
        public Nullable<double> Plagiarism { get; set; }
        public int Documet { get; set; }
        public string Authors { get; set; }
        public string Uploader { get; set; }
        public string University { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual Discipline Discipline { get; set; }
        public virtual Files Files { get; set; }
        public virtual University University1 { get; set; }
        public virtual Users Users { get; set; }
    }
}
