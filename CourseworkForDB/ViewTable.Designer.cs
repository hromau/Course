namespace CourseworkForDB
{
    partial class ViewTable
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewTable));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.редактированиеБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.созданиеТаблицToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеТаблицToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.включеноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отключеноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.редактированиеБДToolStripMenuItem,
            this.toolStripComboBox1,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(823, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // редактированиеБДToolStripMenuItem
            // 
            this.редактированиеБДToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.созданиеТаблицToolStripMenuItem,
            this.редактированиеТаблицToolStripMenuItem});
            this.редактированиеБДToolStripMenuItem.Name = "редактированиеБДToolStripMenuItem";
            this.редактированиеБДToolStripMenuItem.Size = new System.Drawing.Size(126, 23);
            this.редактированиеБДToolStripMenuItem.Text = "Редактирование БД";
            // 
            // созданиеТаблицToolStripMenuItem
            // 
            this.созданиеТаблицToolStripMenuItem.Name = "созданиеТаблицToolStripMenuItem";
            this.созданиеТаблицToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.созданиеТаблицToolStripMenuItem.Text = "Создание таблиц";
            // 
            // редактированиеТаблицToolStripMenuItem
            // 
            this.редактированиеТаблицToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.включеноToolStripMenuItem,
            this.отключеноToolStripMenuItem});
            this.редактированиеТаблицToolStripMenuItem.Name = "редактированиеТаблицToolStripMenuItem";
            this.редактированиеТаблицToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.редактированиеТаблицToolStripMenuItem.Text = "Редактирование таблиц";
            // 
            // включеноToolStripMenuItem
            // 
            this.включеноToolStripMenuItem.Name = "включеноToolStripMenuItem";
            this.включеноToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.включеноToolStripMenuItem.Text = "Включено";
            this.включеноToolStripMenuItem.Click += new System.EventHandler(this.ВключеноToolStripMenuItem_Click);
            // 
            // отключеноToolStripMenuItem
            // 
            this.отключеноToolStripMenuItem.Name = "отключеноToolStripMenuItem";
            this.отключеноToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.отключеноToolStripMenuItem.Text = "Отключено";
            this.отключеноToolStripMenuItem.Click += new System.EventHandler(this.ОтключеноToolStripMenuItem_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBox1.Text = "Choose table";
            this.toolStripComboBox1.TextChanged += new System.EventHandler(this.ToolStripComboBox1_TextChanged);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.ВыходToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(390, 182);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DataGridView1_KeyUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьЗаписьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 26);
            // 
            // удалитьЗаписьToolStripMenuItem
            // 
            this.удалитьЗаписьToolStripMenuItem.Name = "удалитьЗаписьToolStripMenuItem";
            this.удалитьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.удалитьЗаписьToolStripMenuItem.Text = "Удалить запись";
            this.удалитьЗаписьToolStripMenuItem.Click += new System.EventHandler(this.УдалитьЗаписьToolStripMenuItem_Click);
            // 
            // ViewTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 387);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ViewTable";
            this.Text = "ViewTable";
            this.Load += new System.EventHandler(this.ViewTable_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem редактированиеБДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem созданиеТаблицToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактированиеТаблицToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem включеноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отключеноToolStripMenuItem;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem удалитьЗаписьToolStripMenuItem;
    }
}

