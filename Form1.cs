using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HospitalSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent(); // This method initializes the components of the login
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            // This method is called when the text in textBox1 changes
        }

        private void txtUsername_TextChanged(object sender, EventArgs e) {
            // This methos is called when the text in the username field changes
        }

        private void txtPassword_TextChanged(object sender, EventArgs e) {
            // This method is called when the text in the password field changes
        }

        private void btnCancel_Click_1(object sender, EventArgs e) {
            // Clear the text fields for username and password
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsername.Focus();
            chkBoxPasword.Checked = false;
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            // This methos is executed when the user clicks the login button
            if (txtUsername.Text == "admin" && txtPassword.Text == "1234") {
                    Main mainform = new Main(); // Create ans show the main window
                    mainform.Show();
                    this.Hide(); // Hide the login window
            } else {
                    // If the username or password is incorrenct, show an error message
                    MessageBox.Show("Invalid username or password.\nTry again", "Login Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtUsername.Focus();
                chkBoxPasword.Checked = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkBoxPasword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkBoxPasword.Checked ? '\0' : '*';
        }
    }
}
