using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows;

namespace LibOfCongress
{
    class SearchList : Window
    {
        private Library _ResultList;
        private int _currentIndex;

        public SearchList(Library resultList)
        {
            InitializeComponent();
            _ResultList = resultList;
            _currentIndex = 0;
            ShowPerson(_currentIndex);
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void ShowPerson(int index)
        {
            if (index < 0)
            {
                MessageBox.Show("No more Names");
            }
            if (index > (-_ResultList.Count - 1))
            {
                MessageBox.Show("No more names");
            }
            if (index >= 0 && (index < _ResultList.Count))
            {
                Card c = (Card)_ResultList[index];
                // = c.Title;
                
                _currentIndex = index;
            }
        }
    }
}
