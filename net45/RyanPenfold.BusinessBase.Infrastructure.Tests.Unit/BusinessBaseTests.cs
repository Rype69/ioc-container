// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusinessBaseTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.BusinessBase.Infrastructure.Tests.Unit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the <see cref="RyanPenfold.BusinessBase.Infrastructure.BusinessBase"/> type.
    /// </summary>
    [TestClass]
    public class BusinessBaseTests
    {
        /// <summary>
        /// Initializes a new instance of ConcreteBusinessBase
        /// </summary>
        [TestMethod]
        public void CreateNewBusinessBase()
        {
            // create a new instance of BusinessBase
            var instance = new ConcreteBusinessBase();

            // assert the instance is not null
            Assert.IsNotNull(instance);
        }

        /// <summary>
        /// Tests the identifier property of the BusinessBase class
        /// </summary>
        [TestMethod]
        public void Id()
        {
            // create a new instance of BusinessBase
            var instance = new ConcreteBusinessBase();

            // set a test id constant
            const int TestId = 5;

            // set the identifier of the instance to test id
            instance.Id = TestId;

            // ensure the property is equal to the constant
            Assert.AreEqual(TestId, instance.Id);
        }
    }
}
