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

                string resultjson = HttpPut(urlstr, jsonstr);

                txtReJson.Text=resultjson;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Put请求-必有body
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="body">application/json</param>
        /// <returns></returns>
        public static string HttpPut(string url, string body)
        {
            try
            {
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "PUT";
                request.Accept = "application/json, text/javascript, */*"; //"text/html, application/xhtml+xml, */*";
                request.ContentType = "application/json";

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
