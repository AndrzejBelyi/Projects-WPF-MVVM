using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Mathilvania.Models;

namespace Mathilvania.ViewModels
{
   public class OnePlayerGameOptionsViewModel:NavigateViewModel,INotifyPropertyChanged
    {
        private ICommand _startGame_Click;
        private int _speedEnemy;
        private bool _negtiveNumberChecked;
        private bool _additionChecked;
        private bool _substractChecked;
        private bool _multiplicationChecked;
        private int _maxNumb;
        private bool _enabledSand;
        private int _selectedDifficulty;
        #region Properties
       public int speedEnemy
        {
            get
            { 
                return _speedEnemy;
            }
            set
            {
                _speedEnemy = value;
                OnPropertyChanged();
            }
        }
        public bool negativeNumberChecked
        {
            get
            {
                return _negtiveNumberChecked;
            }
            set
            {
                _negtiveNumberChecked = value;
                OnPropertyChanged();
            }
        }
        public bool additionChecked
        {
            get
            {
                return _additionChecked;
            }
            set
            {
                _additionChecked = value;
                OnPropertyChanged();
            }
        }

        public bool substractChecked
        {
            get
            {
                return _substractChecked;
            }
            set
            {
                _substractChecked = value;
                OnPropertyChanged();
            }
        }
        public bool multiplicationChecked
        {
            get
            {
                return _multiplicationChecked;
            }
            set
            {
               _multiplicationChecked = value;
                OnPropertyChanged();
            }
        }
        public int maxNumb
        {
            get
            {
                return _maxNumb;
            }
            set
            {
                _maxNumb = value;
                OnPropertyChanged();
            }
        }
        public bool enabledSand
        {
            get
            {
                return _enabledSand;
            }
            set
            {
                _enabledSand = value;
                OnPropertyChanged();
            }
        }
  
    public int selectedDifficulty
    {
        get
        {
            return _selectedDifficulty;
        }
        set
        {
                
            _selectedDifficulty = value;
                switch(value)
                {
                    case 0:
                        speedEnemy = 20;
                        enabledSand = false;
                        negativeNumberChecked = false;
                        additionChecked = true;
                        substractChecked = false;
                        multiplicationChecked =false;
                        maxNumb = 5;
                        break;
                    case 1:
                        speedEnemy = 15;
                        enabledSand = false;
                        negativeNumberChecked = false;
                        additionChecked = true;
                        substractChecked = true;
                        multiplicationChecked =false;
                        maxNumb = 10;
                        break;
                    case 2:
                        speedEnemy = 15;
                        enabledSand = false;
                        negativeNumberChecked = false;
                        additionChecked = true;
                        substractChecked = true;
                        multiplicationChecked = true;
                        maxNumb = 10;
                        break;
                    case 3:
                        speedEnemy = 15;
                        enabledSand = false;
                        negativeNumberChecked = true;
                        additionChecked = true;
                        substractChecked = true;
                        multiplicationChecked = true;
                        maxNumb = 10;
                        break;
                    case 4:
                        speedEnemy = 20;
                        enabledSand = false;
                        negativeNumberChecked = true;
                        additionChecked = true;
                        substractChecked = true;
                        multiplicationChecked = true;
                        maxNumb = 20;
                        break;
                    case 5:
                        speedEnemy = 25;
                        enabledSand = false;
                        negativeNumberChecked = true;
                        additionChecked = true;
                        substractChecked = true;
                        multiplicationChecked = true;
                        maxNumb = 30;
                        break;
                    case 6:
                        speedEnemy = 10;
                        enabledSand = true;
                        negativeNumberChecked = false;
                        additionChecked = true;
                        substractChecked = false;
                        multiplicationChecked = false;
                        maxNumb = 10;
                        break;
                    default:
                        break;
                }
              OnPropertyChanged();
        }
    }
        #endregion
        public IReadOnlyList<Difficulty> listOfDifficulty { get; set; }
        public OnePlayerGameOptionsViewModel()
        {
            
            listOfDifficulty = Models.Difficulty.getListOfDifficulty();
            selectedDifficulty = 0;
        }
        public ICommand StartGame_Click
        {
            get
            {
                if (_startGame_Click == null)
                {
                    _startGame_Click = new RelayCommand(() =>
                    {
                        if (substractChecked == false && multiplicationChecked == false && additionChecked == false)
                        {
                            additionChecked = true;
                        }
                        else
                        {
                            OnePlayerGameOptionsMessege message = new OnePlayerGameOptionsMessege();
                            message.speedEnemy = speedEnemy;
                            message.negativeNumberChecked = negativeNumberChecked;
                            message.additionChecked = additionChecked;
                            message.substractChecked = substractChecked;
                            message.multiplicationChecked = multiplicationChecked;
                            message.maxNumb = maxNumb;
                            Messenger.Default.Send<OnePlayerGameOptionsMessege>(message);
                            Navigate("Views/OnePlayerGameProcessView.xaml");
                        }
                    });
                }
                return _startGame_Click;
            }
            set { _startGame_Click = value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
