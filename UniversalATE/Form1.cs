using ATECommon;
using ATEControls;
using ATEDBLib;
using GSkinLib;
using InvokersLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ATEControls.ATETestBuildControl;
using static ATEControls.ATETestControl;
using static ATEControls.TestGroupControl;

namespace UniversalATE
{
    public partial class Form1 : Form, IATETestBuildControl, IATETestControl, ITestGroupControl
    {

        ATEDB m_ateDB;
        string m_ateFileName = "UniversalATETestXXX.json";
        ATETestControl m_currentRunningTestControl = null;
        const string m_title = "Universal ATE";
        public static string BaseFolder;

        GenericSettings<ATEDB> m_gAteDB;
        enum VIEW
        {
            BUILD_VIEW,
            TEST_VIEW,
            GROUP_TEST_VIEW
        }
        VIEW m_view = VIEW.TEST_VIEW;

        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            AppSettings.Instance.Load("UniversalATE.json", out string outMessage);


            BaseFolder = Directory.GetCurrentDirectory();

            if (string.IsNullOrEmpty(AppSettings.Instance.Config.LastATEFileName) == false &&
                File.Exists(AppSettings.Instance.Config.LastATEFileName) == true)
            {
                m_ateFileName = AppSettings.Instance.Config.LastATEFileName;
            }

            m_gAteDB = new ATECommon.GenericSettings<ATEDB>(m_ateFileName);
            if (m_gAteDB.Load(out m_ateDB, out outMessage) == false)
            {
                DefaultTests();
            }

            if (ResManager.Load("image.resources") == true)
            {
                LoadSkins();
            }

            LoadControls(m_ateDB.m_allTests, null);

            ShowViewState();
            
            btnStartAll.SetSkin(ResManager.R.GetBitmaps("btn140x40_21"), 0.9f, 0.9f);
            btnStartAll.ForeColor = Color.White;
            btnStartAll.Top -= 12;
            btnStartAll.Left -= 13;
            showExtendedFormToolStripMenuItem.Visible = false;
            clearAllToolStripMenuItem.Visible = false;
            
            if (m_view == VIEW.TEST_VIEW)
            {
                bool b = false;
                foreach (ATETestControl c in flowLayoutPanel1.Controls)
                {
                    b = b | c.IsTestEnable();
                }
                btnStartAll.Enable(b);
            }
        }
        void LoadSkins()
        {
            btnSelectGroup.SetSkin(ResManager.R.GetBitmaps("btn140x40_4"), 0.8f, 0.8f);
            btnSelectGroup.ForeColor = Color.White;
            btnSelectGroup.Top -= 14;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                if (m_view == VIEW.BUILD_VIEW)
                {
                    SaveTestBuilder();
                }
                else if (m_view == VIEW.TEST_VIEW)
                {
                    SaveTests();
                }
            }
            

