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
    public partial class Nurses : UserControl
    {
        // List to store nurse information
        List<NurseInfo> nurseList = new List<NurseInfo>();

        // Filepath to save the nurse data
        string filepath = "C:\\Users\\Judith\\source\\repos\\Hospital system_v3\\NurseInfo\\NurseInfo.txt";

        public Nurses()
        {
            InitializeComponent();
            txtNurseID.Focus(); // Focus on the Doctor ID textbox
            getSaveData();        // Load saved data from the file
            showData();           // Display data in the DataGridView
        }
        public void showData()
        {
            dataGridViewNurse.Rows.Clear(); // Clear previous rows in the grid
            foreach (NurseInfo nurse in nurseList)
            {
                // Add each nurse's data to the grid
                dataGridViewNurse.Rows.Add(nurse.nurseID, nurse.fullName, nurse.department, nurse.phoneNumber);
            }
        }
        public void getSaveData()
        {
            // Read all lines from the text file
            List<string> lines = System.IO.File.ReadAllLines(filepath).ToList();
            foreach (var line in lines)
            {
                // Split each line and assign data to a new nurse
                string[] entries = line.Split(',');
                NurseInfo newNurse = new NurseInfo();
                newNurse.nurseID = entries[0];
                newNurse.fullName = entries[1];
                newNurse.department = entries[2];
                newNurse.phoneNumber = entries[3];
                nurseList.Add(newNurse); // Add the nurse to the list
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Clear all input fields on the form  
            txtNurseID.Text = string.Empty;
            txtNurseName.Text = string.Empty;
            cmbboxDepart.SelectedIndex = -1;
            txtPhoneNumber.Text = string.Empty;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Get the ID of the selected nurse from the grid
            var id = dataGridViewNurse.SelectedCells[0].Value;

            // Find and remove the nurse with the selected ID
            for (int i = nurseList.Count - 1; i >= 0; i--)
            {
                if (nurseList[i].nurseID == id.ToString())
                {
                    nurseList.RemoveAt(i);
                }
            }

            // Create a list to save updated data
            List<string> output = new List<string>();

            // Convert nurse data to text lines
            foreach (var elementObject in nurseList)
            {
                output.Add($"{elementObject.nurseID}, {elementObject.fullName}, {elementObject.phoneNumber}, {elementObject.department}");
            }
            try
            {
                // Save the updated data to the file
                System.IO.File.WriteAllLines(filepath, output);

                // Show confirmation message 
                MessageBox.Show("\r\nData delete updated and saved to the text file.");
                showData(); // Refresh the grid with updated data
            }
            catch (Exception ex)
            {
                // Show error message if saving fails
                MessageBox.Show($"\r\nError saving the data: {ex.Message}");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Create a list to save the updated nurse data
            List<string> output = new List<string>();

            //Create a new nurse using the information entered in the form
            nurseList.Add(new NurseInfo { nurseID = txtNurseID.Text, fullName = txtNurseName.Text, phoneNumber = txtPhoneNumber.Text, department = cmbboxDepart.Text});

            // Convert nurse data to text lines
            foreach (var elementObject in nurseList)
            {
                output.Add($"{elementObject.nurseID}, {elementObject.fullName}, {elementObject.phoneNumber}, {elementObject.department}");
            }
            try
            {
                // Save all lines to the file
                System.IO.File.WriteAllLines(filepath, output);

                // Show confirmation message
                MessageBox.Show("\r\nData successfully updated and saved to the text file.");
                showData(); // Refresh the grid with updated data
            }
            catch (Exception ex)
            {
                // Show error message if something goes wrong
                MessageBox.Show($"\r\nError saving the data: {ex.Message}");
            }
        }
    }
}
