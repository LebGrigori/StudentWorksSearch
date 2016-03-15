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
            string str = "";

            engine.GetUserData("anmur", out str);
       
            MessageBox.Show(str, "Мои данные", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
