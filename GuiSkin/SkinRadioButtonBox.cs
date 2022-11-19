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
    public class SkinRadioButtonBox : Button
    {
        object m_lock = new object();

        public static int NORMAL = 0;
        public static int PRESS = 1;
        public static int ENTER = 2;
        public static int DISABLE = 3;

        private Bitmap[] bmp = new Bitmap[4];
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
        public SkinRadioButtonBox()
        {
            UseVisualStyleBackColor = false;
        }

        public SkinRadioButtonBox(BUTTON_NAME btnName)
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
            
            if (bmp[3] != null)
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

            if (bmp[3] != null)
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

            if (wScale < 1 || hScale <1)
            {
                for(int i=0; i<bmp.Length; i++)
                {
                    bmp[i] = new Bitmap(bmp[i], new Size((int)( bitmaps[i].Width * wScale), (int) (bitmaps[i].Height * hScale))) ;
                }
            }
             
            if (bmp[3] != null)
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

            if (wScale < 1 || hScale < 1)
            {
                for (int i = 0; i < bmp.Length; i++)
                {
                    bmp[i] = new Bitmap(bmp[i], new Size((int)(bitmaps[i].Width * wScale), (int)(bitmaps[i].Height * hScale)));
                }
            }             

            if (bmp[3] != null)
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

            if (wScale < 1 || hScale < 1)
            {
                for (int i = 0; i < bmp.Length; i++)
                {
                    bmp[i] = new Bitmap(bmp[i], new Size((int)(bitmaps[i].Width * wScale), (int)(bitmaps[i].Height * hScale)));
                }
            }
             
            if (bmp[3] != null)
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

            if (wScale < 1 || hScale < 1)
            {
                for (int i = 0; i < bmp.Length; i++)
                {
                    bmp[i] = new Bitmap(bmp[i], new Size((int)(bitmaps[i].Width * wScale), (int)(bitmaps[i].Height * hScale)));
                }
            }


            if (bmp[3] != null)
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

            if (bmp[3] != null)
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

            if (bmp[3] != null)
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

            if (bmp[3] != null)
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
                        if (bmp[ENTER] != null)
                            GuiBackground.CreateControlRegion(this, bmp[ENTER], ControlAs);
                    }
                    else
                    {
                        if (bmp[PRESS] != null)
                            GuiBackground.CreateControlRegion(this, bmp[PRESS], ControlAs);
                    }
                    
                }
                if (m_isEnter == false)
                {
                    if (m_checked == false)
                    {
                        if (bmp[PRESS] != null)
                            GuiBackground.CreateControlRegion(this, bmp[NORMAL], ControlAs);
                    }
                    else
                    {
                        if (bmp[PRESS] != null)
                            GuiBackground.CreateControlRegion(this, bmp[PRESS], ControlAs);
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
                GuiBackground.CreateControlRegion(this, bmp[PRESS], ControlAs);
            }
            else
            {
                if (m_isEnter == false)
                {
                    if (bmp[PRESS] != null)
                    {
                        GuiBackground.CreateControlRegion(this, bmp[PRESS], ControlAs);
                    }
                    else
                    {
                        this.BackColor = EnterColor;
                    }
                }
                else
                {
                    if (bmp[ENTER] != null)
                    {
                        GuiBackground.CreateControlRegion(this, bmp[ENTER], ControlAs);
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
                if (bmp[PRESS] != null)
                {
                    if (this.InvokeRequired == false)
                    {
                        GuiBackground.CreateControlRegion(this, bmp[PRESS], ControlAs);
                    }
                    else
                    {
                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            GuiBackground.CreateControlRegion(this, bmp[PRESS], ControlAs);
                        });
                    }
                }

            }
            else
            {

                if (bmp[NORMAL] != null)
                {
                    if (this.InvokeRequired == false)
                    {
                        GuiBackground.CreateControlRegion(this, bmp[NORMAL], ControlAs);
                    }
                    else
                    {
                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            GuiBackground.CreateControlRegion(this, bmp[NORMAL], ControlAs);
                        });
                    }
                }
            }
        }
        
        
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
                GuiBackground.CreateControlRegion(this, bmp[DISABLE], ControlAs);
            }
            else
            {
                if (m_checked == false && m_checkedState == true)
                    m_checked = m_checkedState;

                if (m_isEnter == false && m_checked == false)
                    GuiBackground.CreateControlRegion(this, bmp[PRESS], ControlAs);
                if (m_isEnter == true && m_checked == false)
                    GuiBackground.CreateControlRegion(this, bmp[ENTER], ControlAs);
                if (m_checked == true)
                    GuiBackground.CreateControlRegion(this, bmp[PRESS], ControlAs);
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
        public void Normal()
        {
            if (m_enable == true)
            {
                if (bmp[NORMAL] != null)
                {

                    if (this.InvokeRequired == false)
                    {
                        GuiBackground.CreateControlRegion(this, bmp[NORMAL], ControlAs);
                    }
                    else
                    {
                        BeginInvoke((Action)delegate
                        {
                            GuiBackground.CreateControlRegion(this, bmp[NORMAL], ControlAs);
                        });
                    }
                }
                else
                {
                    this.BackColor = NormalColor;
                }
            }
        }
    }
}
