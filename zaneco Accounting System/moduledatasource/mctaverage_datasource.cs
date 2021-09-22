using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;


namespace zaneco_Accounting_System.moduledatasource
{
    class mctaverage_datasource
    {
        

        public static DataSet mctunion_filter(String datefrom, String dateto)
        {
            DataSet dataset = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            String qry = @" Select DATE_FORMAT(m.mctdate, '%c/%e/%Y') mctdate,m.mctno,m.description,md.sccode,md.particulars,md.accountcode,md.accountname, md.qty,md.cost,md.debit,md.credit,md.idmctdetails,md.isdebit " +
                         " from zanecoaccounting.mctdetails md " +
                         " left join materialct m on m.mctno = md.mctno " +
                         " where m.mctdate between @datefrom and @dateto " +                        
                         " order by m.mctdate,m.mctno,md.sccode,md.isdebit ";
                        
            using (MySqlConnection Conn = connectionDB.ConnDBopen())
            {
                adapter = new MySqlDataAdapter(qry, Conn);
                adapter.SelectCommand.Parameters.AddWithValue("datefrom", datefrom);
                adapter.SelectCommand.Parameters.AddWithValue("dateto", dateto);
                adapter.Fill(dataset, "mctaverage");

                Conn.Close();
                return dataset;
            }
        }

        
        public static DataSet mctunion_itemindex(String datefrom, String dateto)
        {
            DataSet dataset = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            String qry = @"Set @cnt:=0; Select @cnt:=@cnt+1 as cnt,f.* from (Select concat(@datefrom, ' to ',@dateto) mctdate,m.mctno,m.description,md.sccode,md.particulars,md.accountcode,md.accountname,sum(ifnull(md.qty,0)) as qty,md.cost,md.cost costOrgn,md.debit,md.credit,md.idmctdetails,md.isdebit " +
                         " from zanecoaccounting.mctdetails md " +
                         " left join materialct m on m.mctno = md.mctno " +
                         " where md.isdebit = 1 and m.mctdate between @datefrom and @dateto " +                         
                         " group by md.sccode order by m.mctdate,md.sccode ) f order by f.mctdate,f.sccode";

            using (MySqlConnection Conn = connectionDB.ConnDBopen())
            {
                adapter = new MySqlDataAdapter(qry, Conn);
                adapter.SelectCommand.Parameters.AddWithValue("datefrom", datefrom);
                adapter.SelectCommand.Parameters.AddWithValue("dateto", dateto);
                adapter.Fill(dataset, "mctaverage");

                Conn.Close();
                return dataset;
            }
        }

        public static DataSet average_date()
        {
            DataSet dataset = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            String qry = @" Select DATE_FORMAT(closingdate, '%Y-%m-%d') closingdate from mctaveragedetails group by closingdate order by closingdate desc ";        
                        
            using (MySqlConnection Conn = connectionDB.ConnDBopen())
            {
                adapter = new MySqlDataAdapter(qry, Conn);               
                adapter.Fill(dataset, "averagedate");

                Conn.Close();
                return dataset;
            }
        }

        public static List<mctaverage> mctaveragedetails_filter(String itemcode,String itemname,String datefrom,String dateto)
        {
            List<mctaverage> list_mctd = new List<mctaverage>();
            using (MySqlConnection Conn = connectionDB.ConnDBopen())
            {
                MySqlCommand cmd = new MySqlCommand(string.Format(
                    "Select * from mctaveragedetails where (itemcode={0} or itemname={1}) and closingdate between {2} and {3}", "%"+itemcode+"%", "%"+itemname+"%",datefrom,dateto), Conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mctaverage pmctaverage = new mctaverage();
                    pmctaverage.idmctaveragedetails = reader.GetInt64(0);
                    pmctaverage.itemcode = reader.GetString(1);
                    pmctaverage.itemname = reader.GetString(2);
                    pmctaverage.closingdate = reader.GetDateTime(3).ToString("yyyy-MM-dd");
                    pmctaverage.qty = reader.GetDouble(4);
                    pmctaverage.average = reader.GetDouble(5);
                    pmctaverage.userid = reader.GetString(6);

                    list_mctd.Add(pmctaverage);                    
                }

                Conn.Close();
                return list_mctd;
            }
        }

