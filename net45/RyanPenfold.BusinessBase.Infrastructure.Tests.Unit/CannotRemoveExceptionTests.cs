// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CannotRemoveExceptionTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.BusinessBase.Infrastructure.Tests.Unit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for <see cref="RyanPenfold.BusinessBase.Infrastructure.CannotRemoveException" />
    /// </summary>
    [TestClass]
    public class CannotRemoveExceptionTests
    {
        /// <summary>
        /// A message for CannotRemoveExceptions
        /// </summary>
        public const string TestMessage = "Ipsum Lorem";

        /// <summary>
        /// Initializes a new instance of CannotRemoveException
        /// </summary>
        [TestMethod]
        public void CreateNewCannotRemoveException()
        {
            // create a new instance
            var exception = new CannotRemoveException(TestMessage);
            
            // test that it//s been instantiated
            Assert.IsNotNull(exception);

            // asserts whether the test exception//s message is equal to the test message
            Assert.AreEqual(TestMessage, exception.Message);        
        }

        /// <summary>
        /// Tests the Message property of the CannotRemoveException class
        /// </summary>
        [TestMethod]
        public void SetMessageInConstructor()
        {
            // get new instance
            var instance = new CannotRemoveException(TestMessage);

            // asserts whether the test exception//s message is equal to the test message
            Assert.AreEqual(TestMessage, instance.Message);        
        }
    }
}
