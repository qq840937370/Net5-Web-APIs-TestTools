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

namespace SocketWebserviceWcfWebAPITestTool.Get_And_Post_Test
{
    public partial class PutRequest : Form
    {
        public PutRequest()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                string urlstr = txtURL.Text.Trim();
                if (!string.IsNullOrEmpty(txtName1.Text.Trim()))
                {
                    urlstr += "?"+txtName1.Text.Trim() + "=" + txtValue1.Text.Trim();
                }
                string jsonstr = txtJSONstr.Text.Trim();

                string resultjson = RequestCom.HttpPut(urlstr, jsonstr);

                txtReJson.Text=resultjson;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
