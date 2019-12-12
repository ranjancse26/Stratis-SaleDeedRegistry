using System.Windows.Forms;
using SaleDeedRegistry.Lib.Actors;
using SaleDeedRegistry.Lib.Client;

namespace SaleDeedRegistry.Desktop.SaleDeed
{
    public partial class FrmSaleDeedRegistry : Form
    {
        private readonly Payee payee;
        private readonly PropertyBuyer propertyBuyer;
        private readonly PropertySeller propertySeller;
        private Supervisor supervisor;
        private ReceiptResponse receiptResponse;

        public FrmSaleDeedRegistry()
        {
            InitializeComponent(); 
            payee = new Payee(); 
            propertyBuyer = new PropertyBuyer(); 
            propertySeller = new PropertySeller();
        }

        private void FrmSaleDeedRegistry_Load(object sender, System.EventArgs e)
        {
            btnStartReviewProcess.Enabled = false;
            btnCompleteReviewProcess.Enabled = false;
            btnPayApplicationTransferFee.Enabled = false;
            btnTransferOwnership.Enabled = false;
            lblState.Visible = false;
        }

        private async void btnInitApplication_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAssetID.Text))
            {
                MessageBox.Show("Property AssetID cannot be null or empty", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAssetID.Focus();
                return;
            }

            lblState.Visible = true;
            supervisor = new Supervisor(txtAssetID.Text.Trim());
            receiptResponse = await supervisor.InitApplication();

            if (receiptResponse != null && receiptResponse.success)
            {
                lblState.Text = "In-Progress";
                btnInitApplication.Enabled = false;
                btnStartReviewProcess.Enabled = true;
            }
        }

        private async void btnStartReviewProcess_Click(object sender, System.EventArgs e)
        {
            receiptResponse = await supervisor.StartTheReviewProcess();
            if (receiptResponse != null && receiptResponse.success)
            {
                lblState.Text = "Started Review Process";
                btnStartReviewProcess.Enabled = false;
                btnCompleteReviewProcess.Enabled = true;
            }
        }

        private async void btnCompleteReviewProcess_Click(object sender, System.EventArgs e)
        {
            receiptResponse = await supervisor.CompleteTheReviewProcess();
            if (receiptResponse != null && receiptResponse.success)
            {
                lblState.Text = "Completed Review Process";
                btnCompleteReviewProcess.Enabled = false;
                btnPayApplicationTransferFee.Enabled = true;
            }
        }

        private async void btnPayApplicationTransferFee_Click(object sender, System.EventArgs e)
        {
            receiptResponse = await propertyBuyer.PayTransferFee(payee.GetPayee());
            if (receiptResponse != null && receiptResponse.success)
            {
                lblState.Text = "Paid Application Transfer Fee";
                btnPayApplicationTransferFee.Enabled = false;
                btnTransferOwnership.Enabled = true;
            }
        }

        private async void btnTransferOwnership_Click(object sender, System.EventArgs e)
        {
            receiptResponse = await supervisor.TransferOwnership(propertySeller.GetOwnerAddress(),
                propertyBuyer.GetBuyerAddress());
            if (receiptResponse != null && receiptResponse.success)
            {
                btnTransferOwnership.Enabled = false;
                lblState.Text = "Transfer Ownership Complete";
            }
        }
    }
}
