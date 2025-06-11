using ItlaincenstmentApp.Core.Aplicationn.ViewModels.AssetsTypesViewModels;
using ItlaincenstmentApp.Core.Aplicationn.ViewModels.Common;

namespace ItlaincenstmentApp.Core.Aplicationn.ViewModels.AssetViewModels
{
    public class AssetViewModel : BasicViewModels<int>
    {
        public required string Symbol { get; set; }
        public AssetsTypesViewModel? AssetyTypeViewModel { get; set; }
    }
}
