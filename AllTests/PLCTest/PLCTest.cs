using ATEDBLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
 
 

namespace TestingLib
{
    public class PLCTest : ITest
    {
        PLCBox m_box = null;
        public override bool ShowExtendedForm(bool show)
        {
            if (m_box == null && show == true)
            {
                m_box = new PLCBox();
            }
            if (show == true)
            {
                m_box.Show();
            }
            else
            {
                m_box.Close();
            }
            return true;
        }

        public override bool ShowSettings(ATETest test)
        {
            Settings s = new Settings();
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                return true;
            }
            else
            {
                return false;
            }
        } 
        
        public override bool StartTest(ATETest test, bool sync)
        {
            if (m_iTestNotifier == null)
            {
                return false;
            }
            if ((m_running == true) || (m_thread != null && m_thread.IsAlive == true))
            {
                return false;
            }

            m_abort = false;
            if (sync == true)
            {
                TestProcess();
            }
            else
            {
                m_thread = new Thread(TestProcess);
                m_thread.Start();
            }
             
            return true;
        }
        
        public override bool StopTest()
        {

            m_abort = true;
            if (m_thread != null)
            {
                m_running = false;
                m_sleep.Set();
                m_thread.Join();
            }
            else
            {
                m_sleep.Set();
            }
            
            return !m_running;
        }

        protected override void TestProcess()
        {
            m_running = true;

            //while (m_running == true)
            {
                for (int i = 0; i < 7; i++)
                {
                    m_sleep.WaitOne(1010);
                    if (m_abort == true)
                    {
                        break;
                    }
                    m_iTestNotifier.NotifyTestMessage("Eli");
                    m_iTestNotifier.NotifyProgress(i + 1);
                }
            }
            m_iTestNotifier.NotifyTestPassFail(false, "demo");

            m_running = false;
        }
    }
}
