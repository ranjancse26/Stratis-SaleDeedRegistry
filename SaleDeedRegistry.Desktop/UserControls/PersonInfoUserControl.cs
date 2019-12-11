﻿using System;
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

        public string FirstName
        {
            get
            {
                return txtFirstName.Text;
            }
        }

        public string LastName
        {
            get
            {
                return txtFirstName.Text;
            }
        }

        public string MiddleName
        {
            get
            {
                return txtMiddleName.Text;
            }
        }

        public string PAN
        {
            get
            {
                return txtPAN.Text;
            }
        }

        public string Aaddhar
        {
            get
            {
                return txtAaddhar.Text;
            }
        }

        public string Gender
        {
            get
            {
                return cmbGender.Text;
            }
        }

        public void Clear()
        {
            txtAaddhar.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPAN.Text = "";
            cmbGender.SelectedIndex = 0;
            cmbGender.Text = "Male";
            txtFirstName.Focus();
        }

        /// <summary>
        /// Custom Validate the fields and throw error message
        /// </summary>
        public bool Validate()
        {
            if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
            {
                ShowErrorMessage("Please specify the First Name");
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
            {
                ShowErrorMessage("Please specify the Last Name");
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cmbGender.Text.Trim()))
            {
                ShowErrorMessage("Please select Gender");
                cmbGender.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPAN.Text.Trim()))
            {
                ShowErrorMessage("Please specify the PAN Number");
                txtPAN.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtAaddhar.Text.Trim()))
            {
                ShowErrorMessage("Please specify the Aaddhar Number");
                txtAaddhar.Focus();
                return false;
            }
            return true;
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
