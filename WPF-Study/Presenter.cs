using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace WPF_Study
{
    class Presenter
    {
        private Abstractions.IModel model;
        private Abstractions.IView view;
        public List<Person> PersonsPrs;
        public Presenter(Abstractions.IModel model, Abstractions.IView view)
        {
            this.model = model;
            this.view = view;

            this.view.Read += ReadText;
            this.view.Write += WriteText;
            this.view.Delete += DeleteRecord;

        }


        void ReadText(object sender, EventArgs e)
        {
            model.ReadFile(view.FileName);
            view.ListCount = model.Count();
            try
            {
                PersonsPrs = model.GetList();
                view.persons = PersonsPrs;
                view.CheckBirthDate();

            }
            catch
            {
                Debug.WriteLine("invalid data field");
            }
        }
        void WriteText(object sender, EventArgs e)
        {
            try
            {
                Person temp = new Person(view.txtName, view.txtLastName, Convert.ToDateTime(view.txtBirthDate), view.txtPhone);
                model.AddPerson(temp);
                model.WriteFile();
            }
            catch
            {
                Debug.WriteLine("invalid data field");
            }
        }
        void DeleteRecord(object sender, EventArgs e)
        {
            model.DeletePerson(view.CheckSelectedUser());
        }
    }
}