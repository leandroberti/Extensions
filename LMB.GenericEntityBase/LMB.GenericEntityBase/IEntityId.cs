namespace LMB.GenericEntityBase
{
    /// <summary>
    /// Represents an object that has a single primary key.
    /// </summary>
    public interface IEntityId
    {
        /// <summary>
        /// The entity Id.
        /// </summary>
        object Id { get; set; }
    }
}
