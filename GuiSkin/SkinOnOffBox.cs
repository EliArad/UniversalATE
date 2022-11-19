using InvokersLib;
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
    public class SkinOnOffBox : Button
    {
        object m_lock = new object();

        public static int PRESS_ON = 0;
        public static int PRESS_OFF = 1;
        public static int ENTER_ON = 2;
        public static int ENTER_OFF = 3;
        public static int DISABLE_ON = 4;
        public static int DISABLE_OFF = 5;

        private Bitmap[] bmp = new Bitmap[6];
        bool m_isEnter = false;
        bool m_checked = false;
        bool m_checkedState = false;
        bool m_enable = true;
        bool m_disableButtonExists = false;
        public static string BaseDir;
        IButton pButton = null;
        BUTTON_NAME m_btnName = BUTTON_NAME.NONAME;
        Color NormalColor;
        Color EnterColor;
        Color PressColor;
        public SkinOnOffBox()
        {
            UseVisualStyleBackColor = false;
        }

        public SkinOnOffBox(BUTTON_NAME btnName)
        {
            m_btnName = btnName;

            NormalColor = Color.FromArgb(40, 40, 40);
            EnterColor = Color.FromArgb(200, 200, 20);
            PressColor = Color.Red;
            UseVisualStyleBackColor = false;
        }

        public GuiBackground.WITH_AS ControlAs = GuiBackground.WITH_AS.IMAGE;
        public void SetSkin(Bitmap [] bitmaps, BUTTON_NAME buttonName , string name)
        {
            bmp[0] = bitmaps[0];
            bmp[1] = bitmaps[1];
            bmp[2] = bitmaps[2];
            bmp[3] = bitmaps[3];
            bmp[4] = bitmaps[4];
            bmp[5] = bitmaps[5];
            if (bmp[4] != null && bmp[5] != null)
            {
                m_disableButtonExists = true;
            }
            else
            {
                m_disableButtonExists = false;
            }
            this.Text = name;
            m_btnName = buttonName;

            GuiBackground.CreateControlRegion(this, bmp[0], ControlAs);
        }

        public void SetSkin(Bitmap[] bitmaps)
        {
            bmp[0] = bitmaps[0];
            bmp[1] = bitmaps[1];
            bmp[2] = bitmaps[2];
            bmp[3] = bitmaps[3];
            bmp[4] = bitmaps[4];
            bmp[5] = bitmaps[5];
            if (bmp[4] != null && bmp[5] != null)
            {
                m_disableButtonExists = true;
            }
            else
            {
                m_disableButtonExists = false;
            }            
            GuiBackground.CreateControlRegion(this, bmp[0], ControlAs);
            this.MouseEnter += SkinCheckBox_MouseEnter;
            this.MouseLeave += SkinCheckBox_MouseLeave;
            this.MouseDown += SkinCheckBoxButton_MouseDown;
            this.MouseUp += SkinCheckBoxButton_MouseUp;
        }


        public void SetSkin(Bitmap[] bitmaps, float wScale, float hScale,   BUTTON_NAME buttonName , IButton p, string name)
        {
            bmp[0] = bitmaps[0];
            bmp[1] = bitmaps[1];
            bmp[2] = bitmaps[2];
            bmp[3] = bitmaps[3];
            bmp[4] = bitmaps[4];
            bmp[5] = bitmaps[5];

            if (wScale < 1 || hScale <1)
            {
                for(int i=0; i<bmp.Length; i++)
                {
                    bmp[i] = new Bitmap(bmp[i], new Size((int)( bitmaps[i].Width * wScale), (int) (bitmaps[i].Height * hScale))) ;
                }
            }
             
            if (bmp[4] != null && bmp[5] != null)
            {
                m_disableButtonExists = true;
            }
            else
            {
                m_disableButtonExists = false;
            }
            this.Text = name;
            m_btnName = buttonName;
            SetCallback(p);

            GuiBackground.CreateControlRegion(this, bmp[0], ControlAs);
        }


        public void SetSkin(Bitmap[] bitmaps, float wScale, float hScale)
        {
            bmp[0] = bitmaps[0];
            bmp[1] = bitmaps[1];
            bmp[2] = bitmaps[2];
            bmp[3] = bitmaps[3];
            bmp[4] = bitmaps[4];
            bmp[5] = bitmaps[5];

            if (wScale < 1 || hScale < 1)
            {
                for (int i = 0; i < bmp.Length; i++)
                {
                    bmp[i] = new Bitmap(bmp[i], new Size((int)(bitmaps[i].Width * wScale), (int)(bitmaps[i].Height * hScale)));
                }
            }

             

            if (bmp[4] != null && bmp[5] != null)
            {
                m_disableButtonExists = true;
            }
            else
            {
                m_disableButtonExists = false;
            }
            this.MouseEnter += SkinCheckBox_MouseEnter;
            this.MouseLeave += SkinCheckBox_MouseLeave;
            this.MouseDown += SkinCheckBoxButton_MouseDown;
            this.MouseUp += SkinCheckBoxButton_MouseUp;

            GuiBackground.CreateControlRegion(this, bmp[0], ControlAs);
        }


        public void SetSkin(Bitmap[] bitmaps, float wScale, float hScale, IButton p, string name)
        {
            bmp[0] = bitmaps[0];
            bmp[1] = bitmaps[1];
            bmp[2] = bitmaps[2];
            bmp[3] = bitmaps[3];
            bmp[4] = bitmaps[4];
            bmp[5] = bitmaps[5];

            if (wScale < 1 || hScale < 1)
            {
                for (int i = 0; i < bmp.Length; i++)
                {
                    bmp[i] = new Bitmap(bmp[i], new Size((int)(bitmaps[i].Width * wScale), (int)(bitmaps[i].Height * hScale)));
                }
            }


            if (bmp[4] != null && bmp[5] != null)
            {
                m_disableButtonExists = true;
            }
            else
            {
                m_disableButtonExists = false;
            }
            this.Text = name;
            SetCallback(p);

            GuiBackground.CreateControlRegion(this, bmp[0], ControlAs);
        }

        public void SetSkin(Bitmap[] bitmaps, float wScale, float hScale, BUTTON_NAME buttonName, IButton p)
        {
            bmp[0] = bitmaps[0];
            bmp[1] = bitmaps[1];
            bmp[2] = bitmaps[2];
            bmp[3] = bitmaps[3];
            bmp[4] = bitmaps[4];
            bmp[5] = bitmaps[5];

            if (wScale < 1 || hScale < 1)
            {
                for (int i = 0; i < bmp.Length; i++)
                {
                    bmp[i] = new Bitmap(bmp[i], new Size((int)(bitmaps[i].Width * wScale), (int)(bitmaps[i].Height * hScale)));
                }
            }


            if (bmp[4] != null && bmp[5] != null)
            {
                m_disableButtonExists = true;
            }
            else
            {
                m_disableButtonExists = false;
            }
        
            m_btnName = buttonName;
            SetCallback(p);

            GuiBackground.CreateControlRegion(this, bmp[0], ControlAs);
        }

        public void SetSkin(Bitmap[] bitmaps, IButton p, string name)
        {
            bmp[0] = bitmaps[0];
            bmp[1] = bitmaps[1];
            bmp[2] = bitmaps[2];
            bmp[3] = bitmaps[3];
            bmp[4] = bitmaps[4];
            bmp[5] = bitmaps[5];

            if (bmp[4] != null && bmp[5] != null)
            {
                m_disableButtonExists = true;
            }
            else
            {
                m_disableButtonExists = false;
            }
            this.Text = name;
            SetCallback(p);

            GuiBackground.CreateControlRegion(this, bmp[0], ControlAs);
        }


        public void SetSkin(Bitmap[] bitmaps, float wScale, float hScale, string name)
        {
            bmp[0] = bitmaps[0];
            bmp[1] = bitmaps[1];
            bmp[2] = bitmaps[2];
            bmp[3] = bitmaps[3];

            if (wScale < 1 || hScale < 1)
            {
                for (int i = 0; i < bmp.Length; i++)
                {
                    bmp[i] = new Bitmap(bmp[i], new Size((int)(bitmaps[i].Width * wScale), (int)(bitmaps[i].Height * hScale)));
                }
            }

            if (bmp[4] != null && bmp[5] != null)
            {
                m_disableButtonExists = true;
            }
            else
            {
                m_disableButtonExists = false;
            }
            this.Text = name;

            GuiBackground.CreateControlRegion(this, bmp[0], ControlAs);


            this.MouseEnter += SkinCheckBox_MouseEnter;
            this.MouseLeave += SkinCheckBox_MouseLeave;
            this.MouseDown += SkinCheckBoxButton_MouseDown;
            this.MouseUp += SkinCheckBoxButton_MouseUp;
        }

          
        public void SetSkin(Bitmap[] bitmaps, string name)
        {
            bmp[0] = bitmaps[0];
            bmp[1] = bitmaps[1];
            bmp[2] = bitmaps[2];
            bmp[3] = bitmaps[3];
            bmp[4] = bitmaps[4];
            bmp[5] = bitmaps[5];

            if (bmp[4] != null && bmp[5] != null)
            {
                m_disableButtonExists = true;
            }
            else
            {
                m_disableButtonExists = false;
            }
            this.Text = name;
            GuiBackground.CreateControlRegion(this, bmp[0], ControlAs);
            SetCallback(null);
        }

        public void SetColor(Color color)
        {
            this.ForeColor = color;
        }
        public void SetSkin(Bitmap[] bitmaps, BUTTON_NAME buttonName, IButton p, string name)
        {
            SetSkin(bitmaps, buttonName, name);
            SetCallback(p);
        }


        private void SkinCheckBoxButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_enable == false)
                return;

            if (pButton != null)
            {
                if (e.Button == MouseButtons.Left)
                    pButton.NotifyDown(m_btnName);
            }

        }

        private void SkinCheckBoxButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_enable == false)
                return;

            if (pButton != null)
            {
                if (e.Button == MouseButtons.Left)
                    pButton.NotifyUp(m_btnName);
            }

        }
        public void UpdateText(string name)
        {
            InvokersLib.INVOKERS.InvokeControlText(this, name);
            //this.Text = name;
        }
        
        public void SetCallback(IButton p)
        {
            if (pButton == null)
            {
                pButton = p;
                this.MouseEnter += SkinCheckBox_MouseEnter;
                this.MouseLeave += SkinCheckBox_MouseLeave;
                this.MouseDown += SkinCheckBoxButton_MouseDown;
                this.MouseUp += SkinCheckBoxButton_MouseUp;
            }
        }
          
        public void UpdateSkin(int state, string dir, string buttonName)
        {
            if (state == 1)
            {
                bmp[2] = new Bitmap(dir +  buttonName + ".png");
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

        public bool Toggle()
        {
            if (m_enable == false) return false;

            m_checked = !m_checked;
            Checked(m_checked);
            return m_checked;
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
                if (m_isEnter == true)
                {
                    if (m_checked == false)
                    {
                        if (bmp[ENTER_OFF] != null)
                            GuiBackground.CreateControlRegion(this, bmp[ENTER_OFF], ControlAs);
                    }
                    else
                    {
                        if (bmp[ENTER_ON] != null)
                            GuiBackground.CreateControlRegion(this, bmp[ENTER_ON], ControlAs);
                    }
                    
                }
                if (m_isEnter == false)
                {
                    if (m_checked == false)
                    {
                        if (bmp[PRESS_OFF] != null)
                            GuiBackground.CreateControlRegion(this, bmp[PRESS_OFF], ControlAs);
                    }
                    else
                    {
                        if (bmp[PRESS_ON] != null)
                            GuiBackground.CreateControlRegion(this, bmp[PRESS_ON], ControlAs);
                    }                    
                }
            }
        }
        public void Checked(bool c, Action<bool> cb)
        {
            m_checkedState = c;
            if (m_enable == false) return;
            m_checked = c;
            if (m_checked == true)
            {
                GuiBackground.CreateControlRegion(this, bmp[PRESS_ON], ControlAs);
            }
            else
            {
                if (m_isEnter == false)
                {
                    if (bmp[PRESS_ON] != null)
                    {
                        GuiBackground.CreateControlRegion(this, bmp[PRESS_ON], ControlAs);
                    }
                    else
                    {
                        this.BackColor = EnterColor;
                    }
                }
                else
                {
                    if (bmp[ENTER_ON] != null)
                    {
                        GuiBackground.CreateControlRegion(this, bmp[ENTER_ON], ControlAs);
                    }
                    else
                    {
                        this.BackColor = EnterColor;
                    }
                }
            }
            if (cb != null)
                cb(m_checked);
             
        }

        public bool GetChecked()
        {
            return m_checked;
        }

        public void Checked(bool c, Color fontChecked, Color fontNormal)
        {
            //this.ForeColor = c == true ? fontChecked : fontNormal;
            INVOKERS.InvokeControlForeColor(this, c == true ? fontChecked : fontNormal);
            Checked(c);
        }


        public void Checked(bool c)
        {
            m_checkedState = c;
            if (m_enable == false) return;
            m_checked = c;
            if (c)
            {
                if (bmp[PRESS_ON] != null)
                {
                    if (this.InvokeRequired == false)
                    {
                        GuiBackground.CreateControlRegion(this, bmp[PRESS_ON], ControlAs);
                    }
                    else
                    {
                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            GuiBackground.CreateControlRegion(this, bmp[PRESS_ON], ControlAs);
                        });
                    }
                }

            }
            else
            {

                if (bmp[PRESS_OFF] != null)
                {
                    if (this.InvokeRequired == false)
                    {
                        GuiBackground.CreateControlRegion(this, bmp[PRESS_OFF], ControlAs);
                    }
                    else
                    {
                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            GuiBackground.CreateControlRegion(this, bmp[PRESS_OFF], ControlAs);
                        });
                    }
                }
            }
        }
        
        //public void Normal()
        //{
        //    if (m_enable == true)
        //    {
        //        if (bmp[NORMAL_ON] != null)
        //        {
                    
        //            if (this.InvokeRequired == false)
        //            {
        //                GuiBackground.CreateControlRegion(this, bmp[NORMAL_ON], ControlAs);
        //            }
        //            else
        //            {
        //                BeginInvoke((Action)delegate
        //                {
        //                    GuiBackground.CreateControlRegion(this, bmp[NORMAL_ON], ControlAs);
        //                });
        //            }
        //        }
        //        else
        //        {
        //            this.BackColor = NormalColor;
        //        }
        //    }
        //}

        public bool IsEnable()
        {
            return m_enable;
        }
        public void Enable(bool b)
        {
            if (m_disableButtonExists == false)
                return;
            m_enable = b;
            if (b == false)
            {
                if (m_checked == true)
                {
                    GuiBackground.CreateControlRegion(this, bmp[DISABLE_ON], ControlAs);
                }
                else
                {
                    GuiBackground.CreateControlRegion(this, bmp[DISABLE_OFF], ControlAs);
                }
            }
            else
            {
                if (m_checked == false && m_checkedState == true)
                    m_checked = m_checkedState;

                if (m_isEnter == false && m_checked == false)
                    GuiBackground.CreateControlRegion(this, bmp[PRESS_ON], ControlAs);
                if (m_isEnter == true && m_checked == false)
                    GuiBackground.CreateControlRegion(this, bmp[ENTER_ON], ControlAs);
                if (m_checked == true)
                    GuiBackground.CreateControlRegion(this, bmp[PRESS_ON], ControlAs);
            }           
        }
        private System.Windows.Forms.Label label;
        public Size m_LabelSizePixel = new Size(40, 20);
        public void AddLabel(Color color, int x, int y, string font, int fontSize, string text)
        {
            label = new Label();
            label.AutoSize = true;
            Font fnt = new Font("Arial", fontSize);
            label.Font = fnt;
            label.BackColor = System.Drawing.Color.Transparent;
            label.ForeColor = color;
            label.Location = new System.Drawing.Point(x, y);
            label.Name = "label1";
            label.Size = m_LabelSizePixel;// new System.Drawing.Size(35, 13);
            label.TabIndex = 10;
            label.Text = text;
            this.Controls.Add(label);
            label.BringToFront();
            //label.MouseDown += Label_MouseDown;
            //label.MouseEnter += Label_MouseEnter;
            //label.MouseLeave += Label_MouseLeave;
            //label.MouseUp += Label_MouseUp;
        }

        public void AddLabel(Color color, int x, int y, string text)
        {
            label = new Label();
            label.AutoSize = true;
            label.BackColor = System.Drawing.Color.Transparent;
            label.ForeColor = color;
            label.Location = new System.Drawing.Point(x, y);
            label.Name = "label1";
            label.Size = m_LabelSizePixel;// new System.Drawing.Size(35, 13);
            label.TabIndex = 10;
            label.Text = text;
            this.Controls.Add(label);
            label.BringToFront();
        }
    }
}
