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
    public static class LuceneEngine
    {
        //there is a place where to store the index--->> got to solve it!!!--->uppd: solved
        private static string _luceneDir = Path.Combine("../../../", "lucene_index1");
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
        //uppd: с приватностью решено, что с бул?
        //uppd2: вызвать методы для result and index
        public static void BuildIndex(Work work)
        {
            //
            //
            //здесь вызов метода для обновления index
            //
            //
            using (var std = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30))
            {
                using (IndexWriter idxw = new IndexWriter(_directory, std, true, IndexWriter.MaxFieldLength.UNLIMITED))
                {
                    //check if document exists
                    var searchQuery = new TermQuery(new Term("Id", work.Id.ToString()));
                    idxw.DeleteDocuments(searchQuery);
                    //creation
                    Document doc = new Document();
                    doc.Add(new Field("Id", work.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));//аналайзер разбивает строки на слова
                    doc.Add(new Field("Title", work.Authors, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("Description", work.Text, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("Authors", work.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));//аналайзер разбивает строки на слова
                    doc.Add(new Field("Text", work.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));//аналайзер разбивает строки на слова
                    //write the document to the index
                    idxw.AddDocument(doc);
                    //
                    //
                    //здесь вызов метода для обновления result
                    //
                    //
                    //optimize and close the writer
                    idxw.Optimize();
                }
            }
        }

        //начнем с методов для англ, с русск пока сложнааа

        //public static IEnumerable<Works> Search(string input, out int count, string fieldName = "")
        //{
        //    if (string.IsNullOrEmpty(input))
        //    {
        //        count = 0;
        //        return new List<Works>();
        //    }
        //    //trim- удаляет пробелы с концов
        //    var terms = input.Trim().Replace("-", " ").Split(' ')
        //        .Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim() + "*");
        //    input = string.Join(" ", terms);
        //    return _search(input, out count, fieldName);
        //}

        private static Work _convertDoc(Document doc)
        {
            return new Work
            {
                Id = Convert.ToInt32(doc.Get("Id")),
                Authors = doc.Get("Authors"),
                Text = doc.Get("Text"),
                Title = doc.Get("Title"),
                Description=doc.Get("Description")
            };
        }


        private static IEnumerable<Work> _convertFDocs(IEnumerable<Document> found)
        {
            return found.Select(_convertDoc).ToList();
        }
        private static IEnumerable<Work> _convertDocs(IEnumerable<ScoreDoc> found,
            IndexSearcher searcher)
        {
            return found.Select(oneFound => _convertDoc(searcher.Doc(oneFound.Doc))).ToList();
        }


    }
}
