﻿/**
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
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebserviceWcfWebAPITestTool.Get_And_Post_Test
{
    public partial class GetRequest : Form
    {
        public GetRequest()
        {
            InitializeComponent();
        }

        private void Get请求_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 调用按钮
        /// </summary>
        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                string Url = txtURL.Text;
                if (!string.IsNullOrWhiteSpace(txtName1.Text))
                {
                    Url += "?" + txtName1.Text + "=" + txtValue1.Text;
                   
                }
                if (!string.IsNullOrWhiteSpace(txtName2.Text))
                {
                    Url += "&" + txtName2.Text + "=" + txtValue2.Text;
                    
                }
                if (!string.IsNullOrWhiteSpace(txtName3.Text))
                {
                    Url += "&" + txtName3.Text + "=" + txtValue3.Text;
                    
                }
                if (!string.IsNullOrWhiteSpace(txtName4.Text))
                {
                    Url += "&" + txtName4.Text + "=" + txtValue4.Text;
                    
                }
                if (!string.IsNullOrWhiteSpace(txtName5.Text))
                {
                    Url += "&" + txtName5.Text + "=" + txtValue5.Text;
                   
                }
                if (!string.IsNullOrWhiteSpace(txtName6.Text))
                {
                    Url += "&" + txtName6.Text + "=" + txtValue6.Text;
                }
                string result = GetInfo("", Url);
                txtResultValue.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Get方法
        /// </summary>
        /// 例如：http://localhost:30202/api/ValuesTest/Sum?num1=1&num2=3
        /// <param name="postData">后缀（?num1=1&num2=3）</param>
        /// <param name="Url">url（http://localhost:30202/api/ValuesTest/Sum）</param>
        /// <returns></returns>
        public static string GetInfo(string postData, string Url)
        {
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                HttpWebRequest objWebRequest = (HttpWebRequest)WebRequest.Create(Url);
                objWebRequest.Method = "Get";
                objWebRequest.ContentType = "application/json;charset=UTF-8";
                objWebRequest.ContentLength = byteArray.Length;

                HttpWebResponse response = (HttpWebResponse)objWebRequest.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string textResponse = sr.ReadToEnd(); // 返回的数据
                return textResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
