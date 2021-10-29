﻿/**
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
using System.Web;
using System.Xml;
using static System.Net.WebRequestMethods;

namespace CommonTools
{
    // 请求工具类
    // HttpWebRequest(WebRequest.Create):.NET.Framework的请求/响应模型的抽象基类，用于访问Internet数据。
    // HttpWebResponse:对http协议进行了完整的封装( Header, Content, Cookie)，与HttpWebRequest结合使用。
    public class RequestCom
    {
        #region WebAPI
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

                webRequest.ContentType = "application/json; charset=utf-8";
                webRequest.ContentLength = byteArray.Length;
                webRequest.Accept = "application/json, text/javascript, */*";

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
                webRequest.ContentType = "application/json; charset=utf-8";
                webRequest.ContentLength = byteArray.Length;
                webRequest.GetRequestStream().Write(byteArray, 0, byteArray.Length);
                webRequest.Accept = "application/json, text/javascript, */*";

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
                webRequest.ContentType = "application/json";
                webRequest.ContentLength = byteArray.Length;
                webRequest.GetRequestStream().Write(byteArray, 0, byteArray.Length);
                webRequest.Accept = "application/json, text/javascript, */*";

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
                webRequest.ContentType = "application/json";
                webRequest.ContentLength = byteArray.Length;
                webRequest.GetRequestStream().Write(byteArray, 0, byteArray.Length);
                webRequest.Accept = "application/json, text/javascript, */*";

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

        #endregion

        #region WebService

        // Set-略


        /// <summary>
        /// Post方法
        /// </summary>
        /// <param name="url">webService的URL</param>
        /// <param name="method">调用的方法</param>
        /// <param name="reqBodys"></param>
        /// <returns></returns>
        public static string WebServiceHttpPost(string url, string method, List<ReqBody> reqBodys)
        {
            string result = string.Empty;
            string param = string.Empty;
            byte[] bytes = null;

            Stream writer = null;
            HttpWebRequest request = null;
            HttpWebResponse response = null;

            switch (reqBodys.Count)
            {
                case 0:
                    break;
                case 1:
                    param = HttpUtility.UrlEncode(reqBodys[0].Key) + "=" + HttpUtility.UrlEncode(reqBodys[0].Value);
                    break;
                default:
                    param = HttpUtility.UrlEncode(reqBodys[0].Key) + "=" + HttpUtility.UrlEncode(reqBodys[0].Value);
                    for (int i=1; i<reqBodys.Count; i++)
                    {
                        param += "&" + HttpUtility.UrlEncode(reqBodys[i].Key) + "=" + HttpUtility.UrlEncode(reqBodys[i].Value);
                    }
                    break;
            }

            bytes = Encoding.UTF8.GetBytes(param);

            request = (HttpWebRequest)WebRequest.Create(url + "/" + method);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;

            try
            {
                writer = request.GetRequestStream();        //获取用于写入请求数据的Stream对象
            }
            catch (Exception ex)
            {
                return "";
            }

            writer.Write(bytes, 0, bytes.Length);       //把参数数据写入请求数据流
            writer.Close();

            try
            {
                response = (HttpWebResponse)request.GetResponse();      //获得响应
            }
            catch (WebException ex)
            {
                return "";
            }

            #region 这种方式读取到的是一个返回的结果字符串
            Stream stream = response.GetResponseStream();        //获取响应流
            XmlTextReader Reader = new XmlTextReader(stream);
            Reader.MoveToContent();
            result = Reader.ReadInnerXml();
            #endregion

            #region 这种方式读取到的是一个Xml格式的字符串
            //StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            //result = reader.ReadToEnd();
            #endregion 

            response.Dispose();
            response.Close();

            //reader.Close();
            //reader.Dispose();

            Reader.Dispose();
            Reader.Close();

            stream.Dispose();
            stream.Close();

            return result;
        }
        #endregion
    }
    // 参数
    public class ReqBody
    {
        /// <summary>
        /// 参数名
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 参数值
        /// </summary>
        public string Value { get; set; }
    }
}