
namespace Point_of_Sale
{
    partial class OrderForm
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
            this.comboBoxFirstCourse = new System.Windows.Forms.ComboBox();
            this.comboBoxMainCourse = new System.Windows.Forms.ComboBox();
            this.comboBoxDessert = new System.Windows.Forms.ComboBox();
            this.comboBoxDrink = new System.Windows.Forms.ComboBox();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelSubTotal = new System.Windows.Forms.Label();
            this.labelItbis = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxFirstCourse
            // 
            this.comboBoxFirstCourse.FormattingEnabled = true;
            this.comboBoxFirstCourse.Location = new System.Drawing.Point(148, 107);
            this.comboBoxFirstCourse.Name = "comboBoxFirstCourse";
            this.comboBoxFirstCourse.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFirstCourse.TabIndex = 2;
            this.comboBoxFirstCourse.SelectionChangeCommitted += new System.EventHandler(this.comboBoxFirstCourse_SelectionChangeCommitted);
            // 
            // comboBoxMainCourse
            // 
            this.comboBoxMainCourse.FormattingEnabled = true;
            this.comboBoxMainCourse.Location = new System.Drawing.Point(148, 168);
            this.comboBoxMainCourse.Name = "comboBoxMainCourse";
            this.comboBoxMainCourse.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMainCourse.TabIndex = 3;
            this.comboBoxMainCourse.SelectionChangeCommitted += new System.EventHandler(this.comboBoxMainCourse_SelectionChangeCommitted);
            // 
            // comboBoxDessert
            // 
            this.comboBoxDessert.FormattingEnabled = true;
            this.comboBoxDessert.Location = new System.Drawing.Point(148, 223);
            this.comboBoxDessert.Name = "comboBoxDessert";
            this.comboBoxDessert.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDessert.TabIndex = 4;
            this.comboBoxDessert.SelectionChangeCommitted += new System.EventHandler(this.comboBoxDessert_SelectionChangeCommitted);
            // 
            // comboBoxDrink
            // 
            this.comboBoxDrink.FormattingEnabled = true;
            this.comboBoxDrink.Location = new System.Drawing.Point(148, 272);
            this.comboBoxDrink.Name = "comboBoxDrink";
            this.comboBoxDrink.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDrink.TabIndex = 5;
            this.comboBoxDrink.SelectionChangeCommitted += new System.EventHandler(this.comboBoxDrink_SelectionChangeCommitted);
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(148, 69);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(121, 20);
            this.txtClientName.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(206, 330);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "CREATE ORDER";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "CLIENT NAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "FIRST COURSE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "MAIN COURSE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "DESSERT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "DRINK";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(125, 396);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "SUB TOTAL";
            // 
            // labelSubTotal
            // 
            this.labelSubTotal.AutoSize = true;
            this.labelSubTotal.Location = new System.Drawing.Point(202, 395);
            this.labelSubTotal.Name = "labelSubTotal";
            this.labelSubTotal.Size = new System.Drawing.Size(22, 13);
            this.labelSubTotal.TabIndex = 12;
            this.labelSubTotal.Text = "0.0";
            // 
            // labelItbis
            // 
            this.labelItbis.AutoSize = true;
            this.labelItbis.Location = new System.Drawing.Point(202, 419);
            this.labelItbis.Name = "labelItbis";
            this.labelItbis.Size = new System.Drawing.Size(22, 13);
            this.labelItbis.TabIndex = 14;
            this.labelItbis.Text = "0.0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(125, 420);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "ITBIS";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(202, 447);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(22, 13);
            this.labelTotal.TabIndex = 16;
            this.labelTotal.Text = "0.0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(125, 448);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "TOTAL";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(33, 330);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "CLEAN SELECTION";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 493);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelItbis);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelSubTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.comboBoxDrink);
            this.Controls.Add(this.comboBoxDessert);
            this.Controls.Add(this.comboBoxMainCourse);
            this.Controls.Add(this.comboBoxFirstCourse);
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderForm";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFirstCourse;
        private System.Windows.Forms.ComboBox comboBoxMainCourse;
        private System.Windows.Forms.ComboBox comboBoxDessert;
        private System.Windows.Forms.ComboBox comboBoxDrink;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelSubTotal;
        private System.Windows.Forms.Label labelItbis;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button2;
    }
}