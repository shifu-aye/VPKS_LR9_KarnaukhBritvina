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
using _db = Space.KersherEntities;

namespace Space.Windows
{
    /// <summary>
    /// Логика взаимодействия для Autorize.xaml
    /// </summary>
    public partial class Autorize : Window
    {
        public Autorize()
        {
            InitializeComponent();
        }

        private void AutorizeBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < _db.GetContext().Users.Count(); i++)
            {
                if (LoginTb.Text == _db.GetContext().Users.ToList()[i].email &&
                    PasswordTb.Text == _db.GetContext().Users.ToList()[i].password)
                {
                    MessageBox.Show("Успешная авторизация!");
                    if (_db.GetContext().Users.ToList()[i].roleId == 1)
                    {
                        new Admin().Show();
                        this.Hide();
                    }
                    else if (_db.GetContext().Users.ToList()[i].roleId == 2)
                    {
                        new open_window().Show();
                        this.Hide();
                    }
                }

            }
        }
    }
}
