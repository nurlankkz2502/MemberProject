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

namespace WPF_Study
{
    /// <summary>
    /// Логика взаимодействия для UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        public bool IsSelected = false;
        public UserView()
        {
            InitializeComponent();
            DateTime time = Convert.ToDateTime(txtbDate.Text);
            User = new Person(txtbName.Text, txtbLastName.Text, time, txtbPhone.Text);
        }
        public UserView(string txtbName, string txtbLastName, string txtbDate, string txtbPhone)
        {
            InitializeComponent();
            this.txtbName.Text = txtbName;
            this.txtbLastName.Text = txtbLastName;
            this.txtbDate.Text = txtbDate;
            this.txtbPhone.Text = txtbPhone; 
            DateTime time = Convert.ToDateTime(txtbDate);
            User = new Person(txtbName, txtbLastName ,time, txtbPhone);
        }
        public Person User;
        public string Name { get => txtbName.Text; set => txtbName.Text = value; }
        public string LastName { get => txtbLastName.Text; set => txtbLastName.Text = value; }
        public string BirthDate { get => txtbDate.Text; set => txtbDate.Text = value; }
        public string Phone { get => txtbPhone.Text; set => txtbPhone.Text = value; }
        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            IsSelected = true;
            border.BorderBrush = Brushes.Black;
        }

        
    }
}