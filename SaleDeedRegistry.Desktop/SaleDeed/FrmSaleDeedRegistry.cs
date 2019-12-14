using System;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using SaleDeedRegistry.Lib.Actors;
using SaleDeedRegistry.Lib.Client;

namespace SaleDeedRegistry.Desktop.SaleDeed
{
    public partial class FrmSaleDeedRegistry : Form
    {
        private const string PaidApplicationTransferFee = "Paid Application Transfer Fee";
        private const string InProgressState = "In-Progress";
        private const string StateTheReviewProcess = "Started Review Process";
        private const string CompleteTheReviewProcess = "Completed Review Process";
        private const string TransferOwnershipComplete = "Transfer Ownership Complete";
        
        private readonly Payee payee;
        private readonly PropertyBuyer propertyBuyer;
        private readonly PropertySeller propertySeller;
        private readonly StringBuilder responseStringBuilder;

        private Supervisor supervisor;
        private ReceiptResponse receiptResponse;

        public FrmSaleDeedRegistry()
        {
            InitializeComponent();
            payee = new Payee();
            propertyBuyer = new PropertyBuyer();
            propertySeller = new PropertySeller();
            responseStringBuilder = new StringBuilder();
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
                MessageBox.Show("Please specify the AssetId", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAssetID.Focus();
                return;
            }

            lblState.Visible = true;

            lblState.Text = "Please wait....";
            supervisor = new Supervisor(txtAssetID.Text.Trim());
            receiptResponse = await supervisor.InitApplication();

            if (receiptResponse != null && receiptResponse.success)
            {
                OutputResponseInformation(receiptResponse);
                lblState.Text = InProgressState;
                btnInitApplication.Enabled = false;
                btnStartReviewProcess.Enabled = true;
            }
        }

        /// <summary>
        /// Output the ReceiptResponse information on to the RichTextBox
        /// </summary>
        /// <param name="receiptResponse">ReceiptResponse</param>
        private void OutputResponseInformation(ReceiptResponse receiptResponse)
        {
            responseStringBuilder.AppendLine(DateTime.Now.ToString());
            responseStringBuilder.AppendLine(JsonConvert.SerializeObject(receiptResponse));
            richTextBox1.Text = responseStringBuilder.ToString();
            responseStringBuilder.AppendLine("\n");
        }

        private async void btnStartReviewProcess_Click(object sender, System.EventArgs e)
        {
            lblState.Text = "Please wait....";
            receiptResponse = await supervisor.StartTheReviewProcess();
            if (receiptResponse != null && receiptResponse.success)
            {
                OutputResponseInformation(receiptResponse);
                lblState.Text = StateTheReviewProcess;
                btnStartReviewProcess.Enabled = false;
                btnCompleteReviewProcess.Enabled = true;
            }
        }

        private async void btnCompleteReviewProcess_Click(object sender, System.EventArgs e)
        {
            lblState.Text = "Please wait....";
            receiptResponse = await supervisor.CompleteTheReviewProcess();
            if (receiptResponse != null && receiptResponse.success)
            {
                OutputResponseInformation(receiptResponse);
                lblState.Text = CompleteTheReviewProcess;
                btnCompleteReviewProcess.Enabled = false;
                btnPayApplicationTransferFee.Enabled = true;
            }
        }

        private async void btnPayApplicationTransferFee_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAssetID.Text))
            {
                MessageBox.Show("Please specify the AssetId", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAssetID.Focus();
                return;
            }
            
            lblState.Text = "Please wait....";
            receiptResponse = await propertyBuyer.PayTransferFee(payee.GetPayee(),
                txtAssetID.Text.Trim());
            if (receiptResponse != null && receiptResponse.success)
            {
                OutputResponseInformation(receiptResponse);
                lblState.Text = PaidApplicationTransferFee;
                btnPayApplicationTransferFee.Enabled = false;
                btnTransferOwnership.Enabled = true;
            }
        }

        private async void btnTransferOwnership_Click(object sender, System.EventArgs e)
        {
            lblState.Text = "Please wait....";
            receiptResponse = await supervisor.TransferOwnership(propertySeller.GetOwnerAddress(),
                propertyBuyer.GetBuyerAddress());
            if (receiptResponse != null && receiptResponse.success)
            {
                OutputResponseInformation(receiptResponse);
                btnTransferOwnership.Enabled = false;
                lblState.Text = TransferOwnershipComplete;
            }
        }
    }
}
