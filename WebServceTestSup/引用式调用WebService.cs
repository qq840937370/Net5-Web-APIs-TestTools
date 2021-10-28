using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebServceTestSup
{
    public partial class 引用式调用WebService : Form
    {
        public 引用式调用WebService()
        {
            InitializeComponent();
        }

        private void 引用式调用WebService_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 欢迎
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient requestClient = new ServiceReference1.WebService1SoapClient();

            textBox1.Text = requestClient.HelloWorld();
        }

        /// <summary>
        /// Add方法
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient requestClient = new ServiceReference1.WebService1SoapClient();

            int a = Convert.ToInt32(textBoxa.Text.Trim());
            int b = Convert.ToInt32(textBoxb.Text.Trim());

            textBox1.Text = requestClient.Add(a, b).ToString();
        }

        /// <summary>
        /// Sub方法
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient requestClient = new ServiceReference1.WebService1SoapClient();

            ServiceReference1.Tc1 tc1 = new ServiceReference1.Tc1();  // 数据格式
            tc1.num1 = Convert.ToInt32(textBox3.Text.Trim());
            tc1.num2 = Convert.ToInt32(textBox2.Text.Trim());

            textBox1.Text = requestClient.Sub(tc1).ToString();
        }
    }
}
