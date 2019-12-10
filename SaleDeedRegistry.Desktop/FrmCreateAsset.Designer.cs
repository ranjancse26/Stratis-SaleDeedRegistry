namespace SaleDeedRegistry.Desktop
{
    partial class FrmCreateAsset
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
            this.locationInfoUserControl1 = new SaleDeedRegistry.Desktop.UserControls.LocationInfoUserControl();
            this.assetInfoUserControl1 = new SaleDeedRegistry.Desktop.UserControls.AssetInfoUserControl();
            this.personInfoUserControl1 = new SaleDeedRegistry.Desktop.UserControls.PersonInfoUserControl();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // locationInfoUserControl1
            // 
            this.locationInfoUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.locationInfoUserControl1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.locationInfoUserControl1.Location = new System.Drawing.Point(730, 29);
            this.locationInfoUserControl1.Name = "locationInfoUserControl1";
            this.locationInfoUserControl1.Size = new System.Drawing.Size(656, 516);
            this.locationInfoUserControl1.TabIndex = 1;
            // 
            // assetInfoUserControl1
            // 
            this.assetInfoUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.assetInfoUserControl1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.assetInfoUserControl1.Location = new System.Drawing.Point(31, 407);
            this.assetInfoUserControl1.Name = "assetInfoUserControl1";
            this.assetInfoUserControl1.Size = new System.Drawing.Size(670, 562);
            this.assetInfoUserControl1.TabIndex = 0;
            // 
            // personInfoUserControl1
            // 
            this.personInfoUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.personInfoUserControl1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.personInfoUserControl1.Location = new System.Drawing.Point(31, 29);
            this.personInfoUserControl1.Name = "personInfoUserControl1";
            this.personInfoUserControl1.Size = new System.Drawing.Size(668, 369);
            this.personInfoUserControl1.TabIndex = 2;
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(944, 576);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(192, 61);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(1194, 576);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(192, 61);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FrmCreateAsset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1491, 1055);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.personInfoUserControl1);
            this.Controls.Add(this.locationInfoUserControl1);
            this.Controls.Add(this.assetInfoUserControl1);
            this.Name = "FrmCreateAsset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Asset";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.AssetInfoUserControl assetInfoUserControl1;
        private UserControls.LocationInfoUserControl locationInfoUserControl1;
        private UserControls.PersonInfoUserControl personInfoUserControl1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnClear;
    }
}