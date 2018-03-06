using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Unity;
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
            _unityContainer.RegisterType<IWindowManager, WindowManager>();
            _unityContainer.RegisterType<IEventAggregator, EventAggregator>();
            _unityContainer.RegisterType<ApplicationViewModel>();
            _unityContainer.RegisterType<LogLevelFilterSettingViewModel>();
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
    }
}
