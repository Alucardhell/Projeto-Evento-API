using Autofac;
using Tasken.API.Eventos.Aplicacao.Interface;
using Tasken.API.Eventos.Aplicacao.Services;
using Tasken.API.Eventos.Domain.Core.Interfaces.Repositorys;
using Tasken.API.Eventos.Domain.Core.Interfaces.Services;
using Tasken.API.Eventos.Domain.Services.Services;
using Tasken.API.Eventos.Infra.Data.Repositorios;

namespace Tasken.API.Eventos.Infra.CrossCutting.IOC.Configuration
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Regista IOC

            #region IOC Aplications
            builder.RegisterType<ApplicationServiceEvento>().As<IApplicationServiceEvento>();
            builder.RegisterType<ApplicationServiceLote>().As<IApplicationServiceLote>();
            builder.RegisterType<ApplicationServicePalestrante>().As<IApplicationServicePalestrante>();
            builder.RegisterType<ApplicationServicePalestranteEvento>().As<IApplicationServicePalestranteEvento>();
            builder.RegisterType<ApplicationServiceRedeSocial>().As<IApplicationServiceRedeSocial>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceEvento>().As<IServicesEvento>();
            builder.RegisterType<ServiceLote>().As<IServicesLote>();
            builder.RegisterType<ServicePalestrante>().As<IServicesPalestrante>();
            builder.RegisterType<ServicePalestranteEvento>().As<IServicesPalestranteEvento>();
            builder.RegisterType<ServiceRedeSocial>().As<IServicesRedeSocial>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<RepositorioEvento>().As<IRepositorioEvento>();
            builder.RegisterType<RepositorioLote>().As<IRepositorioLote>();
            builder.RegisterType<RepositorioPalestrante>().As<IRepositorioPalestrante>();
            builder.RegisterType<RepositorioPalestranteEvento>().As<IRepositorioPalestranteEvento>();
            builder.RegisterType<RepositorioRedeSocial>().As<IRepositorioRedeSocial>();
            #endregion

            #endregion
        }
    }
}
