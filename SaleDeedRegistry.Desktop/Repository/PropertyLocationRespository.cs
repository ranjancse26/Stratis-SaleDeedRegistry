using SQLite.Net;
using SQLite.Net.Platform.Win32;
using SaleDeedRegistry.Lib.Entities;

namespace SaleDeedRegistry.Desktop.Repository
{
    /// <summary>
    /// The Property Location Repository responsible for managing the 
    /// Asset or Property Location Info
    /// </summary>
    public class PropertyLocationRespository : SQLiteConnection
    {
        private readonly string path;
        private readonly TableRespository tableRespository;

        public PropertyLocationRespository(string path) : base(new SQLitePlatformWin32(), path)
        {
            this.path = path;
            tableRespository = new TableRespository(path);
            if (!tableRespository.TableExists<PropertyLocation>())
            {
                CreateTable<PropertyLocation>();
            }
        }

        public int GetLastId()
        {
            var db = new SQLiteConnection(new SQLitePlatformWin32(), path);
            return db.ExecuteScalar<int>("SELECT rowid from PropertyLocation order" +
                " by ROWID DESC limit 1");
        }
    }
}
