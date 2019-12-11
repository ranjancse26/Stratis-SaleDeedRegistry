using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ContactManagement;
using SaleDeedRegistry.Desktop.Constants;
using SaleDeedRegistry.Desktop.Signature;

namespace SaleDeedRegistry.Desktop
{
    public partial class FrmMain : Form
    {
        string dbPath = "";

        public FrmMain()
        {
            string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            dbPath = string.Format($"{exePath}\\{DBConstant.SqlLiteDBFileName}");

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;
        }

        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCreateAsset frmCreateAsset = new FrmCreateAsset();
            frmCreateAsset.MdiParent = this;
            frmCreateAsset.Show();
        }

        private void signaturePadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSignaturePad signaturePad = new FrmSignaturePad();
            signaturePad.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAboutBox frmAboutBox = new FrmAboutBox();
            frmAboutBox.ShowDialog();
        }
    }
}
