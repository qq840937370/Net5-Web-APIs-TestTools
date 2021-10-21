
namespace SocketWebserviceWcfWebAPITestTool.Get_And_Post_Test
{
    partial class PutRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PutRequest));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReJson = new System.Windows.Forms.TextBox();
            this.txtJSONstr = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(139, 409);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(638, 189);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "js中Put调用的方式：";
            // 
            // txtReJson
            // 
            this.txtReJson.Location = new System.Drawing.Point(404, 68);
            this.txtReJson.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtReJson.Multiline = true;
            this.txtReJson.Name = "txtReJson";
            this.txtReJson.Size = new System.Drawing.Size(373, 332);
            this.txtReJson.TabIndex = 12;
            // 
            // txtJSONstr
            // 
            this.txtJSONstr.Location = new System.Drawing.Point(13, 68);
            this.txtJSONstr.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtJSONstr.Multiline = true;
            this.txtJSONstr.Name = "txtJSONstr";
            this.txtJSONstr.Size = new System.Drawing.Size(374, 332);
            this.txtJSONstr.TabIndex = 11;
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTest.Location = new System.Drawing.Point(695, 9);
            this.btnTest.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(83, 32);
            this.btnTest.TabIndex = 10;
            this.btnTest.Text = "请求";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(53, 15);
            this.txtURL.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(628, 23);
            this.txtURL.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "URL：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "json文本：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "返回的结果：";
            // 
            // PutRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 604);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtReJson);
            this.Controls.Add(this.txtJSONstr);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label1);
            this.Name = "PutRequest";
            this.Text = "PutRequest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReJson;
        private System.Windows.Forms.TextBox txtJSONstr;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}