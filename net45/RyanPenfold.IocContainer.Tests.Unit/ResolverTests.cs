// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComponentRegistrarTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.IocContainer.Tests.Unit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="Resolver"/> type.
    /// </summary>
    [TestClass]
    public class ResolverTests
    {
        /// <summary>
        /// Tests the resolve method of the IoC container
        /// </summary>
        [TestMethod]
        public void Resolve()
        {
            // attempt to resolve type IFlyable. This should resolve to Aeroplane type.
            var result = Resolver.Resolve<IFlyable>();

            // type should have been successfully resolved and result should not be null
            Assert.IsNotNull(result);

            // result should be of type Aeroplane
            Assert.IsInstanceOfType(result, typeof(Aeroplane));
        }

        /// <summary>
        /// Tests the singleton lifestyle of the IoC container
        /// </summary>
        [TestMethod]
        public void EnsureSingletonLifestyle()
        {
            // attempt to resolve type IFlyable. This should resolve to Aeroplane type.
            var result1 = Resolver.Resolve<IFlyable>();

            // type should have been successfully resolved and result1 should not be null
            Assert.IsNotNull(result1);

            // result1 should be of type Aeroplane
            Assert.IsInstanceOfType(result1, typeof(Aeroplane));

            // attempt to resolve another IFlyable
            var result2 = Resolver.Resolve<IFlyable>();

            // type should have been successfully resolved and result2 should not be null
            Assert.IsNotNull(result2);

            // result1 should be of type Aeroplane
            Assert.IsInstanceOfType(result2, typeof(Aeroplane));

            // result2 should resolve to the same object result1 
            // as the Castle Windsor lifestyle is set to singleton 
            // as per default            
            Assert.IsTrue(result1.Equals(result2));            
        }
    }
}
