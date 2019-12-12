using SaleDeedRegistry.Lib.Helper;

namespace SaleDeedRegistry.Lib.Actors
{
    /// <summary>
    /// Actor - Property Seller 
    /// Seller is the one who's intending to sell his/her land/plot.
    /// </summary>
    public class PropertySeller : BaseActor
    {
        public PropertySeller()
        {

        }

        /// <summary>
        /// Get the property owner address from the configured app key
        /// </summary>
        /// <returns></returns>
        public string GetOwnerAddress()
        {
            return ConfigHelper.GetOwnerAddress;
        }
    }
}
