using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathilvania.Models;
using GalaSoft.MvvmLight.Messaging;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Mathilvania.ViewModels
{
  public class GameOverViewModel : NavigateViewModel, INotifyPropertyChanged
    {
        public string playerName;
        private string _winner;
        private uint _countTrueAnswers;
        private uint _countFalseAnswers;
        private uint _countQuestions;
        private uint _playTime;
        public string winner
        {
            get
            {
                return _winner;
            }
            set
            {
                _winner = value;
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
                _countTrueAnswers=value;
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
        public uint countQuestions
        {
            get
            {
                return _countQuestions;
            }
            set
            {
                _countQuestions= value;
                OnPropertyChanged();
            }
        }
        public uint playTime
        {
            get
            {
                return _playTime;
            }
            set
            {
                _playTime = value;
                OnPropertyChanged();
            }
        }
        public  GameOverViewModel()
        {
            Messenger.Default.Register<GameOverMessege>(this, (messege) =>
            {
                playerName = messege.playerName;
                winner = messege.winner;
                playTime = messege.playTime;
                countTrueAnswers = messege.countTrueAnswers;
                countFalseAnswers = messege.countFalseAnswers;
                countQuestions = messege.countQuestions;
            });
        }
        private ICommand _btnMainMenu_Click;
        public ICommand BtnMainMenu_Click
        {
            get
            {
                if (_btnMainMenu_Click == null)
                {
                    _btnMainMenu_Click = new RelayCommand(() =>
                    {
                        this.Cleanup();
                        Navigate("Views/MainMenuPage.xaml");
                    });
                }
                return _btnMainMenu_Click;
            }
            set { _btnMainMenu_Click = value; }
        }
        public override void Cleanup()
        {
            base.Cleanup();
            ViewModelLocator.Cleanup();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
