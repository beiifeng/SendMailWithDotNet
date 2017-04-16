using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SendMail.Model.Entity
{
    public class ImageEntity
    {
        private string imageUuid;
        private string imagePath;

        /// <summary>
        /// 图片相对路径
        /// </summary>
        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

        /// <summary>
        /// 图片唯一标识
        /// </summary>
        public string ImageUuid
        {
            get { return imageUuid; }
            set { imageUuid = value; }
        }

    }
}
