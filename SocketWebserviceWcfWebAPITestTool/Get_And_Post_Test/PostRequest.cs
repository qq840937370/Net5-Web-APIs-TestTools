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
using CommonTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebserviceWcfWebAPITestTool.Get_And_Post_Test
{
    public partial class PostRequest : Form
    {
        public PostRequest()
        {
            InitializeComponent();
        }

        private void Post请求_Load(object sender, EventArgs e)
        {

        }

        // 请求按钮
        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                string restr;

                string urlstr = txtURL.Text.Trim();
                string jsonstr = txtJSONstr.Text.Trim();
                restr= RequestCom.HttpPost(urlstr, jsonstr);

                txtReJson.Text = restr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
