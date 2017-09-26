namespace ArtGalleryProblem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel_screen = new System.Windows.Forms.Panel();
            this.lbl_cords = new System.Windows.Forms.Label();
            this.cmd_clear = new System.Windows.Forms.Button();
            this.cmd_cut = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_screen.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_screen
            // 
            this.panel_screen.BackColor = System.Drawing.Color.Gray;
            this.panel_screen.Controls.Add(this.label1);
            this.panel_screen.Controls.Add(this.lbl_cords);
            this.panel_screen.Location = new System.Drawing.Point(0, -2);
            this.panel_screen.Name = "panel_screen";
            this.panel_screen.Size = new System.Drawing.Size(939, 450);
            this.panel_screen.TabIndex = 0;
            this.panel_screen.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_screen_Paint);
            this.panel_screen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_screen_MouseMove);
            this.panel_screen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_screen_MouseUp);
            // 
            // lbl_cords
            // 
            this.lbl_cords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_cords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_cords.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_cords.Location = new System.Drawing.Point(846, 433);
            this.lbl_cords.Name = "lbl_cords";
            this.lbl_cords.Size = new System.Drawing.Size(96, 12);
            this.lbl_cords.TabIndex = 4;
            this.lbl_cords.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmd_clear
            // 
            this.cmd_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_clear.FlatAppearance.BorderSize = 0;
            this.cmd_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_clear.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmd_clear.ForeColor = System.Drawing.Color.White;
            this.cmd_clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmd_clear.ImageIndex = 2;
            this.cmd_clear.Location = new System.Drawing.Point(150, 452);
            this.cmd_clear.Name = "cmd_clear";
            this.cmd_clear.Size = new System.Drawing.Size(107, 38);
            this.cmd_clear.TabIndex = 2;
            this.cmd_clear.Text = "Sterge poligonul";
            this.cmd_clear.UseVisualStyleBackColor = true;
            this.cmd_clear.Click += new System.EventHandler(this.cmd_clear_Click);
            // 
            // cmd_cut
            // 
            this.cmd_cut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_cut.Enabled = false;
            this.cmd_cut.FlatAppearance.BorderSize = 0;
            this.cmd_cut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_cut.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_cut.ForeColor = System.Drawing.Color.White;
            this.cmd_cut.ImageIndex = 0;
            this.cmd_cut.Location = new System.Drawing.Point(4, 452);
            this.cmd_cut.Name = "cmd_cut";
            this.cmd_cut.Size = new System.Drawing.Size(107, 38);
            this.cmd_cut.TabIndex = 1;
            this.cmd_cut.Text = "Trianguleaza poligonul";
            this.cmd_cut.UseVisualStyleBackColor = true;
            this.cmd_cut.Click += new System.EventHandler(this.cmd_cut_Click);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(853, 452);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(78, 38);
            this.button5.TabIndex = 13;
            this.button5.Text = "Inchide aplicatia";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(1, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(941, 447);
            this.label1.TabIndex = 14;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(296, 463);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "INFO";
            this.label2.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(939, 494);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.cmd_clear);
            this.Controls.Add(this.cmd_cut);
            this.Controls.Add(this.panel_screen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Problema galeriei de arta - Triangularea poligoanelor";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel_screen.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_screen;
        private System.Windows.Forms.Button cmd_cut;
        private System.Windows.Forms.Button cmd_clear;
        private System.Windows.Forms.Label lbl_cords;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

