namespace LMB.GenericEntityBase
{
    /// <summary>
    /// Represents an object that can be paged.
    /// </summary>
    public interface IPagedEntity
    {
        /// <summary>
        /// Total amount of posts for the query.
        /// </summary>
        int? TotalCount { get; set; }
    }
}
