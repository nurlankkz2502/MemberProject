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
            CheckBirthDate();

        }

        List<Person> Users = new List<Person>();
        List<DayOfWeek> dayOfWeeks = new List<DayOfWeek>();
        private EventArgs e;

        public event EventHandler Read;
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
            if (MyCalendar.DisplayDate.Month != date.Month)
                MyCalendar.DisplayDate = date;
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
            if (Read != null)
                Read.Invoke(this, e);
        }
        public void CheckBirthDate()
        {
            foreach(DayOfWeek d in dayOfWeeks)
                foreach(Person p in Users)
                    if (p.BirthDate.ToString("M")==d.TimeDate.ToString("M"))
                    {
                        UserView temp = new UserView();

                        d.DayPanel.Children.Add(temp);
                    }
        }
    }
}
