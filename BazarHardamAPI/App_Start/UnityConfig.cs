using BazarHardamAPI.Services;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace BazarHardamAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            //======================================================| Initial Dependency Injection
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IAuthenticateService, AuthenticateService>();
            container.RegisterType<ICampaignService, CampaignService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IAddressService, AddressService>();
            container.RegisterType<IVendorService, VendorService>();
            container.RegisterType<IBrandService, BrandService>();
            container.RegisterType<IInventoryService, InventoryService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}