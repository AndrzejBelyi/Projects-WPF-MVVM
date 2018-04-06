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
using GalaSoft.MvvmLight;

namespace Mathilvania.ViewModels
{
    public class OnePlayerGameProcessViewModel : NavigateViewModel, INotifyPropertyChanged
    {
        public Question _question;
        public CurrentPlayerStats player1Stats;
        GeneralPlayerStats generalstats = new GeneralPlayerStats();
        private System.Windows.Threading.DispatcherTimer timer;
        public OnePlayerGameProcessViewModel()
        {
        
            
            Messenger.Default.Register<OnePlayerGameOptionsMessege>(this, (messege) =>
             {
                 _question = new Question(0, messege.maxNumb, messege.additionChecked, messege.substractChecked, messege.multiplicationChecked, messege.negativeNumberChecked);  
                 enemySpeed = messege.speedEnemy;                 
             });
        }
        public void Initialize()
        {
            player1Stats = new CurrentPlayerStats("Player 1");
            generalstats.ReadStats();
  
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
        }

        private void timerTick(object sender, EventArgs e)
        {
            player1Stats.PlayTime++;
            if (isGameOver())
                GameOver(false);
        }
        private void GameOver(bool isPlayerWin)
        {
            timer.Stop();
            GameOverMessege message = new GameOverMessege();
            generalstats.playngTime+=(TimeSpan.FromSeconds(player1Stats.PlayTime));
            generalstats.countGames++;
            if (isPlayerWin)
            {
                generalstats.countWin++;
                message.winner = player1Stats.playerName;
            }
            else
            {
                generalstats.countLose++;
                message.winner = "npc";
            }
            generalstats.countQuestions += player1Stats.countQuestions;
            generalstats.countTrueAnswers += player1Stats.countTrueAnswers;
            generalstats.countFalseAnswers += player1Stats.countFalseAnswers;
            generalstats.WriteStats();
            message.playerName = player1Stats.playerName;
            message.countTrueAnswers = player1Stats.countTrueAnswers;
            message.countFalseAnswers = player1Stats.countFalseAnswers;
            message.countQuestions = player1Stats.countQuestions;
            message.playTime = player1Stats.PlayTime;
            Messenger.Default.Send<GameOverMessege>(message);            
            Navigate("Views/GameOverView.xaml");
        }
        #region GameProcessLogic
        #region Properties
        public int enemySpeed { get; set; }
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
        private bool _startEnemyAnimationFlag;
        private bool _startPlayerAnimationFlag;
        public bool startPlayerAnimationFlag
        {
            get { return _startPlayerAnimationFlag; }
            set
            {
                if (value != _startPlayerAnimationFlag)
                {
                    _startPlayerAnimationFlag = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool startEnemyAnimationFlag
        {
            get { return _startEnemyAnimationFlag; }
            set
            {
                if (value != _startEnemyAnimationFlag)
                {
                    _startEnemyAnimationFlag = value;
                    OnPropertyChanged();
                }
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
        public string Btn1Text
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
        public string Btn2Text
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
        public string Btn3Text
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
        public string Btn4Text
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
        public string LabelAText
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
        public string LabelBText
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
        public ICommand Btn_Click
        {
            get
            {
                return new RelayCommand<string>((string buttonContent) =>
                {
                    startEnemyAnimationFlag = true;
                    timer.Start();
                    if (_question.isTrueAnswer(buttonContent))
                    {
                        player1Stats.countTrueAnswers++;
                        startPlayerAnimationFlag = true;
                        if (isGameOver())
                        {
                            GameOver(true);

                        }
                    }
                    else
                    {
                        player1Stats.countFalseAnswers++;
                    }
                    startPlayerAnimationFlag = false;
                    refreshQuestion();
                });
            }
        }
        private void refreshQuestion()
        {
            _question.newQuestion();
            LabelAText = _question.firstNumb.ToString();
            LabelBText = _question.secondNumb.ToString();
            Btn1Text = _question.listOfAnswers[0].ToString();
            Btn2Text = _question.listOfAnswers[1].ToString();
            Btn3Text = _question.listOfAnswers[2].ToString();
            Btn4Text = _question.listOfAnswers[3].ToString();
            labelOperationText = _question.operation.ToString();
            player1Stats.countQuestions++;
        }
        private bool isGameOver()
        {
            if (player1Stats.PlayTime == enemySpeed || player1Stats.countTrueAnswers == 10)
            return true;
            else
            return false;    
        }
        #endregion
        #region Other
      
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
