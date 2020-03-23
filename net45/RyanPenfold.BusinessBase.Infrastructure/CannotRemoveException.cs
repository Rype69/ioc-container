// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CannotRemoveException.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.BusinessBase.Infrastructure
{
    using System;

    /// <summary>
    /// Represents an error occurring when attempting to remove an item from a set
    /// </summary>
    public class CannotRemoveException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CannotRemoveException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message that describes the error.
        /// </param>
        public CannotRemoveException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CannotRemoveException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message that describes the error.
        /// </param>
        /// <param name="innerException">
        /// Inner exception
        /// </param>
        public CannotRemoveException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
