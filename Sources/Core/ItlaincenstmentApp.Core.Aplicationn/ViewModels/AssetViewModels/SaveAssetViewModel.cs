using ItlaincenstmentApp.Core.Aplicationn.ViewModels.Common;

namespace ItlaincenstmentApp.Core.Aplicationn.ViewModels.AssetViewModels
{
    /// <summary>
    /// view model que servira tanto para editar como para guardar
    /// </summary>
    public class SaveAssetViewModel : BasicViewModels<int>
    {
        public required string Symbol { get; set; }
        public required int AssetTypeId { get; set; }
    }
}