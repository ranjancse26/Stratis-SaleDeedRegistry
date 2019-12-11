using SQLite.Net;
using SQLite.Net.Platform.Win32;
using SaleDeedRegistry.Lib.Entities;

namespace SaleDeedRegistry.Desktop.Repository
{
    public class PropertyLocationRespository : SQLiteConnection
    {
        private readonly TableRespository tableRespository;

        public PropertyLocationRespository(string path) : base(new SQLitePlatformWin32(), path)
        {
            tableRespository = new TableRespository(path);
            if (!tableRespository.TableExists<PropertyLocation>())
            {
                CreateTable<PropertyLocation>();
            }
        }

        public int GetLastId()
        {
            return this.GetLastId();
        }
    }
}
