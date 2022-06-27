using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace WPF_Study.Abstractions
{
    interface IView
    {
        string FileName { get; set; }
        int ListCount { get; set; } 
        Calendar ViewCalendar { get; set; }
        DateTime GetDisplayDate();
        void CheckBirthDate();
        Person CheckSelectedUser();

        List<Person> persons { get; set; }
        string txtName { get; set; }
        string txtLastName { get; set; }
        string txtBirthDate { get; set; }
        string txtPhone { get; set; }

        event EventHandler Delete;
        event EventHandler Read;
        event EventHandler Write;
    }
}
