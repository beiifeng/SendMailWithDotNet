using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.Net;
using SendMail.Model.Entity;
using System.Net.Mime;
using System.Web;

namespace SendMail.DAL
{
    public class MailHelper
    {
        #region 字段

        /// <summary>
        /// 发送邮件服务器地址
        /// </summary>
        private static string mailServer = ConfigurationManager.AppSettings["MailServer"];

        /// <summary>
        /// 发送邮件服务器端口
        /// </summary>
        private static string mailPort = ConfigurationManager.AppSettings["MailPort"];

        /// <summary>
        /// 邮箱登陆用户名
        /// </summary>
        private static string mailLoginAccount = ConfigurationManager.AppSettings["MailLoginName"];

        /// <summary>
        /// 邮箱登录密码
        /// </summary>
        private static string mailLoginPassword = ConfigurationManager.AppSettings["MailLoginPWD"];

        /// <summary>
        /// 邮箱地址
        /// </summary>
        private static string mailSender = ConfigurationManager.AppSettings["MailFromUser"];

        /// <summary>
        /// 邮件发送者名称
        /// </summary>
        private static string mailSenderName = ConfigurationManager.AppSettings["MailFromName"];

        /// <summary>
        /// 是否发送邮件
        /// </summary>
        private static bool isSendMail = bool.Parse(ConfigurationManager.AppSettings["IsSendMail"]);

        #endregion

        #region 方法

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="lisTo">收件人</param>
        /// <param name="lisCc">抄送</param>
        /// <param name="strSubject">主题</param>
        /// <param name="strBody">正文</param>
        /// <param name="isImportant">是否重要</param>
        /// <param name="lisImage">图片</param>
        public static void SendMail2(List<AddressEntity> lisTo, List<AddressEntity> lisCc, string strSubject, string strBody, bool isImportant, List<ImageEntity> lisImage)
        {
            //System.Diagnostics.Debug.WriteLine("Begin Mail:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff"));
            MailMessage mailMessage = new MailMessage();
            #region mailMessage.From
            mailMessage.From = new MailAddress(mailSender, mailSenderName);
            #endregion mailMessage.From
            #region mailMessage.To
            if (lisTo != null)
            {
                foreach (AddressEntity to in lisTo)
                {
                    mailMessage.To.Add(new MailAddress(to.MailAddress, to.DisplayName));
                }
            }
            #endregion mailMessage.To
            #region mailMessage.CC
            if (lisCc != null)
            {
                foreach (AddressEntity cc in lisCc)
                {
                    mailMessage.CC.Add(new MailAddress(cc.MailAddress, cc.DisplayName));
                }
            }
            #endregion mailMessage.CC
            #region mailMessage.Priority 设置邮件重要性
            mailMessage.Priority = isImportant ? MailPriority.High : MailPriority.Normal;
            #endregion mailMessage.Priority 设置邮件重要性
            mailMessage.Subject = strSubject;
            #region mailMessage.AlternateView 富媒体形式的邮件正文
            #region 格式化正文
            int tagIndex = 1;
            int tagTimes = 0;
            while (tagIndex>0)
            {
                tagIndex = strBody.IndexOf("<img", tagIndex + 1);
                if (tagIndex > 0)
                {
                    string contentId = lisImage[tagTimes].ImageUuid;
                    strBody = strBody.Insert(tagIndex + 4, " src=\"cid:" + contentId + "\" ");
                    tagIndex++;
                    tagTimes++;
                }
            }
            #endregion 格式化正文
            #region 添加媒体内容
            AlternateView formatedBody = AlternateView.CreateAlternateViewFromString(strBody, Encoding.GetEncoding("UTF-8"), "text/html");
            if (lisImage.Count > 0)
            {
                for (int i = 0; i < lisImage.Count; i++)
                {
                    LinkedResource lrImage = new LinkedResource(HttpContext.Current.Server.MapPath(lisImage[i].ImagePath), MediaTypeNames.Image.Jpeg);
                    lrImage.ContentId = lisImage[i].ImageUuid;
                    formatedBody.LinkedResources.Add(lrImage);
                }
            }
            #endregion 添加媒体内容
            mailMessage.AlternateViews.Add(formatedBody);
            #endregion mailMessage.AlternateView 富媒体形式的邮件正文
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = mailServer;
            smtpClient.Port = Convert.ToInt32(mailPort);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(mailLoginAccount, mailLoginPassword);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = false;
            #region smtpClient.Send
            if (isSendMail)
            {
                //System.Diagnostics.Debug.WriteLine("Begin Send:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff"));
                smtpClient.Send(mailMessage);
                //System.Diagnostics.Debug.WriteLine("End Send:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff"));
            }
            #endregion smtpClient.Send

        }

        #endregion 方法
    }
}