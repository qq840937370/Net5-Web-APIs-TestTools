using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebserviceWcfWebAPITestTool.常规Get与Post用法
{
    public partial class 常规Get与Post及utf8与json工具 : Form
    {
        public 常规Get与Post及utf8与json工具()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "检验OK";
            string outStr = "";
            if (!string.IsNullOrEmpty(str))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    //将中文字符转为10进制整数，然后转为16进制unicode字符  
                    outStr += "//u" + ((int)str[i]).ToString("x");
                }
            }
            MessageBox.Show(outStr);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Get请求 get = new Get请求();
            get.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Post请求 post = new Post请求();
            post.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            获取Json格式 jsonwin = new 获取Json格式();
            jsonwin.ShowDialog();
        }
    }
}
