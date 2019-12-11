using SQLite.Net.Attributes;

namespace SaleDeedRegistry.Lib.Entities
{
    [Table("AssetPersonInfo")] // SQLite attribute
    public class AssetPersonInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PAN { get; set; } // Unique identification number for Tax purpose
        public string Aaddhar { get; set; } // Unique identification number like SSN
    }
}
