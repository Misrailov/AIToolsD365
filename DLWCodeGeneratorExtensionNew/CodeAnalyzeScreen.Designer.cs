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
            this.components = new System.ComponentModel.Container();
            this.button6 = new System.Windows.Forms.Button();
            this.AnalyseModeBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.errorTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resetButton = new System.Windows.Forms.Button();
            this.currentProjectText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(183)))), ((int)(((byte)(189)))));
            this.button6.FlatAppearance.BorderSize = 0;
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
            this.AnalyseModeBox.BackColor = System.Drawing.Color.White;
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
            this.progressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBar1.Location = new System.Drawing.Point(9, 307);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(85, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLabel.Location = new System.Drawing.Point(9, 157);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(36, 16);
            this.ErrorLabel.TabIndex = 10;
            this.ErrorLabel.Text = "Errors:";
            this.ErrorLabel.Click += new System.EventHandler(this.ErrorLabel_Click);
            // 
            // errorTextBox
            // 
            this.errorTextBox.BackColor = System.Drawing.Color.White;
            this.errorTextBox.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorTextBox.ForeColor = System.Drawing.Color.Red;
            this.errorTextBox.Location = new System.Drawing.Point(12, 176);
            this.errorTextBox.Multiline = true;
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.Size = new System.Drawing.Size(225, 99);
            this.errorTextBox.TabIndex = 11;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(183)))), ((int)(((byte)(189)))));
            this.resetButton.FlatAppearance.BorderSize = 0;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.ForeColor = System.Drawing.Color.White;
            this.resetButton.Location = new System.Drawing.Point(175, 307);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(79, 25);
            this.resetButton.TabIndex = 12;
            this.resetButton.Text = "reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // currentProjectText
            // 
            this.currentProjectText.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentProjectText.Location = new System.Drawing.Point(9, 123);
            this.currentProjectText.Name = "currentProjectText";
            this.currentProjectText.ReadOnly = true;
            this.currentProjectText.Size = new System.Drawing.Size(245, 160);
            this.currentProjectText.TabIndex = 13;
            this.currentProjectText.Text = "";
            // 
            // CodeAnalyzeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.currentProjectText);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.errorTextBox);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AnalyseModeBox);
            this.Controls.Add(this.button6);
            this.Name = "CodeAnalyzeScreen";
            this.Size = new System.Drawing.Size(280, 350);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox AnalyseModeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.TextBox errorTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.RichTextBox currentProjectText;
    }
}
