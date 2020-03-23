// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConcreteBusinessBase.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.BusinessBase.Infrastructure.Tests.Unit
{
    using System;

    /// <summary>
    /// A concrete implementation of the Business Base class
    /// </summary>
    public class ConcreteBusinessBase : RyanPenfold.BusinessBase.Infrastructure.BusinessBase
    {
        /// <summary>
        /// Determines whether the business domain entity is in valid state.
        /// </summary>
        protected override void Validate()
        {
            if (this.Id == null)
            {
                throw new Exception("Object is not valid.");
            }
        }
    }
}
