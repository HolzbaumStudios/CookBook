namespace AdminConsole
{
    partial class AdminForm
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
            this.LabelRecipeName = new System.Windows.Forms.Label();
            this.TextBox_RecipeName = new System.Windows.Forms.TextBox();
            this.Label_Description = new System.Windows.Forms.Label();
            this.Lable_Creator = new System.Windows.Forms.Label();
            this.TextBox_Creator = new System.Windows.Forms.TextBox();
            this.TextBox_Description = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ingredients = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Timer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeUnit = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelRecipeName
            // 
            this.LabelRecipeName.AutoSize = true;
            this.LabelRecipeName.Location = new System.Drawing.Point(13, 13);
            this.LabelRecipeName.Name = "LabelRecipeName";
            this.LabelRecipeName.Size = new System.Drawing.Size(35, 13);
            this.LabelRecipeName.TabIndex = 0;
            this.LabelRecipeName.Text = "Name";
            this.LabelRecipeName.Click += new System.EventHandler(this.label1_Click);
            // 
            // TextBox_RecipeName
            // 
            this.TextBox_RecipeName.Location = new System.Drawing.Point(16, 30);
            this.TextBox_RecipeName.Name = "TextBox_RecipeName";
            this.TextBox_RecipeName.Size = new System.Drawing.Size(136, 20);
            this.TextBox_RecipeName.TabIndex = 1;
            this.TextBox_RecipeName.TextChanged += new System.EventHandler(this.TextBox_RecipeName_TextChanged);
            // 
            // Label_Description
            // 
            this.Label_Description.AutoSize = true;
            this.Label_Description.Location = new System.Drawing.Point(215, 14);
            this.Label_Description.Name = "Label_Description";
            this.Label_Description.Size = new System.Drawing.Size(60, 13);
            this.Label_Description.TabIndex = 2;
            this.Label_Description.Text = "Description";
            // 
            // Lable_Creator
            // 
            this.Lable_Creator.AutoSize = true;
            this.Lable_Creator.Location = new System.Drawing.Point(13, 64);
            this.Lable_Creator.Name = "Lable_Creator";
            this.Lable_Creator.Size = new System.Drawing.Size(41, 13);
            this.Lable_Creator.TabIndex = 0;
            this.Lable_Creator.Text = "Creator";
            this.Lable_Creator.Click += new System.EventHandler(this.label1_Click);
            // 
            // TextBox_Creator
            // 
            this.TextBox_Creator.Location = new System.Drawing.Point(16, 81);
            this.TextBox_Creator.Name = "TextBox_Creator";
            this.TextBox_Creator.Size = new System.Drawing.Size(136, 20);
            this.TextBox_Creator.TabIndex = 1;
            // 
            // TextBox_Description
            // 
            this.TextBox_Description.Location = new System.Drawing.Point(215, 30);
            this.TextBox_Description.Multiline = true;
            this.TextBox_Description.Name = "TextBox_Description";
            this.TextBox_Description.Size = new System.Drawing.Size(546, 86);
            this.TextBox_Description.TabIndex = 1;
            this.TextBox_Description.TextChanged += new System.EventHandler(this.TextBox_RecipeName_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Description,
            this.Ingredients,
            this.Timer,
            this.TimeUnit});
            this.dataGridView1.Location = new System.Drawing.Point(16, 137);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(745, 167);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Width = 300;
            // 
            // Ingredients
            // 
            this.Ingredients.HeaderText = "Ingredients";
            this.Ingredients.Name = "Ingredients";
            this.Ingredients.Width = 250;
            // 
            // Timer
            // 
            this.Timer.HeaderText = "Timer";
            this.Timer.Name = "Timer";
            this.Timer.Width = 50;
            // 
            // TimeUnit
            // 
            this.TimeUnit.HeaderText = "TimeUnit";
            this.TimeUnit.Items.AddRange(new object[] {
            "Seconds",
            "Minutes",
            "Hours"});
            this.TimeUnit.Name = "TimeUnit";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 316);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Label_Description);
            this.Controls.Add(this.TextBox_Creator);
            this.Controls.Add(this.Lable_Creator);
            this.Controls.Add(this.TextBox_Description);
            this.Controls.Add(this.TextBox_RecipeName);
            this.Controls.Add(this.LabelRecipeName);
            this.Name = "AdminForm";
            this.Text = "Create Recipes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelRecipeName;
        private System.Windows.Forms.TextBox TextBox_RecipeName;
        private System.Windows.Forms.Label Label_Description;
        private System.Windows.Forms.Label Lable_Creator;
        private System.Windows.Forms.TextBox TextBox_Creator;
        private System.Windows.Forms.TextBox TextBox_Description;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingredients;
        private System.Windows.Forms.DataGridViewTextBoxColumn Timer;
        private System.Windows.Forms.DataGridViewComboBoxColumn TimeUnit;
    }
}

