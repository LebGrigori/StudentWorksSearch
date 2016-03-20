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
using StudentWorksSearch.LuceneSearch;

namespace StudentWorksSearch
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Программа для поиска и обработки студенческих работ.\n\nВыполнили: Кашицына Оксана\n                       Желандовская Екатерина\n                       Лебедев Григорий\nГруппа: 141","О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnMyData_Click(object sender, RoutedEventArgs e)
        {
            var engine = new DBEngine();
            string str = "LogIn: " + Repository.User.Login + "\nE-Mail: " + Repository.User.E_mail + "\nФИО: " + Repository.User.Name + "\nРегистрация: " + Repository.User.Registration + "\nВУЗ: " + Repository.User.University;
       
            MessageBox.Show(str, "Мои данные", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Repository.Edit = true;
            new Registration().ShowDialog();
        }

        //без статик
       // все что понадобится и может быть связано с папкой  lucene
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
          //  LuceneEngine le = new LuceneEngine();


            int number;//количество результатов
                string field = "";
            IEnumerable<FileToIndex> results;
            if (txtboxSearch.Text.StartsWith("#"))
            {
                field = "Hashtags";
                results = LuceneEngine.Search(txtboxSearch.Text.Substring(1, txtboxSearch.Text.Length - 1),
                    out number, field);
            }
            else
            {
                results = LuceneEngine.Search(txtboxSearch.Text,
                    out number);           
            }
            lstboxResult.Items.Clear();
            foreach (var doc in results)
            {
                lstboxResult.Items.Add(doc.Title);
            }
        }


        //без статик
        private void DeleteWork_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            //если что тут должно быть это
            LuceneEngine.DeleteIndex(id);
        }

        private void AddWork_Click(object sender, RoutedEventArgs e)
        { 
            new AddWork().ShowDialog();
        }

        private void DownloadWork_Click(object sender, RoutedEventArgs e)
        {
            var engine = new FileEngine();
            engine.Save(lstboxResult.SelectedItem.ToString()); 
        }
    }
}
