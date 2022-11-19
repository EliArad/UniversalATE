using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GSkinLib.Common;

namespace GSkinLib
{
    public class SkinJoyButton  : ButtonEx
    {
        bool m_enable = true;
        Bitmap[] bmp = new Bitmap[4];
        bool m_enableButtonExists = false;
        ACTIONS m_state;
        bool m_forePress = false;
        JOYLIKE_BUTTON_NAME m_btnName;
        private static string m_dir;
        IJoystickHandler pButton = null;

        int m_posx;
        int m_posy;
        int m_lastPosx = -1;
        int m_lastPosy = -1;
        const int leftMove = 200;
        Stopwatch sw = new Stopwatch();

        public static void BaseDir(string b)
        {
            m_dir = b;
        }

        public void SetSkin(Bitmap[] bitmaps, float wscale , float hscale, 
                            JOYLIKE_BUTTON_NAME buttonName = JOYLIKE_BUTTON_NAME.JOYSTICK_HANDLER, string name = "")
        {
            bmp[0] = bitmaps[0];
            bmp[1] = bitmaps[1];
            bmp[2] = bitmaps[2];
            bmp[3] = bitmaps[3];

            if (wscale < 1 || hscale < 1)
            {
                for (int i = 0; i < bmp.Length; i++)
                {
                    bmp[i] = new Bitmap(bmp[i], new Size((int)(bitmaps[i].Width * wscale), (int)(bitmaps[i].Height * hscale)));
                }
            }


            sw.Restart();
            if (bmp[3] != null)
            {
                m_enableButtonExists = true;
            }
            else
            {
                m_enableButtonExists = false;

            }
            this.Text = name;
            this.ForeColor = Color.White;
            GuiBackground.CreateControlRegion(this, bmp[0], GuiBackground.WITH_AS.IMAGE);
            m_state = ACTIONS.LEAVE;
            m_btnName = buttonName;

            this.MouseDown += SkinButton_MouseDown;
            this.MouseEnter += SkinButton_MouseEnter;
            this.MouseLeave += SkinButton_MouseLeave;
            this.MouseUp += SkinButton_MouseUp;
            this.MouseMove += SkinJoyButton_MouseMove;

        }

        public void SetSkin(Bitmap [] bitmaps, JOYLIKE_BUTTON_NAME buttonName = JOYLIKE_BUTTON_NAME.JOYSTICK_HANDLER, string name = "")
        {
            bmp[0] = bitmaps[0];
            bmp[1] = bitmaps[1];
            bmp[2] = bitmaps[2];
            bmp[3] = bitmaps[3];
            sw.Restart();
            if (bmp[3] != null)
            {
                m_enableButtonExists = true;
            }
            else
            {
                m_enableButtonExists = false;

            }
            this.Text = name;
            this.ForeColor = Color.White;
            GuiBackground.CreateControlRegion(this, bmp[0], GuiBackground.WITH_AS.IMAGE);
            m_state = ACTIONS.LEAVE;
            m_btnName = buttonName;

            this.MouseDown += SkinButton_MouseDown;
            this.MouseEnter += SkinButton_MouseEnter;
            this.MouseLeave += SkinButton_MouseLeave;
            this.MouseUp += SkinButton_MouseUp;
            this.MouseMove += SkinJoyButton_MouseMove;
            
        }

        enum MOVE_MODE
        {        
            MOVE_RIGHT = 1,
            MOVE_LEFT = 2,
            MOVE_UP,
            MOVE_DOWN   ,
            MOVE_NONE
        }
        
          
        public void UpdateText(string name)
        {
            this.Text = name;
        }
        public void SetForeColor(Color color)
        {
            this.ForeColor = color;
        }
        public void SetSkin(string btnName, JOYLIKE_BUTTON_NAME buttonName, string name = "")
        {
            m_btnName = buttonName;
            if (File.Exists(m_dir + btnName + "_normal.png"))
            {
                bmp[0] = new Bitmap(m_dir + btnName + "_normal.png");
            }
            else
            {
                throw (new SystemException("File: " + m_dir + btnName + "_normal.png" + " does not exists"));
            }

            if (File.Exists(m_dir + btnName + "_enter.png"))
            {
                bmp[1] = new Bitmap(m_dir + btnName + "_enter.png");
            }
            else
            {                
               throw (new SystemException("File: " + m_dir + btnName + "_enter.png" + " does not exists"));             
            }

            if (File.Exists(m_dir + btnName + "_press.png"))
            {
                bmp[2] = new Bitmap(m_dir + btnName + "_press.png");
            }
            else
            {
                throw (new SystemException("File: " + m_dir + btnName + "_press.png" + " does not exists"));
            }

            if (File.Exists(m_dir + btnName + "_disable.png"))
            {
                bmp[3] = new Bitmap(m_dir + btnName + "_disable.png");
                m_enableButtonExists = true;
            }
            else
            {
                m_enableButtonExists = false;
            }


            GuiBackground.CreateControlRegion(this, bmp[0], GuiBackground.WITH_AS.IMAGE);
            m_state = ACTIONS.LEAVE;
            sw.Restart();
            this.MouseDown += SkinButton_MouseDown;
            this.MouseEnter += SkinButton_MouseEnter;
            this.MouseLeave += SkinButton_MouseLeave;
            this.MouseUp += SkinButton_MouseUp;
            this.MouseMove += SkinJoyButton_MouseMove;

        }

