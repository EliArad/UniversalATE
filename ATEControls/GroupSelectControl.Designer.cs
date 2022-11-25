
namespace ATEControls
{
    partial class GroupSelectControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkOnOff = new GSkinLib.SkinOnOffBox();
            this.txtName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkOnOff
            // 
            this.chkOnOff.Location = new System.Drawing.Point(187, 3);
            this.chkOnOff.Name = "chkOnOff";
            this.chkOnOff.Size = new System.Drawing.Size(75, 23);
            this.chkOnOff.TabIndex = 0;
            this.chkOnOff.UseVisualStyleBackColor = false;
            this.chkOnOff.Click += new System.EventHandler(this.chkOnOff_Click);
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(4, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(46, 17);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "label1";
            // 
            // GroupSelectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.chkOnOff);
            this.Name = "GroupSelectControl";
            this.Size = new System.Drawing.Size(280, 49);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GSkinLib.SkinOnOffBox chkOnOff;
        private System.Windows.Forms.Label txtName;
    }
}
