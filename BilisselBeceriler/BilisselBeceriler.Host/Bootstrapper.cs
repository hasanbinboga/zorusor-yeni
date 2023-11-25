using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.UnityExtensions;
using System.Windows;
using Microsoft.Practices.Composite.Modularity;

namespace BilisselBeceriler.Host
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            Shell shell = Container.Resolve<Shell>();
            shell.Show();
            return shell;
        }
        protected override IModuleCatalog GetModuleCatalog()
        {
            ModuleCatalog catalog = new ConfigurationModuleCatalog();
            return catalog;
        }
    }
}
