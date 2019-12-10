namespace SaleDeedRegistry.Wallet
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnWalletBalance = new System.Windows.Forms.Button();
            this.btnWalletInfo = new System.Windows.Forms.Button();
            this.btnRecoverWallet = new System.Windows.Forms.Button();
            this.btnLoadWallet = new System.Windows.Forms.Button();
            this.btnCreateWallet = new System.Windows.Forms.Button();
            this.btnCreateMnuemonic = new System.Windows.Forms.Button();
            this.btnTransactionHistory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWalletBalance
            // 
            this.btnWalletBalance.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnWalletBalance.BackgroundImage")));
            this.btnWalletBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWalletBalance.ForeColor = System.Drawing.Color.White;
            this.btnWalletBalance.Location = new System.Drawing.Point(49, 281);
            this.btnWalletBalance.Name = "btnWalletBalance";
            this.btnWalletBalance.Size = new System.Drawing.Size(296, 143);
            this.btnWalletBalance.TabIndex = 5;
            this.btnWalletBalance.Text = "Wallet Balance";
            this.btnWalletBalance.UseVisualStyleBackColor = true;
            this.btnWalletBalance.Click += new System.EventHandler(this.btnWalletBalance_Click);
            // 
            // btnWalletInfo
            // 
            this.btnWalletInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnWalletInfo.BackgroundImage")));
            this.btnWalletInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWalletInfo.ForeColor = System.Drawing.Color.White;
            this.btnWalletInfo.Location = new System.Drawing.Point(516, 281);
            this.btnWalletInfo.Name = "btnWalletInfo";
            this.btnWalletInfo.Size = new System.Drawing.Size(296, 143);
            this.btnWalletInfo.TabIndex = 4;
            this.btnWalletInfo.Text = "Wallet Info";
            this.btnWalletInfo.UseVisualStyleBackColor = true;
            this.btnWalletInfo.Click += new System.EventHandler(this.btnWalletInfo_Click);
            // 
            // btnRecoverWallet
            // 
            this.btnRecoverWallet.BackColor = System.Drawing.Color.AliceBlue;
            this.btnRecoverWallet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRecoverWallet.BackgroundImage")));
            this.btnRecoverWallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecoverWallet.ForeColor = System.Drawing.Color.White;
            this.btnRecoverWallet.Location = new System.Drawing.Point(984, 281);
            this.btnRecoverWallet.Name = "btnRecoverWallet";
            this.btnRecoverWallet.Size = new System.Drawing.Size(296, 143);
            this.btnRecoverWallet.TabIndex = 3;
            this.btnRecoverWallet.Text = "Recover Wallet";
            this.btnRecoverWallet.UseVisualStyleBackColor = false;
            this.btnRecoverWallet.Click += new System.EventHandler(this.btnRecoverWallet_Click);
            // 
            // btnLoadWallet
            // 
            this.btnLoadWallet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLoadWallet.BackgroundImage")));
            this.btnLoadWallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadWallet.ForeColor = System.Drawing.Color.White;
            this.btnLoadWallet.Location = new System.Drawing.Point(984, 48);
            this.btnLoadWallet.Name = "btnLoadWallet";
            this.btnLoadWallet.Size = new System.Drawing.Size(296, 146);
            this.btnLoadWallet.TabIndex = 2;
            this.btnLoadWallet.Text = "Load Wallet";
            this.btnLoadWallet.UseVisualStyleBackColor = true;
            this.btnLoadWallet.Click += new System.EventHandler(this.btnLoadWallet_Click);
            // 
            // btnCreateWallet
            // 
            this.btnCreateWallet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCreateWallet.BackgroundImage")));
            this.btnCreateWallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateWallet.ForeColor = System.Drawing.Color.White;
            this.btnCreateWallet.Location = new System.Drawing.Point(516, 48);
            this.btnCreateWallet.Name = "btnCreateWallet";
            this.btnCreateWallet.Size = new System.Drawing.Size(296, 146);
            this.btnCreateWallet.TabIndex = 1;
            this.btnCreateWallet.Text = "Create Wallet";
            this.btnCreateWallet.UseVisualStyleBackColor = true;
            this.btnCreateWallet.Click += new System.EventHandler(this.btnCreateWallet_Click);
            // 
            // btnCreateMnuemonic
            // 
            this.btnCreateMnuemonic.BackgroundImage = global::SaleDeedRegistry.Wallet.Properties.Resources.button_blue;
            this.btnCreateMnuemonic.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateMnuemonic.ForeColor = System.Drawing.Color.White;
            this.btnCreateMnuemonic.Location = new System.Drawing.Point(49, 48);
            this.btnCreateMnuemonic.Name = "btnCreateMnuemonic";
            this.btnCreateMnuemonic.Size = new System.Drawing.Size(296, 146);
            this.btnCreateMnuemonic.TabIndex = 0;
            this.btnCreateMnuemonic.Text = "Create Mnemonic";
            this.btnCreateMnuemonic.UseVisualStyleBackColor = true;
            this.btnCreateMnuemonic.Click += new System.EventHandler(this.btnCreateMnuemonic_Click);
            // 
            // btnTransactionHistory
            // 
            this.btnTransactionHistory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTransactionHistory.BackgroundImage")));
            this.btnTransactionHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransactionHistory.ForeColor = System.Drawing.Color.White;
            this.btnTransactionHistory.Location = new System.Drawing.Point(49, 506);
            this.btnTransactionHistory.Name = "btnTransactionHistory";
            this.btnTransactionHistory.Size = new System.Drawing.Size(296, 143);
            this.btnTransactionHistory.TabIndex = 6;
            this.btnTransactionHistory.Text = "Transaction History";
            this.btnTransactionHistory.UseVisualStyleBackColor = true;
            this.btnTransactionHistory.Click += new System.EventHandler(this.btnTransactionHistory_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1412, 773);
            this.Controls.Add(this.btnTransactionHistory);
            this.Controls.Add(this.btnWalletBalance);
            this.Controls.Add(this.btnWalletInfo);
            this.Controls.Add(this.btnRecoverWallet);
            this.Controls.Add(this.btnLoadWallet);
            this.Controls.Add(this.btnCreateWallet);
            this.Controls.Add(this.btnCreateMnuemonic);
            this.Name = "FrmMain";
            this.Text = "SaleDeedRegistry Wallet";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateMnuemonic;
        private System.Windows.Forms.Button btnCreateWallet;
        private System.Windows.Forms.Button btnLoadWallet;
        private System.Windows.Forms.Button btnRecoverWallet;
        private System.Windows.Forms.Button btnWalletInfo;
        private System.Windows.Forms.Button btnWalletBalance;
        private System.Windows.Forms.Button btnTransactionHistory;
    }
}

