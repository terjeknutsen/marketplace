using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Framework
{
    public interface IEntityStore
    {
        /// <summary>
        /// Loads an entity by id 
        /// </summary>
        Task<T> Load<T>(string entityId) where T : Entity;
        /// <summary>
        /// Persist an entity
        /// </summary>
        Task Save<T>(T entity) where T : Entity;
        /// <summary>
        /// Check if entity with a given id already exists
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="entityId"></param>
        /// <returns></returns>
        Task<bool> Exists<T>(string entityId);
    }
}
