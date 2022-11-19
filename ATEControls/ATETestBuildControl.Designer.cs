
using GSkinLib;

namespace ATEControls
{
    partial class ATETestBuildControl
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
            this.txtTestName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSettings = new GSkinLib.SkinButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDllFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowse = new GSkinLib.SkinButton();
            this.btnRemove = new GSkinLib.SkinButton();
            this.chkEnable = new GSkinLib.SkinOnOffBox();
            this.chkVisible = new GSkinLib.SkinOnOffBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTestClassName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkExtendedForm = new GSkinLib.SkinOnOffBox();
            this.SuspendLayout();
            // 
            // txtTestName
            // 
            this.txtTestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtTestName.Location = new System.Drawing.Point(4, 23);
            this.txtTestName.Name = "txtTestName";
            this.txtTestName.Size = new System.Drawing.Size(207, 23);
            this.txtTestName.TabIndex = 3;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtDescription.Location = new System.Drawing.Point(415, 22);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(224, 37);
            this.txtDescription.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Test Name";
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(1113, 23);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "Settings..";
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Description";
            // 
            // txtDllFileName
            // 
            this.txtDllFileName.Location = new System.Drawing.Point(646, 25);
            this.txtDllFileName.Name = "txtDllFileName";
            this.txtDllFileName.Size = new System.Drawing.Size(332, 20);
            this.txtDllFileName.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(645, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Test DLL File Name";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(984, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(1517, 23);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 12;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // chkEnable
            // 
            this.chkEnable.Location = new System.Drawing.Point(1226, 23);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(55, 23);
            this.chkEnable.TabIndex = 13;
            this.chkEnable.UseVisualStyleBackColor = false;
            this.chkEnable.Click += new System.EventHandler(this.chkEnable_Click);
            // 
            // chkVisible
            // 
            this.chkVisible.Location = new System.Drawing.Point(1308, 23);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(55, 23);
            this.chkVisible.TabIndex = 14;
            this.chkVisible.UseVisualStyleBackColor = false;
            this.chkVisible.Click += new System.EventHandler(this.chkVisible_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1224, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Enable";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1305, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Visible";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Class name";
            // 
            // txtTestClassName
            // 
            this.txtTestClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtTestClassName.Location = new System.Drawing.Point(217, 22);
            this.txtTestClassName.Name = "txtTestClassName";
            this.txtTestClassName.Size = new System.Drawing.Size(180, 23);
            this.txtTestClassName.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1400, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Extended form";
            // 
            // chkExtendedForm
            // 
            this.chkExtendedForm.Location = new System.Drawing.Point(1403, 22);
            this.chkExtendedForm.Name = "chkExtendedForm";
            this.chkExtendedForm.Size = new System.Drawing.Size(55, 23);
            this.chkExtendedForm.TabIndex = 19;
            this.chkExtendedForm.UseVisualStyleBackColor = false;
            this.chkExtendedForm.Click += new System.EventHandler(this.chkExtendedForm_Click);
            // 
            // ATETestBuildControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkExtendedForm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTestClassName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkVisible);
            this.Controls.Add(this.chkEnable);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDllFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtTestName);
            this.Name = "ATETestBuildControl";
            this.Size = new System.Drawing.Size(1695, 69);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTestName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private SkinButton btnSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDllFileName;
        private System.Windows.Forms.Label label3;
        private SkinButton btnBrowse;
        private SkinButton btnRemove;
        private SkinOnOffBox chkEnable;
        private SkinOnOffBox chkVisible;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTestClassName;
        private System.Windows.Forms.Label label7;
        private SkinOnOffBox chkExtendedForm;
    }
}
