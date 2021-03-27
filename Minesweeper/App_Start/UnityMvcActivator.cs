/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

using Minesweeper.Services.Utility;
using System.Linq;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Lifetime;

//Essembles the project.
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Minesweeper.UnityMvcActivator), nameof(Minesweeper.UnityMvcActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Minesweeper.UnityMvcActivator), nameof(Minesweeper.UnityMvcActivator.Shutdown))]

namespace Minesweeper
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with ASP.NET Core MVC.
    /// </summary>
    public static class UnityMvcActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start()
        {
            //Gives user the option to use our minesweeper game in Unity (A summer project).
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(UnityConfig.Container));
            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityConfig.Container));
            UnityConfig.Container.RegisterType<ILogger, MyLogger>(new ContainerControlledLifetimeManager());

            // TODO: Uncomment if you want to use PerRequestLifetimeManager
            // Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            UnityConfig.Container.Dispose();
        }
    }
}