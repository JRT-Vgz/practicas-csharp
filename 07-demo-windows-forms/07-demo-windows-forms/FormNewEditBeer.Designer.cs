namespace _07_demo_windows_forms
{
    partial class FormNewEditBeer
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            cboBrand = new ComboBox();
            txtAlcohol = new TextBox();
            button1 = new Button();
            txtDescription = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtPrice = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)txtPrice).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 31);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 65);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 1;
            label2.Text = "Marca";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(60, 100);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 2;
            label3.Text = "Alcohol";
            // 
            // txtName
            // 
            txtName.Location = new Point(130, 28);
            txtName.MaxLength = 50;
            txtName.Name = "txtName";
            txtName.Size = new Size(169, 23);
            txtName.TabIndex = 1;
            // 
            // cboBrand
            // 
            cboBrand.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBrand.FormattingEnabled = true;
            cboBrand.Location = new Point(130, 62);
            cboBrand.Name = "cboBrand";
            cboBrand.Size = new Size(121, 23);
            cboBrand.TabIndex = 2;
            // 
            // txtAlcohol
            // 
            txtAlcohol.Location = new Point(130, 97);
            txtAlcohol.MaxLength = 18;
            txtAlcohol.Name = "txtAlcohol";
            txtAlcohol.Size = new Size(100, 23);
            txtAlcohol.TabIndex = 3;
            txtAlcohol.KeyPress += txtAlcohol_KeyPress;
            // 
            // button1
            // 
            button1.Location = new Point(155, 216);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(130, 133);
            txtDescription.MaxLength = 50;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(169, 23);
            txtDescription.TabIndex = 4;
            txtDescription.TextChanged += textBox1_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(60, 136);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 5;
            label4.Text = "Descripción";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(60, 177);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 6;
            label5.Text = "Precio";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(130, 175);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(120, 23);
            txtPrice.TabIndex = 5;
            // 
            // FormNewEditBeer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 264);
            Controls.Add(txtPrice);
            Controls.Add(label5);
            Controls.Add(txtDescription);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(txtAlcohol);
            Controls.Add(cboBrand);
            Controls.Add(txtName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormNewEditBeer";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nueva Cerveza";
            Load += FormNewEditBeer_Load;
            ((System.ComponentModel.ISupportInitialize)txtPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtName;
        private ComboBox cboBrand;
        private TextBox txtAlcohol;
        private Button button1;
        private TextBox txtDescription;
        private Label label4;
        private Label label5;
        private NumericUpDown txtPrice;
    }
}