using InvokersLib;
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


    public class SkinScroll : Button
    {
        public interface ISkinScroll
        {
            void NotifyScoll(int id, double value, int posInPercentage);
        }
        bool m_forePress = false;
        BUTTON_NAME m_btnName;
        private Bitmap[] bmp = new Bitmap[4];
        static string m_dir = "";
        public static void BaseDir(string b)
        {
            m_dir = b;
        }

        int m_id;
        ISkinScroll piScoll;


        public SkinScroll()
        {

        }

        private System.Windows.Forms.Label labelValue = null;
        public Label AddLabelValue(Color color, string fontName, int fontSize, int x, int y)
        {
            labelValue = new Label();
            labelValue.AutoSize = true;
            Font fnt = new Font(fontName, fontSize);
            labelValue.Font = fnt;
            labelValue.BackColor = System.Drawing.Color.Transparent;
            labelValue.ForeColor = color;
            labelValue.Location = new System.Drawing.Point(x, y);
            labelValue.Name = "label1";
            labelValue.Size = new System.Drawing.Size(35, 13);
            labelValue.TabIndex = 10;
            labelValue.Text = "00";
            return labelValue;
        }
        public void LableSize(Size size)
        {
            labelValue.Size = size;
        }
        public void SetValue(double value)
        {
            labelValue.Text = value.ToString("0.0");
        }

        public void SetValue(int value)
        {
            labelValue.Text = value.ToString();
        }
        public void SetSkin(Bitmap[] bitmaps, BUTTON_NAME buttonName = BUTTON_NAME.NONAME, string name = "")
        {
            bmp[0] = bitmaps[0];
            bmp[1] = bitmaps[1];
            bmp[2] = bitmaps[2];
            bmp[3] = bitmaps[3];

            this.Text = name;
            m_btnName = buttonName;
            this.ForeColor = Color.White;


            this.MouseDown += Bot_MouseDown;
            this.MouseUp += Bot_MouseUp;
            this.MouseMove += Bot_MouseMove;
            this.MouseLeave += SkinScroll_MouseLeave;

            GuiBackground.CreateControlRegion(this, bmp[0], GuiBackground.WITH_AS.IMAGE);
        }

        private void SkinScroll_MouseLeave(object sender, EventArgs e)
        {
            if (m_enable == false) return;
            if (m_forePress == true) return;

            GuiBackground.CreateControlRegion(this, bmp[Common.LEAVE], GuiBackground.WITH_AS.IMAGE);

        }

        public void SetSkin(Bitmap[] bitmaps, BUTTON_NAME buttonName, ISkinScroll p, string name)
        {
            SetSkin(bitmaps, buttonName, name);
            piScoll = p;
        }



        Point point;
        int percentage;
        int X;

        private void Bot_MouseMove(object sender, MouseEventArgs e)
        {

            X = e.X;
            if (m_enable == false) return;
            if (m_forePress == true) return;

            GuiBackground.CreateControlRegion(this, bmp[Common.ENTER], GuiBackground.WITH_AS.IMAGE);


            if (m_handlerMove == true)
            {

                if (X < 0)
                    return;
                if (X < PrevX && this.Left < m_mostLeft)
                    return;
                if (X > PrevX && this.Left >= m_mostRight)
                    return;
                this.Left += (X - 25);
                //Debug.WriteLine(X);

                m_posInPercentage = (int)((this.Left - m_mostLeft) / m_stepRange);                 

                double tmp = (double)((m_fovMin - m_fovMax) / (100.0));
                m_pos = m_posInPercentage * tmp + m_fovMax;

                labelValue.Text = m_pos.ToString("0.00");

                PrevX = X;
            }

        }
        int PrevX;
        bool m_enable = true;
        double m_pos = 0;
        int m_posInPercentage = 0;

        double m_stepRange;

        public void UpdatePosition(int posInPercentage)
        {            
            double tmp = (double)((m_fovMin - m_fovMax) / (100.0));
            double pos = posInPercentage * tmp + m_fovMax;
            m_pos = pos;
            double myleft = posInPercentage * m_stepRange + m_mostLeft;
            this.Left = (int)myleft;

            labelValue.Text = pos.ToString("0.00");

        }
        private void Bot_MouseUp(object sender, MouseEventArgs e)
        {
            m_handlerMove = false;


            if (m_enable == false) return;
            GuiBackground.CreateControlRegion(this, bmp[Common.UP], GuiBackground.WITH_AS.IMAGE);

            if (piScoll != null)
                piScoll.NotifyScoll(m_id, m_pos, m_posInPercentage);

        }

        bool m_handlerMove = false;

        public void Show(bool s)
        {
            this.Visible = s;
            labelValue.Visible = s;

        }

        int m_mostLeft;
        int m_mostRight;

        float m_fovMin;
        float m_fovMax;
        public void UpdateFovMinMax(float min , float max)
        {
            m_fovMin = min;
            m_fovMax = max;
        }

        public void Setup(int initialX, int mostLeft , int mostRight, double percentageRange, int id = 0)
        {
            m_id = id;
            m_mostLeft = mostLeft;
            m_mostRight = mostRight;
            this.Left = initialX;

            m_stepRange = (m_mostRight - m_mostLeft) / percentageRange;

        }
        private void Bot_MouseDown(object sender, MouseEventArgs e)
        {
            m_handlerMove = true;

            if (m_enable == false) return;
            if (m_forePress == true) return;

            GuiBackground.CreateControlRegion(this, bmp[Common.DOWN], GuiBackground.WITH_AS.IMAGE);
  
        }
         
    }
}
