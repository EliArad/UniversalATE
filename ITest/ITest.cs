using ATEDBLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingLib
{
    public abstract class ITest
    {
        public interface ITestNotify
        {
            void NotifyTestMessage(string msg);
            void NotifyTestPassFail(bool pass, string result);
            void NotifyProgress(int value); 
            
        }
        protected AutoResetEvent m_sleep = new AutoResetEvent(false);
        protected bool m_running = false;
        protected Thread m_thread = null;
        protected bool m_abort = false;
        
        public abstract bool StartTest(ATETest test, bool sync);
        public abstract bool StopTest();
        public virtual bool IsRunning()
        {
            return m_running;
        }
        public abstract bool ShowSettings(ATETest test);
        public abstract bool ShowExtendedForm(bool show);
        protected abstract void TestProcess();
        protected ITestNotify m_iTestNotifier = null;
        public virtual void SetNotifier(ITestNotify t)
        {
            m_iTestNotifier = t;
        }

    }
}
