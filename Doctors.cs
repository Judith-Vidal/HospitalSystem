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
    public partial class Doctors : UserControl
    {
        // List to store patient information
        List<DoctorInfo> doctorList = new List<DoctorInfo>();

        // Filepath to save the patient data
        string filepath = "C:\\Users\\Judith\\source\\repos\\Hospital system_v3\\DoctorsInfo\\DoctorInfo.txt";

        public Doctors()
        {
            InitializeComponent();
            txtDoctorID.Focus(); // Focus on the Doctor ID textbox
            getSaveData();        // Load saved data from the file
            showData();           // Display data in the DataGridView
        }
        public void showData()
        {
            dataGridViewDoctor.Rows.Clear(); // Clear previous rows in the grid
            foreach (DoctorInfo doctor in doctorList)
            {
                // Add each patient's data to the grid
                dataGridViewDoctor.Rows.Add(doctor.doctorID, doctor.fullName, doctor.phoneNumber, doctor.department, doctor.specialty);
            }
        }
        public void getSaveData()
        {
            // Read all lines from the text file
            List<string> lines = System.IO.File.ReadAllLines(filepath).ToList();
            foreach (var line in lines)
            {
                // Split each line and assign data to a new doctor
                string[] entries = line.Split(',');
                DoctorInfo newDoctor = new DoctorInfo();
                newDoctor.doctorID = entries[0];
                newDoctor.fullName = entries[1];
                newDoctor.phoneNumber = entries[2];
                newDoctor.department = entries[3];
                newDoctor.specialty = entries[4];

                doctorList.Add(newDoctor); // Add the doctor to the list
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Clear all input fields on the form  
            txtDoctorID.Text = string.Empty;
            txtDoctorName.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            cmbboxDepartment.SelectedIndex = -1;
            cmbboxSpecialty.SelectedIndex = -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Get the ID of the selected doctor from the grid
            var id = dataGridViewDoctor.SelectedCells[0].Value;

            // Find and remove the doctor with the selected ID
            for (int i = doctorList.Count - 1; i >= 0; i--)
            {
                if (doctorList[i].doctorID == id.ToString())
                {
                    doctorList.RemoveAt(i);
                }
            }

            // Create a list to save updated data
            List<string> output = new List<string>();

            // Convert doctor data to text lines
            foreach (var elementObject in doctorList)
            {
                output.Add($"{elementObject.doctorID}, {elementObject.fullName}, {elementObject.phoneNumber}, {elementObject.department}, {elementObject.specialty}");
            }
            try
            {
                // Save the updated data to the file
                System.IO.File.WriteAllLines(filepath, output);

                // Show confirmation message 
                MessageBox.Show("\r\nData successfully updated and saved to the text file.");
                showData(); // Refresh the grid with updated data
            }
            catch (Exception ex)
            {
                // Show error message if saving fails
                MessageBox.Show($"\r\nError saving the data: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Create a list to save the updated doctor data
            List<string> output = new List<string>();

            //Create a new doctor using the information entered in the form
            doctorList.Add(new DoctorInfo { doctorID = txtDoctorID.Text, fullName = txtDoctorName.Text, phoneNumber = txtPhoneNumber.Text, department = cmbboxDepartment.Text, specialty = cmbboxSpecialty.Text});

            // Convert patient data to text lines
            foreach (var elementObject in doctorList)
            {
                output.Add($"{elementObject.doctorID}, {elementObject.fullName}, {elementObject.phoneNumber}, {elementObject.department}, {elementObject.specialty}");
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
