using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SaleDeedRegistry.Lib;

namespace SaleDeedRegistry.Lib.Command
{
    /// <summary>
    /// The SaleDeedRegistry Init Application Command
    /// </summary>
    public class InitApplicationCommand : ISaleDeedRegistryCommand
    {
        private readonly string smartContractUrl;
        private readonly string smartContractAddress;

        public InitApplicationCommand(string contractUrl, string contractAddress)
        {
            smartContractUrl = contractUrl;
            smartContractAddress = contractAddress;
        }

        public async Task<CommandResponse> Execute(SaleDeedRegistryBaseRequest requestObject)
        {
            try
            {
                SaleRegistryFacade saleRegistryFacade = new SaleRegistryFacade(smartContractUrl, smartContractAddress);
                var response = saleRegistryFacade.Init((SaleDeedRegistryRequest)requestObject).Result;
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<CommandResponse>(json);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }
    }
}
