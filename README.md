# UniversalATE

UniversalATE is a c# application to run tests one by one , test that are not
linked with the ATE but reference and load dynamicly
so in order to create a full test ATE , create your DLL , dervied from ITest
and let the ATE knows about your DLL , test name , location

that you can start test , start all and so on

in next version i will add automatic execl generation and word ATP
generation.

the full image.resources  file will not be in this package, sorry about it
you can find a designer to create for you images and create  image.resources
file

image.resources are images that are bound togthther to one resources file

ResourceWriter myResource;
Bitmap bitmap = new Bitmap(fileName);
Console.WriteLine("Adding: " + fileName);
myResource.AddResource(name, bitmap);





to create new test dll , create a new seperate class library

and inherit from ITest

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
    

in the buider of the ATE tell where is the DLL its class name

namespace is constant to  TestingLib ( dont let user think so much adding
also namespace)


for more information easwdev   in 
gmail



