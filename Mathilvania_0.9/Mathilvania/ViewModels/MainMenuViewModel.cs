using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;

namespace Mathilvania.ViewModels
{
 
        public class MainMenuViewModel : NavigateViewModel
        {
            public MainMenuViewModel()
            {
                Title = "MainMenuViewModel";
            }
        private ICommand _btnOnePlayerGame_Click;
        private ICommand _btnTwoPlayersGame_Click;
        private ICommand _btnControls_Click;
        private ICommand _btnGeneralPlayerStats_Click;
        private ICommand _btnAboutApplication_Click;
        public ICommand BtnOnePlayerGame_Click
            {
                get
                {
                    if (_btnOnePlayerGame_Click == null)
                    {
                        _btnOnePlayerGame_Click = new RelayCommand(() =>
                        {
                           Navigate("Views/OnePlayerGameOptionsView.xaml");
                        });
                    }
                    return _btnOnePlayerGame_Click;
                }
                set { _btnOnePlayerGame_Click = value; }
            }
        public ICommand BtnTwoPlayersGame_Click
        {
            get
            {
                if (_btnTwoPlayersGame_Click == null)
                {
                    _btnTwoPlayersGame_Click = new RelayCommand(() =>
                    {
                        Navigate("Views/TwoPlayersGameOptionsView.xaml");
                    });
                }
                return _btnTwoPlayersGame_Click;
            }
            set { _btnTwoPlayersGame_Click = value; }
        }
        public ICommand BtnControls_Click
        {
            get
            {
                if (_btnControls_Click == null)
                {
                    _btnControls_Click = new RelayCommand(() =>
                    {
                        Navigate("Views/GameControlsView.xaml");
                    });
                }
                return _btnControls_Click;
            }
            set { _btnControls_Click = value; }
        }
        public ICommand BtnGeneralPlayerStats_Click
        {
            get
            {
                if (_btnGeneralPlayerStats_Click == null)
                {
                    _btnGeneralPlayerStats_Click = new RelayCommand(() =>
                    {
                        Navigate("Views/GeneralPlayerStatsView.xaml");
                    });
                }
                return _btnGeneralPlayerStats_Click;
            }
            set { _btnGeneralPlayerStats_Click = value; }
        }
        public ICommand BtnAboutApplication_Click
        {
            get
            {
                if (_btnAboutApplication_Click == null)
                {
                    _btnAboutApplication_Click = new RelayCommand(() =>
                    {
                        Navigate("Views/AboutApplicationView.xaml");
                    });
                }
                return _btnAboutApplication_Click;
            }
            set { _btnAboutApplication_Click = value; }

        }
        public ICommand BtnExit_Click
            {
            get
            {
                return new RelayCommand(() => Application.Current.Shutdown());
            }
        }
    }
  

    }
        
 
