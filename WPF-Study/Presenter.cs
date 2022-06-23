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

        }


        void ReadText(object sender, EventArgs e)
        {
            model.ReadFile(view.FileName);
            view.ListCount = model.Count();
            try
            {
                PersonsPrs = model.GetList();
                view.persons = PersonsPrs;

            }
            catch
            {
                Debug.WriteLine("invalid data field");
            }
        }
    }
}