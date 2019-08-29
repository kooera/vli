/**
*
* 功 能： N/A
* 类 名： CmdHelper
* 作 者： weili
* 时 间： 2019/6/8 21:58:33
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Vli.Helper
{
    public class CmdHelper
    {
        private Process proc = null;
        private string logName = "";

        public CmdHelper()
        {
            string dir = Environment.CurrentDirectory + "\\cmdLog\\";
            if (!dir.EndsWith("\\"))
            {
                dir = dir + "\\";
            }
            logName = DirFileHelper.CreateDirectory(dir) + DateTime.Now.ToString("yyyyMMddhhmmssfffff") + ".log";
            proc = new Process();
        }

        public CmdHelper(string logPath)
        {
            if (logPath.EndsWith("\\"))
            {
                logName = DirFileHelper.CreateDirectory(logPath) + DateTime.Now.ToString("yyyyMMddhhmmssfffff") + ".log";
            }
            else
            {
                logName = DirFileHelper.CreateDirectory(logPath) + "\\" + DateTime.Now.ToString("yyyyMMddhhmmssfffff") + ".log";
            }

            proc = new Process();
        }

        public void Execute(string cmd, out string msg)
        {
            msg = "";
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.Start();

            if (!string.IsNullOrEmpty(cmd))
            {
                proc.StandardInput.WriteLine(cmd.TrimEnd('&') + "&exit");
                proc.StandardInput.AutoFlush = true;
            }
            msg = proc.StandardOutput.ReadToEnd();

            proc.WaitForExit();
            proc.Close();

            DirFileHelper.WriteFile(logName, msg + "\n end");
        }

        public void Execute(string cmd)
        {
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;

            proc.OutputDataReceived += new DataReceivedEventHandler(OutputDataReceived);
            proc.Start();

            proc.BeginOutputReadLine();
            if (!string.IsNullOrEmpty(cmd))
            {
                proc.StandardInput.WriteLine(cmd.TrimEnd('&') + "&exit");
                proc.StandardInput.AutoFlush = true;
            }

            proc.WaitForExit();
            proc.Close();
        }

        public void ExecuteTask(string cmd)
        {
            Task ts = new Task(() => Execute(cmd));            
            ts.Start();
        }

        private void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                string str = "[" + DateTime.Now.ToString() + "]    " + e.Data;
                DirFileHelper.WriteFile(logName, str);
            }
        }
    }
}
