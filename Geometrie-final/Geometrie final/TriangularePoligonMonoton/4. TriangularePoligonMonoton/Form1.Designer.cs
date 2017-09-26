namespace _4.TriangularePoligonMonoton
{
    partial class Form1
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
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.mnuTests = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTestsClear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTestsTriangulate = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu1
            // 
            this.MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTests});
            this.MainMenu1.Location = new System.Drawing.Point(0, 0);
            this.MainMenu1.Name = "MainMenu1";
            this.MainMenu1.Size = new System.Drawing.Size(355, 24);
            this.MainMenu1.TabIndex = 0;
            this.MainMenu1.Text = "menuStrip1";
            // 
            // mnuTests
            // 
            this.mnuTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTestsClear,
            this.mnuTestsTriangulate});
            this.mnuTests.Name = "mnuTests";
            this.mnuTests.Size = new System.Drawing.Size(41, 20);
            this.mnuTests.Text = "Test";
            // 
            // mnuTestsClear
            // 
            this.mnuTestsClear.Name = "mnuTestsClear";
            this.mnuTestsClear.Size = new System.Drawing.Size(152, 22);
            this.mnuTestsClear.Text = "Clear";
            this.mnuTestsClear.Click += new System.EventHandler(this.mnuTestsClear_Click);
            // 
            // mnuTestsTriangulate
            // 
            this.mnuTestsTriangulate.Name = "mnuTestsTriangulate";
            this.mnuTestsTriangulate.Size = new System.Drawing.Size(152, 22);
            this.mnuTestsTriangulate.Text = "Triangulate";
            this.mnuTestsTriangulate.Click += new System.EventHandler(this.mnuTestsTriangulate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 357);
            this.Controls.Add(this.MainMenu1);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu1;
        private System.Windows.Forms.ToolStripMenuItem mnuTests;
        private System.Windows.Forms.ToolStripMenuItem mnuTestsClear;
        private System.Windows.Forms.ToolStripMenuItem mnuTestsTriangulate;
    }
}

