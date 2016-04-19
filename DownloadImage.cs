using FaspBrowser.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;

namespace RunningGirl
{
    public class DownloadImage
    {
        private List<downloadObject> downloadFileList;

        private ManualResetEvent evtDownload = null;
        private ManualResetEvent evtPerDownload = null;
        private WebClient clientDownload = null;

        private String jsonFolder;
        private String imageFolder;
        public DownloadImage(string dir)
        {
            downloadFileList = new List<downloadObject>();
            jsonFolder = dir + "/json";
            imageFolder = dir + "/image";

            if (!Directory.Exists(jsonFolder))
            {
                Directory.CreateDirectory(jsonFolder);
            }

            if (!Directory.Exists(imageFolder))
            {
                Directory.CreateDirectory(imageFolder);
            }

            DirectoryInfo folder = new DirectoryInfo(jsonFolder);
            foreach (FileInfo file in folder.GetFiles("*"))
            {
                string json = File.ReadAllText(file.FullName);
                ParseJson(json);
            }

            evtDownload = new ManualResetEvent(true);
            evtDownload.Reset();
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.DownloadFiles));

        }

        public void ParseJson(string json)
        {
            JsonObject obj = JsonUtils.DeserializeJsonToObject<JsonObject>(json);

            if (obj.Data.Picture_num > 0)
            {
                for (int i = 0; i < obj.Data.Picture_num; i++)
                {
                    downloadFileList.Add(new downloadObject(obj.Data.Pictures[i].Id, obj.Data.Pictures[i].Path));
                }
            }
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
                    downloadObject file = this.downloadFileList[0];

                    Console.WriteLine(String.Format("Start Download image:{0}", file.Id + ".jpg"));

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
                            Console.WriteLine(String.Format("Downloaded image:{0}", file.Id + ".jpg"));
                            evtPerDownload.Set();

                        }
                        catch (Exception exp)
                        {
                            Debug.WriteLine(exp.Message);
                        }
                    };

                    evtPerDownload.Reset();

                    System.Guid guid = new Guid();
                    guid = Guid.NewGuid();
                    string str = guid.ToString();

                    clientDownload.DownloadFileAsync(new Uri(file.Path), Path.Combine(imageFolder, file.Id + ".jpg"), file);
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

            if (downloadFileList.Count > 0)
            {
                return;
            }

            Console.WriteLine("All image Downloaded");
            evtDownload.Set();
        }
    }
}
