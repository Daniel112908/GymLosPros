using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbUser.Text = "";
            tbPassword.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(tbUser.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("Falta información");
            }
            else if(tbUser.Text == "Admin" && tbPassword.Text == "Admin")
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();    

            }
            else
            {
                MessageBox.Show("Usuario o contraseña errada");
            }
        }
    }
}
