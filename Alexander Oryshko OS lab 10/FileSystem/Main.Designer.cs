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
            this.panel1 = new System.Windows.Forms.Panel();
            this.info = new System.Windows.Forms.GroupBox();
            this.info_box = new System.Windows.Forms.GroupBox();
            this.CountsClusters = new System.Windows.Forms.Label();
            this.SizeClusters = new System.Windows.Forms.Label();
            this.freeMemory = new System.Windows.Forms.Label();
            this.freeClusters = new System.Windows.Forms.Label();
            this.Size = new System.Windows.Forms.Label();
            this.info_cluster = new System.Windows.Forms.GroupBox();
            this.listFile = new System.Windows.Forms.ListView();
            this.editFile = new System.Windows.Forms.TextBox();
            this.saveFile = new System.Windows.Forms.Button();
            this.editFileGroup = new System.Windows.Forms.GroupBox();
            this.activity = new System.Windows.Forms.GroupBox();
            this.clear = new System.Windows.Forms.Button();
            this.deleting = new System.Windows.Forms.Button();
            this.ListFileBox = new System.Windows.Forms.GroupBox();
            this.treeFS = new System.Windows.Forms.TreeView();
            this.TreeBox = new System.Windows.Forms.GroupBox();
            this.Main_menu.SuspendLayout();
            this.info.SuspendLayout();
            this.info_box.SuspendLayout();
            this.info_cluster.SuspendLayout();
            this.editFileGroup.SuspendLayout();
            this.activity.SuspendLayout();
            this.ListFileBox.SuspendLayout();
            this.TreeBox.SuspendLayout();
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
            this.Main_menu.Size = new System.Drawing.Size(955, 24);
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
            this.сохранитьВToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.сохранитьВToolStripMenuItem.Text = "Сохранить в...";
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 87);
            this.panel1.TabIndex = 1;
            // 
            // info
            // 
            this.info.Controls.Add(this.info_box);
            this.info.Controls.Add(this.info_cluster);
            this.info.Location = new System.Drawing.Point(12, 379);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(931, 145);
            this.info.TabIndex = 2;
            this.info.TabStop = false;
            this.info.Text = "Состояние памяти";
            // 
            // info_box
            // 
            this.info_box.Controls.Add(this.CountsClusters);
            this.info_box.Controls.Add(this.SizeClusters);
            this.info_box.Controls.Add(this.freeMemory);
            this.info_box.Controls.Add(this.freeClusters);
            this.info_box.Controls.Add(this.Size);
            this.info_box.Location = new System.Drawing.Point(747, 18);
            this.info_box.Name = "info_box";
            this.info_box.Size = new System.Drawing.Size(178, 116);
            this.info_box.TabIndex = 5;
            this.info_box.TabStop = false;
            this.info_box.Text = "Информация";
            // 
            // CountsClusters
            // 
            this.CountsClusters.AutoSize = true;
            this.CountsClusters.Location = new System.Drawing.Point(6, 43);
            this.CountsClusters.Name = "CountsClusters";
            this.CountsClusters.Size = new System.Drawing.Size(125, 13);
            this.CountsClusters.TabIndex = 2;
            this.CountsClusters.Text = "Количеcтво кластеров:";
            // 
            // SizeClusters
            // 
            this.SizeClusters.AutoSize = true;
            this.SizeClusters.Location = new System.Drawing.Point(6, 30);
            this.SizeClusters.Name = "SizeClusters";
            this.SizeClusters.Size = new System.Drawing.Size(99, 13);
            this.SizeClusters.TabIndex = 1;
            this.SizeClusters.Text = "Размер кластера:";
            // 
            // freeMemory
            // 
            this.freeMemory.AutoSize = true;
            this.freeMemory.Location = new System.Drawing.Point(6, 69);
            this.freeMemory.Name = "freeMemory";
            this.freeMemory.Size = new System.Drawing.Size(99, 13);
            this.freeMemory.TabIndex = 4;
            this.freeMemory.Text = "Свободно памяти:";
            // 
            // freeClusters
            // 
            this.freeClusters.AutoSize = true;
            this.freeClusters.Location = new System.Drawing.Point(6, 56);
            this.freeClusters.Name = "freeClusters";
            this.freeClusters.Size = new System.Drawing.Size(122, 13);
            this.freeClusters.TabIndex = 3;
            this.freeClusters.Text = "Свободных кластеров:";
            // 
            // Size
            // 
            this.Size.AutoSize = true;
            this.Size.Location = new System.Drawing.Point(6, 17);
            this.Size.Name = "Size";
            this.Size.Size = new System.Drawing.Size(85, 13);
            this.Size.TabIndex = 0;
            this.Size.Text = "Объём памяти:";
            // 
            // info_cluster
            // 
            this.info_cluster.Controls.Add(this.panel1);
            this.info_cluster.Location = new System.Drawing.Point(6, 18);
            this.info_cluster.Name = "info_cluster";
            this.info_cluster.Size = new System.Drawing.Size(735, 116);
            this.info_cluster.TabIndex = 3;
            this.info_cluster.TabStop = false;
            this.info_cluster.Text = "Таблица кластеров";
            // 
            // listFile
            // 
            this.listFile.Location = new System.Drawing.Point(6, 19);
            this.listFile.Name = "listFile";
            this.listFile.Size = new System.Drawing.Size(717, 321);
            this.listFile.TabIndex = 3;
            this.listFile.UseCompatibleStateImageBehavior = false;
            this.listFile.DoubleClick += new System.EventHandler(this.listFile_DoubleClick_1);
            // 
            // editFile
            // 
            this.editFile.Location = new System.Drawing.Point(6, 19);
            this.editFile.Multiline = true;
            this.editFile.Name = "editFile";
            this.editFile.Size = new System.Drawing.Size(735, 114);
            this.editFile.TabIndex = 4;
            // 
            // saveFile
            // 
            this.saveFile.Location = new System.Drawing.Point(9, 19);
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(163, 23);
            this.saveFile.TabIndex = 5;
            this.saveFile.Text = "Сохранить изменения";
            this.saveFile.UseVisualStyleBackColor = true;
            this.saveFile.Click += new System.EventHandler(this.saveFile_Click);
            // 
            // editFileGroup
            // 
            this.editFileGroup.Controls.Add(this.activity);
            this.editFileGroup.Controls.Add(this.editFile);
            this.editFileGroup.Location = new System.Drawing.Point(12, 530);
            this.editFileGroup.Name = "editFileGroup";
            this.editFileGroup.Size = new System.Drawing.Size(931, 139);
            this.editFileGroup.TabIndex = 6;
            this.editFileGroup.TabStop = false;
            this.editFileGroup.Text = "Редактирование файла";
            // 
            // activity
            // 
            this.activity.Controls.Add(this.deleting);
            this.activity.Controls.Add(this.clear);
            this.activity.Controls.Add(this.saveFile);
            this.activity.Location = new System.Drawing.Point(747, 17);
            this.activity.Name = "activity";
            this.activity.Size = new System.Drawing.Size(178, 116);
            this.activity.TabIndex = 5;
            this.activity.TabStop = false;
            this.activity.Text = "Действия";
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(9, 48);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(163, 23);
            this.clear.TabIndex = 6;
            this.clear.Text = "Очистить поле";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // deleting
            // 
            this.deleting.Location = new System.Drawing.Point(9, 77);
            this.deleting.Name = "deleting";
            this.deleting.Size = new System.Drawing.Size(163, 23);
            this.deleting.TabIndex = 7;
            this.deleting.Text = "Удаление";
            this.deleting.UseVisualStyleBackColor = true;
            this.deleting.Click += new System.EventHandler(this.deleting_Click);
            // 
            // ListFileBox
            // 
            this.ListFileBox.Controls.Add(this.listFile);
            this.ListFileBox.Location = new System.Drawing.Point(214, 27);
            this.ListFileBox.Name = "ListFileBox";
            this.ListFileBox.Size = new System.Drawing.Size(729, 346);
            this.ListFileBox.TabIndex = 7;
            this.ListFileBox.TabStop = false;
            this.ListFileBox.Text = "Файлы в папке";
            // 
            // treeFS
            // 
            this.treeFS.Location = new System.Drawing.Point(6, 18);
            this.treeFS.Name = "treeFS";
            this.treeFS.Size = new System.Drawing.Size(184, 321);
            this.treeFS.TabIndex = 8;
            // 
            // TreeBox
            // 
            this.TreeBox.Controls.Add(this.treeFS);
            this.TreeBox.Location = new System.Drawing.Point(12, 28);
            this.TreeBox.Name = "TreeBox";
            this.TreeBox.Size = new System.Drawing.Size(196, 345);
            this.TreeBox.TabIndex = 9;
            this.TreeBox.TabStop = false;
            this.TreeBox.Text = "Дерево файловой системы";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 676);
            this.Controls.Add(this.TreeBox);
            this.Controls.Add(this.ListFileBox);
            this.Controls.Add(this.editFileGroup);
            this.Controls.Add(this.info);
            this.Controls.Add(this.Main_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.Main_menu;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Main_menu.ResumeLayout(false);
            this.Main_menu.PerformLayout();
            this.info.ResumeLayout(false);
            this.info_box.ResumeLayout(false);
            this.info_box.PerformLayout();
            this.info_cluster.ResumeLayout(false);
            this.editFileGroup.ResumeLayout(false);
            this.editFileGroup.PerformLayout();
            this.activity.ResumeLayout(false);
            this.ListFileBox.ResumeLayout(false);
            this.TreeBox.ResumeLayout(false);
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
        private new System.Windows.Forms.Label Size;
        private System.Windows.Forms.Label freeClusters;
        private System.Windows.Forms.Label CountsClusters;
        private System.Windows.Forms.Label freeMemory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox info_box;
        private System.Windows.Forms.GroupBox info_cluster;
        private System.Windows.Forms.ListView listFile;
        private System.Windows.Forms.TextBox editFile;
        private System.Windows.Forms.Button saveFile;
        private System.Windows.Forms.GroupBox editFileGroup;
        private System.Windows.Forms.GroupBox activity;
        private System.Windows.Forms.Button deleting;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.GroupBox ListFileBox;
        private System.Windows.Forms.TreeView treeFS;
        private System.Windows.Forms.GroupBox TreeBox;
    }
}

