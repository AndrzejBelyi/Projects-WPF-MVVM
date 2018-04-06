using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Mathilvania.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using System;
using MahApps.Metro.Controls;
using System.Windows.Media;
using MahApps.Metro.IconPacks;

namespace Mathilvania
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow :MetroWindow
    {
        private MediaPlayer mediaPlayerBackground = new MediaPlayer();
        private MediaPlayer mediaPlayerGameProcess = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
            NavigationSetup();
            window.Loaded += Window_Loaded;
            MainFrame.Navigated += MainFrame_Navigated;
            mediaPlayerBackground.Volume = 1;
            mediaPlayerGameProcess.Volume = 1;
            mediaPlayerBackground.Open(new Uri(@"Resources/Lee_Rosevere_-_09_-_The_Last_Question.mp3", UriKind.Relative));
            mediaPlayerGameProcess.Open(new Uri(@"Resources/BoxCat_Games_-_03_-_Battle_Special.mp3", UriKind.Relative));

        }

        private void ButtonMute_Click(object sender, RoutedEventArgs e)
        {
            if(!mediaPlayerBackground.IsMuted)
            {
                mediaPlayerBackground.IsMuted = true;
                mediaPlayerGameProcess.IsMuted = true;
                ButtonMute_Mute();
            }
            else
            {
                mediaPlayerBackground.IsMuted = false;
                mediaPlayerGameProcess.IsMuted = false;
                ButtonMute_UnMute();
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ButtonMute_UnMute();
           
        }

        private void PlayMusicBackGround()
        {
            mediaPlayerGameProcess.Stop();
            mediaPlayerBackground.Play();
        }
        private void PlayMusicGameProcess()
        {
            mediaPlayerBackground.Stop();
            mediaPlayerGameProcess.Play(); 
        }
        private void ButtonMute_UnMute()
        {
            var stackPanel = new StackPanel() { Orientation = Orientation.Horizontal };
            var packIconMaterial = new PackIconModern()
            {
                Kind = PackIconModernKind.Sound3,
                Margin = new Thickness(4, 4, 2, 4),
                Width = 30,
                Height = 30,
                VerticalAlignment = VerticalAlignment.Center
            };
            stackPanel.Children.Add(packIconMaterial);
            buttonMute.Content = stackPanel;
        }
        private void ButtonMute_Mute()
        {
            var stackPanel = new StackPanel() { Orientation = Orientation.Horizontal };
            var packIconMaterial = new PackIconModern()
            {
                Kind = PackIconModernKind.SoundMute,
                Margin = new Thickness(4, 4, 2, 4),
                Width = 30,
                Height = 30,
                VerticalAlignment = VerticalAlignment.Center
            };
            stackPanel.Children.Add(packIconMaterial);
            buttonMute.Content = stackPanel;
        }

 

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            switch (e.Content.ToString())
            {
                case "Mathilvania.Views.MainMenuPage":
                    {
                        PlayMusicBackGround();
                        buttonMainMenu.Visibility = Visibility.Hidden;
                        break;
                    }
                case "Mathilvania.Views.OnePlayerGameProcessView":
                    {
                        PlayMusicGameProcess();
                        break;
                    }
                case "Mathilvania.Views.TwoPlayersGameProcessView":
                    {
                        PlayMusicGameProcess();
                        break;
                    }
                case "Mathilvania.Views.TwoPlayersGameProcessSplitModeView":
                    {
                        PlayMusicGameProcess();
                        break;
                    }
                case "Mathilvania.Views.GameOverView":
                    {
                        break;
                    }
                case "Mathilvania.Views.GameOverTwoPlayersView":
                    {
                        break;
                    }
                default:
                    PlayMusicBackGround();
                    buttonMainMenu.Visibility = Visibility.Visible;                 
                    break;
            }
        }

        void NavigationSetup()
        {
            Messenger.Default.Register<NavigateArgs>(this, (x) =>
            {
                MainFrame.Navigate(new Uri(x.Url, UriKind.Relative));
            });
        }
    }
}
