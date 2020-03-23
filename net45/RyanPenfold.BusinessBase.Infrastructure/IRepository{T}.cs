// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.BusinessBase.Infrastructure
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines a repository interface
    /// </summary>
    /// <typeparam name="T">
    /// A specified implementation or subtype of <see cref="IAggregateRoot"/>
    /// </typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Gets or sets the mapping information.
        /// </summary>
        IClassMap TypeMap { get; set; }

        /// <summary>
        /// Counts the amount of instances of type <see cref="T"/> in a data store
        /// </summary>
        /// <returns>
        /// The amount of instances of type <see cref="T"/> in a data store
        /// </returns>
        long Count();

        /// <summary>
        /// Finds all the objects.
        /// </summary>
        /// <returns>
        /// All the objects in the repository.
        /// </returns>
        IList<T> FindAll();

        /// <summary>
        /// Finds an object by its identifier.
        /// </summary>
        /// <param name="id">
        /// The identifier of the object to find.
        /// </param>
        /// <returns>
        /// An object if found. If not, null is returned.
        /// </returns>
        T FindById(object id);

        /// <summary>
        /// Attempts to find a set of <see cref="T"/> instances with the given identifiers.
        /// </summary>
        /// <param name="ids">
        /// The identifiers of the objects to find
        /// </param>
        /// <returns>
        /// A <see cref="IList{T}"/>
        /// </returns>
        IList<T> FindByIds(object[] ids);

        /// <summary>
        /// Finds the maximum value of the specified column name.
        /// </summary>
        /// <typeparam name="TValue">
        /// The type of value to find.
        /// </typeparam>
        /// <param name="columnName">
        /// The name of the column to find the maximum value of.
        /// </param>
        /// <returns>
        /// An instance of type <see cref="TValue"/>.
        /// </returns>
        TValue FindMaxValue<TValue>(string columnName);

        /// <summary>
        /// Generates a new unique identifier for the mapped type
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property to generate a new identifier for
        /// </param>
        /// <returns>
        /// A new unique identifier for the mapped type
        /// </returns>
        string NewId(string propertyName);

        /// <summary>
        /// Removes an entity from a data store.
        /// </summary>
        /// <param name="entity">
        /// The entity to remove.
        /// </param>
        void Remove(T entity);

        /// <summary>
        /// Searches for an entity with the given identifier and removes it from a store
        /// </summary>
        /// <param name="id">
        /// The identifier of the entity to remove.
        /// </param>
        void RemoveBy(long id);

        /// <summary>
        /// Persists the entity to a data store.
        /// </summary>
        /// <param name="entity">
        /// The entity to persist.
        /// </param>
        void Save(T entity);
    }
}
