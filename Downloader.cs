using RunningGirl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;

namespace FaspService
{
    public class Downloader
    {
        private List<DownloadItem> downloadFileList = null;

        private ManualResetEvent evtDownload = null;
        private ManualResetEvent evtPerDownload = null;
        private WebClient clientDownload = null;

        private String downloadFolder;
        private String downloadRoot;

        public Downloader(string dir,bool downloadMan , bool downloadWomen)
        {
            downloadFileList = new List<DownloadItem>();
            downloadRoot = dir;
            downloadFolder = dir + "/json";

            if (!Directory.Exists(downloadFolder))
            {
                Directory.CreateDirectory(downloadFolder);
            }

            if (downloadMan)
            {
                for (int i = 1; i <= 16000; i++)
                {
                    string num = buildZero(i);
                    string url = "http://www.osports.cn/running/j/searchPicture?code=as4UW028&number=M" + num;
                    DownloadItem item = new DownloadItem("M" + num, url);
                    downloadFileList.Add(item);
                }
            }

            if (downloadWomen)
            {
                for (int i = 1; i <= 4800; i++)
                {
                    string num = buildZero(i);
                    string url = "http://www.osports.cn/running/j/searchPicture?code=as4UW028&number=F" + num;
                    DownloadItem item = new DownloadItem("F" + num, url);
                    downloadFileList.Add(item);
                }
            }

            evtDownload = new ManualResetEvent(true);
            evtDownload.Reset();
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.DownloadFiles));
        }

        public string buildZero(int i){
            string num = "" + i;
            string res = "";
            switch (num.Length)
            {
                case 1:
                    res = "0000" + i;
                    break;
                case 2:
                    res = "000" + i;
                    break;
                case 3:
                    res = "00" + i;
                    break;
                case 4:
                    res = "0" + i;
                    break;
                default:
                    res = num;
                    break;
            }
            return res;
        }

        /// <summary>
        /// 下载批量文件
        /// </summary>
        /// <param name="o"></param>
        private void DownloadFiles(object o)
        {
            evtPerDownload = new ManualResetEvent(false);

            try
            {
                // 收到信号则继续
                while (!evtDownload.WaitOne(0, false))
                {
                    // 没有下载任务就退出
                    if (this.downloadFileList.Count == 0)
                        break;
                    // 每次取第一个文件进行下载，下载完再移出队列
                    DownloadItem file = this.downloadFileList[0];

                    Console.WriteLine(String.Format("Start Download json file :{0}", file.Code));

                    //开始下载
                    clientDownload = new WebClient();

                    //设置此 WebClient 对象使用的代理
                    clientDownload.Proxy = WebRequest.GetSystemWebProxy();
                    clientDownload.Proxy.Credentials = CredentialCache.DefaultCredentials;
                    clientDownload.Credentials = System.Net.CredentialCache.DefaultCredentials;

                    clientDownload.DownloadFileCompleted += (object sender, AsyncCompletedEventArgs e) =>
                    {
                        try
                        {
                            evtPerDownload.Set();
                        }
                        catch (Exception exp)
                        {
                            Debug.WriteLine(exp.Message);
                        }
                    };

                    evtPerDownload.Reset();

                    clientDownload.DownloadFileAsync(new Uri(file.Url), Path.Combine(downloadFolder, file.Code), file);
                    evtPerDownload.WaitOne();
                    clientDownload.Dispose();
                    clientDownload = null;
                    this.downloadFileList.Remove(file);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("下载异常:" + e.Message);
            }

            //文件没有下载完就返回
            if (downloadFileList.Count > 0)
            {
                return;
            }

            Console.WriteLine("All Json file Downloaded!");

            DownloadImage down = new DownloadImage(downloadRoot);
            evtDownload.Set();
        }

    }
}
