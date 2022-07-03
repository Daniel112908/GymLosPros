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
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
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
            updateSDVG.DataSource = ds.Tables[0];
            Con.Close();
        }

        int key = 0;
        private void updateSDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(updateSDVG.SelectedRows[0].Cells[0].Value.ToString());
            tbName.Text = updateSDVG.SelectedRows[0].Cells[1].Value.ToString();
            tbPhone.Text = updateSDVG.SelectedRows[0].Cells[2].Value.ToString();            
            cbGender.Text = updateSDVG.SelectedRows[0].Cells[3].Value.ToString();
            tbAge.Text = updateSDVG.SelectedRows[0].Cells[4].Value.ToString();
            tbMonthlyAmount.Text = updateSDVG.SelectedRows[0].Cells[5].Value.ToString();
            cbTiming.Text = updateSDVG.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void Update_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            tbPhone.Text = "";
            tbAge.Text = "";
            cbGender.Text = "";
            tbMonthlyAmount.Text = "";
            cbTiming.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if(key == 0)
            {
                MessageBox.Show("Por favor seleccionar un miembro para eliminar");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from Member where MemberID=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Se eliminó con éxito");
                    Con.Close();
                    populate();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (key == 0 || tbName.Text == "" || tbAge.Text == "" || tbMonthlyAmount.Text == "" || tbPhone.Text == "" || cbGender.Text == "" || cbTiming.Text == "")
            {
                MessageBox.Show("Por favor seleccionar un miembro para actulizar");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update Member set MemberName= '" + tbName.Text + "', MemberPhone= '" + tbPhone.Text + "', MemberGen='" + cbGender.Text + "', MemberAge='"+ tbAge.Text +"', MemberAmount='"+ tbMonthlyAmount.Text +"', MemberTime='"+cbTiming.Text+"' where MemberId="+key+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Se actualizó con éxito");
                    Con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
