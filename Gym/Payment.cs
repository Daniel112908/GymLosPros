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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void FillName()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select MemberName from Member", Con);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("MemberName", typeof(string));
            dt.Load(reader);
            cbMember.ValueMember = "MemberName";
            cbMember.DataSource = dt;  
            Con.Close();
        }
        private void Payment_Load(object sender, EventArgs e)
        {
            FillName();
            populate();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void populate()
        {
            Con.Open();
            string query = "select * from Payment";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            PagoSDVG.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            cbMember.Text = "";
            TbCantidad.Text = "";
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
            this.Hide();
        }
        int key = 1;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbMember.Text == "" || TbCantidad.Text == "")
            {
                MessageBox.Show("Falta información");
            }
            else
            {
                string payPeriod = dtPaymentMonth.Value.Month.ToString() + dtPaymentMonth.Value.Year.ToString();
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from Payment where PaymentMember = '"+cbMember.SelectedValue.ToString()+"' and PaymentMonth = '"+ payPeriod + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Ya pagó el mes seleccionado");
                }
                else
                {
                    string query = "insert into Payment values('"+ payPeriod + "', '"+cbMember.SelectedValue.ToString()+"', '"+TbCantidad.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Se pagó con éxito");
                }
                Con.Close();
                populate();
            }
        }

        private void lbExit_Click(object sender, EventArgs e)
        {    
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            filterbyName();
            tbBusquedaNombre.Text = "";
        }

        private void filterbyName()
        {
            Con.Open();
            string query = "select * from Payment where PaymentMember = '"+ tbBusquedaNombre.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            PagoSDVG.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            populate();
        }
    }
}
