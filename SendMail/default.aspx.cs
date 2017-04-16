using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Drawing;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using SendMail.BLL;
using SendMail.Model.Entity;

namespace SendMail.Web
{
    public partial class _default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            this.SendMail();
        }


        public void SendMail()
        {
            List<ImageEntity> lisImage = new List<ImageEntity>();
            lisImage.Add(new ImageEntity()
            {
                ImagePath = "/public/5a.jpg",
                ImageUuid = Guid.NewGuid().ToString()
            });

            string strTo = this.txtTo.Text;

            StringBuilder strBody = new StringBuilder();
            strBody.Append("<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office ");
            strBody.Append("xmlns:w=\"urn:schemas-microsoft-com:office:word\" xmlns:m=\"http://schemas.microsoft.com/office/2004/12/omml ");
            strBody.Append("xmlns=\"http://www.w3.org/TR/REC-html40\">");
            strBody.Append("<head>");
            strBody.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\">");
            strBody.Append("<meta name=\"Generator\" content=\"Microsoft Word 15 (filtered medium)\">");
            strBody.Append("<!--[if !mso]><style>v\\:* {behavior:url(#default#VML);}");
            strBody.Append("o\\:* {behavior:url(#default#VML);}");
            strBody.Append("w\\:* {behavior:url(#default#VML);}");
            strBody.Append(".shape {behavior:url(#default#VML);}");
            strBody.Append("</style><![endif]--><style><!--");
            strBody.Append("/* Font Definitions */");
            strBody.Append("@font-face");
            strBody.Append("{font-family:宋体;");
            strBody.Append("panose-1:2 1 6 0 3 1 1 1 1 1;}");
            strBody.Append("@font-face");
            strBody.Append("{font-family:\"Cambria Math\";");
            strBody.Append("panose-1:2 4 5 3 5 4 6 3 2 4;}");
            strBody.Append("@font-face");
            strBody.Append("{font-family:Calibri;");
            strBody.Append("panose-1:2 15 5 2 2 2 4 3 2 4;}");
            strBody.Append("@font-face");
            strBody.Append("{font-family:\"\\@宋体\";");
            strBody.Append("panose-1:2 1 6 0 3 1 1 1 1 1;}");
            strBody.Append("/* Style Definitions */");
            strBody.Append("p.MsoNormal, li.MsoNormal, div.MsoNormal");
            strBody.Append("{margin:0cm;");
            strBody.Append("margin-bottom:.0001pt;");
            strBody.Append("text-align:justify;");
            strBody.Append("text-justify:inter-ideograph;");
            strBody.Append("font-size:10.5pt;");
            strBody.Append("font-family:\"Calibri\",sans-serif;}");
            strBody.Append("a:link, span.MsoHyperlink");
            strBody.Append("{mso-style-priority:99;");
            strBody.Append("color:#0563C1;");
            strBody.Append("text-decoration:underline;}");
            strBody.Append("a:visited, span.MsoHyperlinkFollowed");
            strBody.Append("{mso-style-priority:99;");
            strBody.Append("color:#954F72;");
            strBody.Append("text-decoration:underline;}");
            strBody.Append("span.EmailStyle17");
            strBody.Append("{mso-style-type:personal-compose;");
            strBody.Append("font-family:\"Calibri\",sans-serif;");
            strBody.Append("color:windowtext;}");
            strBody.Append(".MsoChpDefault");
            strBody.Append("{mso-style-type:export-only;");
            strBody.Append("font-family:\"Calibri\",sans-serif;}");
            strBody.Append("/* Page Definitions */");
            strBody.Append("@page WordSection1");
            strBody.Append("{size:612.0pt 792.0pt;");
            strBody.Append("margin:72.0pt 90.0pt 72.0pt 90.0pt;}");
            strBody.Append("div.WordSection1");
            strBody.Append("{page:WordSection1;}");
            strBody.Append("--></style><!--[if gte mso 9]><xml>");
            strBody.Append("<o:shapedefaults v:ext=\"edit\" spidmax=\"1026\" />");
            strBody.Append("</xml><![endif]--><!--[if gte mso 9]><xml>");
            strBody.Append("<o:shapelayout v:ext=\"edit\">");
            strBody.Append("<o:idmap v:ext=\"edit\" data=\"1\" />");
            strBody.Append("</o:shapelayout></xml><![endif]-->");
            strBody.Append("</head>");
            strBody.Append("<body lang=\"ZH-CN\" link=\"#0563C1\" vlink=\"#954F72\" style=\"text-justify-trim:punctuation\">");
            strBody.Append("<div class=\"WordSection1\">");
            strBody.Append("<p class=\"MsoNormal\"><span style=\"font-family:宋体\">这是测试邮件</span><span lang=\"EN-US\"><o:p></o:p></span></p>");
            strBody.Append("<p class=\"MsoNormal\"><span lang=\"EN-US\"><img width=\"500\" height=\"500\" /><o:p></o:p></span></p>");
            strBody.Append("</div>");
            strBody.Append("</body>");
            strBody.Append("</html>");
            MailManage mailManage = new MailManage();
            this.lbl1.Text = mailManage.SendMail2(strTo, "", "Nihao", strBody.ToString(), lisImage);
        }
    }
}