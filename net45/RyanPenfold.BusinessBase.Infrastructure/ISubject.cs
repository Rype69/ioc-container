// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISubject.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.BusinessBase.Infrastructure
{
    /// <summary>
    /// Contains a collection of observing objects.
    /// </summary>
    /// <remarks>
    /// Provides a mechanism for receiving push-based notifications.
    /// </remarks>
    public interface ISubject
    {
        /// <summary>
        /// Adds an observing object to a set.
        /// </summary>
        /// <param name="observer">
        /// The observing object.
        /// </param>
        void RegisterObserver(IObserver observer);

        /// <summary>
        /// Removes an observing object from a set.
        /// </summary>
        /// <param name="observer">
        /// The observing object.
        /// </param>
        void RemoveObserver(IObserver observer);

        /// <summary>
        /// Notifies all the observing objects in a set that there//s been an update.
        /// </summary>
        void NotifyObservers();
    }
}
