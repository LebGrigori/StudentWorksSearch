using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;

namespace StudentWorksSearch.Engines
{
    class FileEngine
    {
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
            Application Progr = new Application();
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
    }
}
