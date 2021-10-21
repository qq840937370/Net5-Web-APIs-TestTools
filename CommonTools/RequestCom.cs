/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：Http请求工具类
*│  Get     ：像数据库的select,只是用来查询一下数据，不会修改、增加数据，不会影响资源的内容。
*│  Post    ：像数据库的insert操作一样，会创建新的内容。几乎目前所有的提交操作都是用POST请求的。
*│  Put     ：像数据库的update操作一样，用来修改数据的内容，但是不会增加数据的种类等。
*│  Delete  ：像数据库的delete操作
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
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommonTools
{
    // 请求工具类
    // HttpWebRequest(WebRequest.Create):.NET.Framework的请求/响应模型的抽象基类，用于访问Internet数据。
    // HttpWebResponse:对http协议进行了完整的封装( Header, Content, Cookie)，与HttpWebRequest结合使用。
    public class RequestCom
    {
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
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Url);
                webRequest.Method = "GET";
                webRequest.Accept = "application/json, text/javascript, */*";  // 出错就删掉
                webRequest.ContentType = "application/json; charset=utf-8";
                webRequest.ContentLength = byteArray.Length;
 
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                using (StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8))
                {
                    return sr.ReadToEnd(); // 返回的数据
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                byte[] byteArray = Encoding.UTF8.GetBytes(body);
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = "POST";
                webRequest.Accept = "application/json, text/javascript, */*";
                webRequest.ContentType = "application/json; charset=utf-8";
                webRequest.ContentLength = byteArray.Length;
                webRequest.GetRequestStream().Write(byteArray, 0, byteArray.Length);

                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                using (StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                byte[] byteArray = Encoding.UTF8.GetBytes(body);
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = "PUT";
                webRequest.Accept = "application/json, text/javascript, */*";
                webRequest.ContentType = "application/json";
                webRequest.ContentLength = byteArray.Length;
                webRequest.GetRequestStream().Write(byteArray, 0, byteArray.Length);

                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                using (StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete请求-必有body
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="body">application/json</param>
        /// <returns></returns>
        public static string HttpDelete(string url, string body)
        {
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(body);
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = "DELETE";
                webRequest.Accept = "application/json, text/javascript, */*";
                webRequest.ContentType = "application/json";
                webRequest.ContentLength = byteArray.Length;
                webRequest.GetRequestStream().Write(byteArray, 0, byteArray.Length);

                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                using (StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
