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

namespace zaneco_Accounting_System
{
    public partial class sampleFrm : Form
    {
        
        private connDBtmp db = new connDBtmp();
        private MySqlConnection conn = new MySqlConnection();
        private MySqlCommand cmd = new MySqlCommand();
               
        private MySqlDataAdapter da = new MySqlDataAdapter();
        private DataSet ds = new DataSet();
       
        public sampleFrm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addNewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void setForwardedBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Remember the vertical scroll position of the DataGridView
            int saveVScroll = 0;
            if (dataGridView1.Rows.Count > 0)
                saveVScroll = dataGridView1.FirstDisplayedCell.RowIndex;

           
            //=====================================
            loadChart(CodeName_tf.Text,CodeName_tf.Text);


            // Go back to the saved vertical scroll position if available
            if (saveVScroll != 0 && saveVScroll < dataGridView1.Rows.Count)
                dataGridView1.FirstDisplayedScrollingRowIndex = saveVScroll;
                       

        }

        private void chartOfAccount_Load(object sender, EventArgs e)
        {
            conn = db.getConn();

            
        }

               

        private void fillToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fillToolStripButton_Click_2(object sender, EventArgs e)
        {
            try
            {
                this.chartTableTableAdapter.Fill(this.datasetAccounting.chartTable, codeToolStripTextBox.Text, "%"+nameToolStripTextBox.Text+"%");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void loadChart(String codeStr, String nameStr)
        {
            String qry = " SELECT " +
                         " chartacam.idchartAcam, " +
                         " chartacam.accountcode, " +
                         " chartacam.accountname," +
                         "  chartacam.accounttype," +
                         "  chartacam.accountledgertype, " +
                         "  chartacam.BalAsOf," +
                         "  chartacam.BalPeriodCovered," +
                         "  chartacam.Indent," +
                         "  chartacam.category," +
                         "  chartacam.idGL, " +
                         "  chartacam.cstatus," +
                         "  chartacam.acctRepTitle, chartacam.idCashDepType, chartfb.idChartFB, chartfb.idchart, chartfb.balasof AS Expr1, chartfb.period, chartfb.GLDebit, chartfb.GLCredit, chartfb.SLDebit, chartfb.SLCredit, " +
                         "                 chartfb.idgl AS Expr2, chartfb.accountledgertype AS Expr3, chartfb.Accounttype AS Expr4, chartfb.idmaster " +
                        "FROM     chartacam LEFT JOIN " +
                        "                  chartfb ON chartacam.idchartAcam = chartfb.idchart " +
                        "WHERE  (chartacam.accountcode like @code) OR " +
                        "       (chartacam.accountname like @name)";

            try
            {

                ds = new DataSet();
                da = new MySqlDataAdapter(qry, conn);
                da.SelectCommand.Parameters.AddWithValue("@code", codeStr);
                da.SelectCommand.Parameters.AddWithValue("@name", "%" + nameStr + "%");
                da.Fill(ds, "chartA");
                dataGridView1.DataSource = ds.Tables["chartA"];             
            }
            catch (MySqlException ex)
            { MessageBox.Show(ex.ToString(), "ZANECO Accounting System",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            finally
            { }
           
        }

        
    }
}


/*
 *  static string conString = "Server=localhost;Database=peopledb;Uid=root;Pwd=;";
    MySqlConnection con = new MySqlConnection(conString);
    MySqlCommand cmd;
    MySqlDataAdapter adapter;
    DataTable dt = new DataTable();


  //INSERT INTO DB
    private void add(string name,string pos,string team)
    {
      //SQL STMT
      string sql = "INSERT INTO peopleTB(Name,Position,Team) VALUES(@PNAME,@POSITION,@TEAM)";
      cmd = new MySqlCommand(sql, con);

      //ADD PARAMETERS
      cmd.Parameters.AddWithValue("@PNAME", name);
      cmd.Parameters.AddWithValue("@POSITION", pos);
      cmd.Parameters.AddWithValue("@TEAM", team);
      //OPEN CON AND EXEC insert
      try
      {
        con.Open();

        if(cmd.ExecuteNonQuery()>0)
        {
          clearTxts();
          MessageBox.Show("Successfully Inserted");
        }

        con.Close();

        retrieve();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        con.Close();
      }
    }

    //ADD TO DGVIEW
    private void populate(String id,String name,string pos,string team)
    {
      dataGridView1.Rows.Add(id, name, pos, team);
    }

    //RETRIEVE FROM DB
    private void retrieve()
    {
      dataGridView1.Rows.Clear();

      //SQL STMT
      string sql = "SELECT * FROM peopleTB ";
      cmd = new MySqlCommand(sql, con);

      //OPEN CON,RETRIEVE,FILL DGVIEW
      try
      {
        con.Open();

        adapter = new MySqlDataAdapter(cmd);

        adapter.Fill(dt);

        //LOOP THRU DT
        foreach(DataRow row in dt.Rows)
        {
          populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[0].ToString());
        }

        con.Close();

        //CLEAR DT
        dt.Rows.Clear();
      }
      catch (Exception ex)
      {

        MessageBox.Show(ex.Message);
        con.Close();
      }
    }

    //UPDATE DB
    private void update(int id,string name,string pos,string team)
    {
      //SQL STMT
      string sql = "UPDATE peopleTB SET Name='" + name + "',Position='" + pos + "',Team='" + team + "' WHERE ID=" + id + "";
      cmd = new MySqlCommand(sql, con);

      //OPEN CON,UPDATE,RETRIEVE DGVIEW
      try
      {
        con.Open();
        adapter = new MySqlDataAdapter(cmd);

        adapter.UpdateCommand = con.CreateCommand();
        adapter.UpdateCommand.CommandText = sql;

        if(adapter.UpdateCommand.ExecuteNonQuery()>0)
        {
          clearTxts();
          MessageBox.Show("Successfully Updated");
        }

        con.Close();

        retrieve();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        con.Close();
      }

    }

    //DELETE FROM DB
    private void delete(int id)
    {
      //SQLSTMT
      string sql = "DELETE FROM peopleTB WHERE ID=" + id + "";
      cmd = new MySqlCommand(sql, con);

      //'OPEN CON,EXECUTE DELETE,CLOSE CON
      try
      {
        con.Open();
        MessageBox.Show(con.State.ToString());
        adapter = new MySqlDataAdapter(cmd);

        adapter.DeleteCommand = con.CreateCommand();

        adapter.DeleteCommand.CommandText = sql;

         //PROMPT FOR CONFIRMATION
        if(MessageBox.Show("Sure ??","DELETE",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
        {
          if(cmd.ExecuteNonQuery()>0)
          {
            clearTxts();
            MessageBox.Show("Successfully deleted");
          }
        }

        con.Close();

        retrieve();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        con.Close();
      }

    }

    //clear txtx
    private void clearTxts()
    {
      nameTxt.Text = "";
      posTxt.Text = "";
      teamTxt.Text = "";
    }

    private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
    {
      nameTxt.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
      posTxt.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
      teamTxt.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
    }

    private void addBtn_Click(object sender, EventArgs e)
    {
      add(nameTxt.Text, posTxt.Text, teamTxt.Text);
    }

    private void retrieveBtn_Click(object sender, EventArgs e)
    {
      retrieve();
    }

    private void updateBtn_Click(object sender, EventArgs e)
    {
      String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
      int id = Convert.ToInt32(selected);

      update(id, nameTxt.Text, posTxt.Text, teamTxt.Text);
    }

    private void deleteBtn_Click(object sender, EventArgs e)
    {
      String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
      int id = Convert.ToInt32(selected);

      delete(id);
    }

    private void clearBtn_Click(object sender, EventArgs e)
    {
      dataGridView1.Rows.Clear();
    }
  }

     */
