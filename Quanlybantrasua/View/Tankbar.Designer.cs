namespace Quanlybantrasua.View
{
    partial class Tankbar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Them = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.danhsachhanghoa = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.danhsachhanghoa)).BeginInit();
            this.SuspendLayout();
            // 
            // Them
            // 
            this.Them.Location = new System.Drawing.Point(69, 405);
            this.Them.Name = "Them";
            this.Them.Size = new System.Drawing.Size(75, 23);
            this.Them.TabIndex = 0;
            this.Them.Text = "Thêm";
            this.Them.UseVisualStyleBackColor = true;
            this.Them.Click += new System.EventHandler(this.Them_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(451, 405);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "button1";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(848, 405);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "button1";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(784, 34);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "button1";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // danhsachhanghoa
            // 
            this.danhsachhanghoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.danhsachhanghoa.Location = new System.Drawing.Point(69, 85);
            this.danhsachhanghoa.Name = "danhsachhanghoa";
            this.danhsachhanghoa.RowHeadersWidth = 51;
            this.danhsachhanghoa.RowTemplate.Height = 24;
            this.danhsachhanghoa.Size = new System.Drawing.Size(790, 288);
            this.danhsachhanghoa.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(678, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(551, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 3;
            // 
            // Tankbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.danhsachhanghoa);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Them);
            this.Name = "Tankbar";
            this.Size = new System.Drawing.Size(973, 454);
            ((System.ComponentModel.ISupportInitialize)(this.danhsachhanghoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Them;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView danhsachhanghoa;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
