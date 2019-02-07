using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dailyFolder
{
    public partial class Form1 : Form
    {
        const int WM_GETTEXTLENGTH = 0x000E;
        const int EM_SETSEL = 0x00B1;
        const int EM_REPLACESEL = 0x00C2;

        List<string[]> taskList = new List<string[]>();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, int lParam);

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_SelectFolder_Click(object sender, EventArgs e)
        {
            //フォルダ選択ダイアログがキャンセルされた場合、何もしない
            if(folderBrowserDialog1.ShowDialog() != DialogResult.OK){
                return;
            }
            taskList.Clear();
            txtBox_targetPath.Text = folderBrowserDialog1.SelectedPath;
            btn_Start.Enabled = true;

            textArea.Text = "";
            SendMessage(textArea.Handle, EM_REPLACESEL, 1, "以下の処理が実行されます。\r\n");
            SendMessage(textArea.Handle, EM_REPLACESEL, 1, "----------------------------------------\r\n");

            var fileList = Directory.EnumerateFiles(folderBrowserDialog1.SelectedPath,"*");
            if (!fileList.Any())
            {
                SendMessage(textArea.Handle, EM_REPLACESEL, 1, "対象ファイルなし\r\n");
                btn_Start.Enabled = false;
                return;
            }

            foreach (var filePath in fileList)
            {
                var fileAttr = File.GetAttributes(filePath);
                //隠しファイルは対象外
                if ((fileAttr & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    continue;
                }

                var fileName = Path.GetFileName(filePath);
                var createDate = File.GetCreationTime(filePath).ToString("yyyyMMdd");

                var job = new string[] { fileName, createDate };
                taskList.Add(job);

                SendMessage(textArea.Handle, EM_REPLACESEL, 1, fileName +"　が　" + createDate + "　フォルダへ移動します。\r\n");
            }

            SendMessage(textArea.Handle, EM_REPLACESEL, 1, "----------------------------------------\r\n");
            SendMessage(textArea.Handle, EM_REPLACESEL, 1, "Start ボタンをクリックし、処理を実行してください。\r\n");
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            btn_Start.Enabled = false;
            SendMessage(textArea.Handle, EM_REPLACESEL, 1, "\r\n\r\n\r\n");
            SendMessage(textArea.Handle,EM_REPLACESEL,1,"ファイルの移動を実行します。\r\n");
            SendMessage(textArea.Handle, EM_REPLACESEL, 1, "----------------------------------------\r\n");

            foreach (var job in taskList)
            {
                if (!Directory.Exists(folderBrowserDialog1.SelectedPath + "\\" + job[1]))
                {
                    Directory.CreateDirectory(folderBrowserDialog1.SelectedPath + "\\" + job[1]);
                    SendMessage(textArea.Handle, EM_REPLACESEL, 1, job[1] + "　フォルダを作成しました。\r\n");
                }
                try
                {
                    File.Move(folderBrowserDialog1.SelectedPath + "\\" + job[0], folderBrowserDialog1.SelectedPath + "\\" + job[1] + "\\" + job[0]);
                    SendMessage(textArea.Handle, EM_REPLACESEL, 1, job[0] + "　を　" + job[1] + "　フォルダへ移動しました。\r\n");
                }
                catch (IOException)
                {
                    SendMessage(textArea.Handle, EM_REPLACESEL, 1, job[0] + "　が既に移動先へ存在します。ファイルの移動をスキップします。\r\n");
                }
            }
            taskList.Clear();
            SendMessage(textArea.Handle, EM_REPLACESEL, 1, "----------------------------------------\r\n");
            SendMessage(textArea.Handle, EM_REPLACESEL, 1, "処理が完了しました。\r\n");
        }
    }
}
