using ATEDBLib;
using GSkinLib;
using InvokersLib;
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
using TestingLib;
using static TestingLib.ITest;

namespace ATEControls
{

    public partial class ATETestControl : UserControl, ITestNotify
    {

        public interface IATETestControl
        {
            void NotifyStartTest(ATETest test, int testId, ATETestControl control);
            void NotifyStopTest(ATETest test, int testId, ATETestControl control);
            void NotifyOpenSetting(ATETest test, int testId, ATETestControl control);
            void NotifyEnableTest(ATETest test, int testId, ATETestControl control, bool enable);
        }
        int m_testId = -1;

        TestExecuter m_testExecuter = new TestExecuter();
        IATETestControl pIATETestControl;
        
        public ATETestControl(IATETestControl p)
        {
            InitializeComponent();
            pIATETestControl = p;

            btnStart.SetSkin(ResManager.R.GetBitmaps("btn140x40_21"), 0.7f , 0.8f);
            btnStop.SetSkin(ResManager.R.GetBitmaps("btn140x40_21"), 0.7f, 0.8f);
            btnSettings.SetSkin(ResManager.R.GetBitmaps("btn140x40"), 0.7f, 0.8f);


            btnStart.Top -= 12;
            btnStop.Top -= 12;
            btnSettings.Top -= 12;

            chkEnable.SetSkin(ResManager.R.GetOnOffBitmaps("on_off_3"));
            chkEnable.Checked(false);
            chkEnable.Top -= 12;


            btnStart.ForeColor = Color.White;
            btnStop.ForeColor = Color.White;
            btnSettings.ForeColor = Color.White;


            btnStart.Checked(false);
            btnStop.Checked(true);

        }
        ATETest m_test;
        public void Setup(ATETest test, int testId)
        {
            txtDescription.Text = test.testDescription;
            txtTestName.Text = test.testName;
            m_test = test;
            m_testId = testId;
            chkEnable.Checked(test.testEnabled);

            btnStart.Enable(test.testEnabled);
            btnStop.Enable(test.testEnabled);
            btnSettings.Enable(test.testEnabled);
        }

        public void Setup(int testId)
        {
            m_testId = testId;
        }

        public void SetBackColor(Color backColor)
        {
            INVOKERS.InvokeControlBackColor(txtPassFail, backColor);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            INVOKERS.InvokeControlBackColor(txtPassFail, Color.White);
            progressBar1.Value = 0;
            if (StartTest(true, out string outMessage) == true)
            {
                btnStart.Checked(true);
                btnStop.Checked(false);
            }
            pIATETestControl.NotifyStartTest(m_test, m_testId,this);
             
        }
        public bool StopTest(out string outMessage)
        {
            if (chkEnable.GetChecked() == false)
            {
                outMessage = "Test not enabled";
                return false;
            }

            if (InitExeciter(out outMessage) ==false)
            {
                return false;
            }
            bool ret = m_testExecuter.StopTest();
            if (ret == false)
            {
                outMessage = "Not stopped yet";
                return false;
            }
            outMessage = "Test stopped ok";

            
            btnStart.Checked(false);
            btnStop.Checked(true);
            pIATETestControl.NotifyStopTest(m_test, m_testId,this);

            return ret;
        }
      
        public bool StartTest(bool async, out string outMessage)
        {
            if (chkEnable.GetChecked() == false)
            {
                outMessage = "Test not enabled";
                return false;
            }

            if (m_testExecuter.IsRunning() == true)
            {
                outMessage = "Already running";
                return true;
            }

            if (InitExeciter(out outMessage) == false)
            {
                return false;
            }
            outMessage = "Ok";
            
            if (async == true)
            {
                m_testExecuter.StartTestAsync(m_test);
            }
            else
            {
                m_testExecuter.StartTestSync(m_test);
            }

            return true;
        }
        bool InitExeciter(out string outMessage)
        {
            
            if (m_testExecuter.Initialize(m_test.testClassName, m_test.testDllFileName, out outMessage) == false)
            {
                MessageBox.Show("Failed to start test : " + m_test.testName);
                return false;
            }
            m_testExecuter.SetNotifier(this);
            return true;
        }

