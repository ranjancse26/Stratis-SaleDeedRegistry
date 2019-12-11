using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using SaleDeedRegistry.Lib.Helpers;
using SaleDeedRegistry.Lib.Entities;
using SaleDeedRegistry.Desktop.Constants;
using SaleDeedRegistry.Desktop.Repository;

namespace SaleDeedRegistry.Desktop
{
    public partial class FrmCreateAsset : Form
    {
        private readonly string dbPath = "";
        private readonly AssetManagementRepository assetManagementRepository;
        private readonly PersonRespository personRespository;
        private readonly PropertyLocationRespository propertyLocationRespository;
       
        public FrmCreateAsset()
        {
            string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            dbPath = string.Format($"{exePath}\\{DBConstant.SqlLiteDBFileName}");

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            personRespository = new PersonRespository(dbPath);
            assetManagementRepository = new AssetManagementRepository(dbPath);
            propertyLocationRespository = new PropertyLocationRespository(dbPath);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            personInfoUserControl1.Clear();
            locationInfoUserControl1.Clear();
            assetInfoUserControl1.Clear();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                bool isPersonalInfoValid = personInfoUserControl1.Validate();
                if (!isPersonalInfoValid) return;

                bool isAssetInfoValid = assetInfoUserControl1.Validate();
                if (!isAssetInfoValid) return;

                bool isLocationInfoValid = locationInfoUserControl1.Validate();
                if (!isLocationInfoValid) return;

                int id = 0;
                int personId = 0;
                int locationId = 0;

                AssetPersonInfo assetPersonInfo = new AssetPersonInfo
                {
                    FirstName = personInfoUserControl1.FirstName,
                    LastName = personInfoUserControl1.LastName,
                    Gender = personInfoUserControl1.Gender,
                    MiddleName = personInfoUserControl1.MiddleName,
                    Aaddhar = personInfoUserControl1.Aaddhar,
                    PAN = personInfoUserControl1.PAN
                };

                id = personRespository.Insert(assetPersonInfo);
                if(id > 0)
                {
                    personId = personRespository.GetLastId();
                }

                PropertyLocation propertyLocation = new PropertyLocation
                {
                    Address1 = locationInfoUserControl1.AddressLine1,
                    Address2 = locationInfoUserControl1.AddressLine2,
                    City = locationInfoUserControl1.City,
                    State = locationInfoUserControl1.State,
                    ZipCode = locationInfoUserControl1.ZipCode,
                    Country = locationInfoUserControl1.Country,
                    Latitude = locationInfoUserControl1.Latitude,
                    Longitude = locationInfoUserControl1.Longitude
                };

                id = propertyLocationRespository.Insert(propertyLocation);
                if (id > 0)
                {
                    locationId = propertyLocationRespository.GetLastId();
                }

                AssetInfo assetInfo = new AssetInfo
                {
                    AssetId = UniqueIdHelper.GenerateId(),
                    MarketPrice = long.Parse(assetInfoUserControl1.MarketPrice),
                    PropertyNumber = assetInfoUserControl1.PropertyNumber,
                    MuncipleNumber = assetInfoUserControl1.Munciple,
                    WardNumber = assetInfoUserControl1.WardNumber,
                    PurchacePrice = long.Parse(assetInfoUserControl1.PurchasePrice),
                    PropertyTax = long.Parse(assetInfoUserControl1.PropertyTax),
                    SquareFeet = long.Parse(assetInfoUserControl1.Measurment),
                    ESignature = assetInfoUserControl1.Base64EncodedSignature,
                    PersonId = personId,
                    LocationId = locationId
                };

                // Persist the Asset Info
                assetManagementRepository.InsertAsset(assetInfo);
                MessageBox.Show("Saved Successfully!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
