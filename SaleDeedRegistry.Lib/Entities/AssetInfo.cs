namespace SaleDeedRegistry.Lib.Entities
{
    public class AssetInfo
    {
        public AssetInfo()
        {
            PersonInfo = new AssetPersonInfo();
            Location = new PropertyLocation();
            Measurment = new PropertyMeasurment();
        }

        public string AssetId { get; set; }
        public string PropertyNumber { get; set; }
        public AssetPersonInfo PersonInfo { get; set; }
        public string WardNumber { get; set; }
        public string MuncipleNumber { get; set; }
        public PropertyLocation Location { get; set; }
        public PropertyMeasurment Measurment { get; set; }
        public ulong MarketPrice { get; set; }
        public ulong PurchacePrice { get; set; }
        public ulong PropertyTax { get; set; }
        public string ESignature { get; set; }
    }
}
