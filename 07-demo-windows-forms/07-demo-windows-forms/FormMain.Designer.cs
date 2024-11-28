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
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(380, 207);
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
            brandsToolStripMenuItem1.Size = new Size(180, 22);
            brandsToolStripMenuItem1.Text = "Brands";
            brandsToolStripMenuItem1.Click += brandsToolStripMenuItem1_Click;
            // 
            // cervezasToolStripMenuItem
            // 
            cervezasToolStripMenuItem.Name = "cervezasToolStripMenuItem";
            cervezasToolStripMenuItem.Size = new Size(180, 22);
            cervezasToolStripMenuItem.Text = "Cervezas";
            cervezasToolStripMenuItem.Click += cervezasToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMain";
            Text = "Formulario Principal";
            Load += FormMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem brandsToolStripMenuItem;
        private ToolStripMenuItem brandsToolStripMenuItem1;
        private ToolStripMenuItem cervezasToolStripMenuItem;
    }
}
