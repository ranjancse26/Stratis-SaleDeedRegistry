using SQLite.Net;
using SQLite.Net.Platform.Win32;
using SaleDeedRegistry.Lib.Entities;
using System.Collections.Generic;

namespace SaleDeedRegistry.Desktop.Repository
{ 
    /// <summary>
    /// The Asset Management Repository deals with the Contact 
    ///     Add
    ///     Update
    ///     Delete
    ///     Searches
    /// </summary>
    public class AssetManagementRepository : SQLiteConnection
    {
        private readonly TableRespository tableRespository;

        public AssetManagementRepository(string path) : base(new SQLitePlatformWin32(), path)
        {
            tableRespository = new TableRespository(path);
            if (!tableRespository.TableExists<AssetInfo>())
            {
                CreateTable<AssetInfo>();
            }
        }

        public int InsertAsset(AssetInfo assetInfo)
        {
            return this.Insert(assetInfo);
        }

        public int UpdateAsset(AssetInfo assetInfo)
        {
            return this.Update(assetInfo);
        }

        public void DeleteAsset(int id)
        {
            var asset = QueryAssetById(id);
            Delete(asset);
        }

        public void DeleteAllAssets()
        {
            this.DeleteAll<AssetInfo>();
        }

        /// <summary>
        /// Query Assets by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AssetInfo</returns>
        public AssetInfo QueryAssetById(int id)
        {
            return (from contact in Table<AssetInfo>()
                    where contact.Id == id
                    select contact).FirstOrDefault();
        }

        /// <summary>
        ///  Query all the Assets
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AssetInfo> QueryAllAssets()
        {
            return from contact in Table<AssetInfo>()
                   orderby contact.Id
                   select contact;
        }
    }
}
