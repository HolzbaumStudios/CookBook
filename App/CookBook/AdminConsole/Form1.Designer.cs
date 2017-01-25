namespace AdminConsole
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
            this.LabelRecipeName = new System.Windows.Forms.Label();
            this.TextBox_RecipeName = new System.Windows.Forms.TextBox();
            this.Label_Description = new System.Windows.Forms.Label();
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
            // 
            // Label_Description
            // 
            this.Label_Description.AutoSize = true;
            this.Label_Description.Location = new System.Drawing.Point(16, 66);
            this.Label_Description.Name = "Label_Description";
            this.Label_Description.Size = new System.Drawing.Size(60, 13);
            this.Label_Description.TabIndex = 2;
            this.Label_Description.Text = "Description";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 299);
            this.Controls.Add(this.Label_Description);
            this.Controls.Add(this.TextBox_RecipeName);
            this.Controls.Add(this.LabelRecipeName);
            this.Name = "Form1";
            this.Text = "Create Recipes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelRecipeName;
        private System.Windows.Forms.TextBox TextBox_RecipeName;
        private System.Windows.Forms.Label Label_Description;
    }
}

