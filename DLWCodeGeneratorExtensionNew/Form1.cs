using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DLWCodeGeneratorExtensionNew
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // width of ellipse
           int nHeightEllipse // height of ellipse
       );

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));


        }

        private void MinimizeWindowButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void CloseScreenButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CodeGenScreenButton = new System.Windows.Forms.Button();
            this.ProjAnalysisScreenButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MinimizeWindowButton = new System.Windows.Forms.Button();
            this.CloseScreenButton = new System.Windows.Forms.Button();
            this.codeAnalyzeScreen1 = new DLWCodeGeneratorExtensionNew.CodeAnalyzeScreen();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panel1.Controls.Add(this.CodeGenScreenButton);
            this.panel1.Controls.Add(this.ProjAnalysisScreenButton);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(126, 368);
            this.panel1.TabIndex = 0;
            // 
            // CodeGenScreenButton
            // 
            this.CodeGenScreenButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(96)))), ((int)(((byte)(85)))));
            this.CodeGenScreenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CodeGenScreenButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeGenScreenButton.ForeColor = System.Drawing.Color.White;
            this.CodeGenScreenButton.Location = new System.Drawing.Point(0, 180);
            this.CodeGenScreenButton.Name = "CodeGenScreenButton";
            this.CodeGenScreenButton.Size = new System.Drawing.Size(126, 60);
            this.CodeGenScreenButton.TabIndex = 2;
            this.CodeGenScreenButton.Text = "Code Generator";
            this.CodeGenScreenButton.UseVisualStyleBackColor = false;
            // 
            // ProjAnalysisScreenButton
            // 
            this.ProjAnalysisScreenButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(96)))), ((int)(((byte)(85)))));
            this.ProjAnalysisScreenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProjAnalysisScreenButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjAnalysisScreenButton.ForeColor = System.Drawing.Color.White;
            this.ProjAnalysisScreenButton.Location = new System.Drawing.Point(0, 114);
            this.ProjAnalysisScreenButton.Name = "ProjAnalysisScreenButton";
            this.ProjAnalysisScreenButton.Size = new System.Drawing.Size(126, 60);
            this.ProjAnalysisScreenButton.TabIndex = 1;
            this.ProjAnalysisScreenButton.Text = "Project Analyzer";
            this.ProjAnalysisScreenButton.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(96)))), ((int)(((byte)(85)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.TitleLabel);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(126, 108);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Made by \r\nMusa Israilov";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(3, 5);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(100, 21);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "X++ AI Tools";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panel2.Controls.Add(this.MinimizeWindowButton);
            this.panel2.Controls.Add(this.CloseScreenButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(126, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(263, 26);
            this.panel2.TabIndex = 1;
            // 
            // MinimizeWindowButton
            // 
            this.MinimizeWindowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.MinimizeWindowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeWindowButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeWindowButton.ForeColor = System.Drawing.Color.White;
            this.MinimizeWindowButton.Location = new System.Drawing.Point(109, -2);
            this.MinimizeWindowButton.Name = "MinimizeWindowButton";
            this.MinimizeWindowButton.Size = new System.Drawing.Size(79, 25);
            this.MinimizeWindowButton.TabIndex = 7;
            this.MinimizeWindowButton.Text = "Minimize";
            this.MinimizeWindowButton.UseVisualStyleBackColor = false;
            this.MinimizeWindowButton.Click += new System.EventHandler(this.MinimizeWindowButton_Click);
            // 
            // CloseScreenButton
            // 
            this.CloseScreenButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.CloseScreenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseScreenButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseScreenButton.ForeColor = System.Drawing.Color.White;
            this.CloseScreenButton.Location = new System.Drawing.Point(184, -2);
            this.CloseScreenButton.Name = "CloseScreenButton";
            this.CloseScreenButton.Size = new System.Drawing.Size(79, 25);
            this.CloseScreenButton.TabIndex = 6;
            this.CloseScreenButton.Text = "Close";
            this.CloseScreenButton.UseVisualStyleBackColor = false;
            this.CloseScreenButton.Click += new System.EventHandler(this.CloseScreenButton_Click);
            // 
            // codeAnalyzeScreen1
            // 
            this.codeAnalyzeScreen1.Location = new System.Drawing.Point(135, 36);
            this.codeAnalyzeScreen1.Name = "codeAnalyzeScreen1";
            this.codeAnalyzeScreen1.Size = new System.Drawing.Size(254, 332);
            this.codeAnalyzeScreen1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 368);
            this.Controls.Add(this.codeAnalyzeScreen1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
