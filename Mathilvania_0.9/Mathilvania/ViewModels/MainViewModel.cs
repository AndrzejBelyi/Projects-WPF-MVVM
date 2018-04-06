using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Mathilvania.ViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : NavigateViewModel,INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            aspectRatio = "4:3";
            _mainGridWidth = "1366";
            _mainGridHeight ="738";

        }
        private string _aspectRatio;
        private string _mainGridWidth;
        private string _mainGridHeight;
        private ICommand _btnMainMenu_Click;
        public string aspectRatio
        {
            get
            {
                return _aspectRatio;
            }
            set
            {
                _aspectRatio = value;
                OnPropertyChanged();
            }
        }
        public string mainGridWidth
        {
            get
            {
                return _mainGridWidth;
            }
            set
            {
                _mainGridWidth = value;
                OnPropertyChanged();
            }
        }
        public string mainGridHeight
        {
            get
            {
                return _mainGridHeight;
            }
            set
            {
                _mainGridHeight = value;
                OnPropertyChanged();
            }
        }

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
    }

}