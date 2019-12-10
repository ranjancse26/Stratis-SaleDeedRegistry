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
    public partial class LocationInfoUserControl : UserControl
    {
        public LocationInfoUserControl()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            txtAddressLine1.Text = "";
            txtAddressLine2.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            txtLatitude.Text = "";
            txtLongitude.Text = "";
            txtState.Text = "";
            txtZipCode.Text = "";
        }
    }
}
