using FaspService;
using System.Windows.Forms;

namespace RunningGirl
{
    public partial class Form1 : Form
    {
        private string path = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void selectBtn_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.selectedTextBox.Text = f.SelectedPath;
                path = f.SelectedPath;
            }
        }

        private void downloadBtn_Click(object sender, System.EventArgs e)
        {
            bool downloadMan = false;
            bool downloadWomen = false;

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("请选择下载地址！");
            }
            else if (!this.manCheckBox.Checked && !this.womenCheckBox.Checked)
            {
                MessageBox.Show("请选择下载性别！");
            }
            else
            {
                if(this.manCheckBox.Checked)
                {
                    downloadMan = true;
                }

                if (this.manCheckBox.Checked)
                {
                    downloadWomen = true;
                }
                ConsoleShow.AllocConsole();
                Downloader d = new Downloader(path, downloadMan, downloadWomen);
                //DownloadImage d = new DownloadImage();
                
            }
        }
    }
}
