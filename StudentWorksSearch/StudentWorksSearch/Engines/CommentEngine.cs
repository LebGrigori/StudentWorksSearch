using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWorksSearch.Engines
{
    class CommentEngine
    {
        SearchWorkEntities db = new SearchWorkEntities();
        public void AddComment(string userId, int workId, int grade, string text = "")
        {
                db.Comment.Add(new Comment {
                    Work_ID = workId,
                    Author_ID = userId,
                    Date = DateTime.Now,
                    Scores = grade,
                    Text = text
                } );
                db.SaveChanges();
        }
    }
}
