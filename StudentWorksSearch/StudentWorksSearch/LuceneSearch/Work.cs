﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWorksSearch.LuceneSearch
{
    public class Work
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Authors { get; set; }
        public string Title { get; set; }
        public string Hashtags { get; set; }
    }
}
