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
using WMSTOMESTT.Common;

namespace SocketWebserviceWcfWebAPITestTool.Socket_Test
{
    public partial class SocketAPITest : Form
    {
        private static ClientWebSocket clientWebSocket = new ClientWebSocket();

        public SocketAPITest()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 清空消息框数据
            txtInfo.Text = "";
            txtSendMsg.Text = "";
            // 关闭连接
            CloseWebSocket(clientWebSocket);
        }
        // 加载
        private void SocketServerTest_Load(object sender, EventArgs e) { }

        /// <summary>
        /// 连接按钮
        /// </summary>
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUrl.Text.Trim()))  // 判空
            {
                txtInfo.AppendText("请输入URL(ws://...)的值");
                MessageBox.Show("请输入URL(ws://...)的值");
                return;
            }

            if (txtUrl.Enabled == true || btnModify.Text == "连接")  // url变换成不可编辑,btn为修改服务器地址
            {
                txtUrl.Enabled = false;
                btnModify.Text = "修改服务器地址";

                //if (clientWebSocket.State == WebSocketState.Open)  // 关闭当前连接后才能进行新的连接
                //{
                //    CloseWebSocket(clientWebSocket);
                //}
                // 开启连接
                OpenWebSocket(clientWebSocket, txtUrl.Text.Trim());
            }
            else if (txtUrl.Enabled == false && btnModify.Text == "修改")  // url变换成可编辑,btn为确认
            {
                txtUrl.Enabled = true;
                btnModify.Text = "确认";

                // 关闭连接
                CloseWebSocket(clientWebSocket);
            }
        }

        /// <summary>
        /// 发送按钮
        /// </summary>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSendMsg.Text.Trim()))
            {
                txtInfo.AppendText("你怎么能发空消息呢！");
                return;
            }
            if (txtUrl.Enabled == true)
            {
                MessageBox.Show("请先确认地址");
                return;
            }

            // 读取用户信息
            WSMsg wSMsg = JsonfileTools.ReadjsonT<WSMsg>("UserData");
            wSMsg.MsgData = txtSendMsg.Text.Trim();
            string jsondata = JsonConvert.SerializeObject(wSMsg);

            var array = new ArraySegment<byte>(Encoding.UTF8.GetBytes(jsondata));
            try
            {
                if (clientWebSocket.State == WebSocketState.Open)  // 连通状态才允许发送
                {
                    clientWebSocket.SendAsync(array, WebSocketMessageType.Text, true, CancellationToken.None);
                }
                else
                {
                    txtInfo.AppendText("连接状态异常,请尝试重新连接");
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
                txtInfo.AppendText(clientWebSocket.State.ToString());
            }
        }

        #region 方法
        /// <summary>
        /// 打开连接
        /// </summary>
        /// <param name="cWebSocket">ClientWebSocket</param>
        /// <param name="wsUrl">wsUrl地址</param>
        private void OpenWebSocket(ClientWebSocket cWebSocket, string wsUrl)
        {
            try
            {
                if (clientWebSocket.State == WebSocketState.Open)  // 告诉服务器关闭连接
                {
                    CloseWebSocket(clientWebSocket);
                }

                clientWebSocket = new ClientWebSocket();  // 连接重新初始化
                clientWebSocket.ConnectAsync(new Uri(wsUrl), CancellationToken.None).Wait();
                txtInfo.AppendText("开启了连接" + DateTime.Now.ToString() + "\n");

                // 异步接受数据
                StartReceiving(clientWebSocket);
            }
            catch (Exception ex)
            {
                txtInfo.AppendText(ex.ToString() + DateTime.Now.ToString() + "\n");
                MessageBox.Show("连接出现问题，请检查网络是否通畅，地址是否正确，服务端是否开启");
                return;
            }
            finally
            {
                txtInfo.AppendText(clientWebSocket.State.ToString());  // 展示连接状态
            }
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        /// <param name="wsUrl">ClientWebSocket</param>        
        private void CloseWebSocket(ClientWebSocket cWebSocket)
        {
            if (cWebSocket.State == WebSocketState.Open)
            {
                try
                {
                    cWebSocket.CloseAsync(WebSocketCloseStatus.Empty, string.Empty, CancellationToken.None);
                    cWebSocket.Dispose();
                    txtInfo.AppendText("主动关闭了连接" + DateTime.Now.ToString() + "\n");
                }
                catch (Exception ex)
                {
                    txtInfo.AppendText(ex.ToString() + DateTime.Now.ToString() + "\n");
                }
                finally
                {
                    txtInfo.AppendText(cWebSocket.State.ToString());  // 输出连接现在的状态
                }
            }
        }

        /// <summary>
        /// 异步接收服务端数据+显示到数据框中
        /// </summary>
        /// <param name="clientWebSocket"></param>
        private async void StartReceiving(ClientWebSocket cWebSocket)
        {
            if (cWebSocket.State != WebSocketState.Open)  //正常来说进入到此方法的状态都为Open
            {
                txtInfo.AppendText(cWebSocket.State.ToString());
                MessageBox.Show("StartReceiving方法：连接状态异常,请尝试重新连接");
                return;
            }

            try  // 有可能中途连接断开
            {
                while (true)
                {
                    var array = new byte[2048];
                    if (!((cWebSocket.State == WebSocketState.Open) || (cWebSocket.State == WebSocketState.CloseSent)))  // 接收消息的有效状态是Open和CloseSent，如果不是这两种状态，则退出。
                    {
                        // 主动退出也会影响异步线程的接收，因此先进行判断
                        txtInfo.AppendText("接收服务端数据:连接状态异常，退出循环接收，请检查" + DateTime.Now.ToString() + "\n");
                        return;
                    }
                    var result = await cWebSocket.ReceiveAsync(new ArraySegment<byte>(array), CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        // 获取字节数组并转为字符串，此字符串应为json类型，需要反序列化
                        string jsonMsg = Encoding.UTF8.GetString(array, 0, result.Count);

                        // 逻辑处理-显示到数据框
                        ProcessData(jsonMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                txtInfo.AppendText(cWebSocket.State.ToString());
                if (ex.GetType().ToString() == "System.Net.WebSockets.WebSocketException" && cWebSocket.State != WebSocketState.Open)  // 客户端关闭时会抛出此错误
                {
                    txtInfo.AppendText("连接被关闭，请检查网络或服务器" + DateTime.Now.ToString() + "\n");
                }
                else
                {
                    txtInfo.AppendText(ex.ToString() + DateTime.Now.ToString() + "\n");
                }
            }
        }

        /// <summary>
        /// 逻辑处理-显示到数据框
        /// </summary>
        private void ProcessData(string jsonMsg)
        {
            try
            {
                // 显示到显示框   
                WSMsg wsMsg = JsonConvert.DeserializeObject<WSMsg>(jsonMsg);
                string msgHeadstr = "姓名：" + wsMsg.Name + ",年龄：" + wsMsg.Age + ",性别：" + wsMsg.Gender + ",地区：" + wsMsg.Region;
                txtInfo.AppendText(msgHeadstr);
                txtInfo.AppendText("消息:" + wsMsg.MsgData);
            }
            catch (Exception ex)
            {
                //如果json反序列化出了问题
                txtInfo.AppendText(ex.ToString() + DateTime.Now.ToString() + "\n");//将错误类型显示出来
                txtInfo.AppendText(jsonMsg + "\n");//将收到的原始字符串显示出来
            }
        }
        #endregion
    }

    // 通讯的数据
    public class WSMsg
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 年龄
        /// </summary>
        public string Age { set; get; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { set; get; }

        /// <summary>
        /// 地区
        /// </summary>
        public string Region { set; get; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string MsgData { set; get; }
    }
}
