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
            this.TextBox_Tags = new System.Windows.Forms.TextBox();
            this.Label_Tags = new System.Windows.Forms.Label();
            this.Label_SelectImage = new System.Windows.Forms.Label();
            this.Button_Upload = new System.Windows.Forms.Button();
            this.Label_ImagePath = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Steps)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelRecipeName
            // 
            this.LabelRecipeName.AutoSize = true;
            this.LabelRecipeName.Location = new System.Drawing.Point(20, 20);
            this.LabelRecipeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelRecipeName.Name = "LabelRecipeName";
            this.LabelRecipeName.Size = new System.Drawing.Size(51, 20);
            this.LabelRecipeName.TabIndex = 0;
            this.LabelRecipeName.Text = "Name";
            // 
            // TextBox_RecipeName
            // 
            this.TextBox_RecipeName.Location = new System.Drawing.Point(24, 46);
            this.TextBox_RecipeName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBox_RecipeName.Name = "TextBox_RecipeName";
            this.TextBox_RecipeName.Size = new System.Drawing.Size(202, 26);
            this.TextBox_RecipeName.TabIndex = 1;
            // 
            // Label_Description
            // 
            this.Label_Description.AutoSize = true;
            this.Label_Description.Location = new System.Drawing.Point(322, 22);
            this.Label_Description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Description.Name = "Label_Description";
            this.Label_Description.Size = new System.Drawing.Size(89, 20);
            this.Label_Description.TabIndex = 2;
            this.Label_Description.Text = "Description";
            // 
            // Lable_Creator
            // 
            this.Lable_Creator.AutoSize = true;
            this.Lable_Creator.Location = new System.Drawing.Point(20, 98);
            this.Lable_Creator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lable_Creator.Name = "Lable_Creator";
            this.Lable_Creator.Size = new System.Drawing.Size(62, 20);
            this.Lable_Creator.TabIndex = 0;
            this.Lable_Creator.Text = "Creator";
            // 
            // TextBox_Creator
            // 
            this.TextBox_Creator.Location = new System.Drawing.Point(24, 125);
            this.TextBox_Creator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBox_Creator.Name = "TextBox_Creator";
            this.TextBox_Creator.Size = new System.Drawing.Size(202, 26);
            this.TextBox_Creator.TabIndex = 1;
            // 
            // TextBox_Description
            // 
            this.TextBox_Description.Location = new System.Drawing.Point(322, 46);
            this.TextBox_Description.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBox_Description.Multiline = true;
            this.TextBox_Description.Name = "TextBox_Description";
            this.TextBox_Description.Size = new System.Drawing.Size(817, 130);
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
            this.DataGrid_Steps.Location = new System.Drawing.Point(24, 260);
            this.DataGrid_Steps.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DataGrid_Steps.Name = "DataGrid_Steps";
            this.DataGrid_Steps.Size = new System.Drawing.Size(1118, 257);
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
            this.Button_Save.Location = new System.Drawing.Point(951, 526);
            this.Button_Save.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(190, 35);
            this.Button_Save.TabIndex = 4;
            this.Button_Save.Text = "Save Recipe";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // TextBox_Tags
            // 
            this.TextBox_Tags.Location = new System.Drawing.Point(24, 205);
            this.TextBox_Tags.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBox_Tags.Name = "TextBox_Tags";
            this.TextBox_Tags.Size = new System.Drawing.Size(296, 26);
            this.TextBox_Tags.TabIndex = 5;
            // 
            // Label_Tags
            // 
            this.Label_Tags.AutoSize = true;
            this.Label_Tags.Location = new System.Drawing.Point(20, 180);
            this.Label_Tags.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Tags.Name = "Label_Tags";
            this.Label_Tags.Size = new System.Drawing.Size(44, 20);
            this.Label_Tags.TabIndex = 0;
            this.Label_Tags.Text = "Tags";
            // 
            // Label_SelectImage
            // 
            this.Label_SelectImage.AutoSize = true;
            this.Label_SelectImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_SelectImage.Location = new System.Drawing.Point(395, 213);
            this.Label_SelectImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_SelectImage.Name = "Label_SelectImage";
            this.Label_SelectImage.Size = new System.Drawing.Size(125, 20);
            this.Label_SelectImage.TabIndex = 6;
            this.Label_SelectImage.Text = "Recipe Image:";
            // 
            // Button_Upload
            // 
            this.Button_Upload.Location = new System.Drawing.Point(527, 208);
            this.Button_Upload.Name = "Button_Upload";
            this.Button_Upload.Size = new System.Drawing.Size(109, 31);
            this.Button_Upload.TabIndex = 7;
            this.Button_Upload.Text = "Upload";
            this.Button_Upload.UseVisualStyleBackColor = true;
            this.Button_Upload.Click += new System.EventHandler(this.Button_Upload_Click);
            // 
            // Label_ImagePath
            // 
            this.Label_ImagePath.AutoSize = true;
            this.Label_ImagePath.Location = new System.Drawing.Point(653, 213);
            this.Label_ImagePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_ImagePath.MaximumSize = new System.Drawing.Size(500, 50);
            this.Label_ImagePath.Name = "Label_ImagePath";
            this.Label_ImagePath.Size = new System.Drawing.Size(0, 20);
            this.Label_ImagePath.TabIndex = 8;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 580);
            this.Controls.Add(this.Label_ImagePath);
            this.Controls.Add(this.Button_Upload);
            this.Controls.Add(this.Label_SelectImage);
            this.Controls.Add(this.TextBox_Tags);
            this.Controls.Add(this.Button_Save);
            this.Controls.Add(this.DataGrid_Steps);
            this.Controls.Add(this.Label_Description);
            this.Controls.Add(this.TextBox_Creator);
            this.Controls.Add(this.Label_Tags);
            this.Controls.Add(this.Lable_Creator);
            this.Controls.Add(this.TextBox_Description);
            this.Controls.Add(this.TextBox_RecipeName);
            this.Controls.Add(this.LabelRecipeName);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.TextBox TextBox_Tags;
        private System.Windows.Forms.Label Label_Tags;
        private System.Windows.Forms.Label Label_SelectImage;
        private System.Windows.Forms.Button Button_Upload;
        private System.Windows.Forms.Label Label_ImagePath;
    }
}

