using ATEDBLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static TestingLib.ITest;

namespace TestingLib
{
    public class TestExecuter
    {

        MethodInfo methodShowSettings;
        MethodInfo methodStartTest;
        MethodInfo methodStopTest;
        MethodInfo methodNotifier;
        MethodInfo methodIsRunning;
        MethodInfo methodShowExtendedForm;

        object m_activator = null;
        bool m_initialize = false;
        public TestExecuter()
        {

            
        }
        public void Dispose()
        {
            m_initialize = false;
        }

        public bool Initialize(string className, 
                               string fullPathDllFile, 
                               out string outMessage)
        {
            try
            {
                if (m_initialize == true)
                {
                    outMessage = "Already initialized";
                    return true;
                }
                var assembly = Assembly.LoadFile(fullPathDllFile);
                string functionType = $"TestingLib.{className}";
                var type = assembly.GetType(functionType);
                if (type == null)
                {
                    outMessage = "Failed to find class {clsasName} in namespace TestingLib file:" + fullPathDllFile;
                    return false;
                }
                m_activator = Activator.CreateInstance(type);

                methodShowSettings = type.GetMethod("ShowSettings");
                methodStartTest = type.GetMethod("StartTest");
                methodStopTest = type.GetMethod("StopTest");
                methodNotifier = type.GetMethod("SetNotifier");
                methodIsRunning = type.GetMethod("IsRunning");
                methodShowExtendedForm = type.GetMethod("ShowExtendedForm");
                outMessage = "Ok";
                m_initialize = true;
                return true;
            }
            catch (Exception err)
            {
                outMessage = err.Message;
                return false;
            }
        }

        public bool IsInitialize
        {
            get 
            {
                return m_initialize;
            }
        }

        public bool SetNotifier(ITestNotify notifer)
        {
            if (m_initialize == false)
            {
                return false;
            }
            object result = methodNotifier.Invoke(m_activator, new object[] { notifer });

            return true;
        }
        public bool StartTestAsync(ATETest test)
        {
            if (m_initialize == false)
            {
                return false;
            }
            object result = methodStartTest.Invoke(m_activator, new object[] { test, false });

            return (bool)result;
        }

        public bool StartTestSync(ATETest test)
        {
            if (m_initialize == false)
            {
                return false;
            }
            object result = methodStartTest.Invoke(m_activator, new object[] { test, true });

            return (bool)result;
        }
        public bool StopTest()
        {
            if (m_initialize == false)
            {
                return false;
            }
            object result = methodStopTest.Invoke(m_activator, new object[] { });
            return (bool)result;
        }
        public bool ShowSettings(ATETest test)
        {
            if (m_initialize == false)
            {
                return false;
            }
            object result = methodShowSettings.Invoke(m_activator, new object[] { test });
            return (bool)result;
        }

        public bool IsRunning()
        {
            if (m_initialize == false)
            {
                return false;
            }
            object result = methodIsRunning.Invoke(m_activator, new object[] { });

            return (bool)result;
        }
        public bool ShowExtendedForm(bool show)
        {
            if (m_initialize == false)
            {
                return false;
            }
            object result = methodShowExtendedForm.Invoke(m_activator, new object[] { show });

            return (bool)result;
        }
    }
}
