using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StudentWorksSearch.Engines;
using StudentWorksSearch.Repo;
using System.IO;

namespace StudentWorksSearch
{
    /// <summary>
    /// Interaction logic for PlagiarismCheck.xaml
    /// </summary>
    public partial class PlagiarismCheck : Window
    {
        public PlagiarismCheck()
        {
            InitializeComponent();
            progressBar.IsIndeterminate = true;
            //var engineFile = new FileEngine();
            //var engineAPI = new APIEngine();
            //string dir = new FileInfo(Repository.Work.Filepath).DirectoryName;
            //string str = new FileInfo(Repository.Work.Filepath).Name;
            //string full = Path.Combine("../../../Data/DBDocs", str)
            //string text = engineFile.GetDocText(full);
            //txtPlag.Text = engineAPI.POST(text);
            //progressBar.IsIndeterminate = false;
        }
    }
}
