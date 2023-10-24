namespace WindowsFormsApp1
{
    partial class UpdateForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.CategorytextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DescriptiontextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CounttextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.DisconttextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuppliertextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ManuftextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.MaxtdisextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CosttextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NametextBox = new System.Windows.Forms.TextBox();
            this.IDtextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Vladimir Script", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(61, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 44);
            this.button1.TabIndex = 49;
            this.button1.Text = "Изменить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(493, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 16);
            this.label10.TabIndex = 48;
            this.label10.Text = "Категория";
            // 
            // CategorytextBox
            // 
            this.CategorytextBox.Location = new System.Drawing.Point(496, 72);
            this.CategorytextBox.Name = "CategorytextBox";
            this.CategorytextBox.Size = new System.Drawing.Size(100, 22);
            this.CategorytextBox.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(348, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 46;
            this.label7.Text = "Описание";
            // 
            // DescriptiontextBox
            // 
            this.DescriptiontextBox.Location = new System.Drawing.Point(351, 231);
            this.DescriptiontextBox.Multiline = true;
            this.DescriptiontextBox.Name = "DescriptiontextBox";
            this.DescriptiontextBox.Size = new System.Drawing.Size(175, 64);
            this.DescriptiontextBox.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(162, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 16);
            this.label8.TabIndex = 44;
            this.label8.Text = "Количество на складе";
            // 
            // CounttextBox
            // 
            this.CounttextBox.Location = new System.Drawing.Point(195, 241);
            this.CounttextBox.Name = "CounttextBox";
            this.CounttextBox.Size = new System.Drawing.Size(100, 22);
            this.CounttextBox.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(58, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 16);
            this.label9.TabIndex = 42;
            this.label9.Text = "Скидка";
            // 
            // DisconttextBox
            // 
            this.DisconttextBox.Location = new System.Drawing.Point(61, 241);
            this.DisconttextBox.Name = "DisconttextBox";
            this.DisconttextBox.Size = new System.Drawing.Size(100, 22);
            this.DisconttextBox.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 40;
            this.label4.Text = "Поставщик";
            // 
            // SuppliertextBox
            // 
            this.SuppliertextBox.Location = new System.Drawing.Point(351, 164);
            this.SuppliertextBox.Name = "SuppliertextBox";
            this.SuppliertextBox.Size = new System.Drawing.Size(100, 22);
            this.SuppliertextBox.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 38;
            this.label5.Text = "Изготовитель";
            // 
            // ManuftextBox
            // 
            this.ManuftextBox.Location = new System.Drawing.Point(195, 164);
            this.ManuftextBox.Name = "ManuftextBox";
            this.ManuftextBox.Size = new System.Drawing.Size(100, 22);
            this.ManuftextBox.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "Max Скидка";
            // 
            // MaxtdisextBox
            // 
            this.MaxtdisextBox.Location = new System.Drawing.Point(61, 164);
            this.MaxtdisextBox.Name = "MaxtdisextBox";
            this.MaxtdisextBox.Size = new System.Drawing.Size(100, 22);
            this.MaxtdisextBox.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "Стоимость";
            // 
            // CosttextBox
            // 
            this.CosttextBox.Location = new System.Drawing.Point(351, 72);
            this.CosttextBox.Name = "CosttextBox";
            this.CosttextBox.Size = new System.Drawing.Size(100, 22);
            this.CosttextBox.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 16);
            this.label2.TabIndex = 32;
            this.label2.Text = "Название товара";
            // 
            // NametextBox
            // 
            this.NametextBox.Location = new System.Drawing.Point(195, 72);
            this.NametextBox.Name = "NametextBox";
            this.NametextBox.Size = new System.Drawing.Size(100, 22);
            this.NametextBox.TabIndex = 31;
            // 
            // IDtextBox
            // 
            this.IDtextBox.Location = new System.Drawing.Point(61, 72);
            this.IDtextBox.Name = "IDtextBox";
            this.IDtextBox.Size = new System.Drawing.Size(100, 22);
            this.IDtextBox.TabIndex = 29;
            this.IDtextBox.TextChanged += new System.EventHandler(this.IDtextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "ID(Номер)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(602, 112);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 183);
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(717, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 16);
            this.label11.TabIndex = 51;
            this.label11.Text = "Фото";
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CategorytextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DescriptiontextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CounttextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.DisconttextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SuppliertextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ManuftextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MaxtdisextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CosttextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NametextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IDtextBox);
            this.Name = "UpdateForm";
            this.Text = "UpdateForm";
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox CategorytextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox DescriptiontextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox CounttextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox DisconttextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SuppliertextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ManuftextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox MaxtdisextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CosttextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NametextBox;
        private System.Windows.Forms.TextBox IDtextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label11;
    }
}