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
    public partial class Patients : UserControl
    {
        List<PatientInfo> patientList = new List<PatientInfo>();
        // Direccion donde se guardara el archivo en my PC.
        string filepath = "C:\\Users\\Judith\\source\\repos\\Hospital system_v3\\PatientRecords\\PatientRecords.txt";

        public Patients()
        {
            InitializeComponent();
            txtPatientID.Focus();
            getSaveData();
            showData();
        }
        public void showData() 
        { 
            foreach (PatientInfo patient in patientList)
            {
                dataGridView.Rows.Add(patient.patientId, patient.fullName, patient.phoneNumber, patient.gender, patient.age, patient.address );
            }

        }
        public void getSaveData() 
        {
            List<string> lines = System.IO.File.ReadAllLines(filepath).ToList();
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                PatientInfo newPatient = new PatientInfo();
                newPatient.patientId = entries[0];
                newPatient.fullName = entries[1];
                newPatient.phoneNumber = entries[2];
                newPatient.gender = entries[3];
                newPatient.age = entries[4];
                newPatient.address = entries[5];

                patientList.Add(newPatient);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Valores que se guardaran en el archivo de texto
            List<string> output = new List<string>();
            foreach (var elementObject in patientList)
            {
                output.Add($"{elementObject.patientId}, {elementObject.fullName}, {elementObject.phoneNumber}, {elementObject.gender}, {elementObject.age}, {elementObject.address}");
            }
            try
            {
                // Si el archivo ya existe, lo sobrescribe.
                // Si no existe, lo crea automáticamente.
                System.IO.File.WriteAllLines(filepath, output);

                // Mensaje de confirmacion 
                MessageBox.Show("\r\nData successfully updated and saved to the text file.");
            }
            catch (Exception ex)
            {
                // Mensaje de error.
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            patientList.Add(new PatientInfo { patientId = txtPatientID.Text, fullName = txtPatientName.Text, phoneNumber = txtPhoneNumber.Text, gender = cmbboxGender.Text, age = txtAge.Text, address = txtAddress.Text});
        }
    }
}
