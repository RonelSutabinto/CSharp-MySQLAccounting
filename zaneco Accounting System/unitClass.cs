using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;

namespace zaneco_Accounting_System
{
    class unitClass
    {
        //private static String titleMsg = "ZANECO Accounting System";
        private static String titleMsg = "ZANECO Accounting System";
        public DateTime StartOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        public DateTime EndOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        public CultureInfo ci = new CultureInfo("en-us");
        private connDBtmp db_accnt = new connDBtmp();
        private MySqlConnection conn_accnt = new MySqlConnection();

        public String getMsgFrm()
        {
            return titleMsg;
        }

        //=========ZanecoAccounting access===========
        //===========================================
        public void setConn_accnt()
        {
            conn_accnt = db_accnt.getConn();
            conn_accnt.Open();
        }

        public MySqlConnection getConn_accnt()
        {
            return conn_accnt;
        }

        public void closeConn_accnt()
        {
            conn_accnt.Close();
        }
        //=============================================

        public string CenterString(string stringToCenter, int totalLength)
        {
            /*return stringToCenter.PadLeft(((totalLength - stringToCenter.Length) / 2)
                                + stringToCenter.Length,'*')
                       .PadRight(totalLength,'*');*/

            return stringToCenter.PadLeft(((totalLength - stringToCenter.Length-22) / 2)
                                + stringToCenter.Length,'*')
                       .PadRight(totalLength+10, '*');

        }
        public string CenterAmntString(string stringToCenter, int totalLength)
        {
            return stringToCenter.PadLeft(((totalLength - stringToCenter.Length) / 2)
                                + stringToCenter.Length,'*')
                       .PadRight(totalLength,'*');                        
        }


        public class TestClass
        {
            public string Column1 { get; set; }
            public string Column2 { get; set; }
            public string Column3 { get; set; }
            public string Column4 { get; set; }
        }



        public DateTime LastDayOfYear()
        {
            return LastDayOfYear(DateTime.Today);
        }
        static DateTime LastDayOfYear(DateTime d)
        {
            DateTime n = new DateTime(d.Year + 1, 1, 1);
            return n.AddDays(-1);
        }


       
            
       public DateTime FirstDayOfYear()
       {
	        return FirstDayOfYear(DateTime.Today);
       }
       static DateTime FirstDayOfYear(DateTime y)
       {
	    return new DateTime(y.Year, 1, 1);
       }

        /*
         Proverbs 3:5-6
"With all your heart you mus trust the Lord and not your own judgment.Always let Him lead you, and He will clear the road for you to follow."
             */
        /*
         public void ExportToExcel(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                string filename = "DownloadMobileNoExcel.xls"; 
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = dt;
                dgGrid.DataBind();

                //Get the HTML for the control.
                dgGrid.RenderControl(hw);
                //Write the HTML back to the browser.
                //Response.ContentType = application/vnd.ms-excel;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
            }
        }

                     */
        //Start Amount To Words
        //=====================================================================D:\My Source Code\2018\zaneco\CSharp Code\Accounting\zaneco Accounting System\zaneco Accounting System\unitClass.cs
        //=====================================================================
        public String ToWords(Double value)
        {
            string decimals = "";
            string input = Math.Round(value, 2).ToString();

            if (input.Contains("."))
            {
                decimals = input.Substring(input.IndexOf(".") + 1);

                // remove decimal part from input
                input = input.Remove(input.IndexOf("."));
            }            

            // Convert input into words. save it into strWords
            string strWords = GetWords(input) + " Pesos";

            if (decimals.Length > 0)
            {
                // if there is any decimal part convert it to words and add it to strWords.
                //strWords += " and " + GetWords(decimals) + " Cents";
                strWords += " and " + decimals + "/100";
            }

            return strWords;
        }
        
