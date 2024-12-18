namespace _07_demo_windows_forms
{
    partial class FormNewSale
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            cbo_beer = new ComboBox();
            txtQuantity = new NumericUpDown();
            button1 = new Button();
            dgv = new DataGridView();
            IdBeer = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            BeerName = new DataGridViewTextBoxColumn();
            UnitPrice = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            button2 = new Button();
            label3 = new Label();
            lbl_total = new Label();
            ((System.ComponentModel.ISupportInitialize)txtQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 59);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 0;
            label1.Text = "Cerveza";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(275, 56);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 1;
            label2.Text = "Cantidad";
            // 
            // cbo_beer
            // 
            cbo_beer.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_beer.FormattingEnabled = true;
            cbo_beer.Location = new Point(103, 56);
            cbo_beer.Name = "cbo_beer";
            cbo_beer.Size = new Size(121, 23);
            cbo_beer.TabIndex = 1;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(336, 54);
            txtQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(120, 23);
            txtQuantity.TabIndex = 2;
            txtQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // button1
            // 
            button1.Location = new Point(467, 56);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { IdBeer, Quantity, BeerName, UnitPrice, Total });
            dgv.Location = new Point(34, 85);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(531, 182);
            dgv.TabIndex = 5;
            // 
            // IdBeer
            // 
            IdBeer.HeaderText = "IdBeer";
            IdBeer.Name = "IdBeer";
            IdBeer.ReadOnly = true;
            IdBeer.Visible = false;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Cantidad";
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // BeerName
            // 
            BeerName.HeaderText = "Nombre";
            BeerName.Name = "BeerName";
            BeerName.ReadOnly = true;
            // 
            // UnitPrice
            // 
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = "0";
            UnitPrice.DefaultCellStyle = dataGridViewCellStyle1;
            UnitPrice.HeaderText = "Precio unitario";
            UnitPrice.Name = "UnitPrice";
            UnitPrice.ReadOnly = true;
            // 
            // Total
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = "0";
            Total.DefaultCellStyle = dataGridViewCellStyle2;
            Total.HeaderText = "Total";
            Total.Name = "Total";
            Total.ReadOnly = true;
            // 
            // button2
            // 
            button2.Location = new Point(450, 273);
            button2.Name = "button2";
            button2.Size = new Size(92, 23);
            button2.TabIndex = 4;
            button2.Text = "Generar venta";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(49, 292);
            label3.Name = "label3";
            label3.Size = new Size(56, 25);
            label3.TabIndex = 6;
            label3.Text = "Total:";
            // 
            // lbl_total
            // 
            lbl_total.AutoSize = true;
            lbl_total.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_total.Location = new Point(103, 292);
            lbl_total.Name = "lbl_total";
            lbl_total.Size = new Size(61, 25);
            lbl_total.TabIndex = 7;
            lbl_total.Text = "$ 0.00";
            // 
            // FormNewSale
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(616, 365);
            Controls.Add(lbl_total);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(dgv);
            Controls.Add(button1);
            Controls.Add(txtQuantity);
            Controls.Add(cbo_beer);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormNewSale";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nueva venta";
            Load += FormNewSale_Load;
            ((System.ComponentModel.ISupportInitialize)txtQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cbo_beer;
        private NumericUpDown txtQuantity;
        private Button button1;
        private DataGridView dgv;
        private Button button2;
        private DataGridViewTextBoxColumn IdBeer;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn BeerName;
        private DataGridViewTextBoxColumn UnitPrice;
        private DataGridViewTextBoxColumn Total;
        private Label label3;
        private Label lbl_total;
    }
}