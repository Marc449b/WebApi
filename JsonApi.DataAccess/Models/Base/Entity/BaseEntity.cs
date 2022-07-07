namespace JsonApi.DataAccess.Models.Base.Entity
{
    /// <summary>
    /// Base entity for database models.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Primary id
        /// </summary>
        public virtual Guid Id { get; set; }
    }
}