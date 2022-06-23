using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Study.Abstractions
{
    interface IModel
    {
        void ShowIn(string message);
        void ReadFile(string path);
        int Count();
        List<Person> GetList();
        Person ShowData(int a);
    }
}
