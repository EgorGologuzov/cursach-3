using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class TopViewForm : Form
    {
        public TopViewForm()
        {
            InitializeComponent();
            CenterToParent();
        }

        private void TopViewForm_Load(object sender, EventArgs e)
        {
            hardModeComboBox.SelectedIndex = 0;
        }

        private void LoadRecords()
        {
            grid.Rows.Clear();
            int topCount = 1;

            if (hardModeComboBox.SelectedIndex == 0)
            {
                OleDbDataReader reader = DataBaseTool.SelectRecords();
                while (reader.Read())
                {
                    grid.Rows.Add(topCount, reader["UserName"], reader["Time"], reader["ModeName"]);
                    topCount++;
                }
            }
            else
            {
                string modeName = hardModeComboBox.SelectedItem.ToString();
                OleDbDataReader reader = DataBaseTool.SelectRecords(modeName);
                while (reader.Read())
                {
                    grid.Rows.Add(topCount, reader["UserName"], reader["Time"], reader["ModeName"]);
                    topCount++;
                }
            }
        }

        private void hardModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }
    }
}
