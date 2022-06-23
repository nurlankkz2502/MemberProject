using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Study.Abstractions
{
    interface IView
    {
        string FileName { get; set; }

        event EventHandler Read;
    }
}
