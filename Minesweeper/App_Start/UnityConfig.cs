/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

using System;
using Unity;

namespace Minesweeper
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

        #endregion Unity Container

        /// <summary>
        /// Registers the type mappings with the Unity container witch is optional if you want
        /// to run minesweeper in unity. Found by doing research,
        /// pulled from http://unitycontainer.org/tutorials/Composition/composition.html
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();
            // TODO: Register your type's of mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
        }
    }
}