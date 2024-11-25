using System;
using System.Collections;
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
    public partial class Patients : UserControl
    {
        // List to store patient information
        List<PatientInfo> patientList = new List<PatientInfo>();

        // Filepath to save the patient data
        string filepath = "C:\\Users\\Judith\\source\\repos\\Hospital system_v3\\PatientRecords\\PatientRecords.txt";

        public Patients()
        {
            InitializeComponent();
            txtPatientID.Focus(); // Focus on the Patient ID textbox
            getSaveData();        // Load saved data from the file
            showData();           // Display data in the DataGridView
        }
        public void showData() 
        { 
            dataGridView.Rows.Clear(); // Clear previous rows in the grid
            foreach (PatientInfo patient in patientList)
            {
                // Add each patient's data to the grid
                dataGridView.Rows.Add(patient.patientId, patient.fullName, patient.phoneNumber, patient.gender, patient.age, patient.address );
            }
        }
        public void getSaveData() 
        {
            // Read all lines from the text file
            List<string> lines = System.IO.File.ReadAllLines(filepath).ToList();
            foreach (var line in lines)
            {
                // Split each line and assign data to a new patient
                string[] entries = line.Split(',');
                PatientInfo newPatient = new PatientInfo();
                newPatient.patientId = entries[0];
                newPatient.fullName = entries[1];
                newPatient.phoneNumber = entries[2];
                newPatient.gender = entries[3];
                newPatient.age = entries[4];
                newPatient.address = entries[5];

                patientList.Add(newPatient); // Add the patient to the list
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Create a list to save the updated patient data
            List<string> output = new List<string>();

            //Create a new patient using the information entered in the form
            patientList.Add(new PatientInfo { patientId = txtPatientID.Text, fullName = txtPatientName.Text, phoneNumber = txtPhoneNumber.Text, gender = cmbboxGender.Text, age = txtAge.Text, address = txtAddress.Text });

            // Convert patient data to text lines
            foreach (var elementObject in patientList)
            {
                output.Add($"{elementObject.patientId}, {elementObject.fullName}, {elementObject.phoneNumber}, {elementObject.gender}, {elementObject.age}, {elementObject.address}");
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

        private void txtPatientID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPatientName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbboxGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Get the ID of the selected patient from the grid
            var id = dataGridView.SelectedCells[0].Value;

            // Find and remove the patient with the selected ID
            for (int i = patientList.Count - 1; i >= 0; i--) 
            {
                if (patientList[i].patientId == id.ToString()) 
                { 
                    patientList.RemoveAt(i); 
                } 
            }

            // Create a list to save updated data
            List<string> output = new List<string>();

            // Convert patient data to text lines
            foreach (var elementObject in patientList)
            {
                output.Add($"{elementObject.patientId}, {elementObject.fullName}, {elementObject.phoneNumber}, {elementObject.gender}, {elementObject.age}, {elementObject.address}");
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Clear all input fields on the form  
            txtPatientID.Text = string.Empty;
            txtPatientName.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty; 
            cmbboxGender.SelectedIndex = -1;
            txtAge.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
