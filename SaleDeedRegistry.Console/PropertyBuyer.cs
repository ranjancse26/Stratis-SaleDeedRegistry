using Newtonsoft.Json;
using SaleDeedRegistry.Lib;
using SaleDeedRegistry.Lib.Client;
using SaleDeedRegistry.Lib.Command;
using SaleDeedRegistry.Console.Helper;

namespace SaleDeedRegistry.Console
{
    /// <summary>
    /// The Property Buyer "Actor". The buyer is the person who's interested in purchasing the property (land/plot/house etc.) 
    /// from the Propert Owner.
    /// </summary>
    public class PropertyBuyer : BaseActor
    {
        public PropertyBuyer()
        {

        }

        /// <summary>
        /// Get the property buyer address from the configured app key
        /// </summary>
        /// <returns></returns>
        public string GetBuyerAddress()
        {
            return ConfigHelper.GetBuyerAddress;
        }

        /// <summary>
        /// Pay the Application Fee Transfer Fee
        /// </summary>
        /// <returns>ReceiptResponse</returns>
        public ReceiptResponse PayTransferFee(string payee)
        {
            SaleDeedTransferFeeRequest transferFeeObject = new SaleDeedTransferFeeRequest
            {
                GasPrice = ConfigHelper.GasPrice,
                GasLimit = ConfigHelper.GasLimit,
                Amount = ConfigHelper.Amount,
                Sender = ConfigHelper.GetSenderAddress,
                BuyerAddress = ConfigHelper.GetBuyerAddress,
                FeeAmount = ConfigHelper.GasFee,
                WalletName = ConfigHelper.GetWalletName,
                WalletPassword = ConfigHelper.GetWalletPassword,
                PayeeAddress = payee,
                Fees = ConfigHelper.ApplicationFee
            };

            ReceiptResponse receiptResponse = null;
            SaleRegistryFacade saleRegistryFacade = new SaleRegistryFacade(ConfigHelper.GetSmartContractBaseUrl, ConfigHelper.GetContractAddress);

            System.Console.WriteLine("Trying to execute the SaleDeed -> PayApplicationTransferFee Request");

            var transferFeeResponse = saleRegistryFacade.PayApplicationTransferFee(transferFeeObject).Result;

            System.Console.WriteLine("Completed executing SaleDeed -> PayApplicationTransferFee Request");

            var commandResponse = JsonConvert.DeserializeObject<CommandResponse>(transferFeeResponse.Content.ReadAsStringAsync().Result);
            
            if (commandResponse.success)
            {
                receiptResponse = saleRegistryFacade.TryReceiptResponse(commandResponse.transactionId);
                if (receiptResponse != null && receiptResponse.success)
                {
                    Dump(receiptResponse);
                }
                else
                {
                    System.Console.WriteLine("PayTransferFee -> Receipt Response Error");
                    Dump(receiptResponse);
                }
            }

            return receiptResponse;
        }
    }
}
