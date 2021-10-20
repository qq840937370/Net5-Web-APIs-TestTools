
namespace WebserviceWcfWebAPITestTool.Get_And_Post_Test
{
    partial class PostRequest
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtJSONstr = new System.Windows.Forms.TextBox();
            this.txtReJson = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL：";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(63, 16);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(806, 27);
            this.txtURL.TabIndex = 1;
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTest.Location = new System.Drawing.Point(889, 10);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(107, 38);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "请求";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtJSONstr
            // 
            this.txtJSONstr.Location = new System.Drawing.Point(12, 65);
            this.txtJSONstr.Multiline = true;
            this.txtJSONstr.Name = "txtJSONstr";
            this.txtJSONstr.Size = new System.Drawing.Size(480, 442);
            this.txtJSONstr.TabIndex = 4;
            // 
            // txtReJson
            // 
            this.txtReJson.Location = new System.Drawing.Point(516, 65);
            this.txtReJson.Multiline = true;
            this.txtReJson.Name = "txtReJson";
            this.txtReJson.Size = new System.Drawing.Size(480, 442);
            this.txtReJson.TabIndex = 5;
            // 
            // PostRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 519);
            this.Controls.Add(this.txtReJson);
            this.Controls.Add(this.txtJSONstr);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label1);
            this.Name = "PostRequest";
            this.Text = "Post请求";
            this.Load += new System.EventHandler(this.Post请求_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtJSONstr;
        private System.Windows.Forms.TextBox txtReJson;
    }
}