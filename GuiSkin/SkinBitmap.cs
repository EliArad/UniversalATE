using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GSkinLib.Common;

namespace GSkinLib
{
    public class SkinBitmap : ButtonEx
    {
        
        Bitmap bmp;

        public static string BaseDir;
        
        public void SetSkin(Bitmap bitmap)
        {
            bmp  = bitmap;
            
            GuiBackground.CreateControlRegion(this, bmp, GuiBackground.WITH_AS.IMAGE);

        }
        public void SetSkin(string name)
        {
            if (File.Exists(name))
            {
                bmp = new Bitmap(name);
            }
            else
            {
                throw (new SystemException("File: " + name + " does not exists"));
            }

            GuiBackground.CreateControlRegion(this, bmp, GuiBackground.WITH_AS.IMAGE);
        }         
    }
}
