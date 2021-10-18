using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebserviceWcfWebAPITestTool.常规Get与Post用法;

namespace WebserviceWcfWebAPITestTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn常规Get与Post_Click(object sender, EventArgs e)
        {
            常规Get与Post及utf8与json工具 getpost1 = new 常规Get与Post及utf8与json工具();
            getpost1.ShowDialog();
        }
    }
}
