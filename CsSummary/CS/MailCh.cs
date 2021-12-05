using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CheetNetCoreMVC.CS
{
    public class MailCh
    {
        public class MailSend
        {
            public string SmtpServer { get; set; }
            public int PortNo { get; set; }
            public string FromAddress { get; set; }
            public string ToAddress { get; set; }
            public string Subject { get; set; }
            public string MainText { get; set; }

            //認証が必要な場合
            public bool NeedsAuth { get; set; }
            public string AuthId { get; set; }
            public string AuthPassword { get; set; }

            //添付ファイルがある場合
            //public string AttachedFileName { get; set; }
            //public string AttachedFilePath { get; set; }

        }

        //Outlook以外で送信
        public void SendMail(MailSend ms)
        {
            string host = ms.SmtpServer;
            int port = ms.PortNo;

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {

                //SMTPサーバに接続する
                smtp.Connect(host, port, MailKit.Security.SecureSocketOptions.Auto);

                if (ms.NeedsAuth)
                {
                    smtp.Authenticate(ms.AuthId, ms.AuthPassword);
                }

                //送信するメールを作成する
                var mail = new MimeKit.MimeMessage();
                var builder = new MimeKit.BodyBuilder();
                mail.From.Add(new MimeKit.MailboxAddress("", ms.FromAddress));
                mail.To.Add(new MimeKit.MailboxAddress("", ms.ToAddress));
                mail.Subject = ms.Subject;
                builder.TextBody = ms.MainText;
                mail.Body = builder.ToMessageBody();

                //メールを送信する
                smtp.Send(mail);

                //SMTPサーバから切断する
                smtp.Disconnect(true);
            }
        }

        //Outlookで送信
        public void SendOutlookMail()
        {

        }

    }
}