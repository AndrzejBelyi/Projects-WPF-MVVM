using GalaSoft.MvvmLight.Command;
using Mathilvania.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Mathilvania.ViewModels
{
    public class GameProcessViewModel : NavigateViewModel, INotifyPropertyChanged
    {
        private MathExpression _expression;
        private Question _question;
        private List<int> _listOfAnswers;
        public GameProcessViewModel()
        {
            _expression = new MathExpression(1, 10, true, false, false, false);
            _question = new Question(_expression);
            _listOfAnswers = new List<int>(_question.getListOfAnswers());
            getQuestion();
        }
        #region GameProcessLogic
        #region Properties
        private string _btn1Text;
        private string _btn2Text;
        private string _btn3Text;
        private string _btn4Text;
        private string _labelAText;
        private string _labelBText;
        private string _labelResultText;

        public string Btn1Text {
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
        public string LabelResultText
        {
            get
            {
                return _labelResultText;
            }
            set
            {
                _labelResultText = value;
                OnPropertyChanged();
            }
        }
        #endregion
        private ICommand _btnMainMenu_Click;
        public ICommand Btn_Click
        {
            get
            {
                return new RelayCommand<string>((string parameter) =>
                {
                    if (isTrueAnswer(parameter))
                    {
                        LabelResultText = "Верно";
                    }
                    else
                    {
                        LabelResultText = "Неверно";
                    }
                    refreshQuestion();
                   getQuestion();
                });
            }
        }
        private void refreshQuestion()
        {
            _question = new Question(_expression);
        }
        private void getQuestion()
        {
            _listOfAnswers = _question.getListOfAnswers();
            LabelAText = _question.firstNumb.ToString();
            LabelBText = _question.secondNumb.ToString();
            Btn1Text = _listOfAnswers[0].ToString();
            Btn2Text = _listOfAnswers[1].ToString();
            Btn3Text = _listOfAnswers[2].ToString();
            Btn4Text = _listOfAnswers[3].ToString();
        }
        private bool isTrueAnswer(string answer)
        {
            bool result = false;
            if(answer==_question.trueResult.ToString())
            {
                result = true;
            }
            return result;
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
                        Navigate("Views/MainMenuPage.xaml");
                    });
                }
                return _btnMainMenu_Click;
            }
            set { _btnMainMenu_Click = value; }
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
