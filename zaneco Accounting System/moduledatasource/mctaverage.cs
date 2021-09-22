using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace zaneco_Accounting_System.moduledatasource
{
    public class mctaverage
    {
        public Int64 idmctaveragedetails { get; set; }
        public String itemcode { get; set; }
        public String itemname { get; set; }
        public String closingdate { get; set; }
        public Double qty { get; set; }
        public Double average { get; set; }
        public String userid { get; set; }

        public mctaverage() { }
        public mctaverage(Int64 pidmctave, String pitemcode, String pitemname, String pclosingdate, Double pqty, Double paverage,String puserid)
        {
            this.idmctaveragedetails = pidmctave;
            this.itemcode = pitemcode;
            this.itemname = pitemname;
            this.closingdate = pclosingdate;
            this.qty = pqty;
            this.average = paverage;
            this.userid = puserid;
        }
    }
    
}
