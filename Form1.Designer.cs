namespace RunningGirl
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.selectedTextBox = new System.Windows.Forms.TextBox();
            this.selectBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.manCheckBox = new System.Windows.Forms.CheckBox();
            this.womenCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.downloadBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择下载目录 : ";
            // 
            // selectedTextBox
            // 
            this.selectedTextBox.Location = new System.Drawing.Point(27, 71);
            this.selectedTextBox.Name = "selectedTextBox";
            this.selectedTextBox.Size = new System.Drawing.Size(285, 21);
            this.selectedTextBox.TabIndex = 1;
            // 
            // selectBtn
            // 
            this.selectBtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selectBtn.Location = new System.Drawing.Point(318, 69);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(75, 25);
            this.selectBtn.TabIndex = 2;
            this.selectBtn.Text = "浏览";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 3;
            // 
            // manCheckBox
            // 
            this.manCheckBox.AutoSize = true;
            this.manCheckBox.Location = new System.Drawing.Point(105, 109);
            this.manCheckBox.Name = "manCheckBox";
            this.manCheckBox.Size = new System.Drawing.Size(36, 16);
            this.manCheckBox.TabIndex = 4;
            this.manCheckBox.Text = "男";
            this.manCheckBox.UseVisualStyleBackColor = true;
            // 
            // womenCheckBox
            // 
            this.womenCheckBox.AutoSize = true;
            this.womenCheckBox.Location = new System.Drawing.Point(147, 109);
            this.womenCheckBox.Name = "womenCheckBox";
            this.womenCheckBox.Size = new System.Drawing.Size(36, 16);
            this.womenCheckBox.TabIndex = 5;
            this.womenCheckBox.Text = "女";
            this.womenCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(23, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "下载选项：";
            // 
            // downloadBtn
            // 
            this.downloadBtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.downloadBtn.Location = new System.Drawing.Point(472, 143);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(75, 23);
            this.downloadBtn.TabIndex = 7;
            this.downloadBtn.Text = "开始下载";
            this.downloadBtn.UseVisualStyleBackColor = true;
            this.downloadBtn.Click += new System.EventHandler(this.downloadBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 177);
            this.Controls.Add(this.downloadBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.womenCheckBox);
            this.Controls.Add(this.manCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.selectedTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "北京长跑节选手图片批量下载工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox selectedTextBox;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox manCheckBox;
        private System.Windows.Forms.CheckBox womenCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button downloadBtn;
    }
}

