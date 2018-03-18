namespace XmlCompare
{
    partial class frmXmlCompare
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXmlCompare));
            this.txtBaseFile = new System.Windows.Forms.TextBox();
            this.btnBaseFile = new System.Windows.Forms.Button();
            this.lblBaseFile = new System.Windows.Forms.Label();
            this.lblFileToCompare = new System.Windows.Forms.Label();
            this.btnFileToCompare = new System.Windows.Forms.Button();
            this.txtFileToCompare = new System.Windows.Forms.TextBox();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.cboIdentifier = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblIdentifier = new System.Windows.Forms.Label();
            this.btnCompare = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.webResult = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // txtBaseFile
            // 
            this.txtBaseFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBaseFile.Location = new System.Drawing.Point(92, 12);
            this.txtBaseFile.Name = "txtBaseFile";
            this.txtBaseFile.Size = new System.Drawing.Size(364, 20);
            this.txtBaseFile.TabIndex = 0;
            // 
            // btnBaseFile
            // 
            this.btnBaseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBaseFile.Location = new System.Drawing.Point(462, 10);
            this.btnBaseFile.Name = "btnBaseFile";
            this.btnBaseFile.Size = new System.Drawing.Size(40, 23);
            this.btnBaseFile.TabIndex = 1;
            this.btnBaseFile.Text = "...";
            this.toolTip.SetToolTip(this.btnBaseFile, "Open base XML file");
            this.btnBaseFile.UseVisualStyleBackColor = true;
            this.btnBaseFile.Click += new System.EventHandler(this.btnBaseFile_Click);
            // 
            // lblBaseFile
            // 
            this.lblBaseFile.AutoSize = true;
            this.lblBaseFile.Location = new System.Drawing.Point(12, 15);
            this.lblBaseFile.Name = "lblBaseFile";
            this.lblBaseFile.Size = new System.Drawing.Size(50, 13);
            this.lblBaseFile.TabIndex = 2;
            this.lblBaseFile.Text = "Base file:";
            // 
            // lblFileToCompare
            // 
            this.lblFileToCompare.AutoSize = true;
            this.lblFileToCompare.Location = new System.Drawing.Point(12, 41);
            this.lblFileToCompare.Name = "lblFileToCompare";
            this.lblFileToCompare.Size = new System.Drawing.Size(74, 13);
            this.lblFileToCompare.TabIndex = 5;
            this.lblFileToCompare.Text = "Compare with:";
            // 
            // btnFileToCompare
            // 
            this.btnFileToCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileToCompare.Location = new System.Drawing.Point(462, 36);
            this.btnFileToCompare.Name = "btnFileToCompare";
            this.btnFileToCompare.Size = new System.Drawing.Size(40, 23);
            this.btnFileToCompare.TabIndex = 4;
            this.btnFileToCompare.Text = "...";
            this.toolTip.SetToolTip(this.btnFileToCompare, "Open XML file to compare with base");
            this.btnFileToCompare.UseVisualStyleBackColor = true;
            this.btnFileToCompare.Click += new System.EventHandler(this.btnFileToCompare_Click);
            // 
            // txtFileToCompare
            // 
            this.txtFileToCompare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileToCompare.Location = new System.Drawing.Point(92, 38);
            this.txtFileToCompare.Name = "txtFileToCompare";
            this.txtFileToCompare.Size = new System.Drawing.Size(364, 20);
            this.txtFileToCompare.TabIndex = 3;
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.Filter = "XML files|*.xml|All files|*.*";
            // 
            // cboFilter
            // 
            this.cboFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Items.AddRange(new object[] {
            "unfiltered (Merge of both files)",
            "New elements",
            "New attributes",
            "New text nodes",
            "Differend elements",
            "Differend attributes",
            "Missed elements",
            "Missed attributes",
            "Missed text nodes"});
            this.cboFilter.Location = new System.Drawing.Point(92, 64);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(178, 21);
            this.cboFilter.TabIndex = 6;
            // 
            // cboIdentifier
            // 
            this.cboIdentifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIdentifier.FormattingEnabled = true;
            this.cboIdentifier.Items.AddRange(new object[] {
            "ID",
            "Name"});
            this.cboIdentifier.Location = new System.Drawing.Point(328, 64);
            this.cboIdentifier.Name = "cboIdentifier";
            this.cboIdentifier.Size = new System.Drawing.Size(128, 21);
            this.cboIdentifier.TabIndex = 7;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(12, 67);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(32, 13);
            this.lblFilter.TabIndex = 8;
            this.lblFilter.Text = "Filter:";
            // 
            // lblIdentifier
            // 
            this.lblIdentifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIdentifier.AutoSize = true;
            this.lblIdentifier.Location = new System.Drawing.Point(276, 67);
            this.lblIdentifier.Name = "lblIdentifier";
            this.lblIdentifier.Size = new System.Drawing.Size(50, 13);
            this.lblIdentifier.TabIndex = 9;
            this.lblIdentifier.Text = "Identifier:";
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompare.Image = global::XmlCompare.Properties.Resources.Loupe_XML_16x16;
            this.btnCompare.Location = new System.Drawing.Point(462, 62);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(40, 23);
            this.btnCompare.TabIndex = 10;
            this.toolTip.SetToolTip(this.btnCompare, "Compare");
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // webResult
            // 
            this.webResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webResult.Location = new System.Drawing.Point(12, 103);
            this.webResult.MinimumSize = new System.Drawing.Size(20, 20);
            this.webResult.Name = "webResult";
            this.webResult.Size = new System.Drawing.Size(490, 246);
            this.webResult.TabIndex = 11;
            // 
            // frmXmlCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 361);
            this.Controls.Add(this.webResult);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.lblIdentifier);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cboIdentifier);
            this.Controls.Add(this.cboFilter);
            this.Controls.Add(this.lblFileToCompare);
            this.Controls.Add(this.btnFileToCompare);
            this.Controls.Add(this.txtFileToCompare);
            this.Controls.Add(this.lblBaseFile);
            this.Controls.Add(this.btnBaseFile);
            this.Controls.Add(this.txtBaseFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(530, 400);
            this.Name = "frmXmlCompare";
            this.Text = "XmlCompare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBaseFile;
        private System.Windows.Forms.Button btnBaseFile;
        private System.Windows.Forms.Label lblBaseFile;
        private System.Windows.Forms.Label lblFileToCompare;
        private System.Windows.Forms.Button btnFileToCompare;
        private System.Windows.Forms.TextBox txtFileToCompare;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.ComboBox cboIdentifier;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblIdentifier;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.WebBrowser webResult;
    }
}

