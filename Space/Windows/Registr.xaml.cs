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
using _db = Space.KersherEntities;
using Space.Windows;

namespace Space.Windows
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(LoginTb.Text))
                errors.AppendLine("Укажите электронную почту.");
            if (string.IsNullOrEmpty(PasswordTb.Text))
                errors.AppendLine("Укажите пароль.");
            if (string.IsNullOrEmpty(NameTb.Text))
                errors.AppendLine("Укажите имя.");
            if (string.IsNullOrEmpty(AgeTb.Text))
                errors.AppendLine("Укажите город.");
            if (string.IsNullOrEmpty(CityTb.Text))
                errors.AppendLine("Укажите роль.");
            if (string.IsNullOrEmpty(RoleTb.Text))
                errors.AppendLine("Укажите электронную почту.");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
 
            User _currentUser = new User();
            _currentUser.email = LoginTb.Text;
            _currentUser.password = PasswordTb.Text;
            _currentUser.name = NameTb.Text;
            _currentUser.age = Int32.Parse(AgeTb.Text);
            _currentUser.city = CityTb.Text;
            _currentUser.roleId = Int32.Parse(RoleTb.Text);


            KersherEntities.GetContext().Users.Add(_currentUser);

            try
            {
                bool flag = true;
                foreach (User u in KersherEntities.GetContext().Users.ToList())
                {
                    if (u.email == LoginTb.Text) flag = false;
                }
                if (flag)
                {
                    KersherEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже существует.");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
