// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Resolver.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.IocContainer
{
    using System;

    /// <summary>
    /// Resolves object instances from an inversion of control container.
    /// </summary>
    public class Resolver
    {
        /// <summary>
        /// An inversion of control container.
        /// </summary>
        public static IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// Gets an inversion of control container.
        /// </summary>
        public Resolver()
        {
        }

        /// <summary>
        /// Gets an inversion of control container.
        /// </summary>
        public Resolver(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            ServiceProvider = serviceProvider;
        }

        /// <summary>
        /// Attempts to resolve an object instance from an inversion of control container.
        /// </summary>
        /// <typeparam name="T">The type of instance to resolve.</typeparam>
        /// <returns>An instance of type <see cref="T"/>.</returns>
        public static T Resolve<T>()
        {
            return (T)ServiceProvider.GetService(typeof(T));
        }
    }
}
