using System;
using System.Collections.Generic;
using System.Text;

namespace RunningGirl
{
    class JsonObject
    {
        private bool result;
        private bool isAccurate;
        private DataObject data;
        public bool Result
        {
            get
            {
                return result;
            }

            set
            {
                result = value;
            }
        }

        public bool IsAccurate
        {
            get
            {
                return isAccurate;
            }

            set
            {
                isAccurate = value;
            }
        }

        public DataObject Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }
    }

    class DataObject
    {
        private int picture_num;
        private List<downloadObject> pictures;

        public int Picture_num
        {
            get
            {
                return picture_num;
            }

            set
            {
                picture_num = value;
            }
        }

        public List<downloadObject> Pictures
        {
            get
            {
                return pictures;
            }

            set
            {
                pictures = value;
            }
        }

        public DataObject(int picture_num, List<downloadObject> pictures)
        {
            this.picture_num = picture_num;
            this.pictures = pictures;
        }
    }

    public class downloadObject
    {
        private string id;
        private string path;

        public downloadObject(string id, string path)
        {
            this.id = id;
            this.path = path;
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }
    }
}
