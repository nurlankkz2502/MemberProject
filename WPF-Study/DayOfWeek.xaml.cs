﻿using System;
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


namespace WPF_Study
{
    /// <summary>
    /// Логика взаимодействия для DayOfWeek.xaml
    /// </summary>
    public partial class DayOfWeek : UserControl
    {
        public DateTime TimeDate { get; set; }
        public bool IsSelected;
        public DayOfWeek()
        {
            InitializeComponent();
            IsSelected = false;
        }
    }
}
