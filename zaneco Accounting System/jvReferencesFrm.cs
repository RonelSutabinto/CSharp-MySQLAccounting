using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;
using zaneco_Accounting_System.Reports;
using zaneco_Accounting_System.module;

namespace zaneco_Accounting_System
{
    public partial class jvReferencesFrm : Form
    {
        private connDBtmp db_tmp = new connDBtmp();
        private MySqlConnection conn_tmp = new MySqlConnection();

        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataReader dr;
        private MySqlDataAdapter da;
        private DataSet ds = new DataSet();
        private unitClass uc = new unitClass();
        private jvdetailsFrm Frm_jvdetails = new jvdetailsFrm();
        private static Boolean isnotify = false;
        
        public jvReferencesFrm()
        {
            InitializeComponent();
        }
              
        public void setIsnotify(Boolean isntfy)
        {
            isnotify = isntfy;
        }
        public void jvdetailsFrmInitl(jvdetailsFrm Frm_jvdetails1)
        {
            this.Frm_jvdetails = Frm_jvdetails1;
        }
        private void loadCV()
        {
            String qry = " select    " +
                          "     f.*    " +                         
                          "     from    " +
                          "    (Select    " +
                          "       c.cvdate,    " +
                          "       c.cvnumber,    " +
                          "       c.paymentdesc,    " +
                          "       cvpcode,    " +
                          "       c.cvpname,    " +
                          "       ifnull(c.cvamount,0) cvamount,    " +
                          "       c.refnumber,    " +
                          "       r.rvnumber, " +                          
                          "       sum(ifnull(j.jvamount,0))  jvamount," +
                          "       r.rvdate   " +
                          "     from checkvoucher c   " +
                          "       left join journalv j on j.cvnumber =c.cvnumber " +
                          "       left join apvoucher a on a.apvnumber = c.refnumber   and" +
                          "                                substring(c.refnumber, 1, 3) = 'APV' " +
                          "       left join zanecobudget.po p on p.ponumber = a.rvnumber  and  substring(a.rvnumber, 1, 2) = 'PO' and substring(c.refnumber, 1, 3) = 'APV' or " +
                          "                                      p.ponumber = c.refnumber and  substring(c.refnumber, 1, 2) = 'PO' " +
                          "       left join zanecobudget.podetail pd on pd.idpo = p.idPO  and  substring(a.rvnumber, 1, 2) = 'PO' and substring(c.refnumber, 1, 3) = 'APV' or " +
                          "                                      pd.idpo = p.idPO and  substring(c.refnumber, 1, 2) = 'PO'  " +
                          "       left join zanecobudget.requisitiondetail rd on rd.idrequisitiondetail = pd.idRequisitionDetail  and  substring(a.rvnumber, 1, 2) = 'PO' and substring(c.refnumber, 1, 3) = 'APV' or" +
                          "                                      rd.idrequisitiondetail = pd.idRequisitionDetail and  substring(c.refnumber, 1, 2) = 'PO'   " +
                          "       left join zanecobudget.requisition r on r.idrequisition = rd.idrequisition  and  substring(a.rvnumber, 1, 2) = 'PO' and substring(c.refnumber, 1, 3) = 'APV' or " +
                          "                                      r.idrequisition = rd.idrequisition  and  substring(c.refnumber, 1, 2) = 'PO' and substring(c.refnumber, 1, 3) <> 'APV' or  " +
                          "                                      r.rvnumber = a.rvnumber and substring(a.rvnumber, 1, 2) <> 'PO' and substring(c.refnumber, 1, 3) = 'APV' or" +
                          "                                      r.rvnumber = c.refnumber and  substring(c.refnumber, 1, 2) <> 'PO' and substring(c.refnumber, 1, 3) <> 'APV' " +
                          "       where c.cvdate between @datefrom and @dateto and c.forliquidation = 1   group by c.cvnumber  " +
                          "     ) f    " +
                          "     left join zanecobudget.requisition r on r.rvNumber = f.rvnumber    " +
                          "     where f.cvnumber like @cvno and f.cvamount > f.jvamount or f.rvnumber like @cvno and f.cvamount <> f.jvamount ";
            /*
             String qry = " select    " +
                          "     f.*,    " +
                          "     r.rvdate    " +
                          "     from    " +
                          "    (Select    " +
                          "       c.cvdate,    " +
                          "       c.cvnumber,    " +
                          "       c.paymentdesc,    " +
                          "       cvpcode,    " +
                          "       c.cvpname,    " +
                          "       ifnull(c.cvamount,0) cvamount,    " +
                          "       c.refnumber,    " +
                          "       if (substring(c.refnumber, 1, 3) <> 'APV',    " +
                          "          c.refnumber,    " + //// "          -- if (substring(a.rvnumber, 1, 2) <> 'PO',a.rvnumber,r.rvnumber) ) as rvnumber    " +
                          "          r.rvnumber ) as rvnumber," +
                          "       sum(ifnull(j.jvamount,0))  jvamount   " +
                          "     from checkvoucher c   " +
                          "       left join journalv j on j.cvnumber =c.cvnumber " +
                          "       left join apvoucher a on a.apvnumber = c.refnumber    " +
                          "       left join zanecobudget.po p on p.ponumber = a.rvnumber    " +
                          "       left join zanecobudget.podetail pd on pd.idpo = p.idPO    " +
                          "       left join zanecobudget.requisitiondetail rd on rd.idrequisitiondetail = pd.idRequisitionDetail    " +
                          "       left join zanecobudget.requisition r on r.idrequisition = rd.idrequisition    " +
                          "       where c.cvdate between @datefrom and @dateto    group by c.cvnumber  " +
                          "     ) f    " +
                          "     left join zanecobudget.requisition r on r.rvNumber = f.rvnumber    " +
                          "     where f.cvnumber like @cvno and f.cvamount > f.jvamount or f.rvnumber like @cvno and f.cvamount <> f.jvamount ";
             */
           

            ds = new DataSet();

             try
             {
                 conn_tmp.Open();
                 da = new MySqlDataAdapter(qry, conn_tmp);

                 da.SelectCommand.Parameters.AddWithValue("@dateFrom", From_dp.Value);
                 da.SelectCommand.Parameters.AddWithValue("@dateTo", To_dp.Value);
                 da.SelectCommand.Parameters.AddWithValue("@cvno", "%" + search_tf.Text + "%");
                 da.Fill(ds, "checkvoucher");
                 table_dg.AutoGenerateColumns = false;
                 table_dg.DataSource = ds.Tables["checkvoucher"];

                 da.Dispose();
                 conn_tmp.Close();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                 conn_tmp.Close();
             }
        }
        private void close_btn_Click(object sender, EventArgs e)
        {
           
        }

