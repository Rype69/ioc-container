// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IObserver.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.BusinessBase.Infrastructure
{
    /// <summary>
    /// Represents an object observing other object(s)
    /// </summary>
    /// <remarks>
    /// Provides a mechanism for receiving push-based notifications.
    /// </remarks>
    public interface IObserver
    {
        /// <summary>
        /// Gets a unique identifier for the observing object within a set.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Notifies the observing object of an update.
        /// </summary>
        void Update();
    }
}
