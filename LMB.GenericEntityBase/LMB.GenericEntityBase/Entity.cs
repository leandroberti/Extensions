using System;

namespace LMB.GenericEntityBase
{
    /// <summary>
    /// Represents an object that has state, behavior, and identity.
    /// </summary>
    /// <remarks>
    /// Use this abstraction for a compsite primary key entity.
    /// </remarks>
    public abstract class Entity : IEntity
    {
        /// <summary>
        /// Last user to modify the entity.
        /// </summary>
        public virtual string ModifiedBy { get; set; }

        /// <summary>
        /// Entity last modification date.
        /// </summary>
        public virtual DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Total amount of posts for the query.
        /// </summary>
        public virtual int? TotalCount { get; set; }

        /// <summary>
        /// The entity translated name.
        /// </summary>
        /// <remarks>
        /// If this property is not informed returns the name of the current member.
        /// </remarks>
        public virtual string EntityName
        {
            get { return GetType().Name; }
        }

        /// <summary>
        /// Returns the entity Id.
        /// </summary>
        /// <returns>
        /// The entity Id.
        /// </returns>
        public abstract object GetId();
    }

    /// <summary>
    /// Represents an object that has state, behavior, and identity.
    /// </summary>
    /// <typeparam name="T">Type that defines the entity primary key.</typeparam>
    /// <remarks>
    /// Use this interface for a single primary key entity.
    /// </remarks>
    public abstract class Entity<T> : IEntity<T>
    {
        /// <summary>
        /// The entity Id.
        /// </summary>
        public virtual T Id { get; set; }

        /// <summary>
        /// Entity last modification date.
        /// </summary>
        public virtual DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Last user to modify the entity.
        /// </summary>
        public virtual string ModifiedBy { get; set; }

        /// <summary>
        /// Total amount of posts for the query.
        /// </summary>
        public virtual int? TotalCount { get; set; }

        // <summary>
        /// The entity translated name.
        /// </summary>
        /// <remarks>
        /// If this property is not informed returns the name of the current member.
        /// </remarks>
        public virtual string EntityName
        {
            get { return GetType().Name; }
        }

        // <summary>
        /// The entity translated name.
        /// </summary>
        /// <remarks>
        /// If this property is not informed returns the name of the current member.
        /// </remarks>
        string IEntity.EntityName
        {
            get { return EntityName; }
        }

        /// <summary>
        /// Gets or Sets the entity Id.
        /// </summary>
        object IEntityId.Id
        {
            get { return Id; }
            set { Id = (T)value; }
        }

        /// <summary>
        /// Returns the entity Id value.
        /// </summary>
        /// <returns>The entity Id.</returns>
        public virtual object GetId()
        {
            return Id;
        }
    }
}