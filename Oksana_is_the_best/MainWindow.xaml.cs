using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Oksana_is_the_best.Components;

namespace Oksana_is_the_best
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ServiceList.ItemsSource = Db.db.Toy.ToList();
        }

      

        private void Refresh()
        {
            IEnumerable<Toy> filter = Db.db.Toy;
            if (Sort.SelectedIndex > 0)
            {
                if (Sort.SelectedIndex == 1)
                {
                    filter = filter.OrderBy(x => x.Cost);
                }
                else if (Sort.SelectedIndex == 2)
                {
                    filter = filter.OrderByDescending(x => x.Cost);
                }
            }
            if (Search.Text.Length > 0)
            {
                filter = filter.Where(x => x.Name.ToLower().StartsWith(Search.Text.ToLower()) || x.Description.ToLower().StartsWith(Search.Text.ToLower()));
            }
            ServiceList.ItemsSource = filter.ToList();
        }
        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordTb.Text == "0000")
            {
                Redact.Visibility = Visibility.Visible;
                Add.Visibility = Visibility.Visible;
            }
        }
    }
}