        private void jvReferencesFrm_Load(object sender, EventArgs e)
        {
            conn_tmp = db_tmp.getConn();
            From_dp.Value = uc.StartOfMonth;
            To_dp.Value = uc.EndOfMonth;
            fromDP.Value = uc.StartOfMonth;
            toDP.Value = uc.EndOfMonth;

            if (isnotify)
            {
                From_dp.Value = DateTime.Now.AddYears(-2);
                tabControl1.SelectTab(0);
            }
            
            loadCV();

            loadcdcr();
        }

        private void loadcdcr()
        {
            try
            {
                this.cdcr_tblsumTableAdapter.Fill(this.billCollDS.cdcr_tblsum, fromDP.Value, toDP.Value);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            /*
             try
            {
                this.chartTableTableAdapter.Fill(this.datasetAccounting.chartTable, codeToolStripTextBox.Text, "%"+nameToolStripTextBox.Text+"%");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
             */
        }


        private void search_tf_Enter(object sender, EventArgs e)
        {
          /*  if (search_tf.Text == "Search CV Number/RV Number")
            {
                search_tf.Text = "";
                search_tf.ForeColor = Color.Black;
            }*/
        }

        private void search_tf_Leave(object sender, EventArgs e)
        {
           /* if (search_tf.Text == "")
            {
                search_tf.Text = "Search CV Number/RV Number";
                search_tf.ForeColor = Color.DarkGray;
            }*/
        }
              

        private void selectCV()
        {



            /*String qry2 = " (Select    " +
                          "        a.apvnumber,   " +
                          "        r.rvNumber,    " +
                          "        r.rvDate   " +
                          "       from apvoucher a    " +
                          "       left join zanecobudget.po p on p.ponumber = a.rvnumber and   " +
                          "                                       substring(a.rvnumber, 1, 2) = 'PO'   " +
                          "       left join zanecobudget.podetail pd on pd.idpo = p.idpo and   " +
                          "                                       substring(a.rvnumber, 1, 2) = 'PO'   " +
                          "       left join zanecobudget.requisitiondetail rd on rd.idrequisitiondetail = pd.idrequisitiondetail and   " +
                          "                                       substring(a.rvnumber, 1, 2) = 'PO'   " +
                          "       left join zanecobudget.requisition r on if (substring(a.rvnumber, 1, 2) = 'PO',r.idrequisition,r.rvnumber) =  if (substring(a.rvnumber, 1, 2) = 'PO',rd.idrequisition,a.rvnumber)   " +
                          "       where a.rvnumber = @refno and substring(@refno, 1, 3) = 'APV'   " +
                          "       group by a.apvnumber)    " +
                          "       union   " +
                          "       (Select   " +
                          "        '' apvnumber,   " +
                          "        r.rvNumber,   " +
                          "        r.rvDate   " +
                          "        from zanecobudget.po p   " +
                          "        left join zanecobudget.podetail pd on pd.idpo = p.idpo   " +
                          "         left join zanecobudget.requisitiondetail rd on rd.idrequisitiondetail = pd.idrequisitiondetail   " +
                          "      left join zanecobudget.requisition r on r.idrequisition = rd.idrequisition   " +
                          "        where p.ponumber = @refno and   " +
                          "              substring(@refno, 1, 2) = 'PO'  )   " +
                          "       union   ";*/

            Frm_jvdetails.tb_dbGrid.Rows.Clear();

            int selectedrowindex = table_dg.SelectedCells[0].RowIndex;
            DataGridViewRow sRow = table_dg.Rows[selectedrowindex];

            String cvno_ = sRow.Cells[1].Value.ToString();
            
            Frm_jvdetails.cvno_tf.Text = sRow.Cells[1].Value.ToString();
            Frm_jvdetails.rvno_tf.Text = sRow.Cells[2].Value.ToString();
             

            try
            {
                //Frm_jvdetails.txtcvDate.Text = DateTime.Parse(sRow.Cells[0].Value.ToString()).ToString("yyyy-MM-dd");
                Frm_jvdetails.docDate_dp.Value = DateTime.Parse(sRow.Cells[0].Value.ToString());
            }
            catch { }
            try
            {
                //Frm_jvdetails.txtrvDate.Text = DateTime.Parse(sRow.Cells[5].Value.ToString()).ToString("yyyy-MM-dd");
                Frm_jvdetails.rvdate_dp.Value = DateTime.Parse(sRow.Cells[5].Value.ToString());
            }
            catch { }

            Frm_jvdetails.description_tf.Text = sRow.Cells[3].Value.ToString();

            insertjvDetails(cvno_);

        }

        private void insertjvDetails(String cvno)
        {
            CultureInfo ci = new CultureInfo("en-us");//("N02", ci   
            String qry = " (Select   " +
                        "        cd.accountcode,   " +
                        "        cd.cvparticulars as accountname,   " +
                        "        cd.glaccountcode ,   " +
                        "        cd.glaccountname,   " +
                        "        cd.debit as amount,   " +
                        //"        r.rvdate,   " +
                        "        cd.jobid as job,   " +
                        "        cd.jobname,   " +
                        "        c.cvdate,   " +
                        "        c.cvnumber,     " +
                        "        c.paymentdesc as cvdesc,       " +
                        "        c.cvpcode,       " +
                        "        c.cvpname,      " +
                        "        c.cvamount,      " +
                        "        c.refnumber as cvrefno   " +
                        "   from checkvoucher c   " +
                        "   right join cvjournal cd on cd.cvnumber = c.cvnumber and cd.debit > 0   " +
                        //"   left join zanecobudget.requisition r on r.rvNumber = c.refnumber   " +
                        "   where c.forliquidation = 1 and   " +
                        "         cd.debit > 0 and   " +
                        "         substring(c.refnumber, 1, 3) <> 'APV' and   " +
                        //"         c.cvdate between @datefrom and @dateto and   " +
                        "         c.cvnumber = @cvno)    " +
                        "   union   " +
                        "   (Select   " +
                        "        ad.accountcode,   " +
                        "        ad.accountname,   " +
                        "        ad.glaccountcode,   " +
                        "        ad.glaccountname,   " +
                        "        ad.debit as amount,   " +
                        //"        '' rvdate,   " +
                        "        ifnull(ad.jobid,'') as job,   " +
                        "        ifnull(ad.jobname,'') jobname,   " +
                        "        c.cvdate,   " +
                        "        c.cvnumber,   " +
                        "        c.paymentdesc as cvdesc,   " +
                        "        c.cvpcode,   " +
                        "        c.cvpname,   " +
                        "        c.cvamount,   " +
                        "        c.refnumber as cvrefno   " +
                        "   from checkvoucher c   " +
                        "   right join apvdetails ad on ad.apvnumber = c.refnumber and   " +
                        "                               ad.debit > 0   " +
                        //"   left join zanecobudget.requisition r on r.rvNumber = c.refnumber   " +
                        "   where c.forliquidation = 1 and   " +
                        "         ad.debit > 0 and   " +
                        "         substring(c.refnumber, 1, 3) = 'APV' and   " +
                        //"         c.cvdate between @datefrom and @dateto and   " +
                        "         c.cvnumber = @cvno)";

            cmd = new MySqlCommand(qry, conn_tmp);
            cmd.Parameters.AddWithValue("@cvno", cvno);


            //=====================================================
            //=====================================================          
            try
            {

                conn_tmp.Open();
                dr = cmd.ExecuteReader();
                String jobBtn = "...";

                

                while (dr.Read())
                {
                    if (dr.GetString("job").Length > 2)
                        jobBtn = "X";
                    else
                        jobBtn = "...";

                        Frm_jvdetails.tb_dbGrid.Rows.Insert(0, dr.GetString("accountcode"),
                                               "...",
                                               dr.GetString("accountname"),
                                               dr.GetString("cvdesc"),
                                               dr.GetDouble("amount").ToString("N02", ci),
                                               "0.00",
                                               Frm_jvdetails.jvnumber_lbtmp.Text,
                                               "",
                                               0,
                                               jobBtn,
                                               dr.GetString("job"),
                                               dr.GetString("jobname"),
                                               dr.GetString("glaccountcode"),
                                               dr.GetString("glaccountname"));
                }
            }
            catch
            { }
        }

        private void select_btn_Click_1(object sender, EventArgs e)
        {
            loadCV();
        }

        private void close_btn_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void table_dg_KeyDown_1(object sender, KeyEventArgs e)
        {
            selectCV();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadcdcr();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            priviewCdcr();
        }

        
        private void priviewCdcr()
        {
            rptFrm frm = new rptFrm();
            DataSet ds = new DataSet();
            cdcrPreview myReport = new cdcrPreview();           

            DataTable cdcr = new DataTable();

            int selectedrowindex = 0;

            try
            {
                selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            }
            catch { }
                
            DataGridViewRow sRow = dataGridView1.Rows[selectedrowindex];

            String dateF = "";
            String area = sRow.Cells[1].Value.ToString();

            try
            {
                dateF = DateTime.Parse(sRow.Cells[0].Value.ToString()).ToString("yyyy-MM-dd");
            }             
            catch
            { }

            String qry = "SELECT idcdcr_tbl, transdate, area, code, description, format(ifnull(debit,0),2) debitF, format(ifnull(credit,0),2) creditf,debit,credit  FROM cdcr_tbl " +
                          " WHERE transdate like '"+ dateF + "' and area like '"+ area  + "'";
                      

            try
            {
                da = new MySqlDataAdapter(qry, conn_tmp);
                conn_tmp.Open();
                da.Fill(cdcr);
                //da.Dispose();
                ds.Tables.Add(cdcr);
                ds.Tables[0].TableName = "cdcr";

                da.Dispose();
                conn_tmp.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                da.Dispose();
                conn_tmp.Close();
            }
                       

            //set report and view===============
            try
            {
                myReport.SetDataSource(ds);
                frm.crystalRptViewer.ReportSource = myReport;
                frm.ShowDialog();             

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void jvReferencesFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isnotify = false;
        }

        private void cdcrtblsumBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void importBtn_Click(object sender, EventArgs e)
        {

            importjvdetails();
           
        }

        private void importjvdetails()
        {
            CultureInfo ci = new CultureInfo("en-us");
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow sRow = dataGridView1.Rows[selectedrowindex];

            String dateF = "";
            String area = sRow.Cells[1].Value.ToString();

            Frm_jvdetails.tb_dbGrid.Rows.Clear();

            try
            {
                dateF = DateTime.Parse(sRow.Cells[0].Value.ToString()).ToString("yyyy-MM-dd");
                Frm_jvdetails.docDate_dp.Value = DateTime.Parse(sRow.Cells[0].Value.ToString());
            }
            catch
            { }
                        
            String qry = "select f.* from (SELECT ifnull(ct.accountcode,'') accountcode, ifnull(ct.accountname,'') accountname,ifnull(ct.glaccountcode,'') glaccountcode,ifnull(ct.glaccountname,'') glaccountname, c.idcdcr_tbl, c.transdate, c.area, c.code, c.description, if(ifnull(c.debit,0)=0,'debit','credit') as istype,ifnull(c.debit,0) debit,ifnull(c.credit,0) credit  FROM cdcr_tbl c" +
                         " left join chart ct on ct.accountcode = c.code " +
                         " WHERE c.transdate like @dateF and c.area like @area) f order by f.istype desc,idcdcr_tbl";

            //=====================================================
            //===================================================== 
            cmd = new MySqlCommand(qry, conn_tmp);
            cmd.Parameters.AddWithValue("@dateF", dateF);
            cmd.Parameters.AddWithValue("@area", area);

            try
            {
                //MessageBox.Show(dateF + "  - " + area, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Frm_jvdetails.tb_dbGrid.Rows.Insert(0, dr.GetString("accountcode"),
                                               "...",
                                               dr.GetString("accountname"),
                                               dr.GetString("description"),
                                               dr.GetDouble("debit").ToString("N02", ci),
                                               dr.GetDouble("credit").ToString("N02", ci),
                                               "",
                                               "",
                                               0,
                                               "...",
                                               "",
                                               "",                                               
                                               dr.GetString("glaccountcode"),
                                               dr.GetString("glaccountname"));
                }

                conn_tmp.Close();
                Close();

                Frm_jvdetails.description_tf.Text = area + " - Collection";
                Frm_jvdetails.collarea_tf.Text = area + " - Collection";
                
                if (area.Equals("DMO"))
                {
                    Frm_jvdetails.category_cb.SelectedIndex = Frm_jvdetails.category_cb.FindStringExact("DMO-Coll.");//bank_cb.FindStringExact(dr.GetString("bank"));
                }else if (area.Equals("PAS"))
                {
                    Frm_jvdetails.category_cb.SelectedIndex = Frm_jvdetails.category_cb.FindStringExact("PAS-Coll.");
                }
                else if (area.Equals("LAS"))
                {
                    Frm_jvdetails.category_cb.SelectedIndex = Frm_jvdetails.category_cb.FindStringExact("LAS-Coll.");
                }
                else if (area.Equals("SAS"))
                {
                    Frm_jvdetails.category_cb.SelectedIndex = Frm_jvdetails.category_cb.FindStringExact("SAS-Coll.");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, uc.getMsgFrm(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn_tmp.Close();
            }
            
                                   
        }
    }
}
