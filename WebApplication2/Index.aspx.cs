using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace WebApplication2
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/assets/plugins/jquery.min.js"
            }
        );
        }


        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        public void SendMessage()
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add("d.a.shimanov@gmail.com");
            mailMessage.From = new MailAddress("d.a.shimanov@gmail.com");
            mailMessage.Subject = "Тема сообщения: С лэндинга";

            mailMessage.Body = "Имя отправителя: " + nameTbx.Text +
                                "<br><br>" +
                                "Email: " + emailTbx.Text +
                                "<br><br>" +
                                "Номер телефона: " + companyTbx.Text +
                                "<br><br>" +
                                "Сообщение: " + messageTbx.Text;
            mailMessage.IsBodyHtml = true;

            SmtpClient smtp = new
                 SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("d.a.shimanov@gmail.com", "#2^_^-*194qwerk%zl'''><");
            smtp.Send(mailMessage);
        }

        protected void submitBtn_Click1(object sender, EventArgs e)
        {
            SendMessage();
        }
    }
}