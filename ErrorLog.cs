using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace Legal_Mail_Matrix
{
    class ErrorLog
    {
         public static string strLogFilePath = string.Empty;
        public static bool blnEnableLog = false;
        private static StreamWriter sw = null;

        /// <summary>
        /// Setting LogFile path. If the logfile path is null then it will update error info into LogFile.txt under
        /// application directory.
        /// </summary>
        public static string LogFilePath
        {
            set
            {
                strLogFilePath = value;
            }
            get
            {
                return strLogFilePath;
            }
        }

        public static bool EnableLog
        {
            set
            {
                blnEnableLog = value;
            }
            get
            {
                return blnEnableLog;
            }
        }

        /// <summary>
        /// Write Source,method,date,time,computer,error and stack trace information to the text file
        /// </summary>
        /// <param name="strPathName"></param>
        /// <param name="objException"></param>
        /// <returns>false if the problem persists</returns>
        public static bool WriteErrorLog(string strPathName, Exception objException)
        {
            bool bReturn = false;
            string strException = string.Empty;
            try
            {
                StringBuilder sb = new StringBuilder();
                sw = new StreamWriter(strPathName, true);
                sb.AppendLine("Source		: " + objException.Source.ToString().Trim());
                sb.AppendLine("Method		: " + objException.TargetSite.Name.ToString());
                sb.AppendLine("Date		: " + DateTime.Now.ToLongTimeString());
                sb.AppendLine("Time		: " + DateTime.Now.ToShortDateString());
                sb.AppendLine("Computer	: " + Dns.GetHostName().ToString());
                sb.AppendLine("Error		: " + objException.Message.ToString().Trim());
                sb.AppendLine("Stack Trace	: " + objException.StackTrace.ToString().Trim());
                sb.AppendLine("^^-------------------------------------------------------------------^^");
                File.AppendAllText(strPathName, sb.ToString());
                bReturn = true;
            }
            catch (Exception)
            {
                bReturn = false;
            }
            return bReturn;
        }
