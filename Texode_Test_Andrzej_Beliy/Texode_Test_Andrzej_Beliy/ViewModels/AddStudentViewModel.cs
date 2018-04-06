using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Texode_Test_Andrzej_Beliy.Models;
using Texode_Test_Andrzej_Beliy.ViewModels;

namespace Texode_Test_Andrzej_Beliy.ViewModels
{
    public class AddStudentViewModel:IDataErrorInfo,INotifyPropertyChanged
    {
        private int _Id;
        private string _firstName;
        private string _lastName;
        private uint _age=16;
        private uint _gender;
        private List<Gender> _listOfGender;
        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                OnPropertyChanged();
            }
        }
        public string firstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string lastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public uint age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }
        public uint gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }
        public List<Gender> listOfGender
        {
            get { return _listOfGender; }
            set
            {
                _listOfGender = value;
                OnPropertyChanged();
            }
        }

        public AddStudentViewModel()
        {
            listOfGender = Gender.getListOfGender();
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                   
                    case "age":
                        {
                            if ((age < 16) || (age > 100))
                            {
                                error = "Допустимые значения возраста от 16 до 100";
                            }
                            break;
                        }

                    case "firstName":
                        {
                            if (string.IsNullOrEmpty(firstName))
                            {
                                error = "Укажите имя";
                            }
                            break;
                        }
                    case "lastName":

                        {
                            if (string.IsNullOrEmpty(lastName))
                            {
                                error = "Укажите фамилию";
                            }
                            break;
                        }
                    default:
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }  

        public ICommand Add_Click
        {
            get
            {
                return new Services.RelayCommand((x) =>
                {
                    if (MainViewModel.instance != null)
                    {
                            Services.GenderConverter gconverter = new Services.GenderConverter();
                            Student stud = new Student(MainViewModel.instance.listOfStud.Count + 1, firstName, lastName, age,gender);
                            MainViewModel.instance.listOfStud.AddStudent(stud);
                            propertiesInNull();                      
                    }
                });
            }
        }

        private void propertiesInNull()
        {
            Id = 0;
            firstName = null;
            lastName = null;
            age = 16;
            gender = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
