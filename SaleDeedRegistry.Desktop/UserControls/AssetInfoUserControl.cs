using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleDeedRegistry.Desktop.UserControls
{
    public partial class AssetInfoUserControl : UserControl
    {
        public AssetInfoUserControl()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            txtMarketPrice.Text = "";
            txtPropertyNumber.Text = "";
            txtPurchancePrice.Text = "";
            txtPropertyTax.Text = "";
            txtWardNumber.Text = "";
            txtMunciple.Text = "";
            signatureBox.Image = null;
        }
    }
}
