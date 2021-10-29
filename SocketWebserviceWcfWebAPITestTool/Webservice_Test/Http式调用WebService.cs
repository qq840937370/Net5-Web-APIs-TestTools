using CommonTools;
using Newtonsoft.Json;
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
        // set
        private void button4_Click(object sender, EventArgs e)
        {

        }
        // post
        private void button1_Click(object sender, EventArgs e)
        {

            string Method = "HelloWorld";

            List<ReqBody> reqBodys = new List<ReqBody>();

            string result = RequestCom.WebServiceHttpPost(Url, Method, reqBodys);
            textBox5.Text = result;
        }

        // set
        private void button5_Click(object sender, EventArgs e)
        {

        }

        // post
        private void button2_Click(object sender, EventArgs e)
        {
            string Method =  "Add";

            // a=string&b=string
            List<ReqBody> reqBodys = new List<ReqBody>();

            ReqBody reqBody1 = new ReqBody();
            ReqBody reqBody2 = new ReqBody();
            reqBody1.Key=labela.Text.Trim();
            reqBody1.Value = textBoxa.Text.Trim();

            reqBody2.Key = labelb.Text.Trim();
            reqBody2.Value = textBoxb.Text.Trim();

            reqBodys.Add(reqBody1);
            reqBodys.Add(reqBody2);

            string result = RequestCom.WebServiceHttpPost(Url, Method, reqBodys);
            textBox5.Text = result;
        }

        // 其他
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请看http://localhost:65172/WebService1.asmx?op=Sub页面，他并不支持http调用，可能参数是自定义的实体类的都不行");
        }

    }
    public class Tc1
    {
        /// <summary>
        /// 第一个数
        /// </summary>
        public int num1 { get; set; }

        /// <summary>
        /// 第二个数
        /// </summary>
        public int num2 { get; set; }
    }
}
