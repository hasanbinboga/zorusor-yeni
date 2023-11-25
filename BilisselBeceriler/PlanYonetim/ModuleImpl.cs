using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanYonetim.Views;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;


namespace PlanYonetim
{
    public class ModuleImpl : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer _container;

        public ModuleImpl(IUnityContainer Container,IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            _container = Container;
        }

        public void Initialize()
        {
            this.regionManager.Regions["ModuleKapsul"].Add(new SoruTurYonetim());
        }
    }
}
