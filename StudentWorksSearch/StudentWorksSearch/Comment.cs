//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentWorksSearch
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int Id { get; set; }
        public string Author_ID { get; set; }
        public System.DateTime Date { get; set; }
        public int Work_ID { get; set; }
        public int Scores { get; set; }
        public string Text { get; set; }
    
        public virtual Users Users { get; set; }
        public virtual Work Work { get; set; }
    }
}
