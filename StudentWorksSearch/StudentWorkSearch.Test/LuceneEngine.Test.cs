using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentWorkSearch.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void BuildIndex_nullAuthor_NullReferenceException()
        {
            StudentWorksSearch.LuceneSearch.LuceneEngine.BuildIndex(
                new StudentWorksSearch.LuceneSearch.FileToIndex
                {
                    Id = 0,
                    Authors= null,
                    Description="test",
                    Hashtags="test",
                    Text="test",
                    Title="test"           
                });           
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void BuildIndex_nullDescription_NullReferenceException()
        {
            StudentWorksSearch.LuceneSearch.LuceneEngine.BuildIndex(
                new StudentWorksSearch.LuceneSearch.FileToIndex
                {
                    Id = 0,
                    Authors = "test",
                    Description = null,
                    Hashtags = "test",
                    Text = "test",
                    Title = "test"
                });
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void BuildIndex_nullHashtags_NullReferenceException()
        {
            StudentWorksSearch.LuceneSearch.LuceneEngine.BuildIndex(
                new StudentWorksSearch.LuceneSearch.FileToIndex
                {
                    Id = 0,
                    Authors = "test",
                    Description = "test",
                    Hashtags = null,
                    Text = "test",
                    Title = "test"
                });
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void BuildIndex_nullText_NullReferenceException()
        {
            StudentWorksSearch.LuceneSearch.LuceneEngine.BuildIndex(
                new StudentWorksSearch.LuceneSearch.FileToIndex
                {
                    Id = 0,
                    Authors = "test",
                    Description = "test",
                    Hashtags = "test",
                    Text = null,
                    Title = "test"
                });
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void BuildIndex_nullTitle_NullReferenceException()
        {
            StudentWorksSearch.LuceneSearch.LuceneEngine.BuildIndex(
                new StudentWorksSearch.LuceneSearch.FileToIndex
                {
                    Id = 0,
                    Authors = "test",
                    Description = "test",
                    Hashtags = "test",
                    Text = "test",
                    Title = null
                });
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void BuildIndex_nullObject_NullReferenceException()
        {
            StudentWorksSearch.LuceneSearch.LuceneEngine.BuildIndex(
                new StudentWorksSearch.LuceneSearch.FileToIndex());
        }
    }
}
