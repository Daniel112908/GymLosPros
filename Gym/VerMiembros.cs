using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gym
{
    public partial class VerMiembros : Form
    {
        public VerMiembros()
        {
            InitializeComponent();
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        
        private void populate()
        {
            Con.Open();
            string query = "select * from Member";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            ViewMemberSDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        
        private void VerMiembros_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
            this.Hide();
        }

        private void ViewMemberSDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            filterbyName();
            tbNameSearch.Text = "";
        }

        private void filterbyName()
        {
            Con.Open();
            string query = "select * from Member where MemberName = '" + tbNameSearch.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            ViewMemberSDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            populate();
        }
    }
}
