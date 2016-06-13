using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace SMTP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SendMail_tadc();
        } 
        public void sendmail4()
        {
              SmtpClient sc = new SmtpClient("ms14.hinet.net");//<-宣告的時候可以先給主機名稱~記住喔~這是發送端的主機名稱~
                sc.Port = 25;
                MailAddress receiverAddress = new MailAddress("i58540041@gmail.com", "潘建誌");//<-這物件只是用來設定郵件帳號而已~
                MailAddress senderAddress = new MailAddress("jacky@sysplus.com.tw", "精創");
                MailMessage mail = new MailMessage(senderAddress,receiverAddress);//<-這物件是郵件訊息的部分~需設定寄件人跟收件人~可直接打郵件帳號也可以使用MailAddress物件~
                mail.Subject="test";
                mail.Body = "<a href='http://tw.yahoo.com'>yahoo</a>";
                mail.IsBodyHtml = true;//<-如果要這封郵件吃html的話~這屬性就把他設為true~~
               
                //Attachment attachment = new Attachment(@"C:\Test\JackyTest.zip");//<-這是附件部分~先用附件的物件把路徑指定進去~
                
                //mail.Attachments.Add(attachment);//<-郵件訊息中加入附件
                
                sc.Send(mail);//<-這樣就送出去拉~
                Console.WriteLine("Done.");
        }
        public void SendMail3()
        {
            //設定smtp主機
            //SmtpClient mySmtp = new SmtpClient("smtp.hinet.net");
            SmtpClient mySmtp = new SmtpClient("pop3.live.com", 995);
           

            //設定smtp帳密
            //mySmtp.Credentials = new System.Net.NetworkCredential("user", "password");
            mySmtp.Credentials = new System.Net.NetworkCredential("i58540041@hotmail.com", "II241524");
            //信件內容
            string pcontect = "string or html";
            //設定mail內容
            MailMessage msgMail = new MailMessage();
            //寄件者
            msgMail.From = new MailAddress("i58540041@gmail.com");
            //收件者
            msgMail.To.Add("i58540041@gmail.com");
            //主旨
            msgMail.Subject = "信件主旨";

            //信件內容(含HTML時)
            AlternateView alt = AlternateView.CreateAlternateViewFromString(pcontect, null, "text/html");

            msgMail.AlternateViews.Add(alt);
            //寄mail
            mySmtp.Send(msgMail);
        }  
public void SendMail_G()
{
  //設定smtp主機
  //SmtpClient mySmtp = new SmtpClient("smtp.hinet.net");
    SmtpClient mySmtp = new SmtpClient("smtp.gmail.com",465);
    mySmtp.DeliveryMethod = SmtpDeliveryMethod.Network;
    mySmtp.UseDefaultCredentials = false;
  //設定smtp帳密
  //mySmtp.Credentials = new System.Net.NetworkCredential("user", "password");
    mySmtp.Credentials = new System.Net.NetworkCredential("i58540041@gmail.com", "II241524");
  //信件內容
  string pcontect = "string or html";
  //設定mail內容
  //MailMessage msgMail = new MailMessage();
  MailMessage msgMail = new MailMessage("i58540041@gmail.com", "i58540041@gmail.com");
  ////寄件者
  //msgMail.From = new MailAddress("i58540041@gmail.com");
  ////收件者
  //msgMail.To.Add("i58540041@gmail.com");
  //主旨
  msgMail.Subject = "信件主旨";
    
  //信件內容(含HTML時)
  AlternateView alt = AlternateView.CreateAlternateViewFromString(pcontect, null, "text/html");
   
  msgMail.AlternateViews.Add(alt);
  //寄mail
  mySmtp.Send(msgMail);
}
public void SendMail()
{
    //設定smtp主機
    //SmtpClient mySmtp = new SmtpClient("smtp.hinet.net");
    SmtpClient mySmtp = new SmtpClient("192.168.88.5");
    mySmtp.DeliveryMethod = SmtpDeliveryMethod.Network;
    //設定smtp帳密
    //mySmtp.Credentials = new System.Net.NetworkCredential("user", "password");
    //信件內容
    string pcontect = "string or html";
    //設定mail內容
    MailMessage msgMail = new MailMessage("i58540041@gmail.com", "i58540041@gmail.com");
    //MailMessage msgMail = new MailMessage();
    
    ////寄件者

    //msgMail.From = new MailAddress("i58540041@gmail.com");
    ////收件者
    //msgMail.To.Add("i58540041@gmail.com");
    //主旨
    msgMail.Subject = "信件主旨";
    //信件內容(含HTML時)
    AlternateView alt = AlternateView.CreateAlternateViewFromString(pcontect, null, "text/html");
    msgMail.AlternateViews.Add(alt);
    //寄mail
    mySmtp.Send(msgMail);
}
public void SendMail_tadc()
{
    //設定smtp主機
    //SmtpClient mySmtp = new SmtpClient("smtp.hinet.net");
    SmtpClient smtp = new SmtpClient("smtp.office365.com");
    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
    smtp.Port = 587;
    smtp.EnableSsl = true;
    smtp.Credentials = new System.Net.NetworkCredential("una.liao@cadmen.com", "Qq241524"); //設定smtp帳密

    string pcontect = "string";//信件內容
    //設定mail內容
    MailMessage msgMail = new MailMessage("i58540041@gmail.com", "i58540041@gmail.com");
    //MailMessage msgMail = new MailMessage(); 
    ////寄件者

    //msgMail.From = new MailAddress("i58540041@gmail.com");
    ////收件者
    //msgMail.To.Add("i58540041@gmail.com");
    //主旨
    msgMail.Subject = "信件主旨";
    msgMail.Body = "test";
    //信件內容(含HTML時)
    AlternateView alt = AlternateView.CreateAlternateViewFromString(pcontect, null, "text/html");
    msgMail.AlternateViews.Add(alt);
    //寄mail
    smtp.Send(msgMail);
}
private void button1_Click( )
{
    MailMessage mail = new MailMessage();
    NetworkCredential cred = new NetworkCredential("i58540041@gmail.com", "II241524");
    //收件者
    MailMessage msgMail = new MailMessage("i58540041@gmail.com", "i58540041@gmail.com");
    mail.Subject = "subject";
    //寄件者
    mail.From = new System.Net.Mail.MailAddress("i58540041@gmail.com");
    mail.IsBodyHtml = true;
    mail.Body = "message";
    //設定SMTP
    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
  
    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
    

    smtp.UseDefaultCredentials = false;
    smtp.EnableSsl = true;
    smtp.Credentials = new NetworkCredential("i58540041@gmail.com", "II241524");
    smtp.Port = 587;
//    Gmail SMTP port (TLS): 587
//Gmail SMTP port (SSL): 465
//Gmail SMTP TLS/SSL required: yes
    //送出Mail
    smtp.Send(mail);
}
    }
}
