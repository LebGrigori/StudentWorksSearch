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

namespace StudentWorksSearch
{
    /// <summary>
    /// Логика взаимодействия для GradeWork.xaml
    /// </summary>
    public partial class GradeWork : Window
    {
        public GradeWork()
        {
            InitializeComponent();
        }
        bool hasBeenClicked = false;

        private void AddCommentButton_Click(object sender, RoutedEventArgs e)
        {
            List<RadioButton> buttons = new List<RadioButton>
            {
                g1,g2,g3,g4,g5,g6,g7,g8,g9,g10
            };
            var selected = buttons.FirstOrDefault(x => (bool)x.IsChecked);
            if (selected != null)
            {
                string text="";
                var grade = selected.Name.Remove(0, 1);
                if (CommentText.Text != "Добавить комментарий..." && CommentText.Text != "")
                {
                    text = CommentText.Text;
                }

                //вот тут добавить коммент в базу данных , привязать к работе, 
                //надо подумать как это сделать
            }
            else
            {
                MessageBox.Show("Вы не оценили работу!", "Оценка отсутствует");
            }
            this.Close();
        }

        //убирает дефолтный текст в тексбоксе коммента
        private void TextBox_Focus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
        }

    }
}
