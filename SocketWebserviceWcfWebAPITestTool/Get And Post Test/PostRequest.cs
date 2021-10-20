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
                restr=HttpPost(urlstr, jsonstr);

                txtReJson.Text = restr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="body">application/json</param>
        /// <returns></returns>
        public static string HttpPost(string url, string body)
        {
            try
            {
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Accept = "application/json, text/javascript, */*"; //"text/html, application/xhtml+xml, */*";
                request.ContentType = "application/json; charset=utf-8";

                byte[] buffer = encoding.GetBytes(body);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                var res = (HttpWebResponse)ex.Response;
                StringBuilder sb = new StringBuilder();
                StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                sb.Append(sr.ReadToEnd());
                //string ssb = sb.ToString();
                throw new Exception(sb.ToString());
            }
        }
    }
}
