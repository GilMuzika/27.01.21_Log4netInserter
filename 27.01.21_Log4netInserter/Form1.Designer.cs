
namespace _27._01._21_Log4netInserter
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
            this.txtPathToTheProject = new System.Windows.Forms.TextBox();
            this.lblPathToTheProject = new System.Windows.Forms.Label();
            this.btnGetPathToTheProject = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblInfoOutput = new System.Windows.Forms.Label();
            this.cmbFilterByExtension = new System.Windows.Forms.ComboBox();
            this.chkFilterByExtension = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtPathToTheProject
            // 
            this.txtPathToTheProject.Location = new System.Drawing.Point(12, 35);
            this.txtPathToTheProject.Name = "txtPathToTheProject";
            this.txtPathToTheProject.Size = new System.Drawing.Size(707, 20);
            this.txtPathToTheProject.TabIndex = 0;
            // 
            // lblPathToTheProject
            // 
            this.lblPathToTheProject.AutoSize = true;
            this.lblPathToTheProject.Location = new System.Drawing.Point(13, 13);
            this.lblPathToTheProject.Name = "lblPathToTheProject";
            this.lblPathToTheProject.Size = new System.Drawing.Size(97, 13);
            this.lblPathToTheProject.TabIndex = 1;
            this.lblPathToTheProject.Text = "Path to the project:";
            // 
            // btnGetPathToTheProject
            // 
            this.btnGetPathToTheProject.Location = new System.Drawing.Point(16, 72);
            this.btnGetPathToTheProject.Name = "btnGetPathToTheProject";
            this.btnGetPathToTheProject.Size = new System.Drawing.Size(127, 23);
            this.btnGetPathToTheProject.TabIndex = 2;
            this.btnGetPathToTheProject.Text = "Get Path to the project";
            this.btnGetPathToTheProject.UseVisualStyleBackColor = true;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(182, 71);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            // 
            // lblInfoOutput
            // 
            this.lblInfoOutput.Location = new System.Drawing.Point(16, 102);
            this.lblInfoOutput.Name = "lblInfoOutput";
            this.lblInfoOutput.Size = new System.Drawing.Size(273, 47);
            this.lblInfoOutput.TabIndex = 4;
            this.lblInfoOutput.Text = "label1";
            // 
            // cmbFilterByExtension
            // 
            this.cmbFilterByExtension.FormattingEnabled = true;
            this.cmbFilterByExtension.Location = new System.Drawing.Point(312, 128);
            this.cmbFilterByExtension.Name = "cmbFilterByExtension";
            this.cmbFilterByExtension.Size = new System.Drawing.Size(63, 21);
            this.cmbFilterByExtension.TabIndex = 5;
            // 
            // chkFilterByExtension
            // 
            this.chkFilterByExtension.AutoSize = true;
            this.chkFilterByExtension.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFilterByExtension.Location = new System.Drawing.Point(312, 102);
            this.chkFilterByExtension.Name = "chkFilterByExtension";
            this.chkFilterByExtension.Size = new System.Drawing.Size(110, 17);
            this.chkFilterByExtension.TabIndex = 6;
            this.chkFilterByExtension.Text = "Filter by extension";
            this.chkFilterByExtension.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chkFilterByExtension);
            this.Controls.Add(this.cmbFilterByExtension);
            this.Controls.Add(this.lblInfoOutput);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnGetPathToTheProject);
            this.Controls.Add(this.lblPathToTheProject);
            this.Controls.Add(this.txtPathToTheProject);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPathToTheProject;
        private System.Windows.Forms.Label lblPathToTheProject;
        private System.Windows.Forms.Button btnGetPathToTheProject;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblInfoOutput;
        private System.Windows.Forms.ComboBox cmbFilterByExtension;
        private System.Windows.Forms.CheckBox chkFilterByExtension;
    }
}

