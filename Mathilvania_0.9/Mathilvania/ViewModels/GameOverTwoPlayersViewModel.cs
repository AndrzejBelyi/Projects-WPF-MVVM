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
   public class GameOverTwoPlayersViewModel : NavigateViewModel, INotifyPropertyChanged
    {
        private string _winner;
        private uint _countPlayer1TrueAnswers;
        private uint _countPlayer1FalseAnswers;
        private uint _countPlayer1Questions;
        private uint _countPlayer2TrueAnswers;
        private uint _countPlayer2FalseAnswers;
        private uint _countPlayer2Questions;
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
        public uint countPlayer1TrueAnswers
        {
            get
            {
                return _countPlayer1TrueAnswers;
            }
            set
            {
                _countPlayer1TrueAnswers = value;
                OnPropertyChanged();
            }
        }
        public uint countPlayer1FalseAnswers
        {
            get
            {
                return _countPlayer1FalseAnswers;
            }
            set
            {
                _countPlayer1FalseAnswers = value;
                OnPropertyChanged();
            }
        }
        public uint countPlayer1Questions
        {
            get
            {
                return _countPlayer1Questions;
            }
            set
            {
                _countPlayer1Questions = value;
                OnPropertyChanged();
            }
        }

        public uint countPlayer2TrueAnswers
        {
            get
            {
                return _countPlayer2TrueAnswers;
            }
            set
            {
                _countPlayer2TrueAnswers = value;
                OnPropertyChanged();
            }
        }
        public uint countPlayer2FalseAnswers
        {
            get
            {
                return _countPlayer2FalseAnswers;
            }
            set
            {
                _countPlayer2FalseAnswers = value;
                OnPropertyChanged();
            }
        }
        public uint countPlayer2Questions
        {
            get
            {
                return _countPlayer2Questions;
            }
            set
            {
                _countPlayer2Questions = value;
                OnPropertyChanged();
            }
        }
        public uint playingTime
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
        public  GameOverTwoPlayersViewModel()
        {
            Messenger.Default.Register<GameOverTwoPlayersMessege>(this, (messege) =>
            {
                winner = messege.winner+" WIN!";
                playingTime = messege.playTime;
                countPlayer1Questions = messege.countPlayer1Questions;
                countPlayer1TrueAnswers = messege.countPlayer1TrueAnswers;
                countPlayer1FalseAnswers = messege.countPlayer1FalseAnswers;
                countPlayer2Questions = messege.countPlayer2Questions;
                countPlayer2TrueAnswers = messege.countPlayer2TrueAnswers;
                countPlayer2FalseAnswers = messege.countPlayer2FalseAnswers;

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
