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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Main_menu = new System.Windows.Forms.MenuStrip();
            this.файловаяСистемаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.форматироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.дефрагментаторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.файлОСToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.info_box = new System.Windows.Forms.GroupBox();
            this.curDir = new System.Windows.Forms.Label();
            this.CountsClusters = new System.Windows.Forms.Label();
            this.SizeClusters = new System.Windows.Forms.Label();
            this.freeMemory = new System.Windows.Forms.Label();
            this.freeClusters = new System.Windows.Forms.Label();
            this.Size = new System.Windows.Forms.Label();
            this.info_cluster = new System.Windows.Forms.GroupBox();
            this.infoLoadFile = new System.Windows.Forms.TextBox();
            this.infoLoadFileTitle = new System.Windows.Forms.Label();
            this.listFile = new System.Windows.Forms.ListView();
            this.infoDirMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.создатьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьПапкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.editFile = new System.Windows.Forms.TextBox();
            this.saveFile = new System.Windows.Forms.Button();
            this.editFileGroup = new System.Windows.Forms.GroupBox();
            this.activity = new System.Windows.Forms.GroupBox();
            this.clear = new System.Windows.Forms.Button();
            this.ListFileBox = new System.Windows.Forms.GroupBox();
            this.treeFS = new System.Windows.Forms.TreeView();
            this.TreeBox = new System.Windows.Forms.GroupBox();
            this.LoagingFileInFS = new System.Windows.Forms.OpenFileDialog();
            this.seachBox = new System.Windows.Forms.TextBox();
            this.seach = new System.Windows.Forms.Button();
            this.seachText = new System.Windows.Forms.Label();
            this.infoClasters = new System.Windows.Forms.GroupBox();
            this.infoClastersData = new System.Windows.Forms.TextBox();
            this.seachGroup = new System.Windows.Forms.GroupBox();
            this.saveFileOutFS = new System.Windows.Forms.SaveFileDialog();
            this.Main_menu.SuspendLayout();
            this.info_box.SuspendLayout();
            this.info_cluster.SuspendLayout();
            this.infoDirMenu.SuspendLayout();
            this.editFileGroup.SuspendLayout();
            this.activity.SuspendLayout();
            this.ListFileBox.SuspendLayout();
            this.TreeBox.SuspendLayout();
            this.infoClasters.SuspendLayout();
            this.seachGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_menu
            // 
            this.Main_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файловаяСистемаToolStripMenuItem,
            this.файлОСToolStripMenuItem});
            this.Main_menu.Location = new System.Drawing.Point(0, 0);
            this.Main_menu.Name = "Main_menu";
            this.Main_menu.Size = new System.Drawing.Size(983, 24);
            this.Main_menu.TabIndex = 0;
            this.Main_menu.Text = "menuStrip1";
            // 
            // файловаяСистемаToolStripMenuItem
            // 
            this.файловаяСистемаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.форматироватьToolStripMenuItem,
            this.toolStripMenuItem2,
            this.дефрагментаторToolStripMenuItem});
            this.файловаяСистемаToolStripMenuItem.Name = "файловаяСистемаToolStripMenuItem";
            this.файловаяСистемаToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.файловаяСистемаToolStripMenuItem.Text = "Файловая система";
            // 
            // форматироватьToolStripMenuItem
            // 
            this.форматироватьToolStripMenuItem.Name = "форматироватьToolStripMenuItem";
            this.форматироватьToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.форматироватьToolStripMenuItem.Text = "Форматировать";
            this.форматироватьToolStripMenuItem.Click += new System.EventHandler(this.форматироватьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(164, 6);
            // 
            // дефрагментаторToolStripMenuItem
            // 
            this.дефрагментаторToolStripMenuItem.Name = "дефрагментаторToolStripMenuItem";
            this.дефрагментаторToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.дефрагментаторToolStripMenuItem.Text = "Дефрагментатор";
            this.дефрагментаторToolStripMenuItem.Click += new System.EventHandler(this.дефрагментаторToolStripMenuItem_Click);
            // 
            // файлОСToolStripMenuItem
            // 
            this.файлОСToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьВToolStripMenuItem,
            this.загрузитьToolStripMenuItem});
            this.файлОСToolStripMenuItem.Name = "файлОСToolStripMenuItem";
            this.файлОСToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.файлОСToolStripMenuItem.Text = "Windows";
            // 
            // сохранитьВToolStripMenuItem
            // 
            this.сохранитьВToolStripMenuItem.Name = "сохранитьВToolStripMenuItem";
            this.сохранитьВToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.сохранитьВToolStripMenuItem.Text = "Сохранить в Windows";
            this.сохранитьВToolStripMenuItem.Click += new System.EventHandler(this.сохранитьВToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить из Windows";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel1.Location = new System.Drawing.Point(6, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 86);
            this.panel1.TabIndex = 1;
            // 
            // info_box
            // 
            this.info_box.Controls.Add(this.curDir);
            this.info_box.Controls.Add(this.CountsClusters);
            this.info_box.Controls.Add(this.SizeClusters);
            this.info_box.Controls.Add(this.freeMemory);
            this.info_box.Controls.Add(this.freeClusters);
            this.info_box.Controls.Add(this.Size);
            this.info_box.Location = new System.Drawing.Point(12, 392);
            this.info_box.Name = "info_box";
            this.info_box.Size = new System.Drawing.Size(196, 102);
            this.info_box.TabIndex = 5;
            this.info_box.TabStop = false;
            this.info_box.Text = "Информация";
            // 
            // curDir
            // 
            this.curDir.AutoSize = true;
            this.curDir.Location = new System.Drawing.Point(5, 82);
            this.curDir.Name = "curDir";
            this.curDir.Size = new System.Drawing.Size(98, 13);
            this.curDir.TabIndex = 5;
            this.curDir.Text = "Текущий каталог:";
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
            this.info_cluster.Location = new System.Drawing.Point(12, 500);
            this.info_cluster.Name = "info_cluster";
            this.info_cluster.Size = new System.Drawing.Size(959, 106);
            this.info_cluster.TabIndex = 3;
            this.info_cluster.TabStop = false;
            this.info_cluster.Text = "Таблица кластеров";
            // 
            // infoLoadFile
            // 
            this.infoLoadFile.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.infoLoadFile.Location = new System.Drawing.Point(323, 392);
            this.infoLoadFile.Name = "infoLoadFile";
            this.infoLoadFile.ReadOnly = true;
            this.infoLoadFile.ShortcutsEnabled = false;
            this.infoLoadFile.Size = new System.Drawing.Size(479, 20);
            this.infoLoadFile.TabIndex = 6;
            // 
            // infoLoadFileTitle
            // 
            this.infoLoadFileTitle.AutoSize = true;
            this.infoLoadFileTitle.Location = new System.Drawing.Point(221, 395);
            this.infoLoadFileTitle.Name = "infoLoadFileTitle";
            this.infoLoadFileTitle.Size = new System.Drawing.Size(93, 13);
            this.infoLoadFileTitle.TabIndex = 5;
            this.infoLoadFileTitle.Text = "Кластера файла:";
            // 
            // listFile
            // 
            this.listFile.ContextMenuStrip = this.infoDirMenu;
            this.listFile.LargeImageList = this.imageList;
            this.listFile.Location = new System.Drawing.Point(10, 18);
            this.listFile.Name = "listFile";
            this.listFile.Size = new System.Drawing.Size(567, 332);
            this.listFile.TabIndex = 3;
            this.listFile.UseCompatibleStateImageBehavior = false;
            this.listFile.DoubleClick += new System.EventHandler(this.listFile_DoubleClick_1);
            // 
            // infoDirMenu
            // 
            this.infoDirMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьФайлToolStripMenuItem,
            this.создатьПапкуToolStripMenuItem,
            this.удалитToolStripMenuItem});
            this.infoDirMenu.Name = "infoDirMenu";
            this.infoDirMenu.ShowImageMargin = false;
            this.infoDirMenu.Size = new System.Drawing.Size(224, 70);
            // 
            // создатьФайлToolStripMenuItem
            // 
            this.создатьФайлToolStripMenuItem.Name = "создатьФайлToolStripMenuItem";
            this.создатьФайлToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.создатьФайлToolStripMenuItem.Text = "Создать файл...";
            this.создатьФайлToolStripMenuItem.Click += new System.EventHandler(this.создатьФайлToolStripMenuItem_Click);
            // 
            // создатьПапкуToolStripMenuItem
            // 
            this.создатьПапкуToolStripMenuItem.Name = "создатьПапкуToolStripMenuItem";
            this.создатьПапкуToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.создатьПапкуToolStripMenuItem.Text = "Создать папку...";
            this.создатьПапкуToolStripMenuItem.Click += new System.EventHandler(this.создатьПапкуToolStripMenuItem_Click);
            // 
            // удалитToolStripMenuItem
            // 
            this.удалитToolStripMenuItem.Name = "удалитToolStripMenuItem";
            this.удалитToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.удалитToolStripMenuItem.Text = "Удалить выбранный эленемент";
            this.удалитToolStripMenuItem.Click += new System.EventHandler(this.удалитToolStripMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "back.png");
            this.imageList.Images.SetKeyName(1, "zip128.png");
            this.imageList.Images.SetKeyName(2, "text128.png");
            this.imageList.Images.SetKeyName(3, "import.png");
            this.imageList.Images.SetKeyName(4, "documents.png");
            // 
            // editFile
            // 
            this.editFile.Location = new System.Drawing.Point(6, 19);
            this.editFile.Multiline = true;
            this.editFile.Name = "editFile";
            this.editFile.Size = new System.Drawing.Size(404, 50);
            this.editFile.TabIndex = 4;
            // 
            // saveFile
            // 
            this.saveFile.Location = new System.Drawing.Point(9, 19);
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(151, 23);
            this.saveFile.TabIndex = 5;
            this.saveFile.Text = "Сохранить изменения";
            this.saveFile.UseVisualStyleBackColor = true;
            this.saveFile.Click += new System.EventHandler(this.saveFile_Click);
            // 
            // editFileGroup
            // 
            this.editFileGroup.Controls.Add(this.editFile);
            this.editFileGroup.Location = new System.Drawing.Point(214, 418);
            this.editFileGroup.Name = "editFileGroup";
            this.editFileGroup.Size = new System.Drawing.Size(416, 76);
            this.editFileGroup.TabIndex = 6;
            this.editFileGroup.TabStop = false;
            this.editFileGroup.Text = "Редактирование файла";
            // 
            // activity
            // 
            this.activity.Controls.Add(this.clear);
            this.activity.Controls.Add(this.saveFile);
            this.activity.Location = new System.Drawing.Point(636, 418);
            this.activity.Name = "activity";
            this.activity.Size = new System.Drawing.Size(166, 76);
            this.activity.TabIndex = 5;
            this.activity.TabStop = false;
            this.activity.Text = "Действия";
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(9, 48);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(151, 23);
            this.clear.TabIndex = 6;
            this.clear.Text = "Очистить поле";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // ListFileBox
            // 
            this.ListFileBox.Controls.Add(this.listFile);
            this.ListFileBox.Location = new System.Drawing.Point(214, 27);
            this.ListFileBox.Name = "ListFileBox";
            this.ListFileBox.Size = new System.Drawing.Size(588, 359);
            this.ListFileBox.TabIndex = 7;
            this.ListFileBox.TabStop = false;
            this.ListFileBox.Text = "Файлы в папке";
            // 
            // treeFS
            // 
            this.treeFS.Location = new System.Drawing.Point(6, 18);
            this.treeFS.Name = "treeFS";
            this.treeFS.Size = new System.Drawing.Size(184, 261);
            this.treeFS.TabIndex = 8;
            // 
            // TreeBox
            // 
            this.TreeBox.Controls.Add(this.treeFS);
            this.TreeBox.Location = new System.Drawing.Point(12, 27);
            this.TreeBox.Name = "TreeBox";
            this.TreeBox.Size = new System.Drawing.Size(196, 285);
            this.TreeBox.TabIndex = 9;
            this.TreeBox.TabStop = false;
            this.TreeBox.Text = "Дерево файловой системы";
            // 
            // LoagingFileInFS
            // 
            this.LoagingFileInFS.FileName = "LoagingFileInFS";
            // 
            // seachBox
            // 
            this.seachBox.Location = new System.Drawing.Point(12, 34);
            this.seachBox.Name = "seachBox";
            this.seachBox.Size = new System.Drawing.Size(107, 20);
            this.seachBox.TabIndex = 10;
            // 
            // seach
            // 
            this.seach.Location = new System.Drawing.Point(124, 34);
            this.seach.Name = "seach";
            this.seach.Size = new System.Drawing.Size(66, 22);
            this.seach.TabIndex = 11;
            this.seach.Text = "Найти";
            this.seach.UseVisualStyleBackColor = true;
            this.seach.Click += new System.EventHandler(this.seach_Click);
            // 
            // seachText
            // 
            this.seachText.AutoSize = true;
            this.seachText.BackColor = System.Drawing.SystemColors.Control;
            this.seachText.Location = new System.Drawing.Point(9, 18);
            this.seachText.Name = "seachText";
            this.seachText.Size = new System.Drawing.Size(110, 13);
            this.seachText.TabIndex = 12;
            this.seachText.Text = "Введите имя файла:";
            // 
            // infoClasters
            // 
            this.infoClasters.Controls.Add(this.infoClastersData);
            this.infoClasters.Location = new System.Drawing.Point(808, 27);
            this.infoClasters.Name = "infoClasters";
            this.infoClasters.Size = new System.Drawing.Size(163, 467);
            this.infoClasters.TabIndex = 13;
            this.infoClasters.TabStop = false;
            this.infoClasters.Text = "Содержимое кластеров";
            // 
            // infoClastersData
            // 
            this.infoClastersData.Location = new System.Drawing.Point(8, 18);
            this.infoClastersData.Multiline = true;
            this.infoClastersData.Name = "infoClastersData";
            this.infoClastersData.ReadOnly = true;
            this.infoClastersData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.infoClastersData.Size = new System.Drawing.Size(146, 442);
            this.infoClastersData.TabIndex = 0;
            // 
            // seachGroup
            // 
            this.seachGroup.Controls.Add(this.seachText);
            this.seachGroup.Controls.Add(this.seachBox);
            this.seachGroup.Controls.Add(this.seach);
            this.seachGroup.Location = new System.Drawing.Point(12, 316);
            this.seachGroup.Name = "seachGroup";
            this.seachGroup.Size = new System.Drawing.Size(196, 70);
            this.seachGroup.TabIndex = 14;
            this.seachGroup.TabStop = false;
            this.seachGroup.Text = "Поиск";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(983, 613);
            this.Controls.Add(this.info_cluster);
            this.Controls.Add(this.activity);
            this.Controls.Add(this.infoLoadFile);
            this.Controls.Add(this.infoLoadFileTitle);
            this.Controls.Add(this.info_box);
            this.Controls.Add(this.seachGroup);
            this.Controls.Add(this.infoClasters);
            this.Controls.Add(this.TreeBox);
            this.Controls.Add(this.ListFileBox);
            this.Controls.Add(this.editFileGroup);
            this.Controls.Add(this.Main_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.Main_menu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Операционные системы (Лабораторная работа 10)";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Main_menu.ResumeLayout(false);
            this.Main_menu.PerformLayout();
            this.info_box.ResumeLayout(false);
            this.info_box.PerformLayout();
            this.info_cluster.ResumeLayout(false);
            this.infoDirMenu.ResumeLayout(false);
            this.editFileGroup.ResumeLayout(false);
            this.editFileGroup.PerformLayout();
            this.activity.ResumeLayout(false);
            this.ListFileBox.ResumeLayout(false);
            this.TreeBox.ResumeLayout(false);
            this.infoClasters.ResumeLayout(false);
            this.infoClasters.PerformLayout();
            this.seachGroup.ResumeLayout(false);
            this.seachGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Main_menu;
        private System.Windows.Forms.ToolStripMenuItem файловаяСистемаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem форматироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem файлОСToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
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
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.GroupBox ListFileBox;
        private System.Windows.Forms.GroupBox TreeBox;
        private System.Windows.Forms.OpenFileDialog LoagingFileInFS;
        private System.Windows.Forms.TextBox seachBox;
        private System.Windows.Forms.Button seach;
        private System.Windows.Forms.Label seachText;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.GroupBox infoClasters;
        private System.Windows.Forms.TextBox infoClastersData;
        private System.Windows.Forms.TreeView treeFS;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip infoDirMenu;
        private System.Windows.Forms.ToolStripMenuItem создатьФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьПапкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитToolStripMenuItem;
        private System.Windows.Forms.GroupBox seachGroup;
        private System.Windows.Forms.TextBox infoLoadFile;
        private System.Windows.Forms.Label infoLoadFileTitle;
        private System.Windows.Forms.Label curDir;
        private System.Windows.Forms.SaveFileDialog saveFileOutFS;
        private System.Windows.Forms.ToolStripMenuItem дефрагментаторToolStripMenuItem;
    }
}

