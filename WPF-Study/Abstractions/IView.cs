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

        List<Person> persons { get; set; }
        event EventHandler Read;
    }
}
