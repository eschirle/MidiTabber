namespace MidiTabber
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
            this.SelectMidiFileButton = new System.Windows.Forms.Button();
            this.WriteTabButton = new System.Windows.Forms.Button();
            this.SelectFileTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SelectMidiFileButton
            // 
            this.SelectMidiFileButton.Location = new System.Drawing.Point(231, 126);
            this.SelectMidiFileButton.Name = "SelectMidiFileButton";
            this.SelectMidiFileButton.Size = new System.Drawing.Size(75, 40);
            this.SelectMidiFileButton.TabIndex = 0;
            this.SelectMidiFileButton.Text = "Select Midi File";
            this.SelectMidiFileButton.UseVisualStyleBackColor = true;
            this.SelectMidiFileButton.Click += new System.EventHandler(this.SelectMidiFileButton_Click);
            // 
            // WriteTabButton
            // 
            this.WriteTabButton.Location = new System.Drawing.Point(347, 126);
            this.WriteTabButton.Name = "WriteTabButton";
            this.WriteTabButton.Size = new System.Drawing.Size(75, 40);
            this.WriteTabButton.TabIndex = 1;
            this.WriteTabButton.Text = "Write Tab";
            this.WriteTabButton.UseVisualStyleBackColor = true;
            this.WriteTabButton.Click += new System.EventHandler(this.WriteTabButton_Click);
            // 
            // SelectFileTextBox
            // 
            this.SelectFileTextBox.Location = new System.Drawing.Point(12, 80);
            this.SelectFileTextBox.Name = "SelectFileTextBox";
            this.SelectFileTextBox.Size = new System.Drawing.Size(423, 20);
            this.SelectFileTextBox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 346);
            this.Controls.Add(this.SelectFileTextBox);
            this.Controls.Add(this.WriteTabButton);
            this.Controls.Add(this.SelectMidiFileButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Midi Tabber";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectMidiFileButton;
        private System.Windows.Forms.Button WriteTabButton;
        private System.Windows.Forms.TextBox SelectFileTextBox;
    }
}

