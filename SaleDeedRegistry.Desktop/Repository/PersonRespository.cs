using SQLite.Net;
using SQLite.Net.Platform.Win32;
using SaleDeedRegistry.Lib.Entities;

namespace SaleDeedRegistry.Desktop.Repository
{
    public class PersonRespository : SQLiteConnection
    {
        private readonly TableRespository tableRespository;

        public PersonRespository(string path) : base(new SQLitePlatformWin32(), path)
        {
            tableRespository = new TableRespository(path);
            if (!tableRespository.TableExists<AssetPersonInfo>())
            {
                CreateTable<AssetPersonInfo>();
            }
        }

        public int GetLastId()
        {
            return this.GetLastId();
        }
    }
}
