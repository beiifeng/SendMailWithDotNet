using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SendMail.Model.Entity
{
    public class AddressEntity
    {
        private string displayName;
        private string mailAddress;


        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string MailAddress
        {
            get { return mailAddress; }
            set { mailAddress = value; }
        }

    }
}
