using Newtonsoft.Json;
using SaleDeedRegistry.Lib.Client;
using SaleDeedRegistry.Lib.Command;
using SaleDeedRegistry.Lib.Helper;
using System.Threading.Tasks;

namespace SaleDeedRegistry.Lib.Actors
{
    public class Supervisor : BaseActor
    {
        private int gasPrice = ConfigHelper.GasPrice;
        private int gasLimit = ConfigHelper.GasLimit;
        private int amount = ConfigHelper.Amount;
        private double fee = ConfigHelper.GasFee;

        private string walletName = ConfigHelper.GetWalletName;
        private string walletPassword = ConfigHelper.GetWalletPassword;
        private string smartContractUrl = ConfigHelper.GetSmartContractBaseUrl;

        private string sender = ConfigHelper.GetSenderAddress;
        private string buyer = ConfigHelper.GetBuyerAddress;
        private string propertyOwner = ConfigHelper.GetOwnerAddress;

        private string contractAddress = ConfigHelper.GetContractAddress;

        private SaleDeedRegistryRequest requestObject;
        private SaleRegistryFacade saleRegistryFacade;

        public Supervisor(string assetId)
        {
            requestObject = new SaleDeedRegistryRequest
            {
                GasPrice = gasPrice,
                GasLimit = gasLimit,
                Amount = amount,
                Sender = sender,
                BuyerAddress = buyer,
                FeeAmount = fee,
                WalletName = walletName,
                WalletPassword = walletPassword,
                OwnerAddress = propertyOwner,
                AssetId = assetId
            };
            saleRegistryFacade = new SaleRegistryFacade(smartContractUrl, contractAddress);
        }
        
        /// <summary>
        /// Init the Application
        /// </summary>
        /// <param name="assetId">AssetId</param>
        /// <returns>ReceiptResponse</returns>
        public async Task<ReceiptResponse> InitApplication()
        {
            ReceiptResponse receiptResponce = null;

            System.Console.WriteLine("Trying to execute the SaleDeed -> InitApplication Request");

            // Init Application
            var response = await saleRegistryFacade.Init(requestObject);

            System.Console.WriteLine("Completed executing SaleDeed -> InitApplication Request");

            if (response.IsSuccessStatusCode)
            {
                CommandResponse commandResponse = JsonConvert.DeserializeObject<CommandResponse>(response.Content.ReadAsStringAsync().Result);
                if (commandResponse.success)
                {
                    System.Console.WriteLine($"Trying to get the Receipt Response for transactionId: {commandResponse.transactionId}");
                    receiptResponce = await saleRegistryFacade.TryReceiptResponse(commandResponse.transactionId);
                    if (receiptResponce != null && receiptResponce.success)
                    {
                        Dump(receiptResponce);
                    }
                    else
                    {
                        System.Console.WriteLine("InitApplication -> Receipt Response Error");
                        Dump(receiptResponce);
                    }
                }
            }
            else
            {
                System.Console.WriteLine("Problem in performing the Init Operation");
            }
            return receiptResponce;
        }

        /// <summary>
        /// Start the Application Review Process
        /// </summary>
        /// <returns>ReceiptResponse</returns>
        public async Task<ReceiptResponse> StartTheReviewProcess()
        {
            ReceiptResponse receiptResponce = null;

            System.Console.WriteLine("Trying to execute the SaleDeed -> StartReview Request");

            // Start the Review Process
            var response = await saleRegistryFacade.StartReview(requestObject);

            System.Console.WriteLine("Completed executing SaleDeed -> StartReview Request");

            var commandResponse = JsonConvert.DeserializeObject<CommandResponse>(response.Content.ReadAsStringAsync().Result);
            if (commandResponse.success)
            {
                receiptResponce = await saleRegistryFacade.TryReceiptResponse(commandResponse.transactionId);
                if (receiptResponce != null && receiptResponce.success)
                {
                    Dump(receiptResponce);
                }
                else
                {
                    System.Console.WriteLine("StartTheReviewProcess -> Receipt Response Error");
                    Dump(receiptResponce);
                }
            }
            return receiptResponce;
        }

        /// <summary>
        /// Complete the application review
        /// </summary>
        /// <returns>ReceiptResponse</returns>
        public async Task<ReceiptResponse> CompleteTheReviewProcess()
        {
            ReceiptResponse receiptResponce = null;

            System.Console.WriteLine("Trying to execute the SaleDeed -> CompleteReview Request");

            // Complete the Review Process
            var response = await saleRegistryFacade.CompleteReview(requestObject);

            System.Console.WriteLine("Completed executing SaleDeed -> CompleteReview Request");

            var commandResponse = JsonConvert.DeserializeObject<CommandResponse>(response.Content.ReadAsStringAsync().Result);
            if (commandResponse.success)
            {
                receiptResponce = await saleRegistryFacade.TryReceiptResponse(commandResponse.transactionId);
                if (receiptResponce != null && receiptResponce.success)
                {
                    Dump(receiptResponce);
                }
                else
                {
                    System.Console.WriteLine("CompleteTheReviewProcess -> Receipt Response Error");
                    Dump(receiptResponce);
                }
            }
            return receiptResponce;
        }


        /// <summary>
        /// Transfer Ownership
        /// </summary>
        /// <returns>ReceiptResponse</returns>
        public async Task<ReceiptResponse> TransferOwnership(string seller, string buyer)
        {
            ReceiptResponse receiptResponce = null;
            SaleDeedTransferOwnershipRequest transferOwnershipEntity = new SaleDeedTransferOwnershipRequest
            {
                GasPrice = gasPrice,
                GasLimit = gasLimit,
                Amount = amount,
                Sender = sender,
                BuyerAddress = buyer,
                FeeAmount = fee,
                WalletName = walletName,
                WalletPassword = walletPassword,
                OwnerAddress = seller,
                AssetId = requestObject.AssetId
            };

            System.Console.WriteLine("Trying to execute the SaleDeed -> TransferOwnership Request");

            var ownershipResponse = await saleRegistryFacade.TransferOwnership(transferOwnershipEntity);

            System.Console.WriteLine("Completed executing SaleDeed -> TransferOwnership Request");

            var commandResponse = JsonConvert.DeserializeObject<CommandResponse>(ownershipResponse.Content.ReadAsStringAsync().Result);
            if (commandResponse.success)
            {
                receiptResponce = await saleRegistryFacade.TryReceiptResponse(commandResponse.transactionId);
                if (receiptResponce != null && receiptResponce.success)
                {
                    Dump(receiptResponce);
                }
                else
                {
                    System.Console.WriteLine("TransferOwnership -> Receipt Response Error");
                    Dump(receiptResponce);
                }
            }
            return receiptResponce;
        }
        //
    }
}
