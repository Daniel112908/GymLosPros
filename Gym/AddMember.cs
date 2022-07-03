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
    public partial class AddMember : Form
    {
        public AddMember()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void AddMember_Load(object sender, EventArgs e)
        {

        }

        private void tbPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbMonthlyAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbTiming_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(tbName.Text == "" || tbPhone.Text == "" || tbAge.Text == "" || tbMonthlyAmount.Text == "")
            {
                MessageBox.Show("Falta Información");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into Member values('" + tbName.Text + "','" + tbPhone.Text + "', '" + cbGender.SelectedItem.ToString() + "', '" + tbAge.Text + "', '" + tbMonthlyAmount.Text + "', '" + cbTiming.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Se agregó nuevo miembro con éxito!");
                    Con.Close();
                    tbName.Text = "";
                    tbAge.Text = "";
                    tbMonthlyAmount.Text = "";
                    cbGender.Text = "";
                    cbTiming.Text = "";
                    tbPhone.Text = "";
                    tbMonthlyAmount.Text = "";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            tbAge.Text = "";
            tbMonthlyAmount.Text = "";
            cbGender.Text = "";
            cbTiming.Text = "";
            tbPhone.Text = "";
            tbMonthlyAmount.Text = "";

        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    }
}
