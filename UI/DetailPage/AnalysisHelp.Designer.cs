namespace QuadrantAnalysis.UI.DetailPage
{
    partial class AnalysisHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalysisHelp));
            this.richTextMain = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextMain
            // 
            this.richTextMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextMain.Location = new System.Drawing.Point(0, 0);
            this.richTextMain.Name = "richTextMain";
            this.richTextMain.ReadOnly = true;
            this.richTextMain.Size = new System.Drawing.Size(609, 463);
            this.richTextMain.TabIndex = 0;
            this.richTextMain.Text = resources.GetString("richTextMain.Text");
            // 
            // AnalysisHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 463);
            this.Controls.Add(this.richTextMain);
            this.Name = "AnalysisHelp";
            this.Text = "AnalysisHelp";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextMain;
    }
}