using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalSystem
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            patients2.Visible = true;
            doctors2.Visible = false;
            nurses1.Visible = false;
            appointments1.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void lblSignout_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)  {

                Login login = new Login();
                //Form1 login = new Form1();
                login.Show();
                this.Hide();

            }

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /*
        private void btnMedRec_Click(object sender, EventArgs e)
        {

        }
        */
        private void btnPatients_Click(object sender, EventArgs e)
        {
            patients2.Visible = true;
            doctors2.Visible = false;
            nurses1.Visible = false;
            appointments1.Visible = false;
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            doctors2.Visible = true;
            patients2.Visible = false;
            nurses1.Visible = false;
            appointments1.Visible = false;
        }

        private void doctors2_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMedRec_Click_1(object sender, EventArgs e)
        {

        }

        private void patients1_Load(object sender, EventArgs e)
        {

        }

        private void btnNurses_Click(object sender, EventArgs e)
        {
            doctors2.Visible = false;
            patients2.Visible = false;
            nurses1.Visible = true;
            appointments1.Visible = false;
        }

        private void btnAppt_Click(object sender, EventArgs e)
        {
            doctors2.Visible = false; 
            patients2.Visible = false;
            nurses1.Visible = false;
            appointments1.Visible = true;
        }
    }
}
