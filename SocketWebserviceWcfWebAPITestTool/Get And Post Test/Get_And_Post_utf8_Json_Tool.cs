/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：
*│　作    者：执笔小白                                              
*│　版    本：1.0                                       
*│　创建时间：2021-10-20 15:40:56                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: WebserviceWcfWebAPITestTool.ASPNetCoreWebAPI_Test                             
*│　类    名：WebAPITestForm                                     
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebserviceWcfWebAPITestTool.Get_And_Post_Test
{
    public partial class Get_And_Post_utf8_Json_Tool : Form
    {
        public Get_And_Post_utf8_Json_Tool()
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
            GetRequest getR = new GetRequest();
            getR.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PostRequest postR = new PostRequest();
            postR.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ToJsonFrom jsonwin = new ToJsonFrom();
            jsonwin.ShowDialog();
        }

        private void Get_And_Post_utf8_Json_Tool_Load(object sender, EventArgs e)
        {

        }
    }
}
