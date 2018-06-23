namespace DarkHeresyForm
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
            this.rtbCharacterTwo = new System.Windows.Forms.RichTextBox();
            this.rtbCharacterOne = new System.Windows.Forms.RichTextBox();
            this.rtbCharacterThree = new System.Windows.Forms.RichTextBox();
            this.rtbMainText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbCharacterTwo
            // 
            this.rtbCharacterTwo.BackColor = System.Drawing.SystemColors.MenuText;
            this.rtbCharacterTwo.Location = new System.Drawing.Point(593, 5);
            this.rtbCharacterTwo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbCharacterTwo.Name = "rtbCharacterTwo";
            this.rtbCharacterTwo.Size = new System.Drawing.Size(515, 303);
            this.rtbCharacterTwo.TabIndex = 1;
            this.rtbCharacterTwo.Text = "";
            // 
            // rtbCharacterOne
            // 
            this.rtbCharacterOne.BackColor = System.Drawing.SystemColors.MenuText;
            this.rtbCharacterOne.Location = new System.Drawing.Point(47, 4);
            this.rtbCharacterOne.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbCharacterOne.Name = "rtbCharacterOne";
            this.rtbCharacterOne.Size = new System.Drawing.Size(515, 304);
            this.rtbCharacterOne.TabIndex = 2;
            this.rtbCharacterOne.Text = "";
            // 
            // rtbCharacterThree
            // 
            this.rtbCharacterThree.BackColor = System.Drawing.SystemColors.MenuText;
            this.rtbCharacterThree.Location = new System.Drawing.Point(1148, 4);
            this.rtbCharacterThree.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbCharacterThree.Name = "rtbCharacterThree";
            this.rtbCharacterThree.Size = new System.Drawing.Size(515, 304);
            this.rtbCharacterThree.TabIndex = 3;
            this.rtbCharacterThree.Text = "";
            // 
            // rtbMainText
            // 
            this.rtbMainText.BackColor = System.Drawing.SystemColors.MenuText;
            this.rtbMainText.Location = new System.Drawing.Point(392, 343);
            this.rtbMainText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbMainText.Name = "rtbMainText";
            this.rtbMainText.Size = new System.Drawing.Size(894, 411);
            this.rtbMainText.TabIndex = 4;
            this.rtbMainText.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1711, 811);
            this.Controls.Add(this.rtbMainText);
            this.Controls.Add(this.rtbCharacterThree);
            this.Controls.Add(this.rtbCharacterOne);
            this.Controls.Add(this.rtbCharacterTwo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbCharacterTwo;
        private System.Windows.Forms.RichTextBox rtbCharacterOne;
        private System.Windows.Forms.RichTextBox rtbCharacterThree;
        private System.Windows.Forms.RichTextBox rtbMainText;
    }
}

