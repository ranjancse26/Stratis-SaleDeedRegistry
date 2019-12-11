using SQLite.Net;
using SQLite.Net.Platform.Win32;
using SaleDeedRegistry.Lib.Entities;

namespace SaleDeedRegistry.Desktop.Repository
{
    /// <summary>
    /// The Person Repository Responsible for managing the Asset or Property
    /// Person Information
    /// </summary>
    public class PersonRespository : SQLiteConnection
    {
        private readonly string path;
        private readonly TableRespository tableRespository;

        public PersonRespository(string path) : base(new SQLitePlatformWin32(), path)
        {
            this.path = path;
            tableRespository = new TableRespository(path);
            if (!tableRespository.TableExists<AssetPersonInfo>())
            {
                CreateTable<AssetPersonInfo>();
            }
        }

        public int GetLastId()
        {
            var db = new SQLiteConnection(new SQLitePlatformWin32(), path);
            return db.ExecuteScalar<int>("SELECT rowid from AssetPersonInfo order" +
                " by ROWID DESC limit 1");
        }
    }
}
