namespace AdventureMain
{
    partial class AdventureMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHpStatic = new System.Windows.Forms.Label();
            this.lblHp = new System.Windows.Forms.Label();
            this.lblLvStatic = new System.Windows.Forms.Label();
            this.lblXpStatic = new System.Windows.Forms.Label();
            this.lblGpStatic = new System.Windows.Forms.Label();
            this.lblLv = new System.Windows.Forms.Label();
            this.lblXp = new System.Windows.Forms.Label();
            this.lblGp = new System.Windows.Forms.Label();
            this.BtnMoveNorth = new System.Windows.Forms.Button();
            this.BtnMoveSouth = new System.Windows.Forms.Button();
            this.BtnMoveEast = new System.Windows.Forms.Button();
            this.BtnMoveWest = new System.Windows.Forms.Button();
            this.BtnInteract = new System.Windows.Forms.Button();
            this.InventoryView = new System.Windows.Forms.DataGridView();
            this.infoBox = new System.Windows.Forms.RichTextBox();
            this.MinimapGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimapGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHpStatic
            // 
            this.lblHpStatic.AutoSize = true;
            this.lblHpStatic.Location = new System.Drawing.Point(12, 9);
            this.lblHpStatic.Name = "lblHpStatic";
            this.lblHpStatic.Size = new System.Drawing.Size(41, 13);
            this.lblHpStatic.TabIndex = 0;
            this.lblHpStatic.Text = "Health:";
            // 
            // lblHp
            // 
            this.lblHp.AutoSize = true;
            this.lblHp.Location = new System.Drawing.Point(57, 9);
            this.lblHp.Name = "lblHp";
            this.lblHp.Size = new System.Drawing.Size(0, 13);
            this.lblHp.TabIndex = 1;
            // 
            // lblLvStatic
            // 
            this.lblLvStatic.AutoSize = true;
            this.lblLvStatic.Location = new System.Drawing.Point(12, 31);
            this.lblLvStatic.Name = "lblLvStatic";
            this.lblLvStatic.Size = new System.Drawing.Size(36, 13);
            this.lblLvStatic.TabIndex = 2;
            this.lblLvStatic.Text = "Level:";
            // 
            // lblXpStatic
            // 
            this.lblXpStatic.AutoSize = true;
            this.lblXpStatic.Location = new System.Drawing.Point(12, 53);
            this.lblXpStatic.Name = "lblXpStatic";
            this.lblXpStatic.Size = new System.Drawing.Size(24, 13);
            this.lblXpStatic.TabIndex = 3;
            this.lblXpStatic.Text = "XP:";
            // 
            // lblGpStatic
            // 
            this.lblGpStatic.AutoSize = true;
            this.lblGpStatic.Location = new System.Drawing.Point(12, 75);
            this.lblGpStatic.Name = "lblGpStatic";
            this.lblGpStatic.Size = new System.Drawing.Size(32, 13);
            this.lblGpStatic.TabIndex = 4;
            this.lblGpStatic.Text = "Gold:";
            // 
            // lblLv
            // 
            this.lblLv.AutoSize = true;
            this.lblLv.Location = new System.Drawing.Point(57, 31);
            this.lblLv.Name = "lblLv";
            this.lblLv.Size = new System.Drawing.Size(0, 13);
            this.lblLv.TabIndex = 5;
            // 
            // lblXp
            // 
            this.lblXp.AutoSize = true;
            this.lblXp.Location = new System.Drawing.Point(57, 53);
            this.lblXp.Name = "lblXp";
            this.lblXp.Size = new System.Drawing.Size(0, 13);
            this.lblXp.TabIndex = 6;
            // 
            // lblGp
            // 
            this.lblGp.AutoSize = true;
            this.lblGp.Location = new System.Drawing.Point(57, 75);
            this.lblGp.Name = "lblGp";
            this.lblGp.Size = new System.Drawing.Size(0, 13);
            this.lblGp.TabIndex = 7;
            // 
            // BtnMoveNorth
            // 
            this.BtnMoveNorth.Location = new System.Drawing.Point(570, 475);
            this.BtnMoveNorth.Margin = new System.Windows.Forms.Padding(0);
            this.BtnMoveNorth.Name = "BtnMoveNorth";
            this.BtnMoveNorth.Size = new System.Drawing.Size(100, 35);
            this.BtnMoveNorth.TabIndex = 8;
            this.BtnMoveNorth.Text = "North";
            this.BtnMoveNorth.UseVisualStyleBackColor = true;
            this.BtnMoveNorth.Click += new System.EventHandler(this.BtnMoveNorth_Click);
            // 
            // BtnMoveSouth
            // 
            this.BtnMoveSouth.Location = new System.Drawing.Point(570, 510);
            this.BtnMoveSouth.Margin = new System.Windows.Forms.Padding(0);
            this.BtnMoveSouth.Name = "BtnMoveSouth";
            this.BtnMoveSouth.Size = new System.Drawing.Size(100, 35);
            this.BtnMoveSouth.TabIndex = 9;
            this.BtnMoveSouth.Text = "South";
            this.BtnMoveSouth.UseVisualStyleBackColor = true;
            this.BtnMoveSouth.Click += new System.EventHandler(this.BtnMoveSouth_Click);
            // 
            // BtnMoveEast
            // 
            this.BtnMoveEast.Location = new System.Drawing.Point(670, 510);
            this.BtnMoveEast.Margin = new System.Windows.Forms.Padding(0);
            this.BtnMoveEast.Name = "BtnMoveEast";
            this.BtnMoveEast.Size = new System.Drawing.Size(100, 35);
            this.BtnMoveEast.TabIndex = 10;
            this.BtnMoveEast.Text = "East";
            this.BtnMoveEast.UseVisualStyleBackColor = true;
            this.BtnMoveEast.Click += new System.EventHandler(this.BtnMoveEast_Click);
            // 
            // BtnMoveWest
            // 
            this.BtnMoveWest.Location = new System.Drawing.Point(470, 510);
            this.BtnMoveWest.Margin = new System.Windows.Forms.Padding(0);
            this.BtnMoveWest.Name = "BtnMoveWest";
            this.BtnMoveWest.Size = new System.Drawing.Size(100, 35);
            this.BtnMoveWest.TabIndex = 11;
            this.BtnMoveWest.Text = "West";
            this.BtnMoveWest.UseVisualStyleBackColor = true;
            this.BtnMoveWest.Click += new System.EventHandler(this.BtnMoveWest_Click);
            // 
            // BtnInteract
            // 
            this.BtnInteract.Location = new System.Drawing.Point(570, 440);
            this.BtnInteract.Margin = new System.Windows.Forms.Padding(0);
            this.BtnInteract.Name = "BtnInteract";
            this.BtnInteract.Size = new System.Drawing.Size(100, 35);
            this.BtnInteract.TabIndex = 14;
            this.BtnInteract.UseVisualStyleBackColor = true;
            this.BtnInteract.Click += new System.EventHandler(this.BtnInteract_Click);
            // 
            // InventoryView
            // 
            this.InventoryView.AllowUserToAddRows = false;
            this.InventoryView.AllowUserToDeleteRows = false;
            this.InventoryView.AllowUserToResizeColumns = false;
            this.InventoryView.AllowUserToResizeRows = false;
            this.InventoryView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InventoryView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.InventoryView.Location = new System.Drawing.Point(470, 9);
            this.InventoryView.MultiSelect = false;
            this.InventoryView.Name = "InventoryView";
            this.InventoryView.ReadOnly = true;
            this.InventoryView.RowHeadersVisible = false;
            this.InventoryView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.InventoryView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InventoryView.Size = new System.Drawing.Size(300, 414);
            this.InventoryView.TabIndex = 17;
            this.InventoryView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InventoryView_CellClick);
            // 
            // infoBox
            // 
            this.infoBox.Location = new System.Drawing.Point(126, 9);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(338, 228);
            this.infoBox.TabIndex = 18;
            this.infoBox.Text = "";
            // 
            // MinimapGrid
            // 
            this.MinimapGrid.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MinimapGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MinimapGrid.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MinimapGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.MinimapGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.MinimapGrid.Enabled = false;
            this.MinimapGrid.Location = new System.Drawing.Point(15, 245);
            this.MinimapGrid.MultiSelect = false;
            this.MinimapGrid.Name = "MinimapGrid";
            this.MinimapGrid.ReadOnly = true;
            this.MinimapGrid.RowHeadersVisible = false;
            this.MinimapGrid.Size = new System.Drawing.Size(375, 300);
            this.MinimapGrid.TabIndex = 19;
            // 
            // AdventureMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.MinimapGrid);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.InventoryView);
            this.Controls.Add(this.BtnInteract);
            this.Controls.Add(this.BtnMoveWest);
            this.Controls.Add(this.BtnMoveEast);
            this.Controls.Add(this.BtnMoveSouth);
            this.Controls.Add(this.BtnMoveNorth);
            this.Controls.Add(this.lblGp);
            this.Controls.Add(this.lblXp);
            this.Controls.Add(this.lblLv);
            this.Controls.Add(this.lblGpStatic);
            this.Controls.Add(this.lblXpStatic);
            this.Controls.Add(this.lblLvStatic);
            this.Controls.Add(this.lblHp);
            this.Controls.Add(this.lblHpStatic);
            this.Name = "AdventureMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.InventoryView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimapGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHpStatic;
        private System.Windows.Forms.Label lblHp;
        private System.Windows.Forms.Label lblLvStatic;
        private System.Windows.Forms.Label lblXpStatic;
        private System.Windows.Forms.Label lblGpStatic;
        private System.Windows.Forms.Label lblLv;
        private System.Windows.Forms.Label lblXp;
        private System.Windows.Forms.Label lblGp;
        private System.Windows.Forms.Button BtnMoveNorth;
        private System.Windows.Forms.Button BtnMoveSouth;
        private System.Windows.Forms.Button BtnMoveEast;
        private System.Windows.Forms.Button BtnMoveWest;
        private System.Windows.Forms.Button BtnInteract;
        private System.Windows.Forms.DataGridView InventoryView;
        private System.Windows.Forms.RichTextBox infoBox;
        private System.Windows.Forms.DataGridView MinimapGrid;
    }
}

