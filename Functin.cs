using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace MCOLLECTION_FOLLOWUP_UPDATE
{
    class Functions
    {
        MailConfig objmail = new MailConfig();
        DatabaseConnections objdb = new DatabaseConnections();
        public int FunRunTableinsert()
        {
            int ires = 0;
            try
            {
                objdb.FunRunTableInsert();
            }
            catch (Exception ex)
            {
                objmail.SendEmail("Error while M Collection Followup update", " FunRunTableinsert : " + ex.ToString());
                ires = -1;
            }
            return ires;
        }

