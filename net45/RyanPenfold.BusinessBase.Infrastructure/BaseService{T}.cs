namespace RyanPenfold.BusinessBase.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class BaseService<T> : IService<T>
    {
        protected IRepository<T> _repository;

        protected BaseService(IRepository<T> repository)
        {
            _repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Find all the <see cref="T"/> instances.
        /// </summary>
        /// <returns>A set of <see cref="T"/> instances.</returns>
        public virtual IList<T> FindAll()
        {
            return this._repository.FindAll();
        }

        /// <summary>
        /// Attempts to find an <see cref="T"/> instance with the given identifier.
        /// </summary>
        /// <param name="id">
        /// The identifier of the instance to search for
        /// </param>
        /// <returns>
        /// A <see cref="T"/> if found, otherwise null
        /// </returns>
        public virtual T FindById(object id)
        {
            return this._repository.FindById(id);
        }

        /// <summary>
        /// Generates a new identifier
        /// </summary>
        /// <returns>A new identifier</returns>
        public virtual object NewId()
        {
            return this._repository.NewId(this._repository.TypeMap.PrimaryKeyColumnNames.First());
        }

        /// <summary>
        /// Removes a <see cref="T" /> instance from a repository.
        /// </summary>
        /// <param name="subject">The instance to remove</param>
        public virtual void Remove(T subject)
        {
            if (subject == null)
            {
                throw new System.ArgumentNullException(nameof(subject));
            }

            try
            {
                this._repository.Remove(subject);
            }
            catch (System.Exception e)
            {
                var id = "[Unknown]";

                var property = subject.GetType().GetProperties().FirstOrDefault(p => string.Equals(p.Name, "Id", System.StringComparison.InvariantCultureIgnoreCase));
                if (property != null && property.CanWrite)
                {
                    id = property.GetValue(subject)?.ToString();
                }

                throw new CannotRemoveException($"Cannot remove {subject.GetType().Name} with Id #{id}", e);
            }
        }

        /// <summary>
        /// Saves a <see cref="T" /> instance to a repository.
        /// </summary>
        /// <param name="subject">The instance to save</param>
        public virtual void Save(T subject)
        {
            var idProperty = subject.GetType().GetProperties().FirstOrDefault(p => string.Equals(p.Name, "Id", System.StringComparison.InvariantCultureIgnoreCase));
            if (idProperty != null && idProperty.CanWrite)
            {
                var idPropertyValue = idProperty.GetValue(subject);
                if (idPropertyValue != null && string.Equals(idPropertyValue.ToString(),System.Guid.Empty.ToString(), System.StringComparison.InvariantCultureIgnoreCase))
                {
                    var newId = this._repository.NewId("Id");
                    if (idProperty.PropertyType == typeof(System.Guid))
                    {
                        idProperty.SetValue(subject, new System.Guid(newId));
                    }
                    else
                    {
                        idProperty.SetValue(subject, newId);
                    }
                }
            }

            this._repository.Save(subject);
        }
    }
}
