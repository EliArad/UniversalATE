using GSkinLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalATE
{
    public partial class PasswordForm : Form
    {
        SkinPictureBox spbUserName = new SkinPictureBox();

        SkinPictureBox spbPassword = new SkinPictureBox();
        public PasswordForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;

            btnOk.SetSkin(ResManager.R.GetBitmaps("btn140x40_21"), 0.9f, 0.9f);
            btnCancel.SetSkin(ResManager.R.GetBitmaps("btn140x40_21"), 0.9f, 0.9f);

            Point textboxLocation = new Point(12, 35);
            int textboxFontSize = 20;

            spbUserName.SetUpTextControl(ResManager.R.GetBitmap("Textbox_title_up_small_light"),
                                        6,
                                        20,
                                        this,
                                        "User Name",
                                        Color.White,
                                        new Point(20, 12),
                                        textboxLocation,
                                        10,
                                        textboxFontSize);
            spbUserName.CenterTextBox();

            spbPassword.SetUpTextControl(ResManager.R.GetBitmap("Textbox_title_up_small_light"),
                                        6,
                                        spbUserName.Bottom,
                                        this,
                                        "Password",
                                        Color.White,
                                        new Point(20, 12),
                                        textboxLocation,
                                        10,
                                        textboxFontSize);

            spbPassword.SetPasswordField();
            spbPassword.CenterTextBox();

        }

        public string Password
        {
            get
            {
                return spbPassword.textBox.Text;
            }
        }

        public string UserName
        {
            get
            {
                return spbUserName.textBox.Text;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
