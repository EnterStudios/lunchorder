using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Lunchorder.Api.Infrastructure.Services;
using Lunchorder.Common.Interfaces;

namespace Lunchorder.Api.Configuration.IoC
{
    public class ServiceInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer"/>.
        /// </summary>
        /// <param name="container">The container.</param><param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IBadgeService>().ImplementedBy<BadgeService>()
                .LifeStyle.HybridPerWebRequestTransient());

            container.Register(Component.For<IUserService>().ImplementedBy<ApplicationUserService>()
                .LifeStyle.HybridPerWebRequestTransient());

            container.Register(Component.For<IEmailService>().ImplementedBy<SendGridMailService>()
                .LifeStyle.HybridPerWebRequestTransient());

            container.Register(Component.For<ICacheService>().ImplementedBy<MemoryCacheService>()
                .LifeStyle.HybridPerWebRequestTransient());

            container.Register(Component.For<IMenuService>().ImplementedBy<MenuService>()
                .LifeStyle.HybridPerWebRequestTransient());

            container.Register(Component.For<SeedService>().LifeStyle.HybridPerWebRequestTransient());
            
            container.Register(Component.For<ILogger>().UsingFactoryMethod((m, v, i) =>
                    new NLogLogger(i.Handler.ComponentModel.Implementation)));
        }
    }
}