        public bool GetData(out ATETest test, out string outMessage)
        {

            test = new ATETest();
            if (txtTestName.Text == string.Empty)
            {
                outMessage = "Test name is empty";
                return false;
            }
            test.testEnabled = chkEnable.GetChecked();

            test.testClassName = m_test.testClassName;
            test.testDllFileName = m_test.testDllFileName;
            test.testDllFileIsRelative = m_test.testDllFileIsRelative;
            test.testVisible = m_test.testVisible;
            test.extendedForm = m_test.extendedForm;
            test.GroupName = m_test.GroupName;

            if (string.IsNullOrEmpty(test.testClassName) == true)
            {
                outMessage = "Class name is empty";
                return false;
            }

            if (string.IsNullOrEmpty(test.testDllFileName) == true)
            {
                outMessage = "test Dll File Name name is empty";
                return false;
            }

            if (txtTestName.Text == string.Empty)
            {
                outMessage = "Test name cannot be empty:" + (m_testId + 1);
                return false;
            }
  
            test.testDescription = txtDescription.Text;
            test.testName = txtTestName.Text;

            outMessage = "Ok";
            return true;
        }

        public void NotifyTestMessage(string msg)
        {
            INVOKERS.InvokeControlText(txtDescription, msg);
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

        private void ATETestControl_Load(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (StopTest(out string outMessage) == false)
            {
                MessageBox.Show(outMessage);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (InitExeciter(out string outMessage) == false)
            {
                return;
            }
            m_testExecuter.ShowSettings(m_test);
        }

        public void NotifyTestPassFail(bool pass, string result)
        {
            INVOKERS.InvokeControlForeColor(txtPassFail, Color.White);
            INVOKERS.InvokeControlText(txtPassFail, pass == true ? "PASS" : "FAIL");
            INVOKERS.InvokeControlBackColor(txtPassFail, pass == true ? Color.LightGreen : Color.Red);
            INVOKERS.InvokeControlText(txtTestResult, result);
            INVOKERS.InvokeProgressMaximum(progressBar1);

            pIATETestControl.NotifyStopTest(m_test, m_testId, this);
        }

        private void chkEnable_Click(object sender, EventArgs e)
        {
            chkEnable.Toggle((cb) =>
            {
                btnStart.Enable(cb);
                btnStop.Enable(cb);
                btnSettings.Enable(cb);
                m_test.testEnabled = cb;
                pIATETestControl.NotifyEnableTest(m_test, m_testId, this, cb);
            });

           
        }
        public void UpdateTestStatus(bool status, string msg)
        {
            INVOKERS.InvokeControlText(txtPassFail, status == true ? "PASS" : "FAIL");
            INVOKERS.InvokeControlBackColor(txtPassFail, status == true ? Color.LightGreen : Color.Red);
            INVOKERS.InvokeControlText(txtTestResult, msg);
        }

        public void NotifyProgress(int value)
        {
            INVOKERS.InvokeProgressValue(progressBar1, value);
        }
        public void EnableStartButton(bool enable)
        {

            if (btnStart.InvokeRequired)
            {
                btnStart.BeginInvoke((MethodInvoker)delegate ()
                {
                    btnStart.Enable(enable);
                });
            }
            else
            {
                btnStart.Enable(enable);
            }


           
        }
        public void EnableSettingsButton(bool enable)
        {
            if (btnStart.InvokeRequired)
            {
                btnSettings.BeginInvoke((MethodInvoker)delegate ()
                {
                    btnSettings.Enable(enable);
                });
            }
            else
            {
                btnSettings.Enable(enable);
            }
        }

        public void EnableStopButton(bool enable)
        {
            
            if (btnStop.InvokeRequired)
            {
                btnStop.BeginInvoke((MethodInvoker)delegate ()
                {
                    btnStop.Enable(enable);
                });
            }
            else
            {
                btnStop.Enable(enable);
            }

        }
        public void EnableCheckButton(bool enable)
        {
            if (chkEnable.InvokeRequired)
            {
                chkEnable.BeginInvoke((MethodInvoker)delegate ()
                {
                    chkEnable.Enable(enable);
                });
            }
            else
            {
                chkEnable.Enable(enable);
            }
        }
        public void SetProgressValue(int value)
        {
            INVOKERS.InvokeProgressValue(progressBar1, value);
        }
        public void ClearPassFail()
        {
            INVOKERS.InvokeControlText(txtPassFail, string.Empty);
            INVOKERS.InvokeControlBackColor(txtPassFail, Color.White);
        }
        public void ClearTestResult()
        {
            INVOKERS.InvokeControlText(txtTestResult, string.Empty);
            INVOKERS.InvokeControlBackColor(txtTestResult, Color.White);
        }

        private void btnExtended_Click(object sender, EventArgs e)
        {
            
        }

        public void ShowExtendedForm(bool show)
        {
            if (InitExeciter(out string outMessage) == false)
            {
                return;
            }
            bool ret = m_testExecuter.ShowExtendedForm(show);
        }
        public bool IsTestEnable()
        {
            return m_test.testEnabled;
        }
        public void EnabledChecked(bool c)
        {
            chkEnable.Checked(c);
        }
    }
}
