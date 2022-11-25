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
    public partial class TestGroupControl : UserControl
    {

        public interface ITestGroupControl
        {
            void NotifyGroupList(List<string> list);
        }

        List<string> m_groups;

        public TestGroupControl()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Text == string.Empty)
                return;
            if (listBox1.Items.Contains(txtGroupName.Text) == true)
                return;
             
            listBox1.Items.Add(txtGroupName.Text);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 1)
            {
                DialogResult d = MessageBox.Show("Are you sure?", "Instrument Client", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                    listBox1.Items.Clear();
            }
            else
            {
                listBox1.Items.Clear();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            m_groups = listBox1.Items.Cast<String>().ToList();
            pITestGroupControl.NotifyGroupList(m_groups);
        }

        bool once = false;

        ITestGroupControl pITestGroupControl = null;
        public void LoadControl(ITestGroupControl p, List<string> group)
        {
            pITestGroupControl = p;
            if (once == false)
            {
                btnAdd.SetSkin(ResManager.R.GetBitmaps("btn140x30"));
                
                btnSave.SetSkin(ResManager.R.GetBitmaps("btn140x30"));
                btnRemove.SetSkin(ResManager.R.GetBitmaps("btn140x30"));
                btnClearAll.SetSkin(ResManager.R.GetBitmaps("btn140x30"));
                btnDefault.SetSkin(ResManager.R.GetBitmaps("btn140x30"));

                btnSave.SetSkin(ResManager.R.GetBitmaps("btn140x40"));                

                btnAdd.ForeColor = Color.White;
                btnSave.ForeColor = Color.White;
                btnClearAll.ForeColor = Color.White;
                once = true;
            }

            listBox1.Items.Clear();
            if (group != null)
            {
                foreach (string s in group)
                {
                    listBox1.Items.Add(s);
                }
            }
             
        }

        int m_lastGroupIndex = -1;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGroupName.Text = listBox1.SelectedItem.ToString();
            m_lastGroupIndex = listBox1.SelectedIndex;
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            //DialogResult d = MessageBox.Show("Are you sure?", "Instrument", MessageBoxButtons.YesNo);
            //if (d == DialogResult.Yes)
            //{
            //    m_groups = m_api.InstrumentsGroupsBase.DefaultGroups();

            //    listBox1.Items.Clear();
            //    foreach (string s in m_groups)
            //    {
            //        listBox1.Items.Add(s);
            //    }
            //    listBox1.BackColor = Color.White;
            //}
        }
    }
}
