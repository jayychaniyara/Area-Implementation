using Assesment.RepositoryContracts;
using Assesment.RepositoryLayer;
using Assesment.ServiceContracts;
using Assesment.ServiceLayer;
using System;

using Unity;

namespace Assesment
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IBrandsService, BrandsService>();
            container.RegisterType<IBrandsRepository, BrandsRepository>();
            container.RegisterType<IProductsService, ProductService>();
            container.RegisterType<IProductsRepository, ProductsRepository>();
            container.RegisterType<ICategoriesService, CategoriesService>();
            container.RegisterType<ICategoriesRepository, CategoriesRepository>();
        }
    }
}