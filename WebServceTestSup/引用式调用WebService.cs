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
        /// 欢迎 -Async
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

        /// <summary>
        /// DataSet测试
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient requestClient = new ServiceReference1.WebService1SoapClient();

            ServiceReference1.DataSetTB1 dsTB1 = new ServiceReference1.DataSetTB1();

            for (int i = 0; i < 5; i++)
            {
                DataRow dataRow = dsTB1.DTTest1.NewRow();
                {
                    dataRow["ID"] = (i + 1).ToString();
                    dataRow["Name"] = "姓名" + (i + 1).ToString();
                    dataRow["Class"] = "";
                }
                dsTB1.DTTest1.Rows.Add(dataRow);
            }
            ServiceReference1.DataSetTB1 dsTBRe = new ServiceReference1.DataSetTB1();

            //requestClient.DataSetTestAsync();
            dsTBRe = requestClient.DataSetTest(dsTB1);

            List<Xue> xue = DataTools.DataSetToIList<Xue>(dsTBRe, 0);
            textBox1.Text = JsonConvert.SerializeObject(xue);
        }
    }
    
    public class Xue{

        public string ID { get; set; }

        public string Name { get; set; }

        public string Class { get; set; }
    }
}
