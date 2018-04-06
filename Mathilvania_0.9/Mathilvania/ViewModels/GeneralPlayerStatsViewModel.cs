using System;
using System.ComponentModel;
using Mathilvania.Models;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MahApps.Metro.Controls.Dialogs;
using System.Windows;
using MahApps.Metro.Controls;

namespace Mathilvania.ViewModels
{
    public class GeneralPlayerStatsViewModel:NavigateViewModel,INotifyPropertyChanged
    {
        private TimeSpan _playingTime;
        private uint _countGames;
        private uint _countWin;
        private uint _countLose;
        private double _ratioWinLose;
        private uint _countQuestions;
        private uint _countTrueAnswers;
        private uint _countFalseAnswers;
        private double _ratioTrueFalseAnswers;

        public TimeSpan playingTime
        {
            get
            {
       
                return _playingTime;
            }
            set
            {
                _playingTime = value;
                OnPropertyChanged();
            }
        }
        public uint countGames
        {
            get
            {
                return _countGames;
            }
            set
            {
                _countGames = value;
                OnPropertyChanged();
            }
        }
        public uint countWin
        {
            get
            {
                return _countWin;
            }
            set
            {
                _countWin = value;
                OnPropertyChanged();
            }
        }
        public uint countLose
        {
            get
            {
                return _countLose;
            }
            set
            {
                _countLose = value;
                OnPropertyChanged();
            }
        }
        public double ratioWinLose
        {
            get
            {
                return _ratioWinLose;
            }
            set
            {
                _ratioWinLose = value;
                OnPropertyChanged();
            }
        }
        public uint countQuestions
        {
            get
            {
                return _countQuestions;
            }
            set
            {
                _countQuestions = value;
                OnPropertyChanged();
            }
        }
        public uint countTrueAnswers
        {
            get
            {
                return _countTrueAnswers;
            }
            set
            {
                _countTrueAnswers = value;
                OnPropertyChanged();
            }
        }
        public uint countFalseAnswers
        {
            get
            {
                return _countFalseAnswers;
            }
            set
            {
                _countFalseAnswers = value;
                OnPropertyChanged();
            }
        }
        public double ratioTrueFalseAnswers
        {
            get
            {
                return _ratioTrueFalseAnswers;
            }
            set
            {
                _ratioTrueFalseAnswers = value;
                OnPropertyChanged();
            }
        }
        GeneralPlayerStats generalStats = new GeneralPlayerStats();
        public GeneralPlayerStatsViewModel()
        {
            updateData();     
        }
        private void updateData()
        {
            generalStats.ReadStats();
            playingTime = generalStats.playngTime;
            countGames = generalStats.countGames;
            countWin = generalStats.countWin;
            countLose = generalStats.countLose;
            if (countLose == 0)
            {
                ratioWinLose = (double)countWin / 1;
            }
            else
            {
                ratioWinLose = (double)countWin / countLose;
            }
            countQuestions = generalStats.countQuestions;
            countTrueAnswers = generalStats.countTrueAnswers;
            countFalseAnswers = generalStats.countFalseAnswers;
            if (countFalseAnswers == 0)
            {
                ratioTrueFalseAnswers = (double)countTrueAnswers / 1;
            }
            else
            {
                ratioTrueFalseAnswers = (double)countTrueAnswers / countFalseAnswers;
            }
        }
        private ICommand _clearStats;
        public ICommand ClearStats
        {
            get
            {
                if (_clearStats == null)
                {
                    _clearStats = new RelayCommand(async () =>
                    {
                        MetroDialogSettings mySettings = new MetroDialogSettings
                        {
                            AffirmativeButtonText = "Да",
                            NegativeButtonText = "Нет",
                            AnimateShow = true,
                        };
                        MessageDialogResult dialogResult=await (Application.Current.MainWindow as MetroWindow).ShowMessageAsync
                            ("Удаление данных","Вы уверены?",MessageDialogStyle.AffirmativeAndNegative,mySettings);

                        if (dialogResult == MessageDialogResult.Affirmative)
                        {
                            generalStats.ClearStats();
                            updateData();
                        }
                       
                    });
                }
                return _clearStats;
            }
            set { _clearStats = value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
