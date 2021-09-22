using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaneco_Accounting_System.module
{
    public static class globalcutoff
    {
        static DateTime cutoffDate_;
        static DateTime dateAsOf_;
        static String idforwardedchart_;
        static Boolean isforward_;

        public static DateTime cutoffDate
        {
            get { return cutoffDate_; }
            set { cutoffDate_ = value; }
        }

        public static DateTime dateAsOf
        {
            get { return dateAsOf_; }
            set { dateAsOf_ = value; }
        }

        public static String idforwardedchart
        {
            get { return idforwardedchart_; }
            set { idforwardedchart_ = value; }
        }

        public static Boolean isforward
        {
            get { return isforward_; }
            set { isforward_ = value; }
        }
    }
}
