
namespace SocketWebserviceWcfWebAPITestTool.Socket_Test
{
    partial class WinSockerServer1Test
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpenServer = new System.Windows.Forms.Button();
            this.lblListen = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBvalue = new System.Windows.Forms.TextBox();
            this.txtAvalue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSendMsg.Location = new System.Drawing.Point(244, 52);
            this.btnSendMsg.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(100, 48);
            this.btnSendMsg.TabIndex = 21;
            this.btnSendMsg.Text = "发送";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(68, 15);
            this.txtIPAddress.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(200, 23);
            this.txtIPAddress.TabIndex = 16;
            this.txtIPAddress.Text = "ws://10.206.14.152:8080";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "监听地址";
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(271, 14);
            this.btnModify.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(73, 25);
            this.btnModify.TabIndex = 14;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(19, 60);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 25);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "关闭监听";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpenServer
            // 
            this.btnOpenServer.Location = new System.Drawing.Point(19, 11);
            this.btnOpenServer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnOpenServer.Name = "btnOpenServer";
            this.btnOpenServer.Size = new System.Drawing.Size(73, 25);
            this.btnOpenServer.TabIndex = 10;
            this.btnOpenServer.Text = "开启监听";
            this.btnOpenServer.UseVisualStyleBackColor = true;
            this.btnOpenServer.Click += new System.EventHandler(this.btnOpenServer_Click);
            // 
            // lblListen
            // 
            this.lblListen.AutoSize = true;
            this.lblListen.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblListen.Location = new System.Drawing.Point(514, 22);
            this.lblListen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblListen.Name = "lblListen";
            this.lblListen.Size = new System.Drawing.Size(32, 17);
            this.lblListen.TabIndex = 25;
            this.lblListen.Text = "状态";
            this.lblListen.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(9, 125);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(604, 252);
            this.txtInfo.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnOpenServer);
            this.panel1.Location = new System.Drawing.Point(368, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 96);
            this.panel1.TabIndex = 22;
            // 
            // txtBvalue
            // 
            this.txtBvalue.Location = new System.Drawing.Point(68, 80);
            this.txtBvalue.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtBvalue.Name = "txtBvalue";
            this.txtBvalue.Size = new System.Drawing.Size(161, 23);
            this.txtBvalue.TabIndex = 20;
            // 
            // txtAvalue
            // 
            this.txtAvalue.Location = new System.Drawing.Point(68, 49);
            this.txtAvalue.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtAvalue.Name = "txtAvalue";
            this.txtAvalue.Size = new System.Drawing.Size(161, 23);
            this.txtAvalue.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "b：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "a：";
            // 
            // WinSockerServer1Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 382);
            this.Controls.Add(this.btnSendMsg);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.lblListen);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtBvalue);
            this.Controls.Add(this.txtAvalue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "WinSockerServer1Test";
            this.Text = "WinSockerServer1Test";
            this.Load += new System.EventHandler(this.WinSockerServer1Test_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpenServer;
        private System.Windows.Forms.Label lblListen;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBvalue;
        private System.Windows.Forms.TextBox txtAvalue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}