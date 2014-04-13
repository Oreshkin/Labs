namespace FileSystem
{
    partial class Main
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
            this.Main_menu = new System.Windows.Forms.MenuStrip();
            this.файловаяСистемаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.форматироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьНовыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.каталогToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.файлОСToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panel1 = new System.Windows.Forms.Panel();
            this.info = new System.Windows.Forms.GroupBox();
            this.freeMemory = new System.Windows.Forms.Label();
            this.freeClusters = new System.Windows.Forms.Label();
            this.CountsClusters = new System.Windows.Forms.Label();
            this.SizeClusters = new System.Windows.Forms.Label();
            this.Size = new System.Windows.Forms.Label();
            this.Main_menu.SuspendLayout();
            this.info.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_menu
            // 
            this.Main_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файловаяСистемаToolStripMenuItem,
            this.создатьНовыйToolStripMenuItem,
            this.файлОСToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.Main_menu.Location = new System.Drawing.Point(0, 0);
            this.Main_menu.Name = "Main_menu";
            this.Main_menu.Size = new System.Drawing.Size(935, 24);
            this.Main_menu.TabIndex = 0;
            this.Main_menu.Text = "menuStrip1";
            // 
            // файловаяСистемаToolStripMenuItem
            // 
            this.файловаяСистемаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.toolStripMenuItem1,
            this.форматироватьToolStripMenuItem});
            this.файловаяСистемаToolStripMenuItem.Name = "файловаяСистемаToolStripMenuItem";
            this.файловаяСистемаToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.файловаяСистемаToolStripMenuItem.Text = "Файловая система";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
            // 
            // форматироватьToolStripMenuItem
            // 
            this.форматироватьToolStripMenuItem.Name = "форматироватьToolStripMenuItem";
            this.форматироватьToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.форматироватьToolStripMenuItem.Text = "Форматировать";
            this.форматироватьToolStripMenuItem.Click += new System.EventHandler(this.форматироватьToolStripMenuItem_Click);
            // 
            // создатьНовыйToolStripMenuItem
            // 
            this.создатьНовыйToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.каталогToolStripMenuItem});
            this.создатьНовыйToolStripMenuItem.Name = "создатьНовыйToolStripMenuItem";
            this.создатьНовыйToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.создатьНовыйToolStripMenuItem.Text = "Создать новый";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.файлToolStripMenuItem.Text = "Файл";
            this.файлToolStripMenuItem.Click += new System.EventHandler(this.файлToolStripMenuItem_Click);
            // 
            // каталогToolStripMenuItem
            // 
            this.каталогToolStripMenuItem.Name = "каталогToolStripMenuItem";
            this.каталогToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.каталогToolStripMenuItem.Text = "Каталог";
            this.каталогToolStripMenuItem.Click += new System.EventHandler(this.каталогToolStripMenuItem_Click);
            // 
            // файлОСToolStripMenuItem
            // 
            this.файлОСToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьВToolStripMenuItem,
            this.загрузитьToolStripMenuItem});
            this.файлОСToolStripMenuItem.Name = "файлОСToolStripMenuItem";
            this.файлОСToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.файлОСToolStripMenuItem.Text = "Файл ОС";
            // 
            // сохранитьВToolStripMenuItem
            // 
            this.сохранитьВToolStripMenuItem.Name = "сохранитьВToolStripMenuItem";
            this.сохранитьВToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.сохранитьВToolStripMenuItem.Text = "Сохранить в...";
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // panel1
            // 
            panel1.Location = new System.Drawing.Point(12, 375);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(723, 87);
            panel1.TabIndex = 1;
            // 
            // info
            // 
            this.info.Controls.Add(this.freeMemory);
            this.info.Controls.Add(this.freeClusters);
            this.info.Controls.Add(this.CountsClusters);
            this.info.Controls.Add(this.SizeClusters);
            this.info.Controls.Add(this.Size);
            this.info.Location = new System.Drawing.Point(741, 375);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(182, 87);
            this.info.TabIndex = 2;
            this.info.TabStop = false;
            this.info.Text = "Состояние памяти";
            // 
            // freeMemory
            // 
            this.freeMemory.AutoSize = true;
            this.freeMemory.Location = new System.Drawing.Point(7, 68);
            this.freeMemory.Name = "freeMemory";
            this.freeMemory.Size = new System.Drawing.Size(99, 13);
            this.freeMemory.TabIndex = 4;
            this.freeMemory.Text = "Свободно памяти:";
            // 
            // freeClusters
            // 
            this.freeClusters.AutoSize = true;
            this.freeClusters.Location = new System.Drawing.Point(7, 55);
            this.freeClusters.Name = "freeClusters";
            this.freeClusters.Size = new System.Drawing.Size(122, 13);
            this.freeClusters.TabIndex = 3;
            this.freeClusters.Text = "Свободных кластеров:";
            // 
            // CountsClusters
            // 
            this.CountsClusters.AutoSize = true;
            this.CountsClusters.Location = new System.Drawing.Point(7, 42);
            this.CountsClusters.Name = "CountsClusters";
            this.CountsClusters.Size = new System.Drawing.Size(125, 13);
            this.CountsClusters.TabIndex = 2;
            this.CountsClusters.Text = "Количеcтво кластеров:";
            // 
            // SizeClusters
            // 
            this.SizeClusters.AutoSize = true;
            this.SizeClusters.Location = new System.Drawing.Point(6, 29);
            this.SizeClusters.Name = "SizeClusters";
            this.SizeClusters.Size = new System.Drawing.Size(99, 13);
            this.SizeClusters.TabIndex = 1;
            this.SizeClusters.Text = "Размер кластера:";
            // 
            // Size
            // 
            this.Size.AutoSize = true;
            this.Size.Location = new System.Drawing.Point(6, 16);
            this.Size.Name = "Size";
            this.Size.Size = new System.Drawing.Size(85, 13);
            this.Size.TabIndex = 0;
            this.Size.Text = "Объём памяти:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 474);
            this.Controls.Add(this.info);
            this.Controls.Add(panel1);
            this.Controls.Add(this.Main_menu);
            this.MainMenuStrip = this.Main_menu;
            this.Name = "Main";
            this.Text = "Main";
            this.Main_menu.ResumeLayout(false);
            this.Main_menu.PerformLayout();
            this.info.ResumeLayout(false);
            this.info.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Main_menu;
        private System.Windows.Forms.ToolStripMenuItem файловаяСистемаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem форматироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьНовыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каталогToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem файлОСToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.GroupBox info;
        private System.Windows.Forms.Label SizeClusters;
        private System.Windows.Forms.Label Size;
        private System.Windows.Forms.Label freeClusters;
        private System.Windows.Forms.Label CountsClusters;
        private System.Windows.Forms.Label freeMemory;
        public static System.Windows.Forms.Panel panel1;
    }
}

