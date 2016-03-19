using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using System.Windows;
using System.IO;
using Microsoft.Win32;

namespace StudentWorksSearch.Engines
{
    class FileEngine
    {
        SearchWorkEntities db = new SearchWorkEntities();


        public static string GetDocText(string docfile)
        {
            Object filename = docfile;
            Object confirmConversions = Type.Missing;
            Object readOnly = Type.Missing;
            Object addToRecentFiles = Type.Missing;
            Object passwordDocument = Type.Missing;
            Object passwordTemplate = Type.Missing;
            Object revert = Type.Missing;
            Object writePasswordDocument = Type.Missing;
            Object writePasswordTemplate = Type.Missing;
            Object format = Type.Missing;
            Object encoding = Type.Missing;
            Object visible = Type.Missing;
            Object openConflictDocument = Type.Missing;
            Object openAndRepair = Type.Missing;
            Object documentDirection = Type.Missing;
            Object noEncodingDialog = Type.Missing;
            Microsoft.Office.Interop.Word.Application Progr = new Microsoft.Office.Interop.Word.Application();
            Progr.Documents.Open(ref filename,
            ref confirmConversions,
            ref readOnly,
            ref addToRecentFiles,
            ref passwordDocument,
            ref passwordTemplate,
            ref revert,
            ref writePasswordDocument,
            ref writePasswordTemplate,
            ref format,
            ref encoding,
            ref visible,
            ref openConflictDocument,
            ref openAndRepair,
            ref documentDirection,
            ref noEncodingDialog);
            Document Doc = new Document();
            Doc = Progr.Documents.Application.ActiveDocument;
            object start = 0;
            object stop = Doc.Characters.Count;
            Range Rng = Doc.Range(ref start, ref stop);
            string result = Rng.Text;
            object sch = Type.Missing;
            object aq = Type.Missing;
            object ab = Type.Missing;
            Progr.Quit(ref sch, ref aq, ref ab);
            return result;
        }

        public void LoadFile()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Word Documents|*.doc;*.docx";
            file.FilterIndex = 1;
            
                file.ShowDialog();
                string str = new FileInfo(file.FileName).Name;
                Repository.Path = Path.Combine("../../../Data", str);
                File.Copy(file.FileName, Repository.Path);
                Repository.Size = new FileInfo(Repository.Path).Length / 1024;
            
        }

        public void AddFile(string name, int dis, string auth, string tags, string comm)
        {
            var file = new Files
            {
                Path = Repository.Path,
                Size = Repository.Size
            };
            db.Files.Add(file);
            db.SaveChanges();

            if (auth == "")
            {
                auth = null;
            }
            if (tags == "")
            {
                tags = null;
            }
            if (comm == "")
            {
                comm = null;
            }
            db.Work.Add(new Work
            {
                Date = DateTime.Now,
                Descipline = dis + 1,
                Hashtags = tags,
                Documet = file.Id,
                Authors = auth,
                Uploader = Repository.User.Login,
                University = Repository.User.University,
                Name = name
            });
            db.SaveChanges();


        }

    }
}
