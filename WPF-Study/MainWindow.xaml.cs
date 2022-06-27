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
using WPF_Study.Abstractions;

namespace WPF_Study
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, Abstractions.IView
    {

        public MainWindow()
        {
            InitializeComponent();
            SetDays();
            SetDate();
            FileName = "list.txt";
            ViewCalendar = MyCalendar;

        }
        public int a = 0;
        List<Person> Users = new List<Person>();
        List<DayOfWeek> dayOfWeeks = new List<DayOfWeek>();
       
        public string txtName { get => txtBoxName.Text;set=>txtBoxName.Text = value; }
        public string txtLastName { get => txtBoxLastName.Text; set => txtBoxLastName.Text = value; }
        public string txtBirthDate { get=>txtBoxDate.Text; set=>txtBoxDate.Text=value; }
        public string txtPhone { get=>txtBoxPhone.Text; set=>txtBoxPhone.Text=value; }

        public event EventHandler Read;
        public event EventHandler Write;
        public event EventHandler Delete;
        public int ListCount { get; set; }
        public string FileName { get; set; }
        public Calendar ViewCalendar { get; set; }
        List<Person> IView.persons {get => Users;set => Users = value; }
        public void SetDays()
        {
            dayOfWeeks.Add(MondayControl);
            MondayControl.txtBoxDay.Text = "ПОНЕДЕЛЬНИК";
            dayOfWeeks.Add(TuesdayControl);
            TuesdayControl.txtBoxDay.Text = "ВТОРНИК";
            dayOfWeeks.Add(WednesdayControl);
            WednesdayControl.txtBoxDay.Text = "СРЕДА";
            dayOfWeeks.Add(ThursdayControl);
            ThursdayControl.txtBoxDay.Text = "ЧЕТВЕРГ";
            dayOfWeeks.Add(FridayControl);
            FridayControl.txtBoxDay.Text = "ПЯТНИЦА";
            dayOfWeeks.Add(SaturdayControl);
            SaturdayControl.txtBoxDay.Text = "СУББОТА";
            dayOfWeeks.Add(SundayControl);
            SundayControl.txtBoxDay.Text = "ВОСКРЕСЕНЬЕ";
        }
        public void SetDate()
        {
            DateTime date = DateTime.Now;
            foreach (DayOfWeek day in dayOfWeeks)
            {
                MyCalendar.DisplayDate.ToString("dd");
                if (day.txtBoxDay.Text == date.ToString("dddd").ToUpper())
                {
                    day.IsSelected = true;
                    TodayDay(day);
                    SelectDate(MyCalendar.DisplayDate);
                    break;
                }
            }
        }
        public void SelectDate(DateTime date)
        {
            if (MondayControl.IsSelected == true)
            {
                MondayControl.txtBoxDate.Text = date.ToString("dd");
                MondayControl.TimeDate = date;
                TuesdayControl.txtBoxDate.Text = date.AddDays(1).ToString("dd");
                TuesdayControl.TimeDate = date.AddDays(1);
                WednesdayControl.txtBoxDate.Text = date.AddDays(2).ToString("dd");
                WednesdayControl.TimeDate = date.AddDays(3);
                ThursdayControl.txtBoxDate.Text = date.AddDays(3).ToString("dd");
                ThursdayControl.TimeDate = date.AddDays(4);
                FridayControl.txtBoxDate.Text = date.AddDays(4).ToString("dd");
                FridayControl.TimeDate = date.AddDays(5);
                SaturdayControl.txtBoxDate.Text = date.AddDays(5).ToString("dd");
                SaturdayControl.TimeDate = date.AddDays(6);
                SundayControl.txtBoxDate.Text = date.AddDays(6).ToString("dd");
            }
            else if (TuesdayControl.IsSelected == true)
            {
                MondayControl.txtBoxDate.Text = date.AddDays(-1).ToString("dd");
                MondayControl.TimeDate = date.AddDays(-1);
                TuesdayControl.txtBoxDate.Text = date.ToString("dd");
                TuesdayControl.TimeDate = date;
                WednesdayControl.txtBoxDate.Text = date.AddDays(1).ToString("dd");
                WednesdayControl.TimeDate = date.AddDays(1);
                ThursdayControl.txtBoxDate.Text = date.AddDays(2).ToString("dd");
                ThursdayControl.TimeDate = date.AddDays(2);
                FridayControl.txtBoxDate.Text = date.AddDays(3).ToString("dd");
                FridayControl.TimeDate = date.AddDays(3);
                SaturdayControl.txtBoxDate.Text = date.AddDays(4).ToString("dd");
                SaturdayControl.TimeDate = date.AddDays(4);
                SundayControl.txtBoxDate.Text = date.AddDays(5).ToString("dd");
                SundayControl.TimeDate = date.AddDays(5);
            }
            else if (WednesdayControl.IsSelected == true)
            {
                MondayControl.txtBoxDate.Text = date.AddDays(-2).ToString("dd");
                MondayControl.TimeDate = date.AddDays(-2);
                TuesdayControl.txtBoxDate.Text = date.AddDays(-1).ToString("dd");
                TuesdayControl.TimeDate = date.AddDays(-1);
                WednesdayControl.txtBoxDate.Text = date.ToString("dd");
                WednesdayControl.TimeDate = date;
                ThursdayControl.txtBoxDate.Text = date.AddDays(1).ToString("dd");
                ThursdayControl.TimeDate = date.AddDays(1);
                FridayControl.txtBoxDate.Text = date.AddDays(2).ToString("dd");
                FridayControl.TimeDate = date.AddDays(2);
                SaturdayControl.txtBoxDate.Text = date.AddDays(3).ToString("dd");
                SaturdayControl.TimeDate = date.AddDays(3);
                SundayControl.txtBoxDate.Text = date.AddDays(4).ToString("dd");
                SundayControl.TimeDate = date.AddDays(4);
            }
            else if (ThursdayControl.IsSelected == true)
            {
                MondayControl.txtBoxDate.Text = date.AddDays(-3).ToString("dd");
                MondayControl.TimeDate = date.AddDays(-3);
                TuesdayControl.txtBoxDate.Text = date.AddDays(-2).ToString("dd");
                TuesdayControl.TimeDate = date.AddDays(-2);
                WednesdayControl.txtBoxDate.Text = date.AddDays(-1).ToString("dd");
                WednesdayControl.TimeDate = date.AddDays(-1);
                ThursdayControl.txtBoxDate.Text = date.ToString("dd");
                ThursdayControl.TimeDate = date;
                FridayControl.txtBoxDate.Text = date.AddDays(1).ToString("dd");
                FridayControl.TimeDate = date.AddDays(1);
                SaturdayControl.txtBoxDate.Text = date.AddDays(2).ToString("dd");
                SaturdayControl.TimeDate = date.AddDays(2);
                SundayControl.txtBoxDate.Text = date.AddDays(3).ToString("dd");
                SundayControl.TimeDate = date.AddDays(3);
            }
            else if (FridayControl.IsSelected == true)
            {
                MondayControl.txtBoxDate.Text = date.AddDays(-4).ToString("dd");
                MondayControl.TimeDate = date.AddDays(-4);
                TuesdayControl.txtBoxDate.Text = date.AddDays(-3).ToString("dd");
                TuesdayControl.TimeDate = date.AddDays(-3);
                WednesdayControl.txtBoxDate.Text = date.AddDays(-2).ToString("dd");
                WednesdayControl.TimeDate = date.AddDays(-2);
                ThursdayControl.txtBoxDate.Text = date.AddDays(-1).ToString("dd");
                FridayControl.txtBoxDate.Text = date.ToString("dd");
                FridayControl.TimeDate = date;
                SaturdayControl.txtBoxDate.Text = date.AddDays(1).ToString("dd");
                SaturdayControl.TimeDate = date.AddDays(1);
                SundayControl.txtBoxDate.Text = date.AddDays(2).ToString("dd");
                SundayControl.TimeDate = date.AddDays(2);
            }
            else if (SaturdayControl.IsSelected == true)
            {
                MondayControl.txtBoxDate.Text = date.AddDays(-5).ToString("dd");
                MondayControl.TimeDate = date.AddDays(-5);
                TuesdayControl.txtBoxDate.Text = date.AddDays(-4).ToString("dd");
                TuesdayControl.TimeDate = date.AddDays(-4);
                WednesdayControl.txtBoxDate.Text = date.AddDays(-3).ToString("dd");
                WednesdayControl.TimeDate = date.AddDays(-3);
                ThursdayControl.txtBoxDate.Text = date.AddDays(-2).ToString("dd");
                ThursdayControl.TimeDate = date.AddDays(-2);
                FridayControl.txtBoxDate.Text = date.AddDays(-1).ToString("dd");
                FridayControl.TimeDate = date.AddDays(-1);
                SaturdayControl.txtBoxDate.Text = date.ToString("dd");
                SaturdayControl.TimeDate = date;
                SundayControl.txtBoxDate.Text = date.AddDays(1).ToString("dd");
                SundayControl.TimeDate = date.AddDays(1);
            }
            else if (SundayControl.IsSelected == true)
            {
                MondayControl.txtBoxDate.Text = date.AddDays(-6).ToString("dd");
                MondayControl.TimeDate = date.AddDays(-6);
                TuesdayControl.txtBoxDate.Text = date.AddDays(-5).ToString("dd");
                TuesdayControl.TimeDate = date.AddDays(-5);
                WednesdayControl.txtBoxDate.Text = date.AddDays(-4).ToString("dd");
                WednesdayControl.TimeDate = date.AddDays(-4);
                ThursdayControl.txtBoxDate.Text = date.AddDays(-3).ToString("dd");
                ThursdayControl.TimeDate = date.AddDays(-3);
                FridayControl.txtBoxDate.Text = date.AddDays(-2).ToString("dd");
                FridayControl.TimeDate = date.AddDays(-2);
                SaturdayControl.txtBoxDate.Text = date.AddDays(-1).ToString("dd");
                SaturdayControl.TimeDate = date.AddDays(-1);
                SundayControl.txtBoxDate.Text = date.ToString("dd");
                SundayControl.TimeDate = date;
            }
            txtBMonth.Text = date.ToString("MMMM");
            txtYear.Text = date.ToString("yyyy");
            txtFirsDateInWeek.Text = MondayControl.TimeDate.ToString("dd");
            txtLastDateInWeek.Text = SundayControl.TimeDate.ToString("dd");

        }
        public void TodayDay(DayOfWeek day)
        {
            var bc = new BrushConverter();


            foreach (DayOfWeek dayOfWeek in dayOfWeeks)
                dayOfWeek.txtBoxDay.Background = (Brush)bc.ConvertFrom("#FFC6EAC6");

            day.txtBoxDay.Background = (Brush)bc.ConvertFrom("#FF5CC75C");



            /*Background = "#FFC6EAC6"*/ // светлозеленый
            /*Background = "#FF5CC75C"*/ //темнозеленый

        }
        public void CheckTodaySelection()
        {
            var bc = new BrushConverter();

            foreach (DayOfWeek day in dayOfWeeks)
                if (day.TimeDate != DateTime.Today)
                    day.txtBoxDay.Background = (Brush)bc.ConvertFrom("#FFC6EAC6");
                else
                    day.txtBoxDay.Background = (Brush)bc.ConvertFrom("#FF5CC75C");
        }

        private void MyCalendar_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            DateTime date = MyCalendar.DisplayDate;
            foreach (DayOfWeek day in dayOfWeeks)
            {
                if (day.txtBoxDay.Text == MyCalendar.DisplayDate.ToString("dddd").ToUpper())
                {
                    DaySelection(day);
                    SelectDate(MyCalendar.DisplayDate);
                    CheckTodaySelection();
                    CheckBirthDate();
                }
            }
        }
        public void DaySelection(DayOfWeek obj)
        {
            foreach (DayOfWeek day in dayOfWeeks)
                if (day == obj)
                    day.IsSelected = true;
                else
                    day.IsSelected = false;
        }
        private void MyCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = (DateTime)(MyCalendar?.SelectedDate);
            foreach (DayOfWeek day in dayOfWeeks)
            {
                if (day.txtBoxDay.Text == date.ToString("dddd").ToUpper())
                {
                    DaySelection(day);
                    SelectDate(date);
                    CheckTodaySelection();
                    CheckBirthDate();
                }
                else
                {
                    MyCalendar.SelectedDates.Add( date);
                }
            }
        }

        private void btnNxtWeek_Click(object sender, RoutedEventArgs e)
        {
            if (MyCalendar.SelectedDate == null)
                MyCalendar.SelectedDate = DateTime.Now;
            DateTime date = (DateTime)(MyCalendar?.SelectedDate);
            date = date.AddDays(7);
            MyCalendar.SelectedDate = date;
            SelectDate(date);
            CheckBirthDate();
            if (MyCalendar.DisplayDate.Month != date.Month)
                MyCalendar.DisplayDate = date;
        }

        private void btnPrevWeek_Click(object sender, RoutedEventArgs e)
        {
            if (MyCalendar.SelectedDate == null)
                MyCalendar.SelectedDate = DateTime.Now;
            DateTime date = (DateTime)(MyCalendar?.SelectedDate);
            date = date.AddDays(-7);
            MyCalendar.SelectedDate = date;
            SelectDate(date);
            CheckBirthDate();
            if (MyCalendar.DisplayDate.Month != date.Month)
                MyCalendar.DisplayDate = date;
        }

        public void SelectUserView(object sender)
        {
            foreach (DayOfWeek dow in dayOfWeeks)
                if (dow != sender)
                {
                    dow.DayPanel.Children.Clear();
                    foreach (Person p in Users)
                        if (p.BirthDate.ToString("M") == dow.TimeDate.ToString("M"))
                        {
                            UserView temp = new UserView(p.Name, p.LastName, p.BirthDate.ToString("d"), p.PhoneNumber);
                           
                            dow.DayPanel.Children.Add(temp);
                        }
                }
        }
        public Person CheckSelectedUser()
        {
            foreach (DayOfWeek d in dayOfWeeks)
            {
                foreach (Person p in Users)
                {
                    UserView temp = new UserView(p.Name, p.LastName, p.BirthDate.ToString("d"), p.PhoneNumber);
                    temp.IsSelected = true;
                    foreach(UserView view in d.MyItems)
                    {
                        if (temp.Name == view.Name&&temp.LastName==view.LastName&&temp.BirthDate==view.BirthDate&&temp.BirthDate==view.BirthDate)
                            return p;
                    }
                    
                }
               
            }
            return null;

        }
        public DateTime GetDisplayDate()
        {
            return MyCalendar.DisplayDate;
        }


        private void Grid_Initialized(object sender, EventArgs e)
        {
            if (Read != null)
                Read.Invoke(this, e);
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            if (a==0)
                if (Read != null) { 
                    Read.Invoke(this, e);
                    a = 1;
                }
        }
        public void CheckBirthDate()
        {
            if (MyCalendar != null)
                foreach(DayOfWeek d in dayOfWeeks)
                {
                    d.DayPanel.Children.Clear();
                    foreach(Person p in Users)
                        if (p.BirthDate.ToString("M")==d.TimeDate.ToString("M"))
                        {
                            UserView temp = new UserView(p.Name,p.LastName,p.BirthDate.ToString("d"),p.PhoneNumber);
                            d.MyItems.Add(temp);
                            d.DayPanel.Children.Add(temp);
                        }
                }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime time = Convert.ToDateTime(txtBoxDate.Text);
            Person temp = new Person(txtBoxName.Text, txtBoxLastName.Text, time, txtBoxPhone.Text);
            if(Write!=null)
                Write.Invoke(this, e);
            CheckBirthDate();

        }
        //Background="#FF5CC75C"

        private void MondayControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectUserView(sender);
        }

        private void TuesdayControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectUserView(sender);
        }

        private void WednesdayControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectUserView(sender);
        }

        private void ThursdayControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectUserView(sender);
        }

        private void FridayControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectUserView(sender);
        }

        private void SaturdayControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectUserView(sender);
        }

        private void SundayControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectUserView(sender);
        }

        private void Delete_click(object sender, RoutedEventArgs e)
        {
            if (Delete != null)
                Delete.Invoke(this, e);
            CheckBirthDate();
        }
    }
}
