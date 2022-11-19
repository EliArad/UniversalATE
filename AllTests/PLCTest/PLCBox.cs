using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingLib
{
    public partial class PLCBox : Form
    {
        public PLCBox()
        {
            InitializeComponent();
        }

        private void PLCBox_Load(object sender, EventArgs e)
        {

           
        }

        private void PLCBox_DoubleClick(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.Sizable)
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            else
           if (this.FormBorderStyle == FormBorderStyle.FixedToolWindow)
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
            else
           if (this.FormBorderStyle == FormBorderStyle.FixedSingle)
                this.FormBorderStyle = FormBorderStyle.None;
            else
           if (this.FormBorderStyle == FormBorderStyle.None)
                this.FormBorderStyle = FormBorderStyle.Sizable;
        }
    }
}

