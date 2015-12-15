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

namespace LibOfCongress
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        private Library _Lib;

        public AddBook(Library lib)
        {
            InitializeComponent();
            _Lib = lib;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {

            String Title = titleBox.Text;
            List<String> Subjects = new List<string>();
            List<String> Authors = new List<string>();
            Authors.Add(authorBox.Text);
            Subjects.Add(subjectBox.Text);
            int catNumboxx = Int32.Parse(catNumBox.Text);
            int year = Int32.Parse(yearBox.Text);


            Card c = new Card(Title, Authors, new LoCnum(catNumboxx), Subjects,"hijack" ,year , true);
            _Lib.Add(c);
        }

        private void finishedButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}