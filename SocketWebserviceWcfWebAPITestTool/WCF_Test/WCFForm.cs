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
using WebserviceWcfWebAPITestTool.Get_And_Post_Test;

namespace WebserviceWcfWebAPITestTool.WCF_Test
{
    public partial class WCFForm : Form
    {
        public WCFForm()
        {
            InitializeComponent();
        }

        private void WCFForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Get_And_Post_utf8_Json_Tool form= new Get_And_Post_utf8_Json_Tool();
            form.ShowDialog();
        }
    }
}
