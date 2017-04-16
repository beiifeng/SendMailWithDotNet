using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using SendMail.DAL;
using SendMail.Model.Entity;

namespace SendMail.BLL
{
    public class MailManage
    {

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="strTo">收件人</param>
        /// <param name="strCc">抄送</param>
        /// <param name="strSubject">主题</param>
        /// <param name="strBody">正文</param>
        /// <param name="lisImage">图片</param>
        /// <returns></returns>
        public string SendMail2(string strTo, string strCc, string strSubject, string strBody, List<ImageEntity> lisImage)
        {
            try
            {
                List<AddressEntity> lisTo = new List<AddressEntity>();
                List<AddressEntity> lisCc = new List<AddressEntity>();
                #region lisTo
                if (strTo!= null)
                {
                    var tos = strTo.Trim().Split(new[] {';'},StringSplitOptions.RemoveEmptyEntries).Distinct();
                    foreach (string to in tos)
                    {
                        AddressEntity address = new AddressEntity() { MailAddress = to, DisplayName = to.Split('@')[0] };
                        lisTo.Add(address);
                    }
                }
                #endregion lisTo
                #region lisCc
                if (strCc != null)
                {
                    var ccs = strCc.Trim().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Distinct();
                    foreach (string cc in ccs)
                    {
                        AddressEntity address = new AddressEntity() { MailAddress = cc, DisplayName = cc.Split('@')[0] };
                        lisCc.Add(address);
                    }
                }
                #endregion lisCc
                MailHelper.SendMail2(lisTo, lisCc, strSubject, strBody, false, lisImage);
                return("发送成功");
            }
            catch (Exception ex)
            {
                return (ex.Message.ToString());
            }
        }

    }
}