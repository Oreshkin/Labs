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
            this.SizeClusterBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FormatingStart = new System.Windows.Forms.Button();
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
            this.SizeBox.Size = new System.Drawing.Size(100, 20);
            this.SizeBox.TabIndex = 2;
            this.SizeBox.Text = "1000";
            // 
            // SizeClusterBox
            // 
            this.SizeClusterBox.Location = new System.Drawing.Point(111, 45);
            this.SizeClusterBox.Name = "SizeClusterBox";
            this.SizeClusterBox.Size = new System.Drawing.Size(100, 20);
            this.SizeClusterBox.TabIndex = 3;
            this.SizeClusterBox.Text = "4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FormatingStart);
            this.groupBox1.Controls.Add(this.SizeBox);
            this.groupBox1.Controls.Add(this.Size);
            this.groupBox1.Controls.Add(this.SizeCluster);
            this.groupBox1.Controls.Add(this.SizeClusterBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 102);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Форматирование";
            // 
            // FormatingStart
            // 
            this.FormatingStart.Location = new System.Drawing.Point(9, 71);
            this.FormatingStart.Name = "FormatingStart";
            this.FormatingStart.Size = new System.Drawing.Size(204, 23);
            this.FormatingStart.TabIndex = 5;
            this.FormatingStart.Text = "Форматировать";
            this.FormatingStart.UseVisualStyleBackColor = true;
            this.FormatingStart.Click += new System.EventHandler(this.FormatingStart_Click);
            // 
            // Formating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 125);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Formating";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formating";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private new System.Windows.Forms.Label Size;
        private System.Windows.Forms.Label SizeCluster;
        private System.Windows.Forms.TextBox SizeBox;
        private System.Windows.Forms.TextBox SizeClusterBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button FormatingStart;
    }
}