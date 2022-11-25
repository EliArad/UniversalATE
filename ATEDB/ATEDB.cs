using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATEDBLib
{
    public struct ATETest
    {
        public string GroupName;
        public string testName;
        public string testClassName;
        public string testDescription;
        public bool testEnabled;
        public bool testVisible;
        public string testDllFileName;
        public bool testDllFileIsRelative;
        public bool extendedForm;
    }
    public struct ATEDB
    {
        public string AteVersion;
        public List<string> Groups;
        public SortedDictionary<int, ATETest> m_allTests;
    }
}
