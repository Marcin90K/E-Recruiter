using RecruitingSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RecruitingSystem.Data.Repositories.Abstract
{
    public interface IRepository<T>
        where T : Entity
    {
        /// <summary>
        /// Method for getting a single resource by its id.
        /// </summary>
        /// <param name="id">Id of item.</param>
        /// <returns></returns>
        T GetSingle(Guid id);

        /// <summary>
        /// Method for getting a single resource by any predicate.
        /// </summary>
        /// <param name="predicate">Predicate denoting a basic for getting resource.</param>
        /// <returns></returns>
        T GetSingleBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Method for getting a collection of resources by any predicate.
        /// </summary>
        /// <param name="predicate">Predicate denoting a basic for getting a collection of resources.</param>
        /// <returns></returns>
        IQueryable<T> GetBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Method for getting all items of given resource.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Method for adding a resource.
        /// </summary>
        /// <param name="item">Item to be added.</param>
        void Add(T item);

        /// <summary>
        /// Method for updating a resource
        /// </summary>
        /// <param name="id">Resource Id</param>
        /// <param name="item">Resource object with updates.</param>
        /// <returns></returns>
        void Update(Guid id, T item);

        /// <summary>
        /// Method for removing given resource
        /// </summary>
        /// <param name="item">Item to remove.</param>
        void Delete(T item);

        /// <summary>
        /// Method for executing saving changes on database.
        /// </summary>
        /// <returns>True when saving suceeed or false when saving failed.</returns>
        bool Save();
    }
}
