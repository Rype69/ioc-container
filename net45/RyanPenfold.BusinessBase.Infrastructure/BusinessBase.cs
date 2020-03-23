// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusinessBase.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.BusinessBase.Infrastructure
{
    /// <summary>
    /// A base class for business domain entities.
    /// </summary>
    public abstract class BusinessBase : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public object Id { get; set; }

        /// <summary>
        /// Determines whether the business domain entity is in valid state.
        /// </summary>
        protected abstract void Validate();
    }
}
