
namespace UniversalATE
{
    partial class GroupNameForm
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
            this.testGroupControl1 = new ATEControls.TestGroupControl();
            this.SuspendLayout();
            // 
            // testGroupControl1
            // 
            this.testGroupControl1.BackColor = System.Drawing.Color.White;
            this.testGroupControl1.Location = new System.Drawing.Point(0, 2);
            this.testGroupControl1.Name = "testGroupControl1";
            this.testGroupControl1.Size = new System.Drawing.Size(601, 431);
            this.testGroupControl1.TabIndex = 0;
            // 
            // GroupNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 434);
            this.Controls.Add(this.testGroupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GroupNameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GroupNameForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ATEControls.TestGroupControl testGroupControl1;
    }
}