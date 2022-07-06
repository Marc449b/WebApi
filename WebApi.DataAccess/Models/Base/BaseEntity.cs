namespace WebApi.DataAccess.Models.Base
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