        private void SkinJoyButton_MouseMove(object sender, MouseEventArgs e)
        {            
            if (m_state == ACTIONS.DOWN)
            {
                MOVE_MODE moveMode = MOVE_MODE.MOVE_NONE;
                int distanceRight = 0;
                int distanceLeft = 0;
                int distanceTop = 0;
                int distanceBottom = 0;

                m_posx = e.X;
                m_posy = e.Y;
                if (m_lastPosx == -1)
                {
                    m_lastPosx = m_posx;
                    return;
                }
                if (m_lastPosy == -1)
                {
                    m_lastPosy = m_posy;
                    return;
                }

                //Debug.WriteLine("m_posx: " + m_posx + " m_lastPosx: " + m_lastPosx);
                if (m_posx > m_lastPosx)
                {
                    if (this.Right > m_maxRight)
                    {
                        m_lastPosx = m_posx;
                        return;
                    }
                    moveMode = MOVE_MODE.MOVE_RIGHT;
                    //Debug.WriteLine("MOVE RIGHT");                    
                    this.Left += (m_posx - m_lastPosx);
                    //Debug.WriteLine("m_posx: " + m_posx + "m_lastPosx: " + m_lastPosx);
                    distanceRight = this.Left - m_circleMiddleX;
                }
                else if (m_posx < m_lastPosx)
                {
                    if (this.Left < m_maxLeft)
                    {
                        m_lastPosx = m_posx;
                        return;
                    }
                    //Debug.WriteLine("MOVE LEFT");
                    moveMode = MOVE_MODE.MOVE_LEFT;
                    //Debug.WriteLine("MOVE LEFT");                    
                    this.Left -= (m_lastPosx - m_posx);
                    distanceLeft = m_circleMiddleX - this.Left;
                } else 
                if (m_posy > m_lastPosy)
                {
                    if (this.Bottom > m_maxDown)
                    {
                        m_lastPosy = m_posy;
                        return;
                    }
                    //Debug.WriteLine("MOVE DOWN");
                    moveMode = MOVE_MODE.MOVE_DOWN;
                    //Debug.WriteLine("MOVE DOWN");
                    this.Top += (m_posy - m_lastPosy);
                    distanceBottom = this.Top - m_circleMiddleY;
                }
                else if (m_posy < m_lastPosy)
                {
                    if (this.Top < m_maxUp)
                    {
                        m_lastPosy = m_posy;
                        return;
                    }
                    //Debug.WriteLine("MOVE UP");
                    moveMode = MOVE_MODE.MOVE_UP;
                    //Debug.WriteLine("MOVE UP");
                    this.Top -= (m_lastPosy - m_posy);
                    distanceTop = m_circleMiddleY - this.Top;
                }

                if (sw.ElapsedMilliseconds < 30)
                    return;

                sw.Restart();

                if (moveMode == MOVE_MODE.MOVE_RIGHT)
                {
                    double x = 32767 + m_step * distanceRight;
                    if (x <= 65535)
                        pButton.NotifyYaw((int)x);
                }
                else if (moveMode == MOVE_MODE.MOVE_LEFT)
                {
                    double x = 32767 - m_step * distanceLeft;
                    //Debug.WriteLine("distanceLeft:"  +distanceLeft + "x:"+ x);
                    if (x >= 0)
                        pButton.NotifyYaw((int)x);
                }
                else if (moveMode == MOVE_MODE.MOVE_DOWN)
                {
                    double y = 32767 - m_step * distanceBottom;
                    //Debug.WriteLine(y);
                    if (y >= 0)
                        pButton.NotifyPitch((int)y);
                }
                else if (moveMode == MOVE_MODE.MOVE_UP)
                {
                    double y = 32767 + m_step * distanceTop;
                    //Debug.WriteLine(y);
                    if (y <= 65535)
                        pButton.NotifyPitch((int)y);
                }

            }
        }

        public void SetCallback(IJoystickHandler p)
        {
            pButton = p;
        }
        private void SkinButton_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                m_lastPosx = -1;
                m_lastPosy = -1;

