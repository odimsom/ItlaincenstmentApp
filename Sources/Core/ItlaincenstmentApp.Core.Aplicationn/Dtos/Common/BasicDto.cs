namespace ItlaincenstmentApp.Core.Aplicationn.Dtos.Common
{
    /// <summary>
    /// Equivalencia del BaseEntitie de la persitencia
    /// </summary>
    /// <typeparam name="T">TKey del base enties</typeparam>
    public class BasicDto<T>
    {
        public required T Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public bool Remove { get; set; } = false;
    }
}
