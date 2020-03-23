namespace RyanPenfold.BusinessBase.Infrastructure
{
    using System.Collections.Generic;

    public interface IService<T>
    {
        /// <summary>
        /// Find all the <see cref="T"/> instances.
        /// </summary>
        /// <returns>A set of <see cref="T"/> instances.</returns>
        IList<T> FindAll();

        /// <summary>
        /// Attempts to find an <see cref="T"/> instance with the given identifier.
        /// </summary>
        /// <param name="id">
        /// The identifier of the instance to search for
        /// </param>
        /// <returns>
        /// A <see cref="T"/> if found, otherwise null
        /// </returns>
        T FindById(object id);

        /// <summary>
        /// Generates a new identifier
        /// </summary>
        /// <returns>A new identifier</returns>
        object NewId();

        /// <summary>
        /// Removes a <see cref="T" /> instance from a repository.
        /// </summary>
        /// <param name="subject">The instance to remove</param>
        void Remove(T subject);

        /// <summary>
        /// Saves a <see cref="T" /> instance to a repository.
        /// </summary>
        /// <param name="subject">The instance to save</param>
        void Save(T subject);
    }
}
