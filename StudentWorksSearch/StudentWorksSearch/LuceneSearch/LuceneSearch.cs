using System.IO;
using System.Linq;
using System.Web;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Version = Lucene.Net.Util.Version;
using System;
using System.Collections.Generic;

namespace StudentWorksSearch.LuceneSearch
{
    public static class LuceneSearch
    {
        //there is a place where to store the index--->> got to solve it!!!
        private static string _luceneDir = Path.Combine("//Mac/Home/Desktop", "lucene_index1");
        private static FSDirectory _directoryTemp;
        private static FSDirectory _directory
        {
            get
            {
                if (_directoryTemp == null) _directoryTemp = FSDirectory.Open(new
            DirectoryInfo(_luceneDir));
                if (IndexWriter.IsLocked(_directoryTemp)) IndexWriter.Unlock(_directoryTemp);
                var lockFilePath = Path.Combine(_luceneDir, "write.lock");
                if (File.Exists(lockFilePath)) File.Delete(lockFilePath);
                return _directoryTemp;
            }
        }



        //this method creates document from an ObjectToIndex
        //мб возвращать бул и отправлять его в бд? и надо решить с приватностью и репозиторием
        public static void ToIndex(ObjectToIndex sampleData)
        {
            using (var std = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30))
            {
                using (IndexWriter idxw = new IndexWriter(_directory, std, true, IndexWriter.MaxFieldLength.UNLIMITED))
                {
                    //check if document exists
                    var searchQuery = new TermQuery(new Term("Id", sampleData.Id.ToString()));
                    idxw.DeleteDocuments(searchQuery);
                    //crreation
                    Document doc = new Document();
                    doc.Add(new Field("Id", sampleData.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));//аналайзер разбивает строки на слова
                    doc.Add(new Field("Title", sampleData.Authors, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("Description", sampleData.Text, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("Authors", sampleData.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));//аналайзер разбивает строки на слова
                    doc.Add(new Field("Text", sampleData.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));//аналайзер разбивает строки на слова
                    //write the document to the index
                    idxw.AddDocument(doc);
                    //optimize and close the writer
                    idxw.Optimize();
                }
            }
        }
    }
}
