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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage 
    
    {
        private Event _currentEvent = new Event();
        private Button button;
        public AddEditPage(Event selectedEvent)
        {
            InitializeComponent();
            if (selectedEvent != null)
                _currentEvent = selectedEvent;
            DataContext = _currentEvent;
            ComboPlaces.ItemsSource = KersherEntities.GetContext().Places.ToList();
            ComboTypes.ItemsSource = KersherEntities.GetContext().TypeEvents.ToList();
            ComboUsers.ItemsSource = KersherEntities.GetContext().Users.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentEvent.name))
                errors.AppendLine("Укажите название");
            if (string.IsNullOrWhiteSpace(_currentEvent.description))
                errors.AppendLine("Укажите описание");
            if (_currentEvent.Place == null)
                errors.AppendLine("Выберите место");

            if (_currentEvent.TypeEvent == null)
                errors.AppendLine("Выберите тип");
            if (_currentEvent.User == null)
                errors.AppendLine("Выберите куратора");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentEvent.id == 0)
                KersherEntities.GetContext().Events.Add(_currentEvent);
            try
            {
                KersherEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                new MainWindow().Show();
                //this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
