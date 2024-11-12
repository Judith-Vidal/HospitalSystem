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
            patients1.Visible = false;
            doctors1.Visible = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
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
            patients1.Visible = true;
            doctors1.Visible = false;

        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            doctors1.Visible = true;
            patients1.Visible = false;
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
    }
}
