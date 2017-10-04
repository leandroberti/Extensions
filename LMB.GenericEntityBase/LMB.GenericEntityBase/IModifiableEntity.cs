using System;

namespace LMB.GenericEntityBase
{
    /// <summary>
    /// Represents an object that stores the date and the user that modified it.
    /// </summary>
    public interface IModifiableEntity
    {
        /// <summary>
        /// Entity last modification date.
        /// </summary>
        DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Last user to modify the entity.
        /// </summary>
        string ModifiedBy { get; set; }
    }
}
