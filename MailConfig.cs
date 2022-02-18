using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace MCOLLECTION_FOLLOWUP_UPDATE
{
    class MailConfig
    {
        public void SendEmail(string subject, string body)
        {

            //Reading sender Email credential from web.config file                     
            string MailStatus = ConfigurationManager.AppSettings["MailStat"].ToString();
            string toAddress = ConfigurationManager.AppSettings["ToMail"].ToString();
            string senderID = ConfigurationManager.AppSettings["FromMail"].ToString();
            string CCAddress = ConfigurationManager.AppSettings["CCMail"].ToString();