        private static string GetWords(string input)
        {
            // these are seperators for each 3 digit in numbers. you can add more if you want convert beigger numbers.
            string[] seperators = { "", " Thousand ", " Million ", " Billion " };

            // Counter is indexer for seperators. each 3 digit converted this will count.
            int i = 0;

            string strWords = "";

            while (input.Length > 0)
            {
                // get the 3 last numbers from input and store it. if there is not 3 numbers just use take it.
                string _3digits = input.Length < 3 ? input : input.Substring(input.Length - 3);

                // remove the 3 last digits from input. if there is not 3 numbers just remove it.
                input = input.Length < 3 ? "" : input.Remove(input.Length - 3);

                int no = int.Parse(_3digits);

                // Convert 3 digit number into words.
                _3digits = GetWord(no);

                // apply the seperator.
                _3digits += seperators[i];

                // since we are getting numbers from right to left then we must append resault to strWords like this.
                strWords = _3digits + strWords;

                // 3 digits converted. count and go for next 3 digits
                i++;
            }
            return strWords;
        }
               
        // your method just to convert 3digit number into words.
        private static string GetWord(int no)
        {
            string[] Ones ={ "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
                             "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};

            string[] Tens = { "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            string word = "";

            if (no > 99 && no < 1000)
            {
                int i = no / 100;
                word = word + Ones[i - 1] + " Hundred ";
                no = no % 100;
            }

            if (no > 19 && no < 100)
            {
                int i = no / 10;
                word = word + Tens[i - 1] + " ";
                no = no % 10;
            }
                       
            if (no > 0 && no < 20)
            {
                word = word + Ones[no - 1];
            }            

            return word;
        }

        /*
         //=======================================================
         //=======================================================
         //===TO BE MODEFIED======================================

         //=====CHECK VOUCHER=====================================
         doctype(APV,RV)
         glaccountname
         //=======================================================

         //=======================================================
         //=======================================================

        */


        /*
         //=======================================================
         //=======================================================
         //===ALL JOURNAL NOT YET ISSUED CHECK====================
         Select 
            ja.*
            from
            (
            Select 
             IFNULL(a.docnumber,IFNULL(c.refnumber,NULL)) docno,
             IF(a.docnumber is not NULL,'APV',IF(c.refnumber is not NULL,'CV','')) doc,
             fnl.*
            from
            (
            Select 
            f.*,
            if(doctype = 'RV',r.idrequisition,p.idpo) identry,
            r.rvdate,
            r.rvpcode pcode,
            r.rvname pname,
            r.rvdescription
            from
            (
            SELECT 
            j.documentdate approveddate,
            if(j.documenttype ='RV','RV','PO') doctype,
            if(j.documenttype ='RV',j.documentnumber,j.documenttype) rvnumber,
            j.documentnumber,
            j.credit amountApprove

            FROM zanecobudget.journal j
             where j.documentdate between '2018-01-04'  and '2018-01-30' 
             group by j.documentnumber
             order by j.idjournal desc 
             ) f
             left join requisition r on r.rvnumber=f.rvnumber
             left join po p on p.ponumber = f.documentnumber 
             ) fnl
             left join zanecoaccounting.checkvoucher c on c.refnumber=fnl.documentnumber
             left join zanecoaccounting.apvoucher a on a.docnumber = fnl.documentnumber
             ) ja where ja.docno is null
         //==================================================
         //==================================================
         * 
         * 
         SELECT        TimeTrackEmployee.StaffID
           FROM            dbo.tblGBSTimeCard AS GBSTimeCard INNER JOIN
                         TimeTrak.dbo.tblEmployee AS TimeTrackEmployee ON GBSTimeCard.[Employee Number] = TimeTrackEmployee.GBSStaffID

         drop table `procapproved`;
        CREATE TABLE `procapproved` (
          `idprocApproved` int(11) NOT NULL AUTO_INCREMENT,
          `approveddate` date DEFAULT NULL,
          `doctype` varchar(5) DEFAULT NULL,
          `rvnumber` varchar(15) DEFAULT NULL,
          `documentnumber` varchar(15) DEFAULT NULL,
          `amountApprove` double(14,2) DEFAULT '0.00',
          `identry` int(11) DEFAULT NULL,
          `rvdate` date DEFAULT NULL,
          `pcode` varchar(50) DEFAULT NULL,
          `pname` varchar(55) DEFAULT NULL,
          `rvdescription` text,
          PRIMARY KEY (`idprocApproved`),
          KEY `index2` (`documentnumber`)
        ) ENGINE=InnoDB DEFAULT CHARSET=utf8;


         * * */


        //=====================================================================
        //=====================================================================
        //End Statement of Amount to Words

        //Amoun To Word Crystal Report
        //=====================================================================
        //=====================================================================
        /* numbervar RmVal:=0;
         numbervar Amt:=0;
         numbervar pAmt:=0;
         stringvar InWords :="";

         Amt :=3281.45;//3231397545.38; //25,12,000


         if Amt > 1000000000 then RmVal := truncate(Amt/1000000000); 
         if Amt = 1000000000 then RmVal := 1;

         if RmVal = 1 then
         InWords := InWords + " " + towords(RmVal,0) + " Billion" 
         else 
         if RmVal > 1 then InWords := InWords + " " + towords(RmVal,0) + " Billion";


         Amt := Amt - Rmval* 1000000000;

         if Amt > 1000000 then RmVal := truncate(Amt/1000000); 
         if Amt = 1000000 then RmVal := 1;

         if RmVal = 1 then
         InWords := InWords + " " + towords(RmVal,0) + " Million"
         Else
         If RmVal > 1 then InWords := InWords + " " + ToWords(RmVal,0) + " Million";

         Amt := Amt - Rmval* 1000000;

         if Amt > 0 then InWords := InWords + " " + towords(truncate(Amt),0);

                 pAmt := (Amt - truncate(Amt)) * 100;

         if pAmt > 0 then
         InWords := InWords + " Pesos and " + towords(pAmt,0) + " Cents" 
         else 
         InWords := InWords + " Pesos";

         ProperCase(InWords)*/
        //====================================================================
        //=====================================================================

        /* update row dbgrid
               foreach (DataGridViewRow r in dgvTrx.SelectedRows)
                {
                    r.Cells["SettledDate"].Value = "2017/7/23"; //use the column name instead of column index
                }
                this.BindingContext[dgvTrx.DataSource].EndCurrentEdit(); 
        }

         */

        //===============================
        //============================MemobankreconReport
        /*
        set @cntD := 0;
set @cntC := 0;
set @cntD_ := 0;
set @cntC_ := 0;

Select
 fn.cnt, fn.*
from
(
  select
    f.cnt, 
    if(f.codeAmnt='d',f.date,null) dateD,
    if(f.codeAmnt='d',f.amount,null) debit,
  
    cdt.date dateC,
    cdt.amount credit
  from
  ( (SELECT 
      @cntD := @cntD+1 cnt,
      'd' codeAmnt,
      a.date,
      a.debit as amount 
      FROM (Select * from zanecoaccounting.memobankrecon 
            where accountSF =  '121-101-00-003' and debit>0 order by date)  a)
     union
    (SELECT 
      @cntC := @cntC+1 cnt,
      'c' codeAmnt,
      b.date,
      b.credit as amount 
     FROM (Select * from zanecoaccounting.memobankrecon 
           where accountSF =  '121-101-00-003' and credit>0 order by date) b )
   ) f

left join ((SELECT 
             @cntD_ := @cntD_+1 cnt,
             'd' codeAmnt,
              c.date,
              c.debit as amount 
              FROM (Select * from zanecoaccounting.memobankrecon 
		            where accountSF =  '121-101-00-003' and debit>0 order by date) c )
              union
             (SELECT 
               @cntC_ := @cntC_+1 cnt,
               'c' codeAmnt,
               d.date,
               d.credit as amount 
               FROM (Select * from zanecoaccounting.memobankrecon 
                     where accountSF =  '121-101-00-003' and credit>0 order by date) d )
		  ) cdt on cdt.cnt = f.cnt and cdt.codeAmnt = 'c'
) fn group by fn.cnt
         */
    }
}
