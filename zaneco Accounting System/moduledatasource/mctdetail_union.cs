using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaneco_Accounting_System.moduledatasource
{
    public class mctdetail_union
    {
        public Int64 idmctdetails { get; set; }
        public String mctdate { get; set; }
        public String mctno { get; set; }
        public String description { get; set; }
        public String sccode { get; set; }
        public String particulars { get; set; }
        public String accountcode { get; set; }
        public String accountname { get; set; }
        public Double qty { get; set; }
        public Double cost { get; set; }
        public Double debit { get; set; }
        public Double credit { get; set; }
        public Int64 isdebit { get; set; }
        
        
        public mctdetail_union() { }
        public mctdetail_union(Int64 pidmctdetails, String pmctdate, String pmctno, String pdescription,String psccode,String pparticulars,String paccountcode,String paccountname, Double pqty, Double pcost,Double pdebit,Double pcredit, Int64 pisdebit)
        {
            this.idmctdetails = pidmctdetails;
            this.mctdate = pmctdate;
            this.mctno = pmctno;
            this.description = pdescription;
            this.sccode = psccode;
            this.particulars = pparticulars;
            this.accountcode = paccountcode;
            this.accountname = paccountname;
            this.qty = pqty;
            this.cost = pcost;
            this.debit = pdebit;
            this.credit = pcredit;
            this.isdebit = pisdebit;
        }
    }
}
