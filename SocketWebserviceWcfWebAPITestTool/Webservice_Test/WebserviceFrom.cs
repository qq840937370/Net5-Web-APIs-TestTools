using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebServceTestSup;

namespace SocketWebserviceWcfWebAPITestTool.Webservice_Test
{
    public partial class WebserviceFrom : Form
    {
        public WebserviceFrom()
        {
            InitializeComponent();
        }

        private void WebserviceFrom_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请运行【WebServceTestSup】工程中的【引用式调用WebService】");
            //引用式调用WebService webService1 = new 引用式调用WebService();
            //webService1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Http式调用WebService ws2 = new Http式调用WebService();
            ws2.ShowDialog();
        }
    }
}
