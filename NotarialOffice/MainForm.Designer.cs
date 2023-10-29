namespace NotarialOffice
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.приложениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.услугиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сделкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новаяСделкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.незавершенныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеСделкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кассаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетЗаМесяцToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетЗаГодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетОToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.окнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.каскадомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рядомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стопкойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетЗаВсеВремяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.внесенаОплатаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.приложениеToolStripMenuItem,
            this.справочникиToolStripMenuItem,
            this.сделкиToolStripMenuItem,
            this.кассаToolStripMenuItem,
            this.окнаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // приложениеToolStripMenuItem
            // 
            this.приложениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.приложениеToolStripMenuItem.Name = "приложениеToolStripMenuItem";
            this.приложениеToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.приложениеToolStripMenuItem.Text = "&Приложение";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.оПрограммеToolStripMenuItem.Text = "&О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.выходToolStripMenuItem.Text = "&Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.клиентыToolStripMenuItem,
            this.услугиToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "&Справочники";
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.клиентыToolStripMenuItem.Text = "&Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // услугиToolStripMenuItem
            // 
            this.услугиToolStripMenuItem.Name = "услугиToolStripMenuItem";
            this.услугиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.услугиToolStripMenuItem.Text = "&Услуги";
            this.услугиToolStripMenuItem.Click += new System.EventHandler(this.услугиToolStripMenuItem_Click);
            // 
            // сделкиToolStripMenuItem
            // 
            this.сделкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяСделкаToolStripMenuItem,
            this.toolStripSeparator2,
            this.незавершенныеToolStripMenuItem,
            this.всеСделкиToolStripMenuItem});
            this.сделкиToolStripMenuItem.Name = "сделкиToolStripMenuItem";
            this.сделкиToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.сделкиToolStripMenuItem.Text = "&Сделки";
            // 
            // новаяСделкаToolStripMenuItem
            // 
            this.новаяСделкаToolStripMenuItem.Name = "новаяСделкаToolStripMenuItem";
            this.новаяСделкаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.новаяСделкаToolStripMenuItem.Text = "&Новая сделка";
            this.новаяСделкаToolStripMenuItem.Click += new System.EventHandler(this.новаяСделкаToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // незавершенныеToolStripMenuItem
            // 
            this.незавершенныеToolStripMenuItem.Name = "незавершенныеToolStripMenuItem";
            this.незавершенныеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.незавершенныеToolStripMenuItem.Text = "Н&езавершенные";
            // 
            // всеСделкиToolStripMenuItem
            // 
            this.всеСделкиToolStripMenuItem.Name = "всеСделкиToolStripMenuItem";
            this.всеСделкиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.всеСделкиToolStripMenuItem.Text = "&Все сделки";
            this.всеСделкиToolStripMenuItem.Click += new System.EventHandler(this.всеСделкиToolStripMenuItem_Click);
            // 
            // кассаToolStripMenuItem
            // 
            this.кассаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отчетЗаВсеВремяToolStripMenuItem,
            this.отчетЗаМесяцToolStripMenuItem,
            this.отчетЗаГодToolStripMenuItem,
            this.отчетОToolStripMenuItem,
            this.toolStripSeparator1,
            this.внесенаОплатаToolStripMenuItem});
            this.кассаToolStripMenuItem.Name = "кассаToolStripMenuItem";
            this.кассаToolStripMenuItem.Size = new System.Drawing.Size(87, 25);
            this.кассаToolStripMenuItem.Text = "&Финансы";
            // 
            // отчетЗаМесяцToolStripMenuItem
            // 
            this.отчетЗаМесяцToolStripMenuItem.Name = "отчетЗаМесяцToolStripMenuItem";
            this.отчетЗаМесяцToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.отчетЗаМесяцToolStripMenuItem.Text = "Отчет за &месяц";
            this.отчетЗаМесяцToolStripMenuItem.Click += new System.EventHandler(this.отчетЗаМесяцToolStripMenuItem_Click);
            // 
            // отчетЗаГодToolStripMenuItem
            // 
            this.отчетЗаГодToolStripMenuItem.Name = "отчетЗаГодToolStripMenuItem";
            this.отчетЗаГодToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.отчетЗаГодToolStripMenuItem.Text = "Отчет за &год";
            this.отчетЗаГодToolStripMenuItem.Click += new System.EventHandler(this.отчетЗаГодToolStripMenuItem_Click);
            // 
            // отчетОToolStripMenuItem
            // 
            this.отчетОToolStripMenuItem.Name = "отчетОToolStripMenuItem";
            this.отчетОToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.отчетОToolStripMenuItem.Text = "&Популярность услуг";
            this.отчетОToolStripMenuItem.Click += new System.EventHandler(this.отчетОToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // окнаToolStripMenuItem
            // 
            this.окнаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.каскадомToolStripMenuItem,
            this.рядомToolStripMenuItem,
            this.стопкойToolStripMenuItem});
            this.окнаToolStripMenuItem.Name = "окнаToolStripMenuItem";
            this.окнаToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.окнаToolStripMenuItem.Text = "&Окна";
            // 
            // каскадомToolStripMenuItem
            // 
            this.каскадомToolStripMenuItem.Name = "каскадомToolStripMenuItem";
            this.каскадомToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.каскадомToolStripMenuItem.Text = "&Каскадом";
            this.каскадомToolStripMenuItem.Click += new System.EventHandler(this.каскадомToolStripMenuItem_Click);
            // 
            // рядомToolStripMenuItem
            // 
            this.рядомToolStripMenuItem.Name = "рядомToolStripMenuItem";
            this.рядомToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.рядомToolStripMenuItem.Text = "&Рядом";
            this.рядомToolStripMenuItem.Click += new System.EventHandler(this.рядомToolStripMenuItem_Click);
            // 
            // стопкойToolStripMenuItem
            // 
            this.стопкойToolStripMenuItem.Name = "стопкойToolStripMenuItem";
            this.стопкойToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.стопкойToolStripMenuItem.Text = "&Стопкой";
            this.стопкойToolStripMenuItem.Click += new System.EventHandler(this.стопкойToolStripMenuItem_Click);
            // 
            // отчетЗаВсеВремяToolStripMenuItem
            // 
            this.отчетЗаВсеВремяToolStripMenuItem.Name = "отчетЗаВсеВремяToolStripMenuItem";
            this.отчетЗаВсеВремяToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.отчетЗаВсеВремяToolStripMenuItem.Text = "Отчет за &все время";
            this.отчетЗаВсеВремяToolStripMenuItem.Click += new System.EventHandler(this.отчетЗаВсеВремяToolStripMenuItem_Click);
            // 
            // внесенаОплатаToolStripMenuItem
            // 
            this.внесенаОплатаToolStripMenuItem.Name = "внесенаОплатаToolStripMenuItem";
            this.внесенаОплатаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.внесенаОплатаToolStripMenuItem.Text = "В&нести оплату";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Нотариальная контора";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem окнаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каскадомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рядомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стопкойToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem услугиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem приложениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сделкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кассаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новаяСделкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem незавершенныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеСделкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетЗаМесяцToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетЗаГодToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетОToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem отчетЗаВсеВремяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem внесенаОплатаToolStripMenuItem;
    }
}

