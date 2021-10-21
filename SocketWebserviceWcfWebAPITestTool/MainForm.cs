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
using WebserviceWcfWebAPITestTool.ASPNetCoreWebAPI_Test;
using WebserviceWcfWebAPITestTool.Get_And_Post_Test;
using WebserviceWcfWebAPITestTool.Socket_Test;
using WebserviceWcfWebAPITestTool.WCF_Test;
using WebserviceWcfWebAPITestTool.Webservice_Test;

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
            // 常规Get与Post测试工具
            Get_And_Post_utf8_Json_Tool getpost1 = new Get_And_Post_utf8_Json_Tool();
            getpost1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // WebService测试工具
            WebserviceFrom webserviceFrom = new WebserviceFrom();
            webserviceFrom.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // WCF测试工具
            WCFForm wCFForm = new WCFForm();
            wCFForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ASPNET(Core)WebAPI
            WebAPITestForm webAPITestForm = new WebAPITestForm();
            webAPITestForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Socket测试工具
            SocketForm socketForm = new SocketForm();
            socketForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
