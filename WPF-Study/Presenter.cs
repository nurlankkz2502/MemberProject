using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Study
{
    class Presenter
    {
        private Abstractions.IModel model;
        private Abstractions.IView view;
        public Presenter(Abstractions.IModel model, Abstractions.IView view)
        {
            this.model = model;
            this.view = view;

           
        }

        
    }
}
