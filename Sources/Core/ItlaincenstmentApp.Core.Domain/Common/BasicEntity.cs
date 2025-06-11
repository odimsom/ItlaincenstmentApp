namespace ItlaincenstmentApp.Core.Domain.Common
{
    /// <summary>
    /// Base class contain base properties of the Entities for the DataBase
    /// </summary>
    /// <typeparam name="TKey">Refernces to date type of prymary key of the entities</typeparam>
    public class BasicEntity<TKey>
    {
        public required TKey Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public bool Remove { get; set; } = false;
    }
}
