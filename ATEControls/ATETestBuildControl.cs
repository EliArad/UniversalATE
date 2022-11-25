using ATEDBLib;
using GSkinLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATEControls
{
    public partial class ATETestBuildControl : UserControl
    {
        public interface IATETestBuildControl
        {
            void NotifyRemoveTest(ATETest test, int testId, ATETestBuildControl control);
        }
        int m_testId = -1;
        string m_baseFolder;

        IATETestBuildControl pIATETestBuildControl;
        public ATETestBuildControl(string baseFolder, IATETestBuildControl p)
        {
            InitializeComponent();
            m_baseFolder = baseFolder;
            pIATETestBuildControl = p;

            btnRemove.SetSkin(ResManager.R.GetBitmaps("btn140x40"), 0.7f, 0.8f);
            btnBrowse.SetSkin(ResManager.R.GetBitmaps("btn140x40"), 0.7f, 0.8f);
            btnSettings.SetSkin(ResManager.R.GetBitmaps("btn140x40"), 0.7f, 0.8f);


            chkEnable.SetSkin(ResManager.R.GetOnOffBitmaps("on_off_3"));
            chkEnable.Checked(false);

            chkVisible.SetSkin(ResManager.R.GetOnOffBitmaps("on_off_3"));
            chkVisible.Checked(false);

            chkExtendedForm.SetSkin(ResManager.R.GetOnOffBitmaps("on_off_3"));
            chkExtendedForm.Checked(false);


            btnRemove.Top -= 12;
            btnBrowse.Top -= 12;
            btnSettings.Top -= 12;
            chkEnable.Top -= 10;
            chkVisible.Top -= 10;
            chkExtendedForm.Top -= 10;

            btnRemove.ForeColor = Color.White;
            btnBrowse.ForeColor = Color.White;
            btnSettings.ForeColor = Color.White;

        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string Filter = "Dll file (*.dll)|*.dll|All files (*.*)|*.*";
            if (GuiCommon.GetFile("Select DLL For test..", out string fileName, Filter) == true)
            {                
                if (fileName.Contains(m_baseFolder) == true)
                {
                    string s = fileName.Substring(fileName.IndexOf(m_baseFolder) + m_baseFolder.Length + 1);
                    txtDllFileName.Text = s;
                    m_test.testDllFileIsRelative = true;
                    txtDllFileName.ForeColor = Color.Green;
                }
                else
                {
                    txtDllFileName.Text = fileName;
                    m_test.testDllFileIsRelative = false;
                    txtDllFileName.ForeColor = Color.Black;
                }
            }
        }
        ATETest m_test;
        public void Setup(List<string> groups)
        {
            cmbGroup.Items.Add("Root");
            if (groups != null)
            {
                foreach (string s in groups)
                {
                    cmbGroup.Items.Add(s);
                }                
            }
            cmbGroup.SelectedIndex = 0;

        }
         
        public void Setup(List<string> groups, ATETest test, int testId)
        {
            m_test = test;
            m_testId = testId;
            if (test.testDllFileIsRelative == true)
            {
                txtDllFileName.ForeColor = Color.Green;
            }
            else
            {
                txtDllFileName.ForeColor = Color.Black;
            }
            txtDllFileName.Text = test.testDllFileName;
            txtDescription.Text = test.testDescription;
            txtTestName.Text = test.testName;
            txtTestClassName.Text = test.testClassName;
            chkEnable.Checked(test.testEnabled);
            chkVisible.Checked(test.testVisible);
            chkExtendedForm.Checked(test.extendedForm);

            cmbGroup.Items.Add("Root");
            if (groups != null)
            {
                foreach (string s in groups)
                {
                    cmbGroup.Items.Add(s);
                }
            }
            cmbGroup.SelectedIndex = 0;

            try
            {
                cmbGroup.Text = test.GroupName;
            }
            catch (Exception err)
            {
                cmbGroup.SelectedIndex = 0;
            }

        }
        public bool GetData(out ATETest test, out string outMessage)
        {
            
            test = new ATETest();
            bool ok = true;
            outMessage = string.Empty;
            if (txtTestName.Text == string.Empty)
            {
                outMessage += "Test name is empty" + Environment.NewLine;
                ok &= false;
            }

            if (txtTestClassName.Text == string.Empty)
            {
                outMessage += "Test class name is empty" + Environment.NewLine;
                ok &= false;
            }
            test.testClassName = txtTestClassName.Text;
            test.testEnabled = chkEnable.GetChecked();
            test.testVisible = chkVisible.GetChecked();
            if (File.Exists(txtDllFileName.Text) == false)
            {
                outMessage = "Dll file name does not exist:" + (m_testId + 1) + Environment.NewLine;
                ok &= false;
            }
            if (txtTestName.Text == string.Empty)
            {
                outMessage += "Test name cannot be empty:" + (m_testId + 1);
                ok &= false;
            }
            test.extendedForm = chkExtendedForm.GetChecked();
            test.testDllFileName = txtDllFileName.Text;
            test.testDescription = txtDescription.Text;
            test.testName = txtTestName.Text;
            test.GroupName = cmbGroup.Text;

            return ok;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            pIATETestBuildControl.NotifyRemoveTest(m_test, m_testId, this);
        }
        public int Id
        {
            set
            {
                m_testId = value;
            }
            get
            {
                return m_testId;
            }
        }

        private void chkEnable_Click(object sender, EventArgs e)
        {
            chkEnable.Toggle((cb)=>
            {


            });
        }

        private void chkVisible_Click(object sender, EventArgs e)
        {
            chkVisible.Toggle((cb) =>
            {


            });
        }

        private void chkExtendedForm_Click(object sender, EventArgs e)
        {
            chkExtendedForm.Toggle((cb) =>
            {


            });
        }

        public void EnabledChecked(bool c)
        {
            chkEnable.Checked(c);
        }

        public void CheckedVisible(bool c)
        {
            chkVisible.Checked(c);
        }
    }
}
