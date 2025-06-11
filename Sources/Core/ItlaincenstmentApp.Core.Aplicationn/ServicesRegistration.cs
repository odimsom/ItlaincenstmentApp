using ItlaincenstmentApp.Core.Aplicationn.Interfaces;
using ItlaincenstmentApp.Core.Aplicationn.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ItlaincenstmentApp.Core.Aplicationn
{
    public static class ServicesRegistration
    {
        // Extencion method - Decoration pattern 
        public static void AddApplicatinoLaryerIoc(this IServiceCollection services)
        {
            #region Appliction IOC
            services.AddTransient<IAssetServices, AssetServices>();
            services.AddTransient<IAssetTypesServices, AssetTypesServices>();
            #endregion
        }
    }
}
