// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntity.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.BusinessBase.Infrastructure
{
    /// <summary>
    /// Represents a business entity object
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the identifier of the business entity object.
        /// </summary>
        object Id { get; set; }
    }
}
