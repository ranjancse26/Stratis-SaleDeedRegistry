using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using SaleDeedRegistry.Desktop.Constants;

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
        }

        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCreateAsset frmCreateAsset = new FrmCreateAsset();
            frmCreateAsset.ShowDialog();
        }
    }
}
