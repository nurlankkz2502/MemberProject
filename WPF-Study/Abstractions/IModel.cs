using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Study.Abstractions
{
    interface IModel
    {
        void ShowIn(string message);
        void ReadFile(string path);
        Person ShowData(int a);
    }
}
