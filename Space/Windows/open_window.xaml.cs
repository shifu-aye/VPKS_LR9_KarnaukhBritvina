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

namespace Space.Windows
{
    /// <summary>
    /// Логика взаимодействия для open_window.xaml
    /// </summary>
    public partial class open_window : Window
    {
        public open_window()
        {
            InitializeComponent();
            var currentEvents = KersherEntities.GetContext().Events.ToList();
            LViewEvents.ItemsSource = currentEvents;
           

           

            
        }
        private void UpdateTours()
        {
            



          

        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
