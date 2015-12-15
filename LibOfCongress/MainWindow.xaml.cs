using System;
using System.Collections.Generic;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Xml;

namespace LibOfCongress
{
    public partial class MainWindow : Window
    {
        private Library _Lib;

        public MainWindow(Library lib)
        {
            InitializeComponent();
            _Lib = lib;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Serializer serializer = new Serializer();
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    Stream file = File.Open(openFileDialog.FileName, FileMode.Open);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Serializer serializer = new Serializer();
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    serializer.SerializeObject(saveFileDialog.FileName, _Lib);
                }
                catch (Exception ex) {
                    MessageBox.Show(saveFileDialog.FileName);
                    MessageBox.Show("Error: " + ex.Message);
                 }
                }
            }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            Serializer serializer = new Serializer();
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    serializer.CreateNewFile(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Jesse Ragsdale is hoping to get at least an A in this class...");
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Oh you need help? Tough. Figure it out.");
        }

        private void addBook_Click(object sender, RoutedEventArgs e)
        {
            AddBook newBook = new AddBook(_Lib);
            newBook.Show();
        }

        private void BookGotFocus(object sender, RoutedEventArgs e)
        {
            if (searchField.Text == "Book Name...")
            {
                searchField.Clear();
            }
            else
            {
                return;
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Searching... " + _Lib.Count());
            MessageBox.Show("Searching for: " + searchField.Text);
            Library resultList = _Lib.SubjectSearch(searchField.Text);
            if (resultList.Count == 0)
            {
                MessageBox.Show("No books found!");
            }
            else
            {
                SearchList searchList = new SearchList(resultList);
                searchList.Show();
            }
        }
    }
}
