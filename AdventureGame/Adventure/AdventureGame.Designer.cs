namespace Adventure
{
    partial class AdventureGame
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
            this.LblHp = new System.Windows.Forms.Label();
            this.LblMp = new System.Windows.Forms.Label();
            this.LblHpCounter = new System.Windows.Forms.Label();
            this.LblMpCounter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblHp
            // 
            this.LblHp.AutoSize = true;
            this.LblHp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHp.Location = new System.Drawing.Point(6, 9);
            this.LblHp.Name = "LblHp";
            this.LblHp.Size = new System.Drawing.Size(68, 25);
            this.LblHp.TabIndex = 0;
            this.LblHp.Text = "Health";
            // 
            // LblMp
            // 
            this.LblMp.AutoSize = true;
            this.LblMp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMp.Location = new System.Drawing.Point(6, 47);
            this.LblMp.Name = "LblMp";
            this.LblMp.Size = new System.Drawing.Size(62, 25);
            this.LblMp.TabIndex = 1;
            this.LblMp.Text = "Mana";
            // 
            // LblHpCounter
            // 
            this.LblHpCounter.AutoSize = true;
            this.LblHpCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHpCounter.Location = new System.Drawing.Point(104, 9);
            this.LblHpCounter.Name = "LblHpCounter";
            this.LblHpCounter.Size = new System.Drawing.Size(0, 25);
            this.LblHpCounter.TabIndex = 2;
            // 
            // LblMpCounter
            // 
            this.LblMpCounter.AutoSize = true;
            this.LblMpCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMpCounter.Location = new System.Drawing.Point(104, 47);
            this.LblMpCounter.Name = "LblMpCounter";
            this.LblMpCounter.Size = new System.Drawing.Size(0, 25);
            this.LblMpCounter.TabIndex = 3;
            // 
            // AdventureGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 626);
            this.Controls.Add(this.LblMpCounter);
            this.Controls.Add(this.LblHpCounter);
            this.Controls.Add(this.LblMp);
            this.Controls.Add(this.LblHp);
            this.Name = "AdventureGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdventureGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblHp;
        private System.Windows.Forms.Label LblMp;
        private System.Windows.Forms.Label LblHpCounter;
        private System.Windows.Forms.Label LblMpCounter;
    }
}