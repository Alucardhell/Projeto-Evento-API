using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tasken.API.Eventos.Infra.CrossCutting.IOC.Configuration
{
    public class ModuleIOC : Module
    {
        #region Carregar IOC
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationIOC.Load(builder);
        }
        #endregion
    }
}
