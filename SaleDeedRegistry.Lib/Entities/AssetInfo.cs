using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace SaleDeedRegistry.Lib.Entities
{
    public class AssetInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }        
        public string AssetId { get; set; }
        public string PropertyNumber { get; set; }

        [OneToOne]
        [ForeignKey(typeof(AssetPersonInfo))]
        public int PersonId { get; set; }

        public string WardNumber { get; set; }
        public string MuncipleNumber { get; set; }
        
        [OneToOne]
        [ForeignKey(typeof(PropertyLocation))]
        public int LocationId { get; set; }
        
        public long MarketPrice { get; set; }
        public long PurchacePrice { get; set; }
        public long PropertyTax { get; set; }
        public long SquareFeet { get; set; }
        public string ESignature { get; set; }
    }
}
