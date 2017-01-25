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
            this.DataGrid_Steps = new System.Windows.Forms.DataGridView();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ingredients = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Timer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeUnit = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Button_Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Steps)).BeginInit();
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
            // 
            // TextBox_RecipeName
            // 
            this.TextBox_RecipeName.Location = new System.Drawing.Point(16, 30);
            this.TextBox_RecipeName.Name = "TextBox_RecipeName";
            this.TextBox_RecipeName.Size = new System.Drawing.Size(136, 20);
            this.TextBox_RecipeName.TabIndex = 1;
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
            // 
            // DataGrid_Steps
            // 
            this.DataGrid_Steps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid_Steps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Description,
            this.Ingredients,
            this.Timer,
            this.TimeUnit});
            this.DataGrid_Steps.Location = new System.Drawing.Point(16, 137);
            this.DataGrid_Steps.Name = "DataGrid_Steps";
            this.DataGrid_Steps.Size = new System.Drawing.Size(745, 167);
            this.DataGrid_Steps.TabIndex = 3;
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
            // Button_Save
            // 
            this.Button_Save.Location = new System.Drawing.Point(634, 313);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(127, 23);
            this.Button_Save.TabIndex = 4;
            this.Button_Save.Text = "Save Recipe";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 348);
            this.Controls.Add(this.Button_Save);
            this.Controls.Add(this.DataGrid_Steps);
            this.Controls.Add(this.Label_Description);
            this.Controls.Add(this.TextBox_Creator);
            this.Controls.Add(this.Lable_Creator);
            this.Controls.Add(this.TextBox_Description);
            this.Controls.Add(this.TextBox_RecipeName);
            this.Controls.Add(this.LabelRecipeName);
            this.Name = "AdminForm";
            this.Text = "Create Recipes";
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Steps)).EndInit();
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
        private System.Windows.Forms.DataGridView DataGrid_Steps;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingredients;
        private System.Windows.Forms.DataGridViewTextBoxColumn Timer;
        private System.Windows.Forms.DataGridViewComboBoxColumn TimeUnit;
        private System.Windows.Forms.Button Button_Save;
    }
}

