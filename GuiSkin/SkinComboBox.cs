using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSkinLib
{


    public partial class SkinComboBox : UserControl, IButton 
    {

        public delegate void ISkinComboBox(int tagSelected);
        SkinPictureBox comboFrame = new SkinPictureBox();
        public SkinComboBox()
        {
            InitializeComponent();
        }
        int h = 0;
        TextBoxColor.Callback p;

        ISkinComboBox pISkinComboBox;
        public void UpdateOpenButtonTop(int top)
        {
            btnOpen.Top += top;
        }
        public void UpdateOpenButtonLeft(int left)
        {
            btnOpen.Left += left;
        }
        

        public void LoadControl(string comboName, ISkinComboBox p1, float wscale = 1, float hscale = 1)
        {
            if (wscale != 1 || hscale != 1)
            {
                btnOpen.SetSkin(ResManager.R.GetBitmaps("dropdown_btn"), wscale, hscale,BUTTON_NAME.COMBO_TRACK_TYPE, this, "");
            }
            else
            {
                btnOpen.SetSkin(ResManager.R.GetBitmaps("dropdown_btn"), BUTTON_NAME.COMBO_TRACK_TYPE, this, "");
            }
            pISkinComboBox = p1;

            comboFrame.SetSkin(ResManager.R.GetBitmap("dropdown_frame_352x57"));
            comboFrame.Location = new Point(0, 0);
            comboFrame.AddLabel(Color.LightGray, 21, 20, "Ariel", 10, comboName);
            comboFrame.BringToFront();
            this.Controls.Add(comboFrame);
            this.Height = comboFrame.Height;
            this.BorderStyle = BorderStyle.None;
            h = comboFrame.Bottom;

            p = new TextBoxColor.Callback(CallbackTextMsg);

        }

        public void UpdateName(string name)
        {
            comboFrame.UpdateText(name);
        }

        public void UpdateName(int tag)
        {
            UpdateName(m_comboItems[tag]);
        }

        void CallbackTextMsg(int tag)
        {
            pISkinComboBox(tag);
            this.Height = comboFrame.Height;
            m_open = false;
            UpdateName(m_comboItems[tag]);
        }
        public void AddWidth(int w, int openWidth = 0)
        {
            this.Width += w;
            if (openWidth == 0)
                btnOpen.Left += w;
            else
                btnOpen.Left += openWidth;
        }

        List<string> m_lineList = new List<string>();
        List<TextBox> m_lineCombo = new List<TextBox>();
        Dictionary<int, string> m_comboItems = new Dictionary<int, string>();

        public void AddLine(string name,int itemNum, bool ronly = true)
        {
            m_lineList.Add(name);

            TextBoxColor comboLine = new TextBoxColor();
            comboLine.ReadOnly = ronly;
            comboLine.Setup(p, itemNum);
            comboLine.BackColor = Color.LightBlue;
            comboLine.Size = new Size(comboFrame.Width, comboFrame.Height);
            comboLine.Location = new Point(0, h);
            comboLine.Text = name;
            comboLine.BringToFront();
            m_lineCombo.Add(comboLine);
            h += comboLine.Height;
            m_comboItems.Add(itemNum, name);
        }

        public void NotifyDoubleClick(BUTTON_NAME btnName)
        {
            
        }

        public void NotifyDown(BUTTON_NAME btnName, int value = -1)
        {
   
        }

        public void NotifyEnter(BUTTON_NAME btnName)
        {
             
        }

        public void NotifyUp(BUTTON_NAME btnName)
        {
           
        }

        bool m_open = false;
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (m_open == false)
            {
                this.BringToFront();
                foreach (TextBoxColor s in m_lineCombo)
                {
                    this.Controls.Add(s);
                }
                this.Height = h;
            }
            else
            {
                this.Height = comboFrame.Height;
            }
            m_open = !m_open;
        }
    }
}
