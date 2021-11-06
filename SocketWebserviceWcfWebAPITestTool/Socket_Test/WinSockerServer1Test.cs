using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketWebserviceWcfWebAPITestTool.Socket_Test
{
    public partial class WinSockerServer1Test : Form
    {
        static ClientWebSocket client = new ClientWebSocket();//实例化客户端对象

        public WinSockerServer1Test()
        {
            InitializeComponent();
        }

        private void WinSockerServer1Test_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 修改
        /// </summary>
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (btnModify.Text == "修改")
            {
                txtIPAddress.Enabled = true;
                btnModify.Text = "确定";
            }
            else if (btnModify.Text == "确定")
            {
                txtIPAddress.Enabled = false;
                btnModify.Text = "修改";
            }
        }

        /// <summary>
        /// 发送按钮
        /// </summary>
        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (txtIPAddress.Enabled == true)
            {
                MessageBox.Show("请先确认地址");
                return;
            }
            string valueA = string.Empty, valueB = string.Empty;
            valueA = txtAvalue.Text;
            valueB = txtBvalue.Text;
            string jsondata = SerializeJson(valueA, valueB);

            var array = new ArraySegment<byte>(Encoding.UTF8.GetBytes(jsondata));
            //此处需要捕捉异常，连接是否通畅？
            try
            {
                if (client.State == WebSocketState.Open)//连通状态才允许发送
                {
                    client.SendAsync(array, WebSocketMessageType.Text, true, CancellationToken.None);
                }
                else
                {
                    MessageBox.Show("连接状态异常,请尝试重新连接");
                }
            }
            catch (Exception ex)
            {
                txtInfo.AppendText(ex.ToString() + DateTime.Now.ToString() + "\n");
                return;
            }
            finally
            {
                lblListen.Text = client.State.ToString();
            }
        }
        
        /// <summary>
        /// 打开监听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenServer_Click(object sender, EventArgs e)
        {
            if (txtIPAddress.Enabled == true)
            {
                MessageBox.Show("请先确认地址");
                return;
            }

            string ServerAddress = txtIPAddress.Text;
            //如果已经连上了服务端，想要再次进行连接，需要进行判断，关闭当前连接后才能进行
            if (client.State == WebSocketState.Open)
            {
                MessageBox.Show("当前client对象连接状态为open，若要重新连接，请先关闭当前连接");
                return;
            }

            try
            {
                client = new ClientWebSocket();//这一句不要进行状态判断，因为除了Open和Closed，还有Abort等好几种状态。干脆每次连接重新初始化。
                client.ConnectAsync(new Uri(ServerAddress), CancellationToken.None).Wait();
                txtInfo.AppendText("开启了连接" + DateTime.Now.ToString() + "\n");
            }
            catch (Exception ex)
            {
                txtInfo.AppendText(ex.ToString() + DateTime.Now.ToString() + "\n");
                MessageBox.Show("连接出现问题，请检查网络是否通畅，地址是否正确，服务端是否开启");
                return;
            }
            finally
            {
                lblListen.Text = client.State.ToString();
            }

            StartReceiving(client);
        }

        /// <summary>
        /// 关闭监听
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (client.State == WebSocketState.Open)
            {
                try
                {
                    client.CloseAsync(WebSocketCloseStatus.Empty, string.Empty, CancellationToken.None);
                    client.Dispose();
                    txtInfo.AppendText("主动关闭了连接" + DateTime.Now.ToString() + "\n");

                }
                catch (Exception ex)
                {
                    txtInfo.AppendText(ex.ToString() + DateTime.Now.ToString() + "\n");
                }
                finally
                {
                    lblListen.Text = client.State.ToString();
                }
            }
        }

        #region 方法
        /// <summary>
        /// 异步接收服务端数据，获取json数据后反序列化，然后显示到文本框控件中
        /// </summary>
        /// <param name="client"></param>
        private async void StartReceiving(ClientWebSocket client)
        {
            if (client.State != WebSocketState.Open)//正常来说进入到此方法的状态都为Open
            {
                lblListen.Text = client.State.ToString();
                MessageBox.Show("StartReceiving方法：连接状态异常,请尝试重新连接");
                return;
            }
            try//有可能中途连接断开
            {
                while (true)
                {
                    var array = new byte[2048];
                    if (!((client.State == WebSocketState.Open) || (client.State == WebSocketState.CloseSent)))
                    {
                        //接收消息的有效状态是Open和CloseSent，如果不是这两种状态，则退出。
                        //主动退出也会影响异步线程的接收，因此先进行判断
                        lblListen.Text = "Closed";
                        txtInfo.AppendText("StartReceiving方法:连接状态异常，退出循环接收，请检查" + DateTime.Now.ToString() + "\n");
                        return;
                    }
                    var result = await client.ReceiveAsync(new ArraySegment<byte>(array), CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        //获取字节数组并转为字符串，此字符串应为json类型，需要反序列化
                        string jsonmsg = Encoding.UTF8.GetString(array, 0, result.Count);

                        try//将反序列化内容放入try中，避免无法匹配、内容为空等可能报错的地方
                        {
                            //将转换后的字符串内容进行json反序列化。参考：https://www.cnblogs.com/yinmu/p/12160343.html
                            TestValue tv = JsonConvert.DeserializeObject<TestValue>(jsonmsg);
                            //将收到的a,b的值显示到文本框
                            if (tv != null)
                            {
                                string valueA = string.Empty, valueB = string.Empty;
                                if (tv.a != null && tv.a.Length > 0) { valueA = tv.a; }
                                if (tv.a != null && tv.b.Length > 0) { valueB = tv.b; }
                                txtAvalue.Text = valueA;
                                txtBvalue.Text = valueB;

                                lblListen.Text = "/n" + jsonmsg;  // 显示到显示框   
                            }
                        }
                        catch (Exception ex)
                        {
                            //如果json反序列化出了问题
                            txtInfo.AppendText(ex.ToString() + DateTime.Now.ToString() + "\n");//将错误类型显示出来
                            txtInfo.AppendText(jsonmsg + "\n");//将收到的原始字符串显示出来
                        }
                    }
                }
            }
            catch (Exception ex)//看看什么类型的错误
            {
                lblListen.Text = client.State.ToString();
                //MessageBox.Show(ex.ToString());//暂且注释，弹出消息框影响观感
                if (ex.GetType().ToString() == "System.Net.WebSockets.WebSocketException" && client.State != WebSocketState.Open)
                {
                    //客户端关闭时会抛出此错误
                    txtInfo.AppendText("连接被关闭，请检查网络或服务器" + DateTime.Now.ToString() + "\n");
                }
                else
                {
                    txtInfo.AppendText(ex.ToString() + DateTime.Now.ToString() + "\n");
                }
            }
            //finally
            //{
            //    if (client != null)
            //    {
            //        client.Dispose();
            //    }
            //}

        }

        /// <summary>
        /// //以dictionary将数据的键值对匹配，然后进行json序列化，避免定义类的麻烦。
        /// </summary>
        /// <param name="valueA"></param>
        /// <param name="valueB"></param>
        /// <returns></returns>
        public static string SerializeJson(string valueA, string valueB)
        {
            if (valueA.Length == 0) { valueA = "-"; }
            if (valueB.Length == 0) { valueB = "-"; }
            //以dictionary将数据的键值对匹配，然后进行json序列化，避免定义类的麻烦。参考：https://www.cnblogs.com/kevinWu7/p/10163455.html
            Dictionary<string, string> dic = new Dictionary<string, string>(){
                { "a",valueA },
                { "b",valueB }
            };
            string Jsondata = JsonConvert.SerializeObject(dic);
            return Jsondata;
        }
        #endregion
    }

    /// <summary>
    /// 用于json反序列化获取实体
    /// </summary>
    public class TestValue
    {
        public string a { get; set; }
        public string b { get; set; }
    }
}
