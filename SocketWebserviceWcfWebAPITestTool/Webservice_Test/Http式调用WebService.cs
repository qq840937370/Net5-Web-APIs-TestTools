using CommonTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketWebserviceWcfWebAPITestTool.Webservice_Test
{
    public partial class Http式调用WebService : Form
    {
        // URL地址
        string Url = "http://localhost:65172/WebService1.asmx";

        public Http式调用WebService()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string mUrl = Url+ "/HelloWorld";
            string result = RequestCom.WebServiceHttpPost(mUrl,"");
            textBox5.Text = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string methodUrl = Url + "/Sum";

            // a=string&b=string
            string bodystr = textBox1.Text.Trim() + textBox2.Text.Trim();

            string result = RequestCom.WebServiceHttpPost(methodUrl, bodystr);
            textBox5.Text = result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string methodUrl = "/Sub";
            string bodystr = textBox4.Text.Trim() + textBox3.Text.Trim();
            string result = RequestCom.HttpPost(methodUrl, bodystr);
            textBox5.Text = result;
        }
    }
}
