using System;
using System.Windows.Forms;

namespace SaleDeedRegistry.Desktop.UserControls
{
    public partial class PersonInfoUserControl : UserControl, IUserControl
    {
        public PersonInfoUserControl()
        {
            InitializeComponent();
        }

        private void PersonInfoUserControl_Load(object sender, EventArgs e)
        {
            cmbGender.SelectedIndex = 0;
            cmbGender.Text = "Male";
        }

        public void Clear()
        {
            txtAaddhar.Text = "";
            txtFirstName.Text = "";
            txtPAN.Text = "";
            cmbGender.SelectedIndex = 0;
            cmbGender.Text = "Male";
            txtFirstName.Focus();
        }
    }
}
