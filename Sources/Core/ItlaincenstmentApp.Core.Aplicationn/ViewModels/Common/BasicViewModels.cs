namespace ItlaincenstmentApp.Core.Aplicationn.ViewModels.Common
{
    /// <summary>
    /// Equivalencia en view model al basic del dominio
    /// </summary>
    /// <typeparam name="T">T referense T del BasicDto</typeparam>
    public class BasicViewModels<T>
    {
        public required T Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public bool Remove { get; set; } = false;
    }
}
