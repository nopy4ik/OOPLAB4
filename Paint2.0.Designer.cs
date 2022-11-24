namespace OOPLAB4
{
    partial class Form1
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
            this.canvas1 = new System.Windows.Forms.PictureBox();
            this.commandLine = new System.Windows.Forms.TextBox();
            this.commandLog = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.canvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas1
            // 
            this.canvas1.BackColor = System.Drawing.Color.White;
            this.canvas1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.canvas1.Location = new System.Drawing.Point(12, 12);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(1000, 500);
            this.canvas1.TabIndex = 0;
            this.canvas1.TabStop = false;
            // 
            // commandLine
            // 
            this.commandLine.BackColor = System.Drawing.SystemColors.MenuText;
            this.commandLine.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.commandLine.Location = new System.Drawing.Point(12, 518);
            this.commandLine.Name = "commandLine";
            this.commandLine.Size = new System.Drawing.Size(1000, 27);
            this.commandLine.TabIndex = 1;
            this.commandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComandLine_KeyDown);
            // 
            // commandLog
            // 
            this.commandLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.commandLog.FormattingEnabled = true;
            this.commandLog.Location = new System.Drawing.Point(12, 550);
            this.commandLog.Name = "commandLog";
            this.commandLog.Size = new System.Drawing.Size(1000, 28);
            this.commandLog.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 590);
            this.Controls.Add(this.commandLog);
            this.Controls.Add(this.commandLine);
            this.Controls.Add(this.canvas1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.canvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox canvas1;
        private TextBox commandLine;
        private ComboBox commandLog;
    }
}