        public static int insert_average(mctaverage pmctaverage)
        {
            int returnNo = 0;
            String qry = "insert into mctaveragedetails(itemcode,itemname,closingdate,qty,average,userid) values " +
                          "(@itemcode,@itemname,@closingdate,@qty,@average,@userid)";
            using (MySqlConnection conn = connectionDB.ConnDBopen())
            {
                
                MySqlCommand cmd = new MySqlCommand(qry,conn);
                cmd.Parameters.AddWithValue("itemcode", pmctaverage.itemcode);
                cmd.Parameters.AddWithValue("itemname", pmctaverage.itemname);
                cmd.Parameters.AddWithValue("closingdate", pmctaverage.closingdate);
                cmd.Parameters.AddWithValue("qty", pmctaverage.qty);
                cmd.Parameters.AddWithValue("average", pmctaverage.average);
                cmd.Parameters.AddWithValue("userid", pmctaverage.userid);

                returnNo = cmd.ExecuteNonQuery();
                conn.Close();
            }

            return returnNo;
        }
        public static void updateSelectedItem(String itemcode,Double cost, String Datefrom, String Dateto)
        {
            String qry = "update mctdetails md,materialct m set " +
                         " md.cost = @cost," +
                         " md.debit = if(md.isdebit=1,md.qty*@cost,0)," +
                         " md.credit = if(md.isdebit=0,md.qty*@cost,0) " +
                         " where  m.mctdate between @datefrom and @dateto and md.sccode = @itemcode and m.mctno = md.mctno;";
                      
            using (MySqlConnection conn = connectionDB.ConnDBopen())
            {

                MySqlCommand cmd = new MySqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("cost", cost);
                cmd.Parameters.AddWithValue("itemcode", itemcode);
                cmd.Parameters.AddWithValue("datefrom", Datefrom);
                cmd.Parameters.AddWithValue("dateto", Dateto);

                try
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("MCT override ERROR: " + ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            }
        }

        public static void updatemctAmount(String Datefrom, String Dateto)
        {           

            String qry = " update(Select sum(ifnull(credit, 0)) as credit, m_.mctno  " +
                         "            from mctdetails md_  " +
                         "            right join materialct m_ on m_.mctno = md_.mctno  " +
                         "            where m_.mctdate between @datefrom and @dateto group by md_.mctno) md,     " +
                         "            materialct m set     " +
                         "    m.amount = md.credit     " +
                         "    where m.mctdate between @datefrom and @dateto and m.mctno = md.mctno;";
            using (MySqlConnection conn = connectionDB.ConnDBopen())
            {

                MySqlCommand cmd = new MySqlCommand(qry, conn);                
                cmd.Parameters.AddWithValue("datefrom", Datefrom);
                cmd.Parameters.AddWithValue("dateto", Dateto);

                try
                {

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("MCT covered date transaction successfully override...", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("MCT override ERROR: " + ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            }
        }

        public static void updateCostAll(String closingdate,String Datefrom,String Dateto)
        {           
            String qry = "update mctdetails md,mctaveragedetails ma,materialct m set " +
                         " md.cost = ma.average," +
                         " md.debit = if(md.isdebit=1,md.qty*ma.average,0)," +
                         " md.credit = if(md.isdebit=0,md.qty*ma.average,0) " +                         
                         " where ma.closingdate = @closingdate and  ma.itemcode = md.sccode and" +
                         "       md.mctno=m.mctno and m.mctdate between @datefrom and @dateto;" +
                         " update(Select sum(ifnull(credit, 0)) as credit, m_.mctno  " +
                         "            from mctdetails md_  " +
                         "            right join materialct m_ on m_.mctno = md_.mctno  " +                        
                         "            where m_.mctdate between @datefrom and @dateto group by md_.mctno) md,     " +
                         "            materialct m set     " +
                         "    m.amount = md.credit     " +
                         "    where m.mctdate between @datefrom and @dateto and m.mctno = md.mctno;";
            using (MySqlConnection conn = connectionDB.ConnDBopen())
            {
               
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("closingdate", closingdate);
                cmd.Parameters.AddWithValue("datefrom", Datefrom);
                cmd.Parameters.AddWithValue("dateto", Dateto);               
                
                try
                {                   

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("MCT covered date transaction successfully override...", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("MCT override ERROR: " + ex.Message,null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            }

            
        }

        public static void clearCost(String Datefrom, String Dateto)
        {
            String qry = "update mctdetails md,materialct m set " +
                         " md.cost = 0," +
                         " md.debit = 0," +
                         " md.credit = 0," +
                         " m.amount = 0 " +
                         " where md.mctno=m.mctno and m.mctdate between @datefrom and @dateto; ";
                        
            using (MySqlConnection conn = connectionDB.ConnDBopen())
            {
                MySqlCommand cmd = new MySqlCommand(qry, conn);                
                cmd.Parameters.AddWithValue("datefrom", Datefrom);
                cmd.Parameters.AddWithValue("dateto", Dateto);

                try
                {

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("MCT covered date mct transaction cost successfully cleared...", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("MCT cleared ERROR: " + ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            }


        }

        public static void import_mctcost(String datefrom,String dateto, String datefromS, String datetoS)
        {
            String qry = "  DROP TABLE `zanecoaccounting`.`itemindexavetmp`;       " +
                        "    CREATE TABLE `zanecoaccounting`.`itemindexavetmp` (       " +
                        "    `iditemindexavetmp` INT NOT NULL AUTO_INCREMENT,       " +
                        "    `itemcode` VARCHAR(45) NULL,       " +
                        "    `totalqty` DOUBLE(14, 2) NULL DEFAULT 0,       " +
                        "    `totalcost` DOUBLE(14, 2) NULL DEFAULT 0,       " +
                        "    `average` DOUBLE(14, 2) NULL DEFAULT 0,       " +
                        "    `itemname` varchar(85) DEFAULT NULL,       " +
                        "    `unit` varchar(45) DEFAULT NULL,       " +
                        "    PRIMARY KEY(`iditemindexavetmp`),       " +
                        "    INDEX `index2` (`itemcode` ASC));       " +

                        "    insert into `zanecoaccounting`.`itemindexavetmp`(itemcode, totalQty, totalCost, average, itemname, unit)       " +
                        "    Select f.* from(       " +
                        "    SELECT r.itemcode,       " +
                        "        sum(ifnull(r.quantity, 0)) as totalQty,       " +
                        "        sum(ifnull(r.unitcost, 0) * ifnull(r.quantity, 0)) as totalCost,       " +
                        "        sum(ifnull(r.unitcost, 0) * ifnull(r.quantity, 0)) / sum(ifnull(r.quantity, 0)) as average,       " +
                        "        ifnull(i.itemname, '') as itemname,       " +
                        "        ifnull(i.unit, '') as unit       " +
                        "        FROM zanecoinvphp.tbl_receiptsdetails r       " +
                        "        left join zanecoinvphp.tbl_itemindex i on i.itemcode = r.itemcode                   " +
                        "        where r.transactiondate between @datefromS and @datetoS and                   " +
                        "            r.unitcost > 0       " +
                        "        group by itemcode) f where SUBSTRING(f.itemcode, 1,3)='DMO' and f.average is not null order by itemcode;       " +

                        " insert into `zanecoaccounting`.`itemindexavetmp`(itemcode, totalQty, totalCost, average, itemname, unit)    "+
                        "     Select f.itemcode,f.totalqty,f.totalcost,f.totalcost as average,f.itemname,f.unit    " +
                        "     from(    " +
                        "        SELECT i.itemcode,    " +
                        "          1 as totalQty,    " +
                        "          max(ifnull(i.unitcost, 0)) as totalcost,    " +
                        "          ii.itemname,    " +
                        "          ii.unit    " +
                        "         FROM zanecoinvphp.tbl_receiptsdetails i    " +
                        "         left join zanecoinvphp.tbl_itemindex ii on ii.itemcode = i.itemcode    " +
                        "         group by i.itemcode) f    " +
                        "     where SUBSTRING(f.itemcode, 1,3)='DMO' and f.itemname is not null and f.totalcost > 0 and not exists(Select * from zanecoaccounting.itemindexavetmp it where it.itemcode = f.itemcode);    " +

                        "    update zanecoaccounting.mctdetails md, zanecoaccounting.itemindexavetmp i, zanecoaccounting.materialct m set       " +
                        "    md.cost = i.average,       " +
                        "    md.debit =if (md.isdebit = 1,i.average* md.qty,0),       " +
                        "    md.credit =if (md.isdebit = 0,i.average* md.qty,0)       " +
                        "    where m.mctno = md.mctno and       " +
                        "          md.sccode in(concat('DMO', SUBSTRING(i.itemcode, 4, LENGTH(i.itemcode) - 3)),       " +
                        "                       concat('PAS', SUBSTRING(i.itemcode, 4, LENGTH(i.itemcode) - 3)),       " +
                        "                       concat('SAS', SUBSTRING(i.itemcode, 4, LENGTH(i.itemcode) - 3)),       " +
                        "                       concat('LAS', SUBSTRING(i.itemcode, 4, LENGTH(i.itemcode) - 3))) and       " +
                        "          m.mctdate between @datefrom and @dateto and md.posted=0;       " +

                        "    update (Select sum(ifnull(md_.debit, 0)) as total, md_.mctno from zanecoaccounting.mctdetails md_                   " +
                        "             left join zanecoaccounting.materialct m_ on m_.mctno = md_.mctno       " +
                        "             where md_.isdebit = 1 and m_.mctdate between @datefrom and @dateto  group by m_.mctno       " +
                        "           ) md,zanecoaccounting.materialct m set       " +
                        "    m.amount = ifnull(md.total, 0)       " +
                        "    where m.mctno = md.mctno and m.mctdate between @datefrom and @dateto       ";

            using (MySqlConnection conn = connectionDB.ConnDBopen())
            {

                MySqlCommand cmd = new MySqlCommand(qry, conn);                
                cmd.Parameters.AddWithValue("datefrom", datefrom);
                cmd.Parameters.AddWithValue("dateto", dateto);
                cmd.Parameters.AddWithValue("datefromS", datefromS);
                cmd.Parameters.AddWithValue("datetoS", datetoS);

                try
                {

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("MCT import cost successfully override...", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("MCT import cost ERROR: " + ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            }
        }

        public static void import_mctcostExist(String datefrom, String dateto)
        {
            String qry ="    update zanecoaccounting.mctdetails md, zanecoaccounting.itemindexavetmp i, zanecoaccounting.materialct m set       " +
                        "    md.cost = i.average,       " +
                        "    md.debit =if (md.isdebit = 1,i.average* md.qty,0),       " +
                        "    md.credit =if (md.isdebit = 0,i.average* md.qty,0)       " +
                        "    where m.mctno = md.mctno and       " +
                        "          md.sccode in(concat('DMO', SUBSTRING(i.itemcode, 4, LENGTH(i.itemcode) - 3)),       " +
                        "                       concat('PAS', SUBSTRING(i.itemcode, 4, LENGTH(i.itemcode) - 3)),       " +
                        "                       concat('SAS', SUBSTRING(i.itemcode, 4, LENGTH(i.itemcode) - 3)),       " +
                        "                       concat('LAS', SUBSTRING(i.itemcode, 4, LENGTH(i.itemcode) - 3))) and       " +
                        "          m.mctdate between @datefrom and @dateto and md.posted=0;       " +

                        "    update (Select sum(ifnull(md_.debit, 0)) as total, md_.mctno from zanecoaccounting.mctdetails md_                   " +
                        "             left join zanecoaccounting.materialct m_ on m_.mctno = md_.mctno       " +
                        "             where md_.isdebit = 1 and m_.mctdate between @datefrom and @dateto  group by m_.mctno       " +
                        "           ) md,zanecoaccounting.materialct m set       " +
                        "    m.amount = ifnull(md.total, 0)       " +
                        "    where m.mctno = md.mctno and m.mctdate between @datefrom and @dateto       ";

            using (MySqlConnection conn = connectionDB.ConnDBopen())
            {

                MySqlCommand cmd = new MySqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("datefrom", datefrom);
                cmd.Parameters.AddWithValue("dateto", dateto);
                
                try
                {

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("MCT import cost successfully override...", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("MCT import cost ERROR: " + ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            }
        }

        public static int update_average(mctaverage pmctaverage)
        {
            int returnNo = 0;
            String qry = "update mctaveragedetails set " +
                         " itemname = @itemname," +
                         " qty = @qty," +
                         " average = @average," +
                         " userid = @userid " +
                         " where itemcode = @itemcode and  closingdate = @closingdate ";
            using (MySqlConnection conn = connectionDB.ConnDBopen())
            {
                /*MySqlCommand cmd = new MySqlCommand(string.Format("update mctaveragedetails set " +                                                                  
                                                                  " itemname = '{1}'," +                                                                 
                                                                  " qty = '{3}'," +
                                                                  " average = '{4}'," +
                                                                  " userid = '{5}' " +
                                                                  " where itemcode = '{0}' and  closingdate = '{2}' ",                                   
                                   pmctaverage.itemcode, pmctaverage.itemname, pmctaverage.closingdate, pmctaverage.qty, pmctaverage.average, pmctaverage.userid), conn);*/
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("itemcode", pmctaverage.itemcode);
                cmd.Parameters.AddWithValue("itemname", pmctaverage.itemname);
                cmd.Parameters.AddWithValue("closingdate", pmctaverage.closingdate);
                cmd.Parameters.AddWithValue("qty", pmctaverage.qty);
                cmd.Parameters.AddWithValue("average", pmctaverage.average);
                cmd.Parameters.AddWithValue("userid", pmctaverage.userid);

                returnNo = cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("Unable to continue this process. \r\nDebit and credit should be equal value...", uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return returnNo;
        }

        public static bool Exist_average(String pitemcode,String pclosingdate)
        {
            String qry = @"Select * from mctaveragedetails where itemcode = @itemcode and  closingdate = @cdate ";
            using (MySqlConnection conn = connectionDB.ConnDBopen())
            {
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("itemcode", pitemcode);
                cmd.Parameters.AddWithValue("cdate",pclosingdate);
                int returnNo = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                if (returnNo == 0)
                    return false;
                else
                    return true;                
            }
        }
        
    }
}

/*
  public static List<mctdetail_union> mctunion_filter(String datefrom,String dateto)
        {
            String qry = @" Select DATE_FORMAT(m.mctdate, '%c/%e/%Y') mctdate,m.mctno,m.description,md.sccode,md.particulars,md.accountcode,md.accountname,md.qty,md.cost,md.debit,md.credit,md.idmctdetails,md.isdebit " +
                         " from zanecoaccounting.mctdetails md " +
                         " left join materialct m on m.mctno = md.mctno " +
                         " where m.mctdate between @datefrom and @dateto order by m.mctdate,md.sccode,md.isdebit ";

            List<mctdetail_union> list_mctunion = new List<mctdetail_union>();
            using (MySqlConnection Conn = connectionDB.ConnDBopen())
            {
                MySqlCommand cmd = new MySqlCommand(qry, Conn);
                cmd.Parameters.AddWithValue("datefrom", datefrom);
                cmd.Parameters.AddWithValue("dateto", dateto);

                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    mctdetail_union pmctdetailUnion = new mctdetail_union();
                    pmctdetailUnion.idmctdetails = reader.GetInt64("idmctdetails");
                    pmctdetailUnion.mctdate = reader.GetString("mctdate");
                    pmctdetailUnion.mctno = reader.GetString("mctno");
                    pmctdetailUnion.description = reader.GetString("description");
                    pmctdetailUnion.sccode = reader.GetString("sccode");
                    pmctdetailUnion.particulars = reader.GetString("particulars");
                    pmctdetailUnion.accountcode = reader.GetString("accountcode");
                    pmctdetailUnion.accountname = reader.GetString("accountname");
                    pmctdetailUnion.qty = reader.GetDouble("qty");
                    pmctdetailUnion.cost = reader.GetDouble("cost");
                    pmctdetailUnion.debit = reader.GetDouble("debit");
                    pmctdetailUnion.credit = reader.GetDouble("credit");
                    pmctdetailUnion.isdebit = reader.GetInt64("isdebit");

                    list_mctunion.Add(pmctdetailUnion);
                }

                Conn.Close();
                return list_mctunion;
            }
        }
     */
