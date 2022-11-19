using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATEControls
{
    public class GuiCommon
    {

        public static bool GetFile(string title,  out string fileName, string Filter = "")
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = title;
            if (Filter == string.Empty)
            {
                fdlg.Filter = "Json file (*.json)|*.json|All files (*.*)|*.*";
            }
            else
            {
                fdlg.Filter = Filter;
            }
            
            fdlg.FilterIndex = 0;
            fdlg.RestoreDirectory = true;
             
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                fileName = fdlg.FileName;
                return true;
            }
            fileName = string.Empty;
            return false;
        }
    }
}
