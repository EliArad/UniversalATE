using ATEControls;
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

namespace UniversalATE
{
    public partial class SelectGroupForm : Form
    {
        int m_width;
        public SelectGroupForm(List<string> group, List<string> currentShowList)
        {
                        
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            GroupSelectControl control = new GroupSelectControl();
            control.Setup("Root");
            flowLayoutPanel1.Controls.Add(control);
            if (currentShowList.Contains("Root") == true)
            {
                control.SetChecked(true);
            }


            foreach (string s in group)
            {
                control = new GroupSelectControl();
                control.Setup(s);
                flowLayoutPanel1.Controls.Add(control);

                foreach (string g in group)
                {
                    if (currentShowList.Contains(g) == true)
                    {
                        control.SetChecked(true);
                    }
                }
            }

            btnOk.SetSkin(ResManager.R.GetBitmaps("btn140x40_11"), 0.8f, 0.8f);
            btnCancel.SetSkin(ResManager.R.GetBitmaps("btn140x40_11"), 0.8f, 0.8f);
            btnOk.ForeColor = Color.White;
            btnCancel.ForeColor = Color.White;


            btnAll.SetSkin(ResManager.R.GetBitmaps("btn140x40_2"), 0.8f, 0.8f);
            btnClearAll.SetSkin(ResManager.R.GetBitmaps("btn140x40_2"), 0.8f, 0.8f);
            btnAll.ForeColor = Color.White;
            btnClearAll.ForeColor = Color.White;



            m_width = this.Width;
        }
        public List<string> GetList()
        {
            return m_listChecked;
        }

        List<string> m_listChecked = new List<string>();
        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach (GroupSelectControl c in flowLayoutPanel1.Controls)
            {
                bool b = c.GetChecked(out string name);
                if (b == true)
                {
                    m_listChecked.Add(name);
                }
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SelectGroupForm_Resize(object sender, EventArgs e)
        {
            if (this.Width > m_width)
            {
                this.Width = m_width;
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            foreach (GroupSelectControl c in flowLayoutPanel1.Controls)
            {
                c.SetChecked(true);
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            foreach (GroupSelectControl c in flowLayoutPanel1.Controls)
            {
                c.SetChecked(false);
            }
        }
    }
}
