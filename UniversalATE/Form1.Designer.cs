
namespace UniversalATE
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildViewGroupingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTestGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.allEnabled2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AllEnableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allDisableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allVisble2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allVisibleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.allUnVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showExtendedFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartAll = new GSkinLib.SkinButton();
            this.btnSelectGroup = new GSkinLib.SkinButton();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.testsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1367, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.saveToolStripMenuItem.Text = "Save - Ctrl +S";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildViewToolStripMenuItem,
            this.buildViewGroupingToolStripMenuItem,
            this.addNewTestToolStripMenuItem,
            this.addTestGroupToolStripMenuItem,
            this.clearAllToolStripMenuItem,
            this.toolStripMenuItem1,
            this.allEnabled2ToolStripMenuItem,
            this.allVisble2ToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // buildViewToolStripMenuItem
            // 
            this.buildViewToolStripMenuItem.Name = "buildViewToolStripMenuItem";
            this.buildViewToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.buildViewToolStripMenuItem.Text = "Build View";
            this.buildViewToolStripMenuItem.Click += new System.EventHandler(this.buildViewToolStripMenuItem_Click);
            // 
            // buildViewGroupingToolStripMenuItem
            // 
            this.buildViewGroupingToolStripMenuItem.Name = "buildViewGroupingToolStripMenuItem";
            this.buildViewGroupingToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.buildViewGroupingToolStripMenuItem.Text = "Test View - Grouping";
            this.buildViewGroupingToolStripMenuItem.Click += new System.EventHandler(this.testViewGroupingToolStripMenuItem_Click);
            // 
            // addNewTestToolStripMenuItem
            // 
            this.addNewTestToolStripMenuItem.Name = "addNewTestToolStripMenuItem";
            this.addNewTestToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.addNewTestToolStripMenuItem.Text = "Add New Test - Ctrl + A";
            this.addNewTestToolStripMenuItem.Click += new System.EventHandler(this.addNewTestToolStripMenuItem_Click);
            // 
            // addTestGroupToolStripMenuItem
            // 
            this.addTestGroupToolStripMenuItem.Name = "addTestGroupToolStripMenuItem";
            this.addTestGroupToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.addTestGroupToolStripMenuItem.Text = "Add Test Group";
            this.addTestGroupToolStripMenuItem.Click += new System.EventHandler(this.addTestGroupToolStripMenuItem_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.clearAllToolStripMenuItem.Text = "Clear All";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(195, 6);
            // 
            // allEnabled2ToolStripMenuItem
            // 
            this.allEnabled2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AllEnableToolStripMenuItem,
            this.allDisableToolStripMenuItem});
            this.allEnabled2ToolStripMenuItem.Name = "allEnabled2ToolStripMenuItem";
            this.allEnabled2ToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.allEnabled2ToolStripMenuItem.Text = "Enable";
            // 
            // AllEnableToolStripMenuItem
            // 
            this.AllEnableToolStripMenuItem.Name = "AllEnableToolStripMenuItem";
            this.AllEnableToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.AllEnableToolStripMenuItem.Text = "All Enable";
            this.AllEnableToolStripMenuItem.Click += new System.EventHandler(this.AllEnableToolStripMenuItem_Click);
            // 
            // allDisableToolStripMenuItem
            // 
            this.allDisableToolStripMenuItem.Name = "allDisableToolStripMenuItem";
            this.allDisableToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.allDisableToolStripMenuItem.Text = "All Disable";
            this.allDisableToolStripMenuItem.Click += new System.EventHandler(this.allDisableToolStripMenuItem_Click);
            // 
            // allVisble2ToolStripMenuItem
            // 
            this.allVisble2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allVisibleToolStripMenuItem1,
            this.allUnVisibleToolStripMenuItem});
            this.allVisble2ToolStripMenuItem.Name = "allVisble2ToolStripMenuItem";
            this.allVisble2ToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.allVisble2ToolStripMenuItem.Text = "Visible";
            // 
            // allVisibleToolStripMenuItem1
            // 
            this.allVisibleToolStripMenuItem1.Name = "allVisibleToolStripMenuItem1";
            this.allVisibleToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.allVisibleToolStripMenuItem1.Text = "All Visible";
            this.allVisibleToolStripMenuItem1.Click += new System.EventHandler(this.allVisibleToolStripMenuItem1_Click);
            // 
            // allUnVisibleToolStripMenuItem
            // 
            this.allUnVisibleToolStripMenuItem.Name = "allUnVisibleToolStripMenuItem";
            this.allUnVisibleToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.allUnVisibleToolStripMenuItem.Text = "All UnVisible";
            this.allUnVisibleToolStripMenuItem.Click += new System.EventHandler(this.allUnVisibleToolStripMenuItem_Click);
            // 
            // testsToolStripMenuItem
            // 
            this.testsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startAllToolStripMenuItem,
            this.stopAlToolStripMenuItem,
            this.showExtendedFormToolStripMenuItem});
            this.testsToolStripMenuItem.Name = "testsToolStripMenuItem";
            this.testsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.testsToolStripMenuItem.Text = "Tests";
            // 
            // startAllToolStripMenuItem
            // 
            this.startAllToolStripMenuItem.Name = "startAllToolStripMenuItem";
            this.startAllToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.startAllToolStripMenuItem.Text = "Start All";
            this.startAllToolStripMenuItem.Click += new System.EventHandler(this.startAllToolStripMenuItem_Click);
            // 
            // stopAlToolStripMenuItem
            // 
            this.stopAlToolStripMenuItem.Name = "stopAlToolStripMenuItem";
            this.stopAlToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.stopAlToolStripMenuItem.Text = "Stop All";
            this.stopAlToolStripMenuItem.Click += new System.EventHandler(this.stopAlToolStripMenuItem_Click);
            // 
            // showExtendedFormToolStripMenuItem
            // 
            this.showExtendedFormToolStripMenuItem.Name = "showExtendedFormToolStripMenuItem";
            this.showExtendedFormToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.showExtendedFormToolStripMenuItem.Text = "Show Extended Form";
            this.showExtendedFormToolStripMenuItem.Click += new System.EventHandler(this.showExtendedFormToolStripMenuItem_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 68);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1367, 542);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(343, 36);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(245, 26);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search:";
            // 
            // btnStartAll
            // 
            this.btnStartAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartAll.Location = new System.Drawing.Point(1228, 33);
            this.btnStartAll.Name = "btnStartAll";
            this.btnStartAll.Size = new System.Drawing.Size(75, 23);
            this.btnStartAll.TabIndex = 4;
            this.btnStartAll.Text = "Start Tests";
            this.btnStartAll.UseVisualStyleBackColor = true;
            this.btnStartAll.Click += new System.EventHandler(this.btnStartAll_Click);
            // 
            // btnSelectGroup
            // 
            this.btnSelectGroup.Location = new System.Drawing.Point(594, 38);
            this.btnSelectGroup.Name = "btnSelectGroup";
            this.btnSelectGroup.Size = new System.Drawing.Size(75, 23);
            this.btnSelectGroup.TabIndex = 5;
            this.btnSelectGroup.Text = "Groups..";
            this.btnSelectGroup.UseVisualStyleBackColor = false;
            this.btnSelectGroup.Visible = false;
            this.btnSelectGroup.Click += new System.EventHandler(this.btnSelectGroup_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 612);
            this.Controls.Add(this.btnSelectGroup);
            this.Controls.Add(this.btnStartAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Universal ATE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private GSkinLib.SkinButton btnStartAll;
        private System.Windows.Forms.ToolStripMenuItem showExtendedFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem allEnabled2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allVisble2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AllEnableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allDisableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allVisibleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem allUnVisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTestGroupToolStripMenuItem;
        private GSkinLib.SkinButton btnSelectGroup;
        private System.Windows.Forms.ToolStripMenuItem buildViewGroupingToolStripMenuItem;
    }
}

