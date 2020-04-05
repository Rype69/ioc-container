// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Resolver.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.IocContainer
{
    using System.Collections.Generic;

    using Autofac;
    using Autofac.Configuration;
    using Autofac.Core;

    /// <summary>
    /// Resolves object instances from an inversion of control container.
    /// </summary>
    public class Resolver
    {
        /// <summary>
        /// An inversion of control container.
        /// </summary>
        private static IContainer _container;

        /// <summary>
        /// An IoC-container builder
        /// </summary>
        private static ContainerBuilder _containerBuilder;

        /// <summary>
        /// Gets an inversion of control container.
        /// </summary>
        public static IContainer Container
        {
            get
            {
                if (_container != null)
                {
                    return _container;
                }

                if (_containerBuilder == null)
                {
                    _containerBuilder = new ContainerBuilder();
                }

                _containerBuilder.RegisterModule(new ConfigurationSettingsReader());
                _container = _containerBuilder.Build();

                return _container;
            }
        }

        /// <summary>
        /// Attempts to resolve an object instance from an inversion of control container.
        /// </summary>
        /// <typeparam name="T">The type of instance to resolve.</typeparam>
        /// <returns>An instance of type <see cref="T"/>.</returns>
        public static T Resolve<T>()
        {
            // TODO: Is LifetimeScope required for every resolve?
            using (var scope = Container.BeginLifetimeScope())
            {
                return scope.Resolve<T>();
            }
        }

        /// <summary>
        /// Attempts to resolve an object instance from an inversion of control container.
        /// </summary>
        /// <param name="constructorParameters">
        /// The parameters to pass to the constructor
        /// </param>
        /// <typeparam name="T">
        /// The type of instance to resolve.
        /// </typeparam>
        /// <returns>
        /// An instance of type <see cref="T"/>.
        /// </returns>
        public static T Resolve<T>(IEnumerable<Parameter> constructorParameters)
        {
            // TODO: Is LifetimeScope required for every resolve?
            using (var scope = Container.BeginLifetimeScope())
            {
                return scope.Resolve<T>(constructorParameters);
            }
        }
    }
}
