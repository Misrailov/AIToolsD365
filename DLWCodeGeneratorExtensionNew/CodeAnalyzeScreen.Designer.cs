namespace DLWCodeGeneratorExtensionNew
{
    partial class CodeAnalyzeScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.AnalyseModeBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(96)))), ((int)(((byte)(85)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(100, 307);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(79, 25);
            this.button5.TabIndex = 5;
            this.button5.Text = "Cancel";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(96)))), ((int)(((byte)(85)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(175, 307);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(79, 25);
            this.button6.TabIndex = 4;
            this.button6.Text = "Continue";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // AnalyseModeBox
            // 
            this.AnalyseModeBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AnalyseModeBox.FormattingEnabled = true;
            this.AnalyseModeBox.Items.AddRange(new object[] {
            "Analyze Current Project",
            "Analyze Current Window"});
            this.AnalyseModeBox.Location = new System.Drawing.Point(9, 96);
            this.AnalyseModeBox.Name = "AnalyseModeBox";
            this.AnalyseModeBox.Size = new System.Drawing.Size(242, 21);
            this.AnalyseModeBox.TabIndex = 6;
            this.AnalyseModeBox.Text = "Analyze Current Project";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose Analysis Mode:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 39);
            this.label2.TabIndex = 8;
            this.label2.Text = "Project Analysis";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 307);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(85, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // CodeAnalyzeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AnalyseModeBox);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Name = "CodeAnalyzeScreen";
            this.Size = new System.Drawing.Size(254, 332);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox AnalyseModeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
