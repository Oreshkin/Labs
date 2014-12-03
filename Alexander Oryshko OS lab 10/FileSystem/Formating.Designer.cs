namespace FileSystem
{
    partial class Formating
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
            this.Size = new System.Windows.Forms.Label();
            this.SizeCluster = new System.Windows.Forms.Label();
            this.SizeBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SizeClusterBox = new System.Windows.Forms.ComboBox();
            this.FormatingStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Size
            // 
            this.Size.AutoSize = true;
            this.Size.Location = new System.Drawing.Point(6, 22);
            this.Size.Name = "Size";
            this.Size.Size = new System.Drawing.Size(89, 13);
            this.Size.TabIndex = 0;
            this.Size.Text = "Размер памяти:";
            // 
            // SizeCluster
            // 
            this.SizeCluster.AutoSize = true;
            this.SizeCluster.Location = new System.Drawing.Point(6, 48);
            this.SizeCluster.Name = "SizeCluster";
            this.SizeCluster.Size = new System.Drawing.Size(99, 13);
            this.SizeCluster.TabIndex = 1;
            this.SizeCluster.Text = "Размер кластера:";
            // 
            // SizeBox
            // 
            this.SizeBox.Location = new System.Drawing.Point(111, 19);
            this.SizeBox.Name = "SizeBox";
            this.SizeBox.Size = new System.Drawing.Size(97, 20);
            this.SizeBox.TabIndex = 2;
            this.SizeBox.Text = "1000";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SizeClusterBox);
            this.groupBox1.Controls.Add(this.FormatingStart);
            this.groupBox1.Controls.Add(this.SizeBox);
            this.groupBox1.Controls.Add(this.Size);
            this.groupBox1.Controls.Add(this.SizeCluster);
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 103);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Форматирование";
            // 
            // SizeClusterBox
            // 
            this.SizeClusterBox.FormattingEnabled = true;
            this.SizeClusterBox.Items.AddRange(new object[] {
            "2",
            "4",
            "8",
            "16",
            "32",
            "64"});
            this.SizeClusterBox.Location = new System.Drawing.Point(111, 44);
            this.SizeClusterBox.Name = "SizeClusterBox";
            this.SizeClusterBox.Size = new System.Drawing.Size(97, 21);
            this.SizeClusterBox.TabIndex = 9;
            this.SizeClusterBox.Text = "Выберите...";
            this.SizeClusterBox.Click += new System.EventHandler(this.SizeClusterBox_Click);
            // 
            // FormatingStart
            // 
            this.FormatingStart.Location = new System.Drawing.Point(9, 71);
            this.FormatingStart.Name = "FormatingStart";
            this.FormatingStart.Size = new System.Drawing.Size(199, 23);
            this.FormatingStart.TabIndex = 5;
            this.FormatingStart.Text = "Форматировать";
            this.FormatingStart.UseVisualStyleBackColor = true;
            this.FormatingStart.Click += new System.EventHandler(this.FormatingStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 47);
            this.label1.TabIndex = 6;
            this.label1.Text = "Formatting";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 168);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(214, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // Formating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(239, 201);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Formating";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Форматирование";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private new System.Windows.Forms.Label Size;
        private System.Windows.Forms.Label SizeCluster;
        private System.Windows.Forms.TextBox SizeBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button FormatingStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox SizeClusterBox;
    }
}