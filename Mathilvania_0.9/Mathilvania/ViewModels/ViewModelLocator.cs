/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WPFNavigation"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Mathilvania.ViewModels;

namespace Mathilvania.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MainMenuViewModel>();
            SimpleIoc.Default.Register<OnePlayerGameOptionsViewModel>();
            SimpleIoc.Default.Register<OnePlayerGameProcessViewModel>(true);
            SimpleIoc.Default.Register<TwoPlayersGameOptionsViewModel>();
            SimpleIoc.Default.Register<TwoPlayersGameProcessViewModel>(true);
            SimpleIoc.Default.Register<TwoPlayersGameProcessSplitModeViewModel>(true);
            SimpleIoc.Default.Register<GameOverViewModel>(true);
            SimpleIoc.Default.Register<GameOverTwoPlayersViewModel>(true);
            SimpleIoc.Default.Register<GameControlsViewModel>();
            SimpleIoc.Default.Register<GeneralPlayerStatsViewModel>();
            SimpleIoc.Default.Register<AboutApplicationViewModel>();
        }

        public MainViewModel MainWindow
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public MainMenuViewModel MainMenuPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainMenuViewModel>();
            }
        }
        public OnePlayerGameOptionsViewModel OnePlayerGameOptionsView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OnePlayerGameOptionsViewModel>();
            }
        }


        public OnePlayerGameProcessViewModel OnePlayerGameProcessView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OnePlayerGameProcessViewModel>();
            }
        }
        public TwoPlayersGameOptionsViewModel TwoPlayersGameOptionsView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TwoPlayersGameOptionsViewModel>();
            }
        }
        public TwoPlayersGameProcessViewModel TwoPlayersGameProcessView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TwoPlayersGameProcessViewModel>();
            }
        }
        public TwoPlayersGameProcessSplitModeViewModel TwoPlayersGameProcessSplitModeView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TwoPlayersGameProcessSplitModeViewModel>();
            }
        }

        public GameOverViewModel GameOverView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GameOverViewModel>();
            }
        }
        public GameOverTwoPlayersViewModel GameOverTwoPlayersView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GameOverTwoPlayersViewModel>();
            }
        }
        public GameControlsViewModel GameControlsView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GameControlsViewModel>();
            }
        }
        public GeneralPlayerStatsViewModel GeneralPlayerStatsView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GeneralPlayerStatsViewModel>();
            }
        }
        public AboutApplicationViewModel AboutApplicationView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AboutApplicationViewModel>();
            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
            SimpleIoc.Default.Unregister<OnePlayerGameProcessViewModel>();
            SimpleIoc.Default.Register<OnePlayerGameProcessViewModel>(true);
            SimpleIoc.Default.Unregister<TwoPlayersGameProcessViewModel>();
            SimpleIoc.Default.Register<TwoPlayersGameProcessViewModel>(true);
            SimpleIoc.Default.Unregister<TwoPlayersGameProcessSplitModeViewModel>();
            SimpleIoc.Default.Register<TwoPlayersGameProcessSplitModeViewModel>(true);
            SimpleIoc.Default.Unregister<GameOverViewModel>();
            SimpleIoc.Default.Register<GameOverViewModel>(true);
            SimpleIoc.Default.Unregister<GameOverTwoPlayersViewModel>();
            SimpleIoc.Default.Register<GameOverTwoPlayersViewModel>(true);
            SimpleIoc.Default.Unregister<GeneralPlayerStatsViewModel>();
            SimpleIoc.Default.Register<GeneralPlayerStatsViewModel>();
        }
    }
}