namespace LMB.GenericEntityBase
{
    /// <summary>
    /// Represents an object that has state, behavior, and identity.
    /// </summary>
    /// <remarks>
    /// Use this interface for compsite primary key entities.
    /// </remarks>
    public interface IEntity : IModifiableEntity, IPagedEntity
    {
        /// <summary>
        /// The entity translated name.
        /// </summary>
        string EntityName { get; }

        /// <summary>
        /// Returns the entity Id.
        /// </summary>
        /// <returns></returns>
        object GetId();
    }

    /// <summary>
    /// Represents an object that has state, behavior, and identity.
    /// </summary>
    /// <typeparam name="T">Type that defines the entity primary key.</typeparam>
    /// <remarks>
    /// Use this interface for single primary key entities.
    /// </remarks>
    public interface IEntity<T> : IEntity, IEntityId, IPagedEntity
    {
        /// <summary>
        /// The entity Id (primary key).
        /// </summary>
        new T Id { get; set; }

        /// <summary>
        /// The entity translated name.
        /// </summary>
        new string EntityName { get; }
    }
}
