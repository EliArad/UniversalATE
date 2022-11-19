using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSkinLib
{
    public class TextBoxColor : TextBox
    {
        public delegate void Callback(int tag);
        int m_id;
        public TextBoxColor()
        {
            this.MouseEnter += TextBoxColor_MouseEnter;
            this.MouseLeave += TextBoxColor_MouseLeave;
            this.MouseDown += TextBoxColor_MouseDown;
        }

        Callback pCallback = null;
        public void Setup(Callback p, int id)
        {
            pCallback = p;
            m_id = id;
        }
        private void TextBoxColor_MouseDown(object sender, MouseEventArgs e)
        {
            BackColor = Color.LightSkyBlue;
            pCallback(m_id);
        }

        private void TextBoxColor_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.LightBlue;
            this.Cursor = Cursors.Default;
        }

        private void TextBoxColor_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.LightGray;
            this.Cursor = Cursors.Arrow;
        }
        
    }
}
