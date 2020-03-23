// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAggregateRoot.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.BusinessBase.Infrastructure
{
    /// <summary>
    /// Provides a common interface for all business entity types
    /// </summary>
    public interface IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the unique identifier of the object
        /// </summary>
        long Id { get; set; }
    }
}
