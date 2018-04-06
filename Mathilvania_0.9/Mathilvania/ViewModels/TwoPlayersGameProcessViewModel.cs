using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Mathilvania.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;
using System;

namespace Mathilvania.ViewModels
{
    public class TwoPlayersGameProcessViewModel : NavigateViewModel, INotifyPropertyChanged
    {
        public Question _question;
        public CurrentPlayerStats player1Stats;
        public CurrentPlayerStats player2Stats;
        private System.Windows.Threading.DispatcherTimer timer;
        public TwoPlayersGameProcessViewModel()
        {
            Messenger.Default.Register<OnePlayerGameOptionsMessege>(this, (messege) =>
            {
                _question = new Question(0, messege.maxNumb, messege.additionChecked, messege.substractChecked, messege.multiplicationChecked, messege.negativeNumberChecked);
            });
        }
        public void Initialize()
        {
            player1Stats = new CurrentPlayerStats("Player 1");
            player2Stats = new CurrentPlayerStats("Player 2");
            
        }
        public void UnLoaded()
        {
            Cleanup();
        }
        public void OnLoaded()
        {
            refreshQuestion();
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }
        private void timerTick(object sender, EventArgs e)
        {
            player1Stats.PlayTime++;
        }
        private void GameOver(string text)
        {
            timer.Stop();
            GameOverTwoPlayersMessege messagePlayersStat = new GameOverTwoPlayersMessege();
            messagePlayersStat.winner = text;
            messagePlayersStat.countPlayer1TrueAnswers = player1Stats.countTrueAnswers;
            messagePlayersStat.countPlayer1FalseAnswers = player1Stats.countFalseAnswers;
            messagePlayersStat.countPlayer1Questions = player1Stats.countQuestions;
            messagePlayersStat.playTime = player1Stats.PlayTime;

            messagePlayersStat.countPlayer2TrueAnswers = player2Stats.countTrueAnswers;
            messagePlayersStat.countPlayer2FalseAnswers = player2Stats.countFalseAnswers;
            messagePlayersStat.countPlayer2Questions = player2Stats.countQuestions;

            Messenger.Default.Send<GameOverTwoPlayersMessege>(messagePlayersStat);
            Navigate("Views/GameOverTwoPlayersView.xaml");

        }
        private bool isGameOver()
        {
            if (player1Stats.countTrueAnswers == 10 || player2Stats.countTrueAnswers == 10)
                return true;
            else
                return false;
        }

        #region GameProcessLogic
        #region Properties
        private string _btn1Text;
        private string _btn2Text;
        private string _btn3Text;
        private string _btn4Text;
        private string _labelAText;
        private string _labelBText;
        private string _labelOperationText;
        private SolidColorBrush _button1Color = new SolidColorBrush(Colors.GhostWhite);
        private SolidColorBrush _button2Color = new SolidColorBrush(Colors.GhostWhite);
        private SolidColorBrush _button3Color = new SolidColorBrush(Colors.GhostWhite);
        private SolidColorBrush _button4Color = new SolidColorBrush(Colors.GhostWhite);
        private bool _player1StartAnimationFlag;
        private bool _player2StartAnimationFlag;
        public bool player1StartAnimationFlag
        {
            get { return _player1StartAnimationFlag; }
            set
            {
                if (value != _player1StartAnimationFlag)
                {
                    _player1StartAnimationFlag = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool player2StartAnimationFlag
        {
            get { return _player2StartAnimationFlag; }
            set
            {
                if (value != _player2StartAnimationFlag)
                {
                    _player2StartAnimationFlag = value;
                    OnPropertyChanged();
                }
            }
        }
        public string btn1Text
        {
            get
            {
                return _btn1Text;
            }
            set
            {
                _btn1Text = value;
                OnPropertyChanged();
            }
        }
        public string btn2Text
        {
            get
            {
                return _btn2Text;
            }
            set
            {
                _btn2Text = value;
                OnPropertyChanged();
            }
        }
        public string btn3Text
        {
            get
            {
                return _btn3Text;
            }
            set
            {
                _btn3Text = value;
                OnPropertyChanged();
            }
        }
        public string btn4Text
        {
            get
            {
                return _btn4Text;
            }
            set
            {
                _btn4Text = value;
                OnPropertyChanged();
            }
        }
        public SolidColorBrush button1Color
        {
            get { return _button1Color; }
            set
            {
                if (value != _button1Color)
                {
                    _button1Color = value;
                    OnPropertyChanged();
                }
            }
        }
        public SolidColorBrush button2Color
        {
            get { return _button2Color; }
            set
            {
                if (value != _button2Color)
                {
                    _button2Color = value;
                    OnPropertyChanged();
                }
            }
        }
        public SolidColorBrush button3Color
        {
            get { return _button3Color; }
            set
            {
                if (value != _button3Color)
                {
                    _button3Color = value;
                    OnPropertyChanged();
                }
            }
        }
        public SolidColorBrush button4Color
        {
            get { return _button4Color; }
            set
            {
                if (value != _button4Color)
                {
                    _button4Color = value;
                    OnPropertyChanged();
                }
            }
        }
        public string labelAText
        {
            get
            {
                return _labelAText;
            }
            set
            {
                _labelAText = value;
                OnPropertyChanged();
            }
        }
        public string labelBText
        {
            get
            {
                return _labelBText;
            }
            set
            {
                _labelBText = value;
                OnPropertyChanged();
            }
        }
        public string labelOperationText
        {
            get
            {
                return _labelOperationText;
            }
            set
            {
                _labelOperationText = value;
                OnPropertyChanged();
            }
        }
        #endregion
        private ICommand _btnMainMenu_Click;
        public ICommand BtnPlayer1_Click
        {
            get
            {
                return new RelayCommand<string>((string buttonContent) =>
                {
                    if (_question.isTrueAnswer(buttonContent))
                    {
                        player1StartAnimationFlag = true;
                        player1Stats.countTrueAnswers++;
                        if (isGameOver())
                            GameOver(player1Stats.playerName);
                    }
                    else
                    {
                        player1Stats.countFalseAnswers++;
                    }
                    player1StartAnimationFlag = false;
                    refreshQuestion();
                });
            }
        }
        public ICommand BtnPlayer2_Click
        {
                get
            {
                    return new RelayCommand<string>((string buttonContent) =>
                    {
                        if (_question.isTrueAnswer(buttonContent))
                        {
                            player2StartAnimationFlag = true;
                            player2Stats.countTrueAnswers++;
                            if (isGameOver())
                                GameOver(player2Stats.playerName);
                        }
                        else
                        {
                            player2Stats.countFalseAnswers++;
                        }
                        player2StartAnimationFlag = false;
                        refreshQuestion();
                    });
                }
         }
        private void refreshQuestion()
        {
            _question.newQuestion();
            labelAText = _question.firstNumb.ToString();
            labelBText = _question.secondNumb.ToString();
            btn1Text = _question.listOfAnswers[0].ToString();
            btn2Text = _question.listOfAnswers[1].ToString();
            btn3Text = _question.listOfAnswers[2].ToString();
            btn4Text = _question.listOfAnswers[3].ToString();
            labelOperationText = _question.operation.ToString();
            player1Stats.countQuestions++;
            player2Stats.countQuestions = player1Stats.countQuestions;
        }
        #endregion
        #region Other
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
            timer.Stop();
            Messenger.Default.Unregister(this);
            ViewModelLocator.Cleanup();
            base.Cleanup();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion
    }
}
