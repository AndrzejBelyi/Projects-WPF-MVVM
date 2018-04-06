using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Texode_Test_Andrzej_Beliy.Models;
using Texode_Test_Andrzej_Beliy;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Texode_Test_Andrzej_Beliy.ViewModels
{
    public class MainViewModel:INotifyPropertyChanged
    {
        private ListOfStudents _listOfStud = new ListOfStudents();
        private static MainViewModel _instance = null;
        private int _selectedIndex=-1;
        private bool _editDelEnable;
        private bool _confirmDelete;

        public bool confirmDelete
        {
            get
            {
                return _confirmDelete;
            }
            set
            {
                _confirmDelete = value;
                OnPropertyChanged();
            }
        }
        public bool editDelEnable
        {
            get { return _editDelEnable; }
            set
            {
                _editDelEnable = value;
                OnPropertyChanged();
            }
        }
        public int selectedIndex
        {
            get { return _selectedIndex; }
            set
            {                                
                _selectedIndex = value;
                OnPropertyChanged();
                if (_selectedIndex >=0)
                    editDelEnable = true;
                else
                    editDelEnable = false;

               
            }
        }
        public ListOfStudents listOfStud
        {
            get
            {
                return _listOfStud;
            }
            set
            {              
                _listOfStud = value;
                OnPropertyChanged();
            }
        }
        public static MainViewModel instance { get { return _instance; } private set{ _instance = value; } }

        public MainViewModel()
        {
            instance = this;
        }
        public ICommand Delete_Click
        {
            get
            {
                return new Services.RelayCommand((selectedItems) =>
                {   /////////////////////////////////////////////////////////////////////////////////////////
                    //Небольшое нарушение паттерна MVVM,вызовом диалога из модели представления
                    //,чтобы не нарушать паттерн можно воспользоваться сторонними библиотеками,
                    //однако в данном случае это решение будет слишком громоздким для данного приложения.
                    //////////////////////////////////////////////////////////////////////////////////////////
                    System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show("Вы уверены?", "Удаление данных", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question);
                    if (result == System.Windows.MessageBoxResult.Yes)
                    {
                        var selected = selectedItems as IList;
                        for (int i = selected.Count - 1; i >= 0; i--)
                        {
                            listOfStud.DeleteStud(listOfStud.IndexOf(selected[i] as Student));
                        }
                    }
                   
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
