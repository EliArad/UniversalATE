using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSkinLib
{
    public class SkinSwitch : Button
    {
      
        private Bitmap[,] bmp = new Bitmap[2,4];
        bool m_isEnter = false;
        bool m_checked = false;
        bool m_checkedState = false;
        bool m_enable = true;
        bool m_disableExists = false;
        public SkinSwitch()
        {
        
        }

        public void SetSkin(string dir, string onButtonName, string offButtonName)
        {
            string[] names = { onButtonName, offButtonName };
            for (int i = 0; i < 2; i++)
            {
                if (File.Exists(dir + names[i] + "_normal.png") == true)
                    bmp[i,0] = new Bitmap(dir + names[i] + "_normal.png");
                else
                    throw (new SystemException("File: " + dir + names[i] + "_normal.png" + " does not exists"));

                if (File.Exists(dir + names[i] + "_enter.png") == true)
                    bmp[i, 1] = new Bitmap(dir + names[i] + "_enter.png");
                else
                    throw (new SystemException("File: " + dir + names[i] + "_enter.png" + " does not exists"));

                if (File.Exists(dir + names[i] + "_press.png") == true)
                    bmp[i, 2] = new Bitmap(dir + names[i] + "_press.png");
                else
                    throw (new SystemException("File: " + dir + onButtonName + "_press.png" + " does not exists"));

                if (File.Exists(dir + names[i] + "_disable.png") == true)
                {
                    bmp[i, 3] = new Bitmap(dir + names[i] + "_disable.png");
                    m_disableExists = true;
                }
                else
                {
                    m_disableExists = false;
                }
                    
            }

            this.MouseEnter += SkinCheckBox_MouseEnter;
            this.MouseLeave += SkinCheckBox_MouseLeave;

            GuiBackground.CreateControlRegion(this, bmp[0,0], GuiBackground.WITH_AS.IMAGE);
        }


        public void UpdateSkin(int state, string dir, int index, string buttonName)
        {
            if (state == 1)
            {
                bmp[index, 2] = new Bitmap(dir +  buttonName + ".png");
            }
        }
        private void SkinCheckBox_MouseLeave(object sender, EventArgs e)
        {
            onEnter = false;
        }

        public void Toggle(Action<bool> cb)
        {
            if (m_enable == false) return;

            m_checked = !m_checked;            
            Checked(m_checked);
            cb(m_checked);
        }

        public void Toggle()
        {
            if (m_enable == false) return;

            m_checked = !m_checked;
            Checked(m_checked);
        }

        private void SkinCheckBox_MouseEnter(object sender, EventArgs e)
        {
            onEnter = true;
        }

        public bool onEnter
        {
            set
            {
                if (m_enable == false) return;
                m_isEnter = value;
                int index = m_checked == false ? 0 : 1;
                if (m_isEnter == true)
                {
                    GuiBackground.CreateControlRegion(this, bmp[index, Common.ENTER], GuiBackground.WITH_AS.IMAGE);
                }
                if (m_isEnter == false)
                {
                    GuiBackground.CreateControlRegion(this, bmp[index, Common.DOWN], GuiBackground.WITH_AS.IMAGE);
                }
            }
        }
        public void Checked(bool c, Action<bool> cb)
        {
            m_checkedState = c;
           
            if (m_enable == false) return;
            m_checked = c;
            int index = m_checked == false ? 0 : 1;
            if (m_checked == true)
            {
                GuiBackground.CreateControlRegion(this, bmp[index, Common.DOWN], GuiBackground.WITH_AS.IMAGE);
            }
            else
            {
                if (m_isEnter == false)
                    GuiBackground.CreateControlRegion(this, bmp[index, Common.UP], GuiBackground.WITH_AS.IMAGE);
                else
                    GuiBackground.CreateControlRegion(this, bmp[index, Common.ENTER], GuiBackground.WITH_AS.IMAGE);
            }
            cb(m_checked);
             
        }

        public bool GetChecked()
        {
            return m_checked;
        }
      
        public void Checked(bool c)
        {
            m_checkedState = c;
            if (m_enable == false) return;
            m_checked = c;
            int index = m_checked == false ? 0 : 1;
            if (c)
            {
                GuiBackground.CreateControlRegion(this, bmp[index, Common.DOWN], GuiBackground.WITH_AS.IMAGE);
            }
            else
            {
                if (m_isEnter == false)
                    GuiBackground.CreateControlRegion(this, bmp[index, Common.DOWN], GuiBackground.WITH_AS.IMAGE);
                else
                    GuiBackground.CreateControlRegion(this, bmp[index, Common.ENTER], GuiBackground.WITH_AS.IMAGE);
            }           
        }

        public void Toogle()
        {

            if (m_enable == false) return;
            m_checked = !m_checked;

            int index = m_checked == false ? 0 : 1;

            if (m_checked)
            {
                GuiBackground.CreateControlRegion(this, bmp[index, Common.DOWN], GuiBackground.WITH_AS.IMAGE);
            }
            else
            {
                if (m_isEnter == false)
                    GuiBackground.CreateControlRegion(this, bmp[index, Common.LEAVE], GuiBackground.WITH_AS.IMAGE);
                else
                    GuiBackground.CreateControlRegion(this, bmp[index, Common.ENTER], GuiBackground.WITH_AS.IMAGE);
            }
        }

        public void Toogle(Action<bool> cb)
        {

            if (m_enable == false) return;
            m_checked = !m_checked;
            int index = m_checked == false ? 0 : 1;
            if (m_checked)
            {
                GuiBackground.CreateControlRegion(this, bmp[index, Common.DOWN], GuiBackground.WITH_AS.IMAGE);
            }
            else
            {
                if (m_isEnter == false)
                    GuiBackground.CreateControlRegion(this, bmp[index, Common.LEAVE], GuiBackground.WITH_AS.IMAGE);
                else
                    GuiBackground.CreateControlRegion(this, bmp[index, Common.ENTER], GuiBackground.WITH_AS.IMAGE);
            }
            cb(m_checked);
        }

        public void Enable(bool b)
        {
            if (m_disableExists == false) return;
            m_enable = b;
            int index = m_checked == false ? 0 : 1;
            if (b == false)
            {
                GuiBackground.CreateControlRegion(this, bmp[index, Common.DISABLE], GuiBackground.WITH_AS.IMAGE);
            }
            else
            {
                if (m_checked == false && m_checkedState == true)
                    m_checked = m_checkedState;

                if (m_isEnter == false && m_checked == false)
                    GuiBackground.CreateControlRegion(this, bmp[index, Common.LEAVE], GuiBackground.WITH_AS.IMAGE);
                if (m_isEnter == true && m_checked == false)
                    GuiBackground.CreateControlRegion(this, bmp[index, Common.ENTER], GuiBackground.WITH_AS.IMAGE);
                if (m_checked == true)
                    GuiBackground.CreateControlRegion(this, bmp[index, Common.DOWN], GuiBackground.WITH_AS.IMAGE);
            }           
        }
    }
}
