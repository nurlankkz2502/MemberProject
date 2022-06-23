using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
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
    class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }

        public Person(string name, string lastname, DateTime birthdate, string phonenumber)
        {
            Name = name;
            LastName = lastname;
            BirthDate = birthdate;
            PhoneNumber = phonenumber;
        }
    }
    class Model : Abstractions.IModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<Person> Persons = new List<Person>();


        public void ReadFile(string str)
        {
            if (Persons.Count == 0)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(str))
                    {


                        string line;
                        // Read and display lines from the file until the end of
                        // the file is reached.
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] arr = { "\t" };
                            arr = line.Split(arr, StringSplitOptions.RemoveEmptyEntries);
                            DateTime birth = Convert.ToDateTime(arr[2]);
                            Person temp = new Person(arr[1], arr[0], birth, arr[3]);
                            Persons.Add(temp);

                        }
                    }

                }

                catch (Exception e)
                {
                    Debug.WriteLine("The file could not be read:");
                    Debug.WriteLine(e.Message);
                }
            }
        }
        public int Count()
        {
            return Persons.Count;
        }
        public Person ShowData(int number)
        {
            if (number > 0 && number <= Persons.Count)
                return Persons[number - 1];
            else
                return null;
        }

    
        public List<Person> GetList()
        {
            return Persons;

        }

        public void ShowIn(string message)
        {
            Debug.WriteLine(message);
           
        }

    }
}
