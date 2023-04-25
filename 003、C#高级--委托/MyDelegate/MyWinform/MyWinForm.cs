using System;
using System.Windows.Forms;

namespace MyWinform
{
    public partial class MyWinForm : Form
    {
        public MyWinForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("触发了点击事件");
        }
    }
}
