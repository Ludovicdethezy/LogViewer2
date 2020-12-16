using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LogViewer2
{
    public partial class Form1 : Form
    {
        protected SqlConnection oConnection;
        public string unit ="";
        public Filtre frm;
        public Form1()
        {
            InitializeComponent();
        }

        public string ParentProperty { get; set; }




        private void Form1_Load(object sender, EventArgs e)
        {
          
            // TODO: cette ligne de code charge les données dans la table 'hostTestDataSet.EventLog'. Vous pouvez la déplacer ou la supprimer selon les besoins.
             //        this.eventLogTableAdapter.Fill(this.hostTestDataSet.EventLog);
                Databaseupdate();
     
           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // this.oConnection = new SqlConnection("server=.//SQLEXPRES;database=HostTest;uid=test;pwd=test");
          
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Server =.\\SQLEXPRESS; Database = HostTest; Trusted_Connection = True; ";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                toolStripStatusLabel1.Text = "connection OK";

               
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Can not open connection ! ";
            }

            SqlDataAdapter da = new SqlDataAdapter("select * from LogView",cnn);
            
            DataSet ds = new DataSet();
            da.Fill(ds, "MyTable");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "MyTable";
            //dataGridView1.AutoResizeColumns();
        //  toolStripStatusLabel2.Text = dataGridView1.RowCount.ToString();
            cnn.Close();
        }

        public void Databaseupdate()
        {
            // this.oConnection = new SqlConnection("server=.//SQLEXPRES;database=HostTest;uid=test;pwd=test");

            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Server =.\\SQLEXPRESS; Database = HostTest; Trusted_Connection = True; ";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                toolStripStatusLabel1.Text = "connection OK";


            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Can not open connection ! ";
            }

            string srt;
            if (unit == "")
            {
                 srt = " SELECT   [CreatedUTC] ,[UnitId],[EventType],[EventCode],[Description],[Parameter1],[Parameter2],[Parameter3] ,[Parameter4]   FROM[HostTest].[dbo].[EventLog]   order by createdUTC desc";

            }
            else
            {
                 srt = " SELECT   [CreatedUTC] ,[UnitId],[EventType],[EventCode],[Description],[Parameter1],[Parameter2],[Parameter3] ,[Parameter4]   FROM[HostTest].[dbo].[EventLog]  where UnitId=" + unit + " order by createdUTC desc";

            }


           // string srt = " SELECT   [CreatedUTC] ,[UnitId],[EventType],[EventCode],[Description],[Parameter1],[Parameter2],[Parameter3] ,[Parameter4]   FROM[HostTest].[dbo].[LogView]  where UnitId="+ unit +" order by createdUTC desc";

        SqlDataAdapter da = new SqlDataAdapter(srt, cnn);

            DataSet ds = new DataSet();
            da.Fill(ds, "MyTable");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "MyTable";
            dataGridView1.Columns[4].Width = 400;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[3].Width = 70;
            toolStripStatusLabel2.Text = dataGridView1.RowCount.ToString();
            cnn.Close();
        }

        private void màJToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manuelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Databaseupdate();
        }

        private void filtréToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void filtreToolStripMenuItem_Click(object sender, EventArgs e)
        {
       //     frm = new Filtre();
       //     frm.Show();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

     

        private void button2_Click(object sender, EventArgs e)
        {
            unit = textBox1.Text;
            Databaseupdate();
        }
    }
}

