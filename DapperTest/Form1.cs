using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DapperLibrary;
using DapperLibrary.Models;
using DapperLibrary.Interfaces;

namespace DapperTest
{
    public partial class Form1 : Form
    {
        OpleidingenService opleidingenService = new OpleidingenService();
        Docent docent = new Docent();
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
             var allCampus = opleidingenService.GetCampus();
             cmbCampus.DataSource = allCampus;

           var allDocent = opleidingenService.GetDocent();
            lstDocent.DataSource = allDocent;
        }

        private void cmbCampus_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCampus.Text = cmbCampus.SelectedItem.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            docent.Voornaam = txtName.Text;
            docent.Familienaam = txtSurname.Text;
            docent.Wedde = Convert.ToDecimal(txtWedde.Text);
            docent.CampusNr = cmbCampus.SelectedIndex + 1;

            opleidingenService.AddNewDocent(docent);
            txtName.Text = null;
            txtSurname.Text = null;
            txtWedde.Text = null;

            MessageBox.Show("Record added");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int docentNr = lstDocent.SelectedIndex + 1;
             opleidingenService.DeleteDocent(docentNr);
            MessageBox.Show("Record deleted");
            lblName.Text = null;
            lblSurname.Text = null;
        }

        private void lstDocent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int docentNr = lstDocent.SelectedIndex + 1;
            var docents = opleidingenService.FindDocent(docentNr);
            //listBox1.DataSource = docents;
            lblName.Text = docent.Voornaam; 
            lblSurname.Text = docent.Familienaam;
            //lblName.Text = lstDocent.SelectedValue.ToString().Split(' ')[0];
            // lblSurname.Text = lstDocent.SelectedValue.ToString().Split(' ')[1];
            lblWedde.Text = Convert.ToString(docent.Wedde);
        }
    }
}
