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
using System.Windows.Shapes;

namespace _06._09_byMe.Forms
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Window
    {
            private List<string> genderContextComboboxGender = new List<string>() { "Мужской", "Женский" };

        public User()
        {
            InitializeComponent();
            this.Loaded += User_Loaded;
            this.Closing += User_Closed;
        }

        private void User_Closed(object? sender, CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void User_Loaded(object sender, RoutedEventArgs e)
        {
            cbGender.ItemsSource = genderContextComboboxGender;
            cbGender.SelectedIndex = 0;
        }

        private void btDown_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btAddUser_Click(object sender, RoutedEventArgs e)
        {
            #region валидация
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("укажите имя пользователя");
                return;
            }
            int age = 0;
            try

            {
                age = Convert.ToInt32(tbAge.Text);
                if (age < 0)
                {
                    MessageBox.Show("Некоректный возраст пользователя");
                    return;
                }
            }

            catch
            {
                MessageBox.Show("вы указали не число в графе возраст", "Не надо так", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            #endregion
            DB.User1 newUser = new DB.User1
            {
                UserName = tbName.Text,
                UserAge = age,
                Gender = cbGender.SelectedItem.ToString()

            };
            DB.MyContext myContext = new DB.MyContext();
            try
            {
                myContext.Users.Add(newUser);
                myContext.SaveChanges();
                MessageBox.Show($"Пользователь {newUser.UserName} добавлен в базу данных");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления полдьзователя в базу данных" + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

    }
}
