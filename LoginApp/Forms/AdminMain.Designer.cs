namespace LoginApp.Forms
{
    partial class AdminMain
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
            this.gv_Data = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // gv_Data
            // 
            this.gv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_Data.Location = new System.Drawing.Point(199, 12);
            this.gv_Data.Name = "gv_Data";
            this.gv_Data.Size = new System.Drawing.Size(937, 426);
            this.gv_Data.TabIndex = 1;
            // 
            // AdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 450);
            this.Controls.Add(this.gv_Data);
            this.Name = "AdminMain";
            this.Text = "AdminMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminMain_FormClosing);
            this.Load += new System.EventHandler(this.AdminMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_Data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gv_Data;
    }
}