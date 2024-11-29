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
    public partial class Appointments : UserControl
    {
        // List to store appointment information
        List<AppointmentInfo> apptList = new List<AppointmentInfo>();

        // Filepath to save the appt data
        string filepath = "C:\\Users\\Judith\\source\\repos\\Hospital system_v3\\AppointmentInfo\\AppointmentInfo.txt";

        public Appointments()
        {
            InitializeComponent();
            cmbPatientAppt.Focus(); // Focus on the Patient Name combo box
            getSaveData();        // Load saved data from the file
            showData();           // Display data in the DVGAppointment
        }
        public void showData()
        {
            DVGAppointment.Rows.Clear(); // Clear previous rows in the grid
            foreach (AppointmentInfo appt in apptList)
            {
                // Add each appointment's data to the grid
                DVGAppointment.Rows.Add(appt.patientName, appt.doctor, appt.department, appt.date, appt.time, appt.specifications);
            }
        }

        public void getSaveData()
        {
            // Read all lines from the text file
            List<string> lines = System.IO.File.ReadAllLines(filepath).ToList();
            foreach (var line in lines)
            {
                // Split each line and assign data to a new appointment
                string[] entries = line.Split(',');
                AppointmentInfo newAppt = new AppointmentInfo();
                newAppt.patientName = entries[0];
                newAppt.doctor = entries[1];
                newAppt.department = entries[2];
                newAppt.date = entries[3];
                newAppt.time = entries[4];
                newAppt.specifications = entries[5];
                apptList.Add(newAppt); // Add the appt to the list
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Create a list to save the updated appointment data
            List<string> output = new List<string>();

            //Create a new appointment using the information entered in the form
            apptList.Add(new AppointmentInfo { patientName = cmbPatientAppt.Text, doctor = cmbDoctorAppt.Text, department = cmbDepartAppt.Text, date = dtpDate.Text, time = dtpTime.Text, specifications = txtSpecAppt.Text });

            // Convert appointment data to text lines
            foreach (var elementObject in apptList)
            {
                output.Add($"{elementObject.patientName}, {elementObject.doctor}, {elementObject.department}, {elementObject.date}, {elementObject.time}, {elementObject.specifications}");
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
            // Clear all input fields on the form  
            cmbPatientAppt.SelectedIndex = -1;
            cmbDoctorAppt.SelectedIndex = -1;
            cmbDepartAppt.SelectedIndex = -1;
            txtSpecAppt.Text = string.Empty;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Get the ID of the selected appointment from the grid
            var id = DVGAppointment.SelectedCells[0].Value;

            // Find and remove the appointment with the selected ID
            for (int i = apptList.Count - 1; i >= 0; i--)
            {
                if (apptList[i].patientName == id.ToString())
                {
                    apptList.RemoveAt(i);
                }
            }

            // Create a list to save updated data
            List<string> output = new List<string>();

            // Convert appointment data to text lines
            foreach (var elementObject in apptList)
            {
                output.Add($"{elementObject.patientName}, {elementObject.doctor}, {elementObject.department}, {elementObject.date}, {elementObject.time}, {elementObject.specifications}");
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
            cmbPatientAppt.SelectedIndex = -1;
            cmbDoctorAppt.SelectedIndex = -1;
            cmbDepartAppt.SelectedIndex = -1;
            txtSpecAppt.Text = string.Empty;
        }
    }
}
