using ATECommon;
using ATEDBLib;
using GSkinLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ATEControls.ATETestControl;

namespace ATEControls
{
    public partial class ATETestGroupControl : UserControl
    {
        GenericSettings<ATEDB> m_gAteDB;
        readonly int m_b4height;
        public ATETestGroupControl()
        {
            InitializeComponent();

            btnCollapseShow.SetSkin(ResManager.R.GetBitmaps("btn140x40_5"), 0.6f, 0.5f);
            btnCollapseShow.ForeColor = Color.White;
            btnCollapseShow.Top -= 7;
            m_b4height = this.Height;
        }
        IATETestControl piATETestControl;
        string m_ateFileName;
        public void Setup(string groupName, IATETestControl itest, string ateFileName)
        {
            lblGroupName.Text = groupName;
            piATETestControl = itest;
            m_ateFileName = ateFileName;
        }
        ATEDB m_ateDB;
        private void btnCollapseShow_Click(object sender, EventArgs e)
        {
            if (btnCollapseShow.Text == "+")
            {
                flowLayoutPanel1.Visible = true;
                flowLayoutPanel1.Controls.Clear();
                this.Height = m_b4height;
                int i = 0;
                m_gAteDB = new ATECommon.GenericSettings<ATEDB>(m_ateFileName);
                if (m_gAteDB.Load(out m_ateDB, out string outMessage) == false)
                {
                    return;
                }

                foreach (KeyValuePair<int, ATETest> test in m_ateDB.m_allTests)
                {
                    //if ((search != string.Empty) && test.Value.testName.ToLower().Contains(search.ToLower()) == false)
                    //{
                    //    continue;
                    //}

                    if (test.Value.testVisible == false)
                    {
                        continue;
                    }
                    if (test.Value.GroupName != lblGroupName.Text)
                    {
                        continue;
                    }

                    ATETestControl control = AddTestontrol();
                    this.Height += control.Height;

                    control.Setup(test.Value, i++);
                    flowLayoutPanel1.Controls.Add(control);
                }
                btnCollapseShow.Text = "-";
            }
            else
            {
                flowLayoutPanel1.Visible = false;
                flowLayoutPanel1.Controls.Clear();
                this.Height = m_b4height;
                btnCollapseShow.Text = "+";
            }
        }

        public List<ATETestControl> GetAteControls()
        {
            List<ATETestControl> list = new List<ATETestControl>();
            foreach (ATETestControl c in flowLayoutPanel1.Controls)
            {
                list.Add(c);
            }
            return list;
        }
        ATETestControl AddTestontrol()
        {

            ATETestControl t = new ATETestControl(piATETestControl);
            flowLayoutPanel1.Controls.Add(t);
            return t;
        }
        public bool DoWeHaveEnabledTestThere()
        {
            bool b = false;
            foreach (ATETestControl c in flowLayoutPanel1.Controls)
            {
                b = b | c.IsTestEnable();
            }
            return b;
        }
        public bool StopTests()
        {
            foreach (ATETestControl c in flowLayoutPanel1.Controls)
            {
                while (c.StopTest(out string outMessage) == false)
                {
                    Thread.Sleep(100);
                }
            }

            return true;
        }
        public void ClearBeforeAllStart()
        {
            foreach (ATETestControl c in flowLayoutPanel1.Controls)
            {
                c.ClearPassFail();
                c.ClearTestResult();
                c.SetProgressValue(0);
            }
        }
        public bool StartTests()
        {
            bool b = false;
            
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
            return b;
        }
        public void EnableSettingsButton(bool enable)
        {
            foreach (ATETestControl c in flowLayoutPanel1.Controls)
            {
                if (c.IsTestEnable() == true && enable == true)
                {
                    c.EnableSettingsButton(enable);
                }
            }
        }
        public void EnableTestButtons(bool enable)
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
    }
}
