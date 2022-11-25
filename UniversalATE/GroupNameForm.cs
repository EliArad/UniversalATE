using ATEDBLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ATEControls.TestGroupControl;

namespace UniversalATE
{
    public partial class GroupNameForm : Form
    {
        
        public GroupNameForm(ITestGroupControl p, List<string> group)
        {
            InitializeComponent();
            testGroupControl1.LoadControl(p, group);
        }
    }
}
