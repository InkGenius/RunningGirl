namespace RunningGirl
{       
    public class DownloadItem
    {   
        private string code;
        private string url;

        public DownloadItem(string code, string url)
        {
            this.code = code;
            this.url = url;
        }

        public string Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }
        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }
    }
}
