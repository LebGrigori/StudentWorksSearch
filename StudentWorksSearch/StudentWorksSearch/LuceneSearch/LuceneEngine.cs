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
using StudentWorksSearch.Engines;

namespace StudentWorksSearch.LuceneSearch
{
    public static class LuceneEngine
    {
        //разобраться с серчером, там что то про изменения в индексе



        //there is a place where to store the index--->> got to solve it!!!--->
        //uppd: solved
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

        static StandardAnalyzer GetAnalyzer()
        {
            return new StandardAnalyzer(Version.LUCENE_30);
        }

        //this method creates document from an ObjectToIndex
        //мб возвращать бул и отправлять его в бд? и надо решить с приватностью и репозиторием
        //uppd: с приватностью решено, что с бул?
        //uppd2: вызвать методы для result and index
        //uppd3: ANALYZER CHANGED
        //uppd4: ANALYZER CHANGED--->MUST WORK
        public static void BuildIndex(Work work)
        {
            //
            //
            //здесь вызов метода для обновления index
            // DBEngine db = new DBEngine();
            // var indexQuery=from db.Files 

            //

            //
            //using (var std = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30))
            //using (var analyzer= new Lucene.Net.Analysis.Snowball.SnowballAnalyzer(Version.LUCENE_30, "Russian"))
            using (var analyzer = new Lucene.Net.Analysis.Ru.RussianAnalyzer(Version.LUCENE_30))
            {
                using (IndexWriter idxw = new IndexWriter(_directory, analyzer, true, IndexWriter.MaxFieldLength.UNLIMITED))
                {
                    //check if document exists, if true deletes existing
                    var searchQuery = new TermQuery(new Term("Id", work.Id.ToString()));
                    idxw.DeleteDocuments(searchQuery);
                    //creation
                    Document doc = new Document();
                    doc.Add(new Field("Id", work.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));//аналайзер разбивает строки на слова
                    doc.Add(new Field("Title", work.Authors, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("Description", work.Text, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("Authors", work.Authors, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("Text", work.Text, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("Hashtags", work.Hashtags, Field.Store.YES, Field.Index.ANALYZED));
                    //write the document to the index
                    idxw.AddDocument(doc);
                    //
                    //
                    //здесь вызов метода для обновления result
                    //
                    //
                    //optimize and close the writer
                    idxw.Commit();
                    idxw.Optimize();
                }
            }
        }

        //начнем с методов для англ, с русск пока сложнааа

        public static IEnumerable<Work> Search(string input, out int count, string fieldName = "")
        {
            if (string.IsNullOrEmpty(input))
            {
                count = 0;
                return new List<Work>();
            }
            //trim- удаляет пробелы с концов
            var terms = input.Trim().Replace("-", " ").Split(' ')
                .Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim());
            input = string.Join(" ", terms);
            return _search(input, out count, fieldName);
        }

        //ANALYZER CHANGED
        static IEnumerable<Work> _search(string keywords, out int count, string field = "")
        {
            if (string.IsNullOrEmpty(keywords.Replace("*", "").Replace("?", "")))
            {
                count = 0;
                return new List<Work>();
            }
            using (var searcher = new IndexSearcher(_directory))
            //using (var analyzer = GetAnalyzer())
            //using (var analyzer=new Lucene.Net.Analysis.Snowball.SnowballAnalyzer(Version.LUCENE_30, "Russian"))
            using (var analyzer = new Lucene.Net.Analysis.Ru.RussianAnalyzer(Version.LUCENE_30))
            {
                if (!string.IsNullOrEmpty(field))
                {
                    var parser = new QueryParser(Version.LUCENE_30, field, analyzer);
                    var queryForField = parseQuery(keywords, parser);
                    var docs = searcher.Search(queryForField, 1000);
                    count = docs.TotalHits;
                    var samples = _convertDocs(docs.ScoreDocs, searcher);
                    searcher.Dispose();
                    return samples;
                }
                else
                {
                    var parser = new MultiFieldQueryParser
                        (Version.LUCENE_30, new[] { "Title", "Authors", "Description", "Text" }, analyzer);
                    var queryForField = parseQuery(keywords, parser);
                    var docs = searcher.Search(queryForField, null, 1000, Sort.RELEVANCE);
                    count = docs.TotalHits;
                    var samples = _convertDocs(docs.ScoreDocs, searcher);
                    searcher.Dispose();
                    return samples;
                }
            }
        }

        static Query parseQuery(string searchQuery, QueryParser parser)
        {
            Query query;
            try
            {
                query = parser.Parse(searchQuery.Trim());
            }
            catch (ParseException)
            {
                //make query with some symbols ignored
                query = parser.Parse(QueryParser.Escape(searchQuery.Trim()));
            }
            return query;
        }


        //converting

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

        private static IEnumerable<Work> _convertDocs(IEnumerable<ScoreDoc> docs, IndexSearcher searcher)
        {
            var samples = new List<Work>();
            foreach (var doc in docs)
            {
                samples.Add(_convertDoc(searcher.Doc(doc.Doc)));
            }
            return samples;
        }

        private static IEnumerable<Work> _convertDocs(IEnumerable<Document> docs)
        {
            var samples = new List<Work>();
            foreach (var doc in docs)
            {
                samples.Add(_convertDoc(doc));
            }
            return samples;
        }


        //count all documents in indexrr
        public static int CountDocs()
        {
            var reader = IndexReader.Open(_directory, true);
            return reader.NumDocs();
        }

        //deleting index
        public static void DeleteIndex(int id)
        {
            using (var analyzer = new Lucene.Net.Analysis.Ru.RussianAnalyzer(Version.LUCENE_30))
            using (var writer = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                var searchQuery = new TermQuery(new Term("Id", id.ToString()));
                writer.DeleteDocuments(searchQuery);
                writer.Commit();
            }
        }

    }
}
