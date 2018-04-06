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
    public class TwoPlayersGameProcessSplitModeViewModel : NavigateViewModel, INotifyPropertyChanged
    {
        public Question _question1;
        public Question _question2;
        public CurrentPlayerStats player1Stats;
        public CurrentPlayerStats player2Stats;
        private System.Windows.Threading.DispatcherTimer timer;
        public TwoPlayersGameProcessSplitModeViewModel()
        {
            Messenger.Default.Register<OnePlayerGameOptionsMessege>(this, (messege) =>
            {
                _question1 = new Question(0, messege.maxNumb, messege.additionChecked, messege.substractChecked, messege.multiplicationChecked, messege.negativeNumberChecked);
                _question2 = new Question(0, messege.maxNumb, messege.additionChecked, messege.substractChecked, messege.multiplicationChecked, messege.negativeNumberChecked);              
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
            refreshQuestion1();
            refreshQuestion2();
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }
        private void timerTick(object sender, EventArgs e)
        {
            player1Stats.PlayTime++;  
        }
        private void GameOver(string winner)
        {
            timer.Stop();
            GameOverTwoPlayersMessege messagePlayersStat = new GameOverTwoPlayersMessege();
            messagePlayersStat.winner = winner;
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
            if (player1Stats.countTrueAnswers==10 || player2Stats.countTrueAnswers == 10)
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
        private string _btn5Text;
        private string _btn6Text;
        private string _btn7Text;
        private string _btn8Text;
        private string _labelA1Text;
        private string _labelB1Text;
        private string _labelA2Text;
        private string _labelB2Text;
        private string _labelOperation1Text;
        private string _labelOperation2Text;
        private SolidColorBrush _button1Color = new SolidColorBrush(Colors.GhostWhite);
        private SolidColorBrush _button2Color = new SolidColorBrush(Colors.GhostWhite);
        private SolidColorBrush _button3Color = new SolidColorBrush(Colors.GhostWhite);
        private SolidColorBrush _button4Color = new SolidColorBrush(Colors.GhostWhite);
        private SolidColorBrush _button5Color = new SolidColorBrush(Colors.GhostWhite);
        private SolidColorBrush _button6Color = new SolidColorBrush(Colors.GhostWhite);
        private SolidColorBrush _button7Color = new SolidColorBrush(Colors.GhostWhite);
        private SolidColorBrush _button8Color = new SolidColorBrush(Colors.GhostWhite);
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
        public string btn5Text
        {
            get
            {
                return _btn5Text;
            }
            set
            {
                _btn5Text = value;
                OnPropertyChanged();
            }
        }
        public string btn6Text
        {
            get
            {
                return _btn6Text;
            }
            set
            {
                _btn6Text = value;
                OnPropertyChanged();
            }
        }
        public string btn7Text
        {
            get
            {
                return _btn7Text;
            }
            set
            {
                _btn7Text = value;
                OnPropertyChanged();
            }
        }
        public string btn8Text
        {
            get
            {
                return _btn8Text;
            }
            set
            {
                _btn8Text = value;
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
        public SolidColorBrush button5Color
        {
            get { return _button5Color; }
            set
            {
                if (value != _button5Color)
                {
                    _button5Color = value;
                    OnPropertyChanged();
                }
            }
        }
        public SolidColorBrush button6Color
        {
            get { return _button6Color; }
            set
            {
                if (value != _button6Color)
                {
                    _button6Color = value;
                    OnPropertyChanged();
                }
            }
        }
        public SolidColorBrush button7Color
        {
            get { return _button7Color; }
            set
            {
                if (value != _button7Color)
                {
                    _button7Color = value;
                    OnPropertyChanged();
                }
            }
        }
        public SolidColorBrush button8Color
        {
            get { return _button8Color; }
            set
            {
                if (value != _button8Color)
                {
                    _button8Color = value;
                    OnPropertyChanged();
                }
            }
        }
        public string labelA1Text
        {
            get
            {
                return _labelA1Text;
            }
            set
            {
                _labelA1Text = value;
                OnPropertyChanged();
            }
        }
        public string labelB1Text
        {
            get
            {
                return _labelB1Text;
            }
            set
            {
                _labelB1Text = value;
                OnPropertyChanged();
            }
        }
        public string labelA2Text
        {
            get
            {
                return _labelA2Text;
            }
            set
            {
                _labelA2Text = value;
                OnPropertyChanged();
            }
        }
        public string labelB2Text
        {
            get
            {
                return _labelB2Text;
            }
            set
            {
                _labelB2Text = value;
                OnPropertyChanged();
            }
        }
        public string labelOperation1Text
        {
            get
            {
                return _labelOperation1Text;
            }
            set
            {
                _labelOperation1Text = value;
                OnPropertyChanged();
            }
        }
        public string labelOperation2Text
        {
            get
            {
                return _labelOperation2Text;
            }
            set
            {
                _labelOperation2Text = value;
                OnPropertyChanged();
            }
        }
        #endregion
        
        public ICommand Btn_Player1Click
        {
            get
            {
                return new RelayCommand<string>((string buttonContent) =>
                {
                    if(_question1.isTrueAnswer(buttonContent))
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
                    refreshQuestion1();
                });
            }
        }
        public ICommand Btn_Player2Click
        {
            get
            {
                return new RelayCommand<string>((string buttonContent) =>
                {
                    if (_question2.isTrueAnswer(buttonContent))
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
                    refreshQuestion2();
                });
            }
        }
        private void refreshQuestion1()
        {
            _question1.newQuestion();
            labelA1Text = _question1.firstNumb.ToString();
            labelB1Text = _question1.secondNumb.ToString();
            btn1Text = _question1.listOfAnswers[0].ToString();
            btn2Text = _question1.listOfAnswers[1].ToString();
            btn3Text = _question1.listOfAnswers[2].ToString();
            btn4Text = _question1.listOfAnswers[3].ToString();
            labelOperation1Text = _question1.operation.ToString();
            player1Stats.countQuestions++;
        }
        private void refreshQuestion2()
        {
            _question2.newQuestion();
            labelA2Text = _question2.firstNumb.ToString();
            labelB2Text = _question2.secondNumb.ToString();
            btn5Text = _question2.listOfAnswers[0].ToString();
            btn6Text = _question2.listOfAnswers[1].ToString();
            btn7Text = _question2.listOfAnswers[2].ToString();
            btn8Text = _question2.listOfAnswers[3].ToString();
            labelOperation2Text = _question2.operation.ToString();
            player2Stats.countQuestions++;
        }
        #endregion
        #region Other
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
