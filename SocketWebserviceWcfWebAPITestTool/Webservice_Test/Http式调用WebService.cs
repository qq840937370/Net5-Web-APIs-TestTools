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

        private void button1_Click(object sender, EventArgs e)
        {

            string mUrl = Url + "/HelloWorld";
            string result = RequestCom.WebServiceHttpPost(mUrl,"");
            MessageBox.Show("三天没写出来，大神请留言告诉我怎么做");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string methodUrl = Url + "/Add HTTP/1.1";

            // a=string&b=string
            string bodystr = "a=" + textBox1.Text.Trim()+ "&b=" + textBox2.Text.Trim();
            
             string result = RequestCom.WebServiceHttpPost(Url, bodystr);
            MessageBox.Show("三天没写出来，大神请留言告诉我怎么做");
        }

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
