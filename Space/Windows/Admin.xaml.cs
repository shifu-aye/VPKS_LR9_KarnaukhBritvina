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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Space.Windows;

namespace Space.Windows
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            DGridEvents.ItemsSource = KersherEntities.GetContext().Events.ToList();
           
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            new AddEvenr().Show();
            this.Hide();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            var eventForRemoving = DGridEvents.SelectedItems.Cast<Event>().ToList();
            if (MessageBox.Show($" Вы точно хотите удалить следующие {eventForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    KersherEntities.GetContext().Events.RemoveRange(eventForRemoving);
                    KersherEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridEvents.ItemsSource = KersherEntities.GetContext().Events.ToList();
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            new AddEdit(null).Show();
            this.Hide();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                KersherEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridEvents.ItemsSource = KersherEntities.GetContext().Events.ToList();
            }
        }
    }
}
