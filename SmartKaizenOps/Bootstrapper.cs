using SmartKaizenOps.Models;
using SmartKaizenOps.ViewModels;
using SmartKaizenOps.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmartKaizenOps
{
    public class Bootstrapper : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // シングルトンクラスとして登録したい時
            containerRegistry.RegisterSingleton<IMovieControlerModel?, MovieControlerModel>();
            containerRegistry.RegisterDialog<MediaPlayer, MediaPlayerViewModel>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.Register(typeof(MainWindow).ToString(), typeof(MainWindowViewModel));

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //moduleCatalog.AddModule<ViewerModule>();
        }

    }
}
