using GSkinLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATEControls
{
    public partial class GroupSelectControl : UserControl
    {
        public GroupSelectControl()
        {
            InitializeComponent();

            chkOnOff.SetSkin(ResManager.R.GetOnOffBitmaps("on_off_4"));
            chkOnOff.Checked(false);
        }
        public void Setup(string name)
        {
            txtName.Text = name;
        }

        private void chkOnOff_Click(object sender, EventArgs e)
        {
            chkOnOff.Toggle((cb)=>
            {

            });
        }
        public bool GetChecked(out string name)
        {
            name = txtName.Text;
            return chkOnOff.GetChecked();
        }
        public void SetChecked(bool c)
        {
            chkOnOff.Checked(c);
        }
    }
}
