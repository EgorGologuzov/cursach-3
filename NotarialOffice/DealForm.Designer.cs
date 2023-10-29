
namespace NotarialOffice
{
    partial class DealForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.clientComboBox = new System.Windows.Forms.ComboBox();
            this.newClientButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comissionTextBox = new System.Windows.Forms.TextBox();
            this.comissionPercentComboBox = new System.Windows.Forms.ComboBox();
            this.conclusionDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Клиент:";
            // 
            // clientComboBox
            // 
            this.clientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientComboBox.FormattingEnabled = true;
            this.clientComboBox.Location = new System.Drawing.Point(12, 25);
            this.clientComboBox.Name = "clientComboBox";
            this.clientComboBox.Size = new System.Drawing.Size(399, 21);
            this.clientComboBox.TabIndex = 1;
            // 
            // newClientButton
            // 
            this.newClientButton.Location = new System.Drawing.Point(417, 25);
            this.newClientButton.Name = "newClientButton";
            this.newClientButton.Size = new System.Drawing.Size(87, 23);
            this.newClientButton.TabIndex = 2;
            this.newClientButton.Text = "Новый клиент";
            this.newClientButton.UseVisualStyleBackColor = true;
            this.newClientButton.Click += new System.EventHandler(this.newClientButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Сумма сделки:";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(12, 74);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(100, 20);
            this.amountTextBox.TabIndex = 4;
            this.amountTextBox.Text = "10000";
            this.amountTextBox.TextChanged += new System.EventHandler(this.updateComission);
            this.amountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.acceptOnlyDigitSymbols);
            this.amountTextBox.Leave += new System.EventHandler(this.leaveTextBox);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Комиссия:";
            // 
            // comissionTextBox
            // 
            this.comissionTextBox.Location = new System.Drawing.Point(118, 74);
            this.comissionTextBox.Name = "comissionTextBox";
            this.comissionTextBox.Size = new System.Drawing.Size(100, 20);
            this.comissionTextBox.TabIndex = 6;
            this.comissionTextBox.TextChanged += new System.EventHandler(this.userChangeComission);
            this.comissionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.acceptOnlyDigitSymbols);
            this.comissionTextBox.Leave += new System.EventHandler(this.leaveTextBox);
            // 
            // comissionPercentComboBox
            // 
            this.comissionPercentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comissionPercentComboBox.FormattingEnabled = true;
            this.comissionPercentComboBox.Items.AddRange(new object[] {
            "5%",
            "10%",
            "15%",
            "20%",
            "Другая"});
            this.comissionPercentComboBox.Location = new System.Drawing.Point(224, 73);
            this.comissionPercentComboBox.Name = "comissionPercentComboBox";
            this.comissionPercentComboBox.Size = new System.Drawing.Size(74, 21);
            this.comissionPercentComboBox.TabIndex = 7;
            this.comissionPercentComboBox.SelectedIndexChanged += new System.EventHandler(this.updateComission);
            // 
            // conclusionDatePicker
            // 
            this.conclusionDatePicker.Location = new System.Drawing.Point(304, 74);
            this.conclusionDatePicker.Name = "conclusionDatePicker";
            this.conclusionDatePicker.Size = new System.Drawing.Size(200, 20);
            this.conclusionDatePicker.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Дата заключения:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Услуги:";
            // 
            // grid
            // 
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Description});
            this.grid.Location = new System.Drawing.Point(15, 123);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.Size = new System.Drawing.Size(489, 127);
            this.grid.TabIndex = 11;
            // 
            // Title
            // 
            this.Title.HeaderText = "Название";
            this.Title.Name = "Title";
            // 
            // Description
            // 
            this.Description.HeaderText = "Комментарий";
            this.Description.Name = "Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Комментарий к сделке:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(15, 280);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(489, 52);
            this.descriptionTextBox.TabIndex = 13;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(392, 338);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(112, 23);
            this.addButton.TabIndex = 14;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(274, 338);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // DealForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 374);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.conclusionDatePicker);
            this.Controls.Add(this.comissionPercentComboBox);
            this.Controls.Add(this.comissionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.newClientButton);
            this.Controls.Add(this.clientComboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DealForm";
            this.Text = "Добавление новой сделки";
            this.Activated += new System.EventHandler(this.DealForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox clientComboBox;
        private System.Windows.Forms.Button newClientButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox comissionTextBox;
        private System.Windows.Forms.ComboBox comissionPercentComboBox;
        private System.Windows.Forms.DateTimePicker conclusionDatePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridViewComboBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}