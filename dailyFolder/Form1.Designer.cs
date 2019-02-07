namespace dailyFolder
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBox_targetPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_SelectFolder = new System.Windows.Forms.Button();
            this.textArea = new System.Windows.Forms.TextBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBox_targetPath
            // 
            this.txtBox_targetPath.Location = new System.Drawing.Point(106, 13);
            this.txtBox_targetPath.Name = "txtBox_targetPath";
            this.txtBox_targetPath.ReadOnly = true;
            this.txtBox_targetPath.Size = new System.Drawing.Size(495, 19);
            this.txtBox_targetPath.TabIndex = 0;
            this.txtBox_targetPath.WordWrap = false;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "処理の対象となるフォルダを選択してください。";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // btn_SelectFolder
            // 
            this.btn_SelectFolder.Location = new System.Drawing.Point(13, 13);
            this.btn_SelectFolder.Name = "btn_SelectFolder";
            this.btn_SelectFolder.Size = new System.Drawing.Size(87, 23);
            this.btn_SelectFolder.TabIndex = 1;
            this.btn_SelectFolder.Text = "フォルダを選択";
            this.btn_SelectFolder.UseVisualStyleBackColor = true;
            this.btn_SelectFolder.Click += new System.EventHandler(this.btn_SelectFolder_Click);
            // 
            // textArea
            // 
            this.textArea.Location = new System.Drawing.Point(13, 43);
            this.textArea.Multiline = true;
            this.textArea.Name = "textArea";
            this.textArea.ReadOnly = true;
            this.textArea.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textArea.Size = new System.Drawing.Size(588, 395);
            this.textArea.TabIndex = 2;
            this.textArea.WordWrap = false;
            // 
            // btn_Start
            // 
            this.btn_Start.Enabled = false;
            this.btn_Start.Location = new System.Drawing.Point(13, 445);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_Start.TabIndex = 3;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 477);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.textArea);
            this.Controls.Add(this.btn_SelectFolder);
            this.Controls.Add(this.txtBox_targetPath);
            this.Name = "Form1";
            this.Text = "DailyFolder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox_targetPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_SelectFolder;
        private System.Windows.Forms.TextBox textArea;
        private System.Windows.Forms.Button btn_Start;
    }
}

