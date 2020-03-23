namespace RyanPenfold.BusinessBase.Infrastructure
{
    using System;

    public class InvalidEnumValueException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CannotRemoveException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message that describes the error.
        /// </param>
        public InvalidEnumValueException(string message) : base(message)
        {
        }
    }
}