                if (m_enable == false) return;
                GuiBackground.CreateControlRegion(this, bmp[Common.UP], GuiBackground.WITH_AS.IMAGE);
                m_state = ACTIONS.UP;
                SetMiddle();
                pButton.NotifyJoyHandlerStop();
                System.Drawing.Point p1 = this.PointToScreen(new Point(m_circleMiddleX - m_circleMiddleX/2, m_circleMiddleY - m_circleMiddleY/2));
                pButton.NotifyJoyHandlerPositionMiddle(p1);
            }
            else if (e.Button == MouseButtons.Right)
            {
                pButton.NotifyJoyHandlerRightClick();
            }
        }

        private void SkinButton_MouseLeave(object sender, EventArgs e)
        {
            if (m_enable == false) return;
            if (m_forePress == true) return;
            GuiBackground.CreateControlRegion(this, bmp[Common.LEAVE], GuiBackground.WITH_AS.IMAGE);
            m_state = ACTIONS.LEAVE;
        }

        private void SkinButton_MouseEnter(object sender, EventArgs e)
        {
            if (m_enable == false) return;
            if (m_forePress == true) return;
            GuiBackground.CreateControlRegion(this, bmp[Common.ENTER], GuiBackground.WITH_AS.IMAGE);
            m_state = ACTIONS.ENTER;
        }

        private void SkinButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_enable == false) return;
            if (m_forePress == true) return;
            GuiBackground.CreateControlRegion(this, bmp[Common.DOWN], GuiBackground.WITH_AS.IMAGE);

            if (e.Button == MouseButtons.Left)
            {
                m_state = ACTIONS.DOWN;
            }
              
        }

        public bool IsEnable()
        {
            return m_enable;
        } 
        public void Enable(bool b)
        {
            if (m_enableButtonExists == false) return;
            m_enable = b;
            if (b == false)
            {
                GuiBackground.CreateControlRegion(this, bmp[DISABLE], GuiBackground.WITH_AS.IMAGE);
                m_state = ACTIONS.DISABLE;
            }
            else
            {
                if (m_state == ACTIONS.LEAVE)
                    GuiBackground.CreateControlRegion(this, bmp[Common.LEAVE], GuiBackground.WITH_AS.IMAGE);
                if (m_state == ACTIONS.ENTER)
                    GuiBackground.CreateControlRegion(this, bmp[Common.ENTER], GuiBackground.WITH_AS.IMAGE);



            }
        }

        public void PressState()
        {
            GuiBackground.CreateControlRegion(this, bmp[Common.DOWN], GuiBackground.WITH_AS.IMAGE);
            m_state = ACTIONS.DOWN;
        }

        public void EnterState()
        {
            GuiBackground.CreateControlRegion(this, bmp[Common.ENTER], GuiBackground.WITH_AS.IMAGE);
            m_state = ACTIONS.ENTER;
        }
        public void NormalState()
        {
            GuiBackground.CreateControlRegion(this, bmp[Common.LEAVE], GuiBackground.WITH_AS.IMAGE);
            m_state = ACTIONS.LEAVE;
        }

        public void UpdateSate()
        {
            switch (m_state)
            {
                case ACTIONS.LEAVE:
                    GuiBackground.CreateControlRegion(this, bmp[Common.LEAVE], GuiBackground.WITH_AS.IMAGE);
                break;
                case ACTIONS.ENTER:
                    GuiBackground.CreateControlRegion(this, bmp[Common.ENTER], GuiBackground.WITH_AS.IMAGE);
                break;
                case ACTIONS.DOWN:
                    GuiBackground.CreateControlRegion(this, bmp[Common.DOWN], GuiBackground.WITH_AS.IMAGE);
                break;
                case ACTIONS.DISABLE:
                    GuiBackground.CreateControlRegion(this, bmp[Common.DISABLE], GuiBackground.WITH_AS.IMAGE);
                break;

            }
        }

        public void ForcePress(bool value)
        {
            m_forePress = value;
            if (value == true) PressState();
            else NormalState();
            
        }
        public void SimulateEnter()
        {
            GuiBackground.CreateControlRegion(this, bmp[Common.ENTER], GuiBackground.WITH_AS.IMAGE);

        }


        int m_parentWidth = 0;
        int m_parentHeight = 0;
        

        int m_circleMiddleX;
        int m_circleMiddleY;
        int m_maxRight = 0;
        int m_maxLeft = 0;
        int m_maxUp;
        int m_maxDown;
        int m_range;
        double m_step = 0;
        
        public void SetParent(int circleMiddleX, int circleMiddleY, int width, int height)
        {
            m_parentWidth = width;
            m_parentHeight = height;

            m_circleMiddleX = circleMiddleX;
            m_circleMiddleY = circleMiddleY;

            m_maxRight = m_parentWidth;
            m_maxLeft = 0;
            m_maxUp = 0;
            m_maxDown = m_parentHeight;
            m_range = m_parentWidth / 2 - this.Width/2;
 

            m_step = (double)32767.0 / m_range;
        }

        public void SetMiddle()
        {
            this.Location = new Point(m_circleMiddleX, m_circleMiddleY);
        }
    }
}
