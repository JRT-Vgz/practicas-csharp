namespace _07_demo_windows_forms
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            brandsToolStripMenuItem = new ToolStripMenuItem();
            brandsToolStripMenuItem1 = new ToolStripMenuItem();
            cervezasToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            button2 = new Button();
            dgv = new DataGridView();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 415);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { brandsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // brandsToolStripMenuItem
            // 
            brandsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { brandsToolStripMenuItem1, cervezasToolStripMenuItem });
            brandsToolStripMenuItem.Name = "brandsToolStripMenuItem";
            brandsToolStripMenuItem.Size = new Size(93, 20);
            brandsToolStripMenuItem.Text = "Configuration";
            brandsToolStripMenuItem.Click += brandsToolStripMenuItem_Click;
            // 
            // brandsToolStripMenuItem1
            // 
            brandsToolStripMenuItem1.Name = "brandsToolStripMenuItem1";
            brandsToolStripMenuItem1.Size = new Size(120, 22);
            brandsToolStripMenuItem1.Text = "Brands";
            brandsToolStripMenuItem1.Click += brandsToolStripMenuItem1_Click;
            // 
            // cervezasToolStripMenuItem
            // 
            cervezasToolStripMenuItem.Name = "cervezasToolStripMenuItem";
            cervezasToolStripMenuItem.Size = new Size(120, 22);
            cervezasToolStripMenuItem.Text = "Cervezas";
            cervezasToolStripMenuItem.Click += cervezasToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 68);
            panel1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(28, 23);
            button2.Name = "button2";
            button2.Size = new Size(116, 23);
            button2.TabIndex = 0;
            button2.Text = "Nueva venta";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 92);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(800, 358);
            dgv.TabIndex = 3;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMain";
            Text = "Formulario Principal";
            Load += FormMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem brandsToolStripMenuItem;
        private ToolStripMenuItem brandsToolStripMenuItem1;
        private ToolStripMenuItem cervezasToolStripMenuItem;
        private Panel panel1;
        private Button button2;
        private DataGridView dgv;
    }
}
