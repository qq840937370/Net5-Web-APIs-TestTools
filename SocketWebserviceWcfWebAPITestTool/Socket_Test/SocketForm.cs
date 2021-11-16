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
using SocketWebserviceWcfWebAPITestTool.Socket_Test;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebserviceWcfWebAPITestTool.Socket_Test
{
    public partial class SocketForm : Form
    {
        public SocketForm()
        {
            InitializeComponent();
        }

        private void SocketForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            WinSockerServer1Test winSockerServer1Test = new WinSockerServer1Test();
            winSockerServer1Test.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SocketAPITest socketAPITest = new SocketAPITest();
            socketAPITest.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请运行WinSocketWebTest项目，WinSoketTest页面的内容");
        }
    }
}
