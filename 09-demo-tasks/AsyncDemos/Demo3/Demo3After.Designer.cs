namespace AsyncDemos.Demo3
{
    partial class Demo3After
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
            lblMessage = new Label();
            label1 = new Label();
            textBox2 = new TextBox();
            lstAmiibos = new ListBox();
            btnSearch = new Button();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(29, 320);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(114, 15);
            lblMessage.TabIndex = 13;
            lblMessage.Text = "Important messages";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(461, 81);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 11;
            label1.Text = "Notes";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(450, 121);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(110, 191);
            textBox2.TabIndex = 10;
            // 
            // lstAmiibos
            // 
            lstAmiibos.FormattingEnabled = true;
            lstAmiibos.ItemHeight = 15;
            lstAmiibos.Location = new Point(27, 83);
            lstAmiibos.Name = "lstAmiibos";
            lstAmiibos.Size = new Size(392, 229);
            lstAmiibos.TabIndex = 9;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(450, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 45);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // Demo1Before
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 364);
            Controls.Add(lblMessage);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(lstAmiibos);
            Controls.Add(btnSearch);
            Name = "Demo1Before";
            Text = "Demo1Before";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMessage;
        private Label label1;
        private TextBox textBox2;
        private ListBox lstAmiibos;
        private Button btnSearch;
    }
}