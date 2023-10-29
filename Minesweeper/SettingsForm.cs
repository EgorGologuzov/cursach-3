using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public enum HardMode
    {
        Easy, Medium, Hard, Custom
    }

    public partial class SettingsForm : Form
    {
        private HardMode hardMode;

        public SettingsForm()
        {
            InitializeComponent();
            CenterToParent();
        }

        private void upDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown upDown = sender as NumericUpDown;
            if (upDown.Focused)
            {
                decimal cellCount = widthNumericUpDown.Value * heightNumericUpDown.Value;
                decimal minesCount = minesCountNumericUpDown.Value;

                if (cellCount <= minesCount)
                {
                    minesCountNumericUpDown.Value = cellCount - 1;
                    MessageBox.Show("Количество мин не может быть больше чем размер поля.");
                }

                modeComboBox.SelectedIndex = 3;
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            hardMode = (HardMode)Properties.Settings.Default.ModeIndex;
            modeComboBox.SelectedIndex = (int)hardMode;

            switch (hardMode)
            {
                case HardMode.Easy:
                    widthNumericUpDown.Value = 8;
                    heightNumericUpDown.Value = 8;
                    minesCountNumericUpDown.Value = 10;
                    break;
                case HardMode.Medium:
                    widthNumericUpDown.Value = 16;
                    heightNumericUpDown.Value = 16;
                    minesCountNumericUpDown.Value = 40;
                    break;
                case HardMode.Hard:
                    widthNumericUpDown.Value = 30;
                    heightNumericUpDown.Value = 16;
                    minesCountNumericUpDown.Value = 99;
                    break;
                case HardMode.Custom:
                    widthNumericUpDown.Value = Properties.Settings.Default.FieldWidth;
                    heightNumericUpDown.Value = Properties.Settings.Default.FieldHeight;
                    minesCountNumericUpDown.Value = Properties.Settings.Default.MinesCount;
                    break;
                default:
                    throw new ArgumentException("Значение индекса режима игры, в файле настроек, вне допустимого диапозона.");
            }
        }

        private void saveSettings(object sender, EventArgs e)
        {
            decimal cellCount = widthNumericUpDown.Value * heightNumericUpDown.Value;
            decimal minesCount = minesCountNumericUpDown.Value;

            if (cellCount <= minesCount)
            {
                minesCountNumericUpDown.Value = cellCount - 1;
                MessageBox.Show("Количество мин не может быть больше чем размер поля.");
                return;
            }

            Properties.Settings.Default.FieldWidth = widthNumericUpDown.Value;
            Properties.Settings.Default.FieldHeight = heightNumericUpDown.Value;
            Properties.Settings.Default.MinesCount = minesCountNumericUpDown.Value;
            Properties.Settings.Default.ModeIndex = modeComboBox.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void modeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((HardMode)modeComboBox.SelectedIndex)
            {
                case HardMode.Easy:
                    widthNumericUpDown.Value = 8;
                    heightNumericUpDown.Value = 8;
                    minesCountNumericUpDown.Value = 10;
                    break;
                case HardMode.Medium:
                    widthNumericUpDown.Value = 16;
                    heightNumericUpDown.Value = 16;
                    minesCountNumericUpDown.Value = 40;
                    break;
                case HardMode.Hard:
                    widthNumericUpDown.Value = 30;
                    heightNumericUpDown.Value = 16;
                    minesCountNumericUpDown.Value = 99;
                    break;
            }
        }
    }
}
