// <summary> BaseRepository, Abstract class responsible for implementing the Base interface </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Core.Entities;
using Management.Core.Interfaces.Repositories;
using Management.Infrastructure.DbContextConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Management.Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        protected readonly ManagementContext _context;
        protected readonly DbSet<TEntity> _entities;

        public BaseRepository(ManagementContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        /// <summary>
        /// Method responsible for returning all records of the co entity
        /// </summary>
        /// <returns>Returns a list of records <see cref="TEntity"/></returns>
        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        /// <summary>
        /// Method responsible for returning a specific record using the primary key
        /// </summary>
        /// <param name="id">Primary Key Entity</param>
        /// <returns>Returns the record <see cref="TEntity"/></returns>
        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        /// <summary>
        /// Method responsible for creating the record in the database
        /// </summary>
        /// <param name="entity">Record to be created</param>
        /// <returns>Returns the created record <see cref="TEntity"/></returns>
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            _entities.Add(entity);

            await SaveChanges();

            return entity;
        }

        /// <summary>
        /// Method responsible for removing the record from the database
        /// </summary>
        public virtual async Task RemoveAsync(TEntity entity)
        {
            _entities.Remove(entity);

            await SaveChanges();
        }

        /// <summary>
        /// Method responsible for updating the record in the database
        /// </summary>
        public async Task UpdateAsync(TEntity entity)
        {
            _entities.Update(entity);

            await SaveChanges();
        }

        /// <summary>
        /// Method responsible for saving data to the database
        /// </summary>
        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method responsible for reallocating resources that are not being used
        /// </summary>
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
