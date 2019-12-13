using System;
using SaleDeedRegistry.Lib.Actors;
using SaleDeedRegistry.Lib.Helpers;

namespace SaleDeedRegistry.Console
{
    partial class Program
    {
        /// <summary>
        /// The SaleRegistry Console Client Demonstrating the overall
        /// Workflow or Process of obtaining the ownership of the property.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                string assetId = UniqueIdHelper.GenerateId();

                Payee payee = new Payee();
                Supervisor supervisor = new Supervisor(assetId);
                PropertyBuyer propertyBuyer = new PropertyBuyer();
                PropertySeller propertySeller = new PropertySeller();

                System.Console.WriteLine("Initiating the " +
                    "Sale Deed Application Process");

                supervisor.InitApplication().Wait();
                supervisor.StartTheReviewProcess().Wait();
                supervisor.CompleteTheReviewProcess().Wait();

                propertyBuyer.PayTransferFee(payee.GetPayee(), assetId).Wait();
                supervisor.TransferOwnership(propertySeller.GetOwnerAddress(),
                    propertyBuyer.GetBuyerAddress()).Wait();

                System.Console.WriteLine("Completed executing the " +
                    "Sale Deed Application Process");
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }

            System.Console.ReadLine();
        }
    }
}