            if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
            {
                if (m_view == VIEW.BUILD_VIEW)
                {
                    AddTestBuildControl();

                    int id = 0;
                    foreach (ATETestBuildControl c in flowLayoutPanel1.Controls)
                    {
                        c.Id = id;
                        id++;
                        c.Setup(m_ateDB.Groups);
                    }
                }                 
            }            
        }

        bool ShowViewState()
        {
            if (m_view == VIEW.BUILD_VIEW)
            {
                if (Debugger.IsAttached == false)
                {
                    PasswordForm passform = new PasswordForm();
                    if (passform.ShowDialog() == DialogResult.Cancel)
                        return false;
                    if (passform.UserName != "Admin" || passform.Password != "12456")
                        return false;
                }

                
                this.Text = m_title + " - " + "Build View";
                addNewTestToolStripMenuItem.Visible = true;
                testsToolStripMenuItem.Visible = false;
                btnStartAll.Visible = false;
                allVisble2ToolStripMenuItem.Visible = true;
                clearAllToolStripMenuItem.Visible = true;
            }
            else if (m_view == VIEW.TEST_VIEW)
            {
             
                this.Text = m_title + " - " + "Test View";
                addNewTestToolStripMenuItem.Visible = false;
                testsToolStripMenuItem.Visible = true;
                btnStartAll.Visible = true;
                allVisble2ToolStripMenuItem.Visible = false;
                clearAllToolStripMenuItem.Visible = false;
            }
            return true;
        }
        void LoadControls(SortedDictionary<int, ATETest> tests, List<string> groups, string search = "")
        {
            flowLayoutPanel1.Controls.Clear();
            int width = 0;
            if (m_ateDB.m_allTests != null)
            {
                int i = 0;
                if (m_view == VIEW.BUILD_VIEW)
                {
                    foreach (KeyValuePair<int, ATETest> test in tests)
                    {
                        if ((search != string.Empty) && test.Value.testName.ToLower().Contains(search.ToLower()) == false)
                            continue;
                        if (groups != null)
                        {
                            if (groups.Contains(test.Value.GroupName) == false)
                                continue;
                        }
                        ATETestBuildControl control = AddTestBuildControl();
                        control.Setup(m_ateDB.Groups, test.Value,i++);
                        width = control.Width + 15;
                    }
                }
                else if (m_view == VIEW.TEST_VIEW)
                {
                    foreach (KeyValuePair<int, ATETest> test in m_ateDB.m_allTests)
                    {
                        if ((search != string.Empty) && test.Value.testName.ToLower().Contains(search.ToLower()) == false)
                        {
                            continue;
                        }

                        if (test.Value.testVisible == false)
                        {
                            continue;
                        }
                        if (groups != null)
                        {
                            if (groups.Contains(test.Value.GroupName) == false)
                                continue;
                        }
                        ATETestControl control = AddTestontrol();
                        width = control.Width;
                        control.Setup(test.Value, i++);
                    }
                }
                if (width > 0)
                {
                    this.Width = width + 25;
                }
            }
        }
         
        ATETestControl AddTestontrol()
        {
            
            ATETestControl t = new ATETestControl(this);
            flowLayoutPanel1.Controls.Add(t);
            return t;
        }

        ATETestBuildControl AddTestBuildControl()
        {
            ATETestBuildControl t = new ATETestBuildControl(BaseFolder, this);
            flowLayoutPanel1.Controls.Add(t);
            return t;
        }
        void DefaultTests()
        {
            m_ateDB = new ATEDB();
            m_ateDB.AteVersion = "1.0.0";
            m_ateDB.m_allTests = new SortedDictionary<int,ATETest>();
            ATETest t = new ATETest
            {
                testDescription = "Test 1",
                testDllFileName = "PLCTest.dll",
                testEnabled = true,
                testName = "PLC Test",
                testVisible = true
            };
            m_ateDB.m_allTests.Add(0 , t);


            t = new ATETest
            {
                testDescription = "Test 2",
                testDllFileName = "PLCTest2.dll",
                testEnabled = true,
                testName = "Oven Test",
                testVisible = true
            };
            m_ateDB.m_allTests.Add(1, t);

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GuiCommon.GetFile("Select ATE Project" , out string fileName) == true)
            {

            }
        }

        private void buildViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            
            m_view = VIEW.BUILD_VIEW;
            btnSelectGroup.Visible = false;
            if (ShowViewState() == false)
            {
                m_view = VIEW.TEST_VIEW;
                return;
            }

            LoadControls(m_ateDB.m_allTests, null);
            AppSettings.Instance.Save();

           
        }

        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string outMessage = string.Empty;
            if (m_view == VIEW.BUILD_VIEW)
            {
                SaveTestBuilder();
            }
            else if (m_view == VIEW.TEST_VIEW)
            {
                SaveTests();
            }
            else if(m_view == VIEW.GROUP_TEST_VIEW)
            {
                m_ateDB.m_allTests.Clear();
                foreach (ATETestGroupControl c in flowLayoutPanel1.Controls)
                {
                    List<ATETestControl> ateControls = c.GetAteControls();
                    SaveTests(ateControls);
                }
                if (m_gAteDB.Save(m_ateDB, out outMessage) == false)
                {
                    MessageBox.Show("Failed to save " + outMessage);
                }
                else
                {
                    this.Text = m_title + " - Saved";
                    await Task.Delay(500);
                    ShowViewState();
                }

            }
        }
        async void SaveTests()
        {
            m_ateDB.m_allTests.Clear();
            string outMessage;
            foreach (ATETestControl c in flowLayoutPanel1.Controls)
            {
                if (c.GetData(out ATETest test, out outMessage) == false)
                {
                    Color bc = c.BackColor;
                    c.BackColor = Color.Red;
                    MessageBox.Show("Failed to get data from test: " + (c.Id + 1) + Environment.NewLine + outMessage);
                    c.BackColor = bc;
                    return;
                }
            }
            int i = 0;
            foreach (ATETestControl c in flowLayoutPanel1.Controls)
            {
                if (c.GetData(out ATETest test, out outMessage) == false)
                {
                    return;
                }
                m_ateDB.m_allTests.Add(i++, test);
            }

            
            if (m_gAteDB.Save(m_ateDB, out outMessage) == false)
            {
                MessageBox.Show("Failed to save " + outMessage);
            }
            else
            {
                this.Text = m_title + " - Saved";
                await Task.Delay(500);
                ShowViewState();

            }
        }

        async void SaveTests(List<ATETestControl> ateControls)
        {
           
            string outMessage;
            foreach (ATETestControl c in ateControls)
            {
                if (c.GetData(out ATETest test, out outMessage) == false)
                {
                    Color bc = c.BackColor;
                    c.BackColor = Color.Red;
                    MessageBox.Show("Failed to get data from test: " + (c.Id + 1) + Environment.NewLine + outMessage);
                    c.BackColor = bc;
                    return;
                }
            }
            int i = 0;
            foreach (ATETestControl c in ateControls)
            {
                if (c.GetData(out ATETest test, out outMessage) == false)
                {
                    return;
                }
                m_ateDB.m_allTests.Add(i++, test);
            }

                      
        }
        async void SaveTestBuilder()
        {
            m_ateDB.m_allTests.Clear();
            string outMessage;
            int i = 0;
            foreach (ATETestBuildControl c in flowLayoutPanel1.Controls)
            {
                if (c.GetData(out ATETest test, out outMessage) == false)
                {
                    Color bc = c.BackColor;
                    c.BackColor = Color.Red;
                    MessageBox.Show("Failed to get data from test: " + (c.Id + 1) + Environment.NewLine + outMessage);
                    c.BackColor = bc;
                    return;
                }
            }

            i = 0;
            foreach (ATETestBuildControl c in flowLayoutPanel1.Controls)
            {
                if (c.GetData(out ATETest test, out outMessage) == false)
                {
                    return;
                }
                m_ateDB.m_allTests.Add(i++, test);
            }
            

            if (m_gAteDB.Save(m_ateDB, out outMessage) == false)
            {
                MessageBox.Show("Failed to save " + outMessage);
            }
            else
            {
                this.Text = m_title + " - Saved";
                await Task.Delay(500);
                ShowViewState();

            }
        }

        public void NotifyRemoveTest(ATETest test, int testId, ATETestBuildControl control)
        {
            flowLayoutPanel1.Controls.Remove(control);
            if (string.IsNullOrEmpty(test.testName) == false)
            {
                m_ateDB.m_allTests.Remove(testId);
            }
            int id = 0;
            foreach (ATETestBuildControl c in flowLayoutPanel1.Controls)
            {
                c.Id = id;
                id++;
            }
            SortedDictionary<int, ATETest> sd = new SortedDictionary<int, ATETest>();
            id = 0;
            foreach (KeyValuePair<int , ATETest> t in m_ateDB.m_allTests)
            {
                sd.Add(id++, t.Value);    
            }
            m_ateDB.m_allTests.Clear();
            m_ateDB.m_allTests = sd;
        }

        private void addNewTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_view == VIEW.BUILD_VIEW)
            {
                ATETestBuildControl control = AddTestBuildControl();

                int id = 0;
                foreach (ATETestBuildControl c in flowLayoutPanel1.Controls)
                {
                    c.Id = id;
                    id++;
                    c.Setup(m_ateDB.Groups);
                }
            }
            
        }

        public void NotifyStartTest(ATETest test, int testId, ATETestControl control)
        {
            showExtendedFormToolStripMenuItem.Visible = true;
            m_currentRunningTestControl = control;
        }

        public void NotifyStopTest(ATETest test, int testId, ATETestControl control)
        {
            m_currentRunningTestControl = null;

            if (this.InvokeRequired == true)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    showExtendedFormToolStripMenuItem.Visible = false;
                });
            }
            else
            {
                showExtendedFormToolStripMenuItem.Visible = false;
            }
        }

        public void NotifyOpenSetting(ATETest test, int testId, ATETestControl control)
        {
            
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_view == VIEW.BUILD_VIEW)
            {
                DialogResult d = MessageBox.Show("Are you sure you want to clear all tests?", "Universal ATE", MessageBoxButtons.YesNo);
                if (d == DialogResult.No)
                    return;

                this.flowLayoutPanel1.Controls.Clear();
                m_ateDB.m_allTests.Clear();
                SaveTests();
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_view == VIEW.TEST_VIEW)
            {
                foreach (ATETestControl t in flowLayoutPanel1.Controls)
                {
                    t.StopTest(out string outMessage);
                }
            }
            

            AppSettings.Instance.Save();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            if (txtSearch.Text == string.Empty)
            {
                LoadControls(m_ateDB.m_allTests, null);
            }            
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                 
                if (txtSearch.Text != string.Empty)
                {
                    foreach (KeyValuePair<int, ATETest> t in m_ateDB.m_allTests)
                    {
                        LoadControls(m_ateDB.m_allTests, null , txtSearch.Text);
                    }

                }
                else
                {
                    LoadControls(m_ateDB.m_allTests, null);
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        void EnableTestButtons(bool enable)
        {
            foreach (ATETestControl c in flowLayoutPanel1.Controls)
            {
                if (enable == true)
                {
                    if (c.IsTestEnable() == true)
                    {
                        c.EnableStartButton(enable);
                        c.EnableStopButton(enable);
                    }                                    
                }
                else
                {
                    c.EnableStartButton(enable);
                    c.EnableStopButton(enable);
                }
            }
        }
        void EnableSettingsButton(bool enable)
        {
            foreach (ATETestControl c in flowLayoutPanel1.Controls)
            {
                if (c.IsTestEnable() == true && enable == true)
                {
                    c.EnableSettingsButton(enable);
                }
            }
        }

        void SetAllProgressValue(int value)
        {
            foreach (ATETestControl c in flowLayoutPanel1.Controls)
            {
                c.SetProgressValue(value);
            }
        }

        void ClearAllPassFail()
        {
            foreach (ATETestControl c in flowLayoutPanel1.Controls)
            {
                c.ClearPassFail();
            }
        }

        private void startAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartAllTests();
        }

        void ClearBeforeAllStart(bool start)
        {
            foreach (ATETestControl c in flowLayoutPanel1.Controls)
            {
                c.ClearPassFail();
                c.ClearTestResult();
                c.SetProgressValue(0);
            }
             
        }
        bool m_allRunningTests = false;
        async void StartAllTests()
        {
            
            if (m_view == VIEW.TEST_VIEW)
            {
                if (m_allRunningTests == false)
                {
                    ClearBeforeAllStart(true);
                    btnStartAll.Text = "Stop All";
                    await Task.Run(() =>
                    {
                        m_allRunningTests = true;
                        foreach (ATETestControl c in flowLayoutPanel1.Controls)
                        {
                            if (c.IsTestEnable() == true)
                            {
                                c.EnableStartButton(true);
                                c.EnableStopButton(true);
                                c.EnableSettingsButton(true);

                                if (c.StartTest(false, out string outMessage) == false)
                                {
                                    c.UpdateTestStatus(false, outMessage);
                                }
                            }
                        }
                    });
                    EnableTestButtons(true);
                    EnableSettingsButton(true);
                    m_allRunningTests = false;
                    INVOKERS.InvokeControlText(btnStartAll, "Start Tests");
                }
                else
                {
                    ClearBeforeAllStart(true);
                    btnStartAll.Text = "Stop All";
                    await Task.Run(() =>
                    {
                        m_allRunningTests = true;
                        StopAllTests();
                    });
                    EnableTestButtons(true);
                    EnableSettingsButton(true);
                    m_allRunningTests = false;
                    INVOKERS.InvokeControlText(btnStartAll, "Start Tests");
                }
            }
            else
            {
                if (m_allRunningTests == false)
                {                    
                    foreach (ATETestGroupControl c in flowLayoutPanel1.Controls)
                    {
                        c.ClearBeforeAllStart();
                    }
                    btnStartAll.Text = "Stop All";
                    await Task.Run(() =>
                    {
                        foreach (ATETestGroupControl c in flowLayoutPanel1.Controls)
                        {
                            c.StartTests();
                        }
                    });
                    foreach (ATETestGroupControl c in flowLayoutPanel1.Controls)
                    {
                        c.EnableTestButtons(true);
                        c.EnableSettingsButton(true);
                    }
                   
                    m_allRunningTests = false;
                    INVOKERS.InvokeControlText(btnStartAll, "Start Tests");
                }
                else
                {
                    await Task.Run(() =>
                    {
                        foreach (ATETestGroupControl c in flowLayoutPanel1.Controls)
                        {
                            c.StopTests();
                        }
                    });
                    EnableTestButtons(true);
                    EnableSettingsButton(true);
                    m_allRunningTests = false;
                    INVOKERS.InvokeControlText(btnStartAll, "Start Tests");
                }
            }
        }
        void StopAllTests()
        {
            foreach (ATETestControl c in flowLayoutPanel1.Controls)
            {
                while (c.StopTest(out string outMessage) == false)
                {
                    Thread.Sleep(100);
                }
            }
            EnableTestButtons(true);
            EnableSettingsButton(true);
            m_allRunningTests = false;
            INVOKERS.InvokeControlText(btnStartAll, "Start Tests");
        }
        private void btnStartAll_Click(object sender, EventArgs e)
        {
            StartAllTests();
        }

        private void stopAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopAllTests();
        }

        public void NotifyShowForm(Form control, int x = -1, int y = -1)
        {
             
        }

        private void showExtendedFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_currentRunningTestControl != null)
            {
                m_currentRunningTestControl.ShowExtendedForm(true);
            }
        }

        private void AllEnableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_view == VIEW.BUILD_VIEW)
            {
                foreach (ATETestBuildControl c in flowLayoutPanel1.Controls)
                {
                    c.EnabledChecked(true);
                }
            }
            else if (m_view == VIEW.TEST_VIEW)
            {
                foreach (ATETestControl c in flowLayoutPanel1.Controls)
                {
                    c.EnabledChecked(true);
                }

            }
        }

        private void allDisableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_view == VIEW.BUILD_VIEW)
            {
                foreach (ATETestBuildControl c in flowLayoutPanel1.Controls)
                {
                    c.EnabledChecked(false);
                }
            }
        }

        private void allVisibleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (m_view == VIEW.BUILD_VIEW)
            {
                foreach (ATETestBuildControl c in flowLayoutPanel1.Controls)
                {
                    c.CheckedVisible(true);
                }
            }
        }

        private void allUnVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_view == VIEW.BUILD_VIEW)
            {
                foreach (ATETestBuildControl c in flowLayoutPanel1.Controls)
                {
                    c.CheckedVisible(false);
                }
            }
        }

        public void NotifyEnableTest(ATETest test, int testId, ATETestControl control, bool enable)
        {
            if (m_view == VIEW.TEST_VIEW)
            {
                bool b = false;
                foreach (ATETestControl c in flowLayoutPanel1.Controls)
                {
                    b = b | c.IsTestEnable();
                }
                btnStartAll.Enable(b);                               
            }
            else if (m_view == VIEW.GROUP_TEST_VIEW)
            {
                bool b = false;
                foreach (ATETestGroupControl c in flowLayoutPanel1.Controls)
                {
                    b = b | c.DoWeHaveEnabledTestThere();
                }
                btnStartAll.Enable(b);
            }
        }

        private void addTestGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupNameForm f = new GroupNameForm(this, m_ateDB.Groups);
            f.ShowDialog();
        }

        public void NotifyGroupList(List<string> list)
        {
            m_ateDB.Groups = list;
            m_gAteDB.Save(m_ateDB, out string outMessage);

        }

        List<string> m_currentShowList = new List<string>();
        private void btnSelectGroup_Click(object sender, EventArgs e)
        {
            SelectGroupForm s = new SelectGroupForm(m_ateDB.Groups, m_currentShowList);
            if (s.ShowDialog() == DialogResult.OK)
            {
                m_currentShowList = s.GetList();
                LoadControls(m_ateDB.m_allTests, m_currentShowList, txtSearch.Text);  
            }
        }

        private void testViewGroupingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            btnStartAll.Visible = true;
            if (m_view == VIEW.BUILD_VIEW)
            {
                m_view = VIEW.TEST_VIEW;                
            }

            if (m_view == VIEW.TEST_VIEW)
            {
                btnSelectGroup.Visible = false;
                m_view = VIEW.GROUP_TEST_VIEW;
            }
            else
            {
                m_view = VIEW.TEST_VIEW;
                btnSelectGroup.Visible = true;
            }
            if (m_view == VIEW.GROUP_TEST_VIEW)
            {
                buildViewGroupingToolStripMenuItem.Text = "Test View";

                foreach (var t in m_ateDB.m_allTests)
                {
                    if (t.Value.GroupName == "Root")
                    {
                        ATETestGroupControl control = new ATETestGroupControl();
                        control.Setup(t.Value.GroupName, this, m_ateFileName);
                        flowLayoutPanel1.Controls.Add(control);
                        control.Width = this.Width - 15;
                    }
                }

                if (m_ateDB.Groups != null)
                {
                    foreach (string group in m_ateDB.Groups)
                    {
                        int count = 0;
                        foreach (var t in m_ateDB.m_allTests)
                        {
                            if (t.Value.GroupName == group)
                            {
                                count++;
                            }
                        }
                        if (count == 0)
                            continue;

                        ATETestGroupControl control = new ATETestGroupControl();
                        control.Setup(group, this, m_ateFileName);
                        flowLayoutPanel1.Controls.Add(control);
                        control.Width = this.Width - 15;
                    }
                }
            }
            if (m_view == VIEW.TEST_VIEW)
            {
                LoadControls(m_ateDB.m_allTests, null);
                buildViewGroupingToolStripMenuItem.Text = "Test View - Grouping";
            }

            if (m_view == VIEW.TEST_VIEW)
            {
                bool b = false;
                foreach (ATETestControl c in flowLayoutPanel1.Controls)
                {
                    b = b | c.IsTestEnable();
                }
                btnStartAll.Enable(b);
            }
        }
    }
}
 