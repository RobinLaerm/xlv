using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Xitaso.Logging.Viewer.App.Provider;
using Xitaso.Logging.Viewer.App.ViewModels;

namespace Xitaso.Logging.Viewer.App
{
    public class Bootstrapper : BootstrapperBase
    {
        private IUnityContainer _unityContainer;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ApplicationViewModel>();
        }

        protected override void Configure()
        {
            base.Configure();
            _unityContainer = new UnityContainer();
            _unityContainer.RegisterSingleton<IWindowManager, WindowManager>();
            _unityContainer.RegisterSingleton<IEventAggregator, EventAggregator>();
            _unityContainer.RegisterType<ApplicationViewModel>();
            _unityContainer.RegisterType<LogProviderListViewModel>();
            _unityContainer.RegisterType<LogEntryViewerContainerViewModel>();
            _unityContainer.RegisterType<LogEntryViewerViewModel>();
            _unityContainer.RegisterType<LogLevelFilterSettingViewModel>();

            _unityContainer.RegisterSingleton<ILogProviderService, LogProviderService>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _unityContainer.Resolve(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _unityContainer.ResolveAll(service);
        }

        protected override void BuildUp(object instance)
        {
            _unityContainer.BuildUp(instance);
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            _unityContainer.Dispose();
            base.OnExit(sender, e);
        }
    }
}
