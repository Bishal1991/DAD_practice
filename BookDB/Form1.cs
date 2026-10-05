using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BookDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void Display_Records(object s, EventArgs e)
        {
            DataSet ds = new DataSet();
            string dbconnection = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BookCSharp.accdb";
            string dbcommand = "SELECT *  FROM Books";
            OleDbConnection conn = new OleDbConnection(dbconnection);
            OleDbCommand cmd = new OleDbCommand(dbcommand, conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);


            adapter.Fill(ds);

            lstDisplayBooks.Items.Clear();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lstDisplayBooks.Items.Add(row["Bookkey"].ToString() + " -- " + row["Title"].ToString() + " -- "+ row["Pages"].ToString());
            }

        }

        void Exit(object s, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstDisplayBooks.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lstDisplayBooks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

