using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zaneco_Accounting_System;
using MySql.Data.MySqlClient;

namespace zaneco_Accounting_System.module
{
    public static class globalmainFrm
    {
        static String userlog_;
        static String usertype_;
        static connDBtmp db_accnt = new connDBtmp();
        static MySqlConnection conn_accnt = new MySqlConnection();
        static connectionDB_budget db_budget = new connectionDB_budget();
        static MySqlConnection conn_budget = new MySqlConnection();

        public static String userlog
        {
            get { return userlog_; }
            set { userlog_ = value; }
        }

        public static String usertype
        {
            get { return usertype_; }
            set { usertype_ = value; }
        }

        //=========ZanecoAccounting access===========
        //===========================================
        public static void setConn_accnt()
        {
            conn_accnt = db_accnt.getConn();
            conn_accnt.Open();
        }

        public static String getConnString()
        {
            return db_accnt.getConnString();
        }
        public static MySqlConnection getConn_accnt()
        {
            return conn_accnt;
        }

        public static void closeConn_accnt()
        {
            conn_accnt.Close();
        }
        //=============================================

        //=========ZanecoBudget access===========
        //===========================================
        public static void setConn_budget()
        {
            conn_budget = db_budget.getConn();
            conn_budget.Open();
        }

       
        public static MySqlConnection getConn_budget()
        {
            return conn_budget;
        }

        public static void closeConn_budget()
        {
            conn_budget.Close();
        }
        //=============================================
    }
}
