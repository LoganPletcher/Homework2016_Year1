namespace CLass_Practice
{
    partial class VictoryWindow
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
            this.saveButton = new System.Windows.Forms.Button();
            this.restartButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.Vtext = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveButton.BackColor = System.Drawing.Color.Black;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.Gold;
            this.saveButton.Location = new System.Drawing.Point(490, 266);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(105, 47);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save Party";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // restartButton
            // 
            this.restartButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.restartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restartButton.Font = new System.Drawing.Font("Algerian", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartButton.ForeColor = System.Drawing.Color.Gold;
            this.restartButton.Location = new System.Drawing.Point(490, 213);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(105, 47);
            this.restartButton.TabIndex = 1;
            this.restartButton.Text = "Replay the Game";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.quitButton.BackColor = System.Drawing.Color.Transparent;
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitButton.Font = new System.Drawing.Font("Algerian", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.ForeColor = System.Drawing.Color.Black;
            this.quitButton.Location = new System.Drawing.Point(490, 319);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(105, 47);
            this.quitButton.TabIndex = 2;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // Vtext
            // 
            this.Vtext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Vtext.BackColor = System.Drawing.Color.Red;
            this.Vtext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Vtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Vtext.Location = new System.Drawing.Point(490, 108);
            this.Vtext.Multiline = true;
            this.Vtext.Name = "Vtext";
            this.Vtext.Size = new System.Drawing.Size(105, 32);
            this.Vtext.TabIndex = 3;
            this.Vtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // VictoryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1069, 542);
            this.Controls.Add(this.Vtext);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.saveButton);
            this.Name = "VictoryWindow";
            this.Text = "VictoryWindow";
            this.Load += new System.EventHandler(this.VictoryWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.TextBox Vtext;
    }
}