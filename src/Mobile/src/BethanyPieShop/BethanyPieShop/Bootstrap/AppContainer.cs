using Autofac;
using BethanyPieShop.Core.CacheStrategy;
using BethanyPieShop.Core.Contracts;
using BethanyPieShop.Core.Services.Data;
using BethanyPieShop.Core.Services.General;
using BethanyPieShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BethanyPieShop.Core.Bootstrap
{
    public class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //ViewModels
            builder.RegisterType<CheckoutViewModel>();
            builder.RegisterType<ContactViewModel>();
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<PieCatalogViewModel>();
            builder.RegisterType<PieDetailViewModel>();
            builder.RegisterType<RegistrationViewModel>();
            builder.RegisterType<ShoppingCartViewModel>().SingleInstance();
            builder.RegisterType<MenuViewModel>();
            builder.RegisterType<HomeViewModel>();
            builder.RegisterType<LogOutViewModel>();

            //services - data
            builder.RegisterType<CatalogDataService>().As<ICatalogDataService>();
            builder.RegisterType<ShoppingCartDataService>().As<IShoppingCartDataService>();
            builder.RegisterType<ContactDataService>().As<IContactDataService>();
            builder.RegisterType<OrderDataService>().As<IOrderDataService>();

            //services - general
            builder.RegisterType<ConnectionService>().As<IConnectionService>();
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<DialogService>().As<IDialogService>();
            builder.RegisterType<PhoneContactService>().As<IPhoneContactService>();
            builder.RegisterType<SettingsService>().As<ISettingsService>().SingleInstance();

            //General
            builder.RegisterType<RequestProvider>().As<IRequestProvider>();

            builder.RegisterType<PolicyStrategy.PolicyStrategy>().As<IPolicyStrategy>();

            builder.RegisterType<BaseCacheStrategy>().As<IBaseCacheStrategy>();


            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
