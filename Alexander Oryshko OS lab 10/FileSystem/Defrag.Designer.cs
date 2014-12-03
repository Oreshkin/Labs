namespace FileSystem
{
    partial class Defrag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Defrag));
            this.startRecluster = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.TextBox();
            this.infoWorkReclaster = new System.Windows.Forms.GroupBox();
            this.infoReclaster = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.info_cluster = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.infoWorkReclaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.info_cluster.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // startRecluster
            // 
            this.startRecluster.Location = new System.Drawing.Point(9, 90);
            this.startRecluster.Name = "startRecluster";
            this.startRecluster.Size = new System.Drawing.Size(342, 39);
            this.startRecluster.TabIndex = 0;
            this.startRecluster.Text = "Дефрагментировать";
            this.startRecluster.UseVisualStyleBackColor = true;
            this.startRecluster.Click += new System.EventHandler(this.check_Click);
            // 
            // info
            // 
            this.info.Location = new System.Drawing.Point(6, 19);
            this.info.Multiline = true;
            this.info.Name = "info";
            this.info.ReadOnly = true;
            this.info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.info.Size = new System.Drawing.Size(317, 152);
            this.info.TabIndex = 2;
            // 
            // infoWorkReclaster
            // 
            this.infoWorkReclaster.Controls.Add(this.info);
            this.infoWorkReclaster.Location = new System.Drawing.Point(639, 14);
            this.infoWorkReclaster.Name = "infoWorkReclaster";
            this.infoWorkReclaster.Size = new System.Drawing.Size(329, 177);
            this.infoWorkReclaster.TabIndex = 3;
            this.infoWorkReclaster.TabStop = false;
            this.infoWorkReclaster.Text = "Выходная информация";
            // 
            // infoReclaster
            // 
            this.infoReclaster.AutoSize = true;
            this.infoReclaster.Location = new System.Drawing.Point(357, 14);
            this.infoReclaster.Name = "infoReclaster";
            this.infoReclaster.Size = new System.Drawing.Size(276, 117);
            this.infoReclaster.TabIndex = 4;
            this.infoReclaster.Text = resources.GetString("infoReclaster.Text");
            // 
            // logo
            // 
            this.logo.AutoSize = true;
            this.logo.Font = new System.Drawing.Font("Bauhaus 93", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logo.Location = new System.Drawing.Point(81, 7);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(262, 73);
            this.logo.TabIndex = 7;
            this.logo.Text = "DEFRAG";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(6, 19);
            this.progressBar.MarqueeAnimationSpeed = 10;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(612, 31);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // info_cluster
            // 
            this.info_cluster.Controls.Add(this.panel1);
            this.info_cluster.Location = new System.Drawing.Point(9, 193);
            this.info_cluster.Name = "info_cluster";
            this.info_cluster.Size = new System.Drawing.Size(959, 106);
            this.info_cluster.TabIndex = 10;
            this.info_cluster.TabStop = false;
            this.info_cluster.Text = "Таблица кластеров (ДО)";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Location = new System.Drawing.Point(9, 304);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(959, 106);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Таблица кластеров (ПОСЛЕ)";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel2.Location = new System.Drawing.Point(6, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(944, 86);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBar);
            this.groupBox2.Location = new System.Drawing.Point(9, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(624, 57);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Процент выполнения";
            // 
            // Defrag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(980, 419);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.info_cluster);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.infoReclaster);
            this.Controls.Add(this.infoWorkReclaster);
            this.Controls.Add(this.startRecluster);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Defrag";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Операционные системы (Лабораторная работа 11) \"Дефрагментатор\"";
            this.TopMost = true;
            this.infoWorkReclaster.ResumeLayout(false);
            this.infoWorkReclaster.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.info_cluster.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startRecluster;
        private System.Windows.Forms.TextBox info;
        private System.Windows.Forms.GroupBox infoWorkReclaster;
        private System.Windows.Forms.Label infoReclaster;
        private System.Windows.Forms.Label logo;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox info_cluster;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}