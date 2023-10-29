using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotarialOffice
{
    public partial class MainForm : Form
    {
        public static string connectionString = "provider = Microsoft.Jet.OLEDB.4.0; Data Source = db.mdb";
        public static OleDbConnection conn = new OleDbConnection(connectionString);

        public MainForm()
        {
            InitializeComponent();
            conn.Open();
            InformationForm form = new InformationForm();
            form.MdiParent = this;
            form.Show();
        }

        private bool TryFindAndActivateForm(string name)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name == name)
                {
                    form.BringToFront();
                    return true;
                }
            }
            return false;
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (TryFindAndActivateForm("ClientsCatalogForm"))
            {
                return;
            }

            ClientsCatalogForm clientsCatalogForm = new ClientsCatalogForm();
            clientsCatalogForm.MdiParent = this;
            clientsCatalogForm.Show();
        }

        private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TryFindAndActivateForm("ServiceCatalogForm"))
            {
                return;
            }

            ServiceCatalogForm serviceCatalogForm = new ServiceCatalogForm();
            serviceCatalogForm.MdiParent = this;
            serviceCatalogForm.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void каскадомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void рядомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void стопкойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void новаяСделкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DealForm form = new DealForm();
            form.MdiParent = this;
            form.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TryFindAndActivateForm("InformationForm"))
            {
                return;
            }

            InformationForm form = new InformationForm();
            form.MdiParent = this;
            form.Show();
        }

        private void отчетЗаВсеВремяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TryFindAndActivateForm("ReportForAllTime"))
            {
                return;
            }

            ReportForm form = new ReportForm(ReportForm.ReportVars.AllTime);
            form.MdiParent = this;
            form.Show();
        }

        private void отчетЗаМесяцToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TryFindAndActivateForm("ReportForMonth"))
            {
                return;
            }

            ReportForm form = new ReportForm(ReportForm.ReportVars.Month);
            form.MdiParent = this;
            form.Show();
        }

        private void отчетЗаГодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TryFindAndActivateForm("ReportForYear"))
            {
                return;
            }

            ReportForm form = new ReportForm(ReportForm.ReportVars.Year);
            form.MdiParent = this;
            form.Show();
        }

        private void всеСделкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TryFindAndActivateForm("DealViewForm"))
            {
                return;
            }

            DealViewForm form = new DealViewForm();
            form.MdiParent = this;
            form.Show();
        }

        private void отчетОToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TryFindAndActivateForm("ServiceDiagramForm"))
            {
                return;
            }

            ServiceDiagramForm form = new ServiceDiagramForm();
            form.MdiParent = this;
            form.Show();
        }
    }